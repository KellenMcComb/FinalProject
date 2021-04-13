// Author:          Kellen McComb
// Last Modified:   April 13, 2021
// Description:
//  This program takes user input for a car's make, model, manufacture year, 
//  price, and new status, and adds them to a list of car class objects. The
//  cars are displayed in an inventory form and existing cars can be modified. 
//  Used as an MDI child form for NETD2202's Final Project.


using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinalProject
{
    public partial class formCarInventory : Form
    {
        // Create list for car objects.
        private List<Car> carList = new List<Car>();
        private bool isAutomated = false;
        private int selectedIndex = -1;

        private static formCarInventory instance;

        public formCarInventory()
        {
            InitializeComponent();
        }

        #region "Event Handlers"

        /// <summary>
        /// When the form loads, create list of years, instantiate some cars, and add them to the form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormLoad(object sender, EventArgs e)
        {
            // Grabs current year and populates the "Year" comboBox with the last 100 years.
            for (int count = 0; count < 100; count++)
            {
                comboBoxYear.Items.Add(DateTime.Today.Year - count);
            }


            // Declare and instantiate some cars to test.
            Car vehicle1 = new Car("Land Rover", "Range Rover", 1993, 500, false);
            Car vehicle2 = new Car("Dodge", "Dorito", 2021, 28000, true);

            // Add the cars to the car list.
            carList.Add(vehicle1);
            carList.Add(vehicle2);

            // Add the cars to the listView.
            PopulateListView(carList);
        }

        /// <summary>
        /// Validates all inputs and if valid creates the car object, adds it to the list, and
        /// adds it to the ListView.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonEnterClick(object sender, EventArgs e)
        {
            // Empty the output message label.
            labelOutput.Text = String.Empty;

            // Validate all the user input.
            if(IsCarValid(comboBoxMake.Text, textBoxModel.Text,
                 comboBoxYear.Text, textBoxPrice.Text))
            {
                // If a car is selected... 
                if (selectedIndex >= 0)
                {
                    // ...update the information of the old car object.
                    carList[selectedIndex].Make = comboBoxMake.Text;
                    carList[selectedIndex].Model = textBoxModel.Text;
                    carList[selectedIndex].Year = int.Parse(comboBoxYear.Text);
                    carList[selectedIndex].Price = decimal.Parse(textBoxPrice.Text);
                    carList[selectedIndex].NewStatus = checkBoxNew.Checked;
                }
                // If a car is not selected...
                else
                {
                    // ...create car object using user input.
                    Car newCarToAdd = new Car(comboBoxMake.Text, textBoxModel.Text,
                     int.Parse(comboBoxYear.Text), decimal.Parse(textBoxPrice.Text), checkBoxNew.Checked);

                    // Add the new car to the list of cars.
                    carList.Add(newCarToAdd);
                    labelOutput.Text = "Success!";
                }

                PopulateListView(carList);
                SetDefaults();
            }
            
        }

        /// <summary>
        /// Resets controls to their default state.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonResetClick(object sender, EventArgs e)
        {
            SetDefaults();
        }

        /// <summary>
        /// Closes the active instance.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void ButtonCloseClick(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Copies the car's properties to the input fields when a car is selected.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CarSelected(object sender, EventArgs e)
        {
            // If there is at least one car in the list, and any car is selected:
            if (listViewEntries.Items.Count > 0 && listViewEntries.FocusedItem != null)
            {
                // Copy the selected car's properties to input fields.
                comboBoxMake.Text = listViewEntries.FocusedItem.SubItems[2].Text;
                textBoxModel.Text = listViewEntries.FocusedItem.SubItems[3].Text;
                comboBoxYear.Text = listViewEntries.FocusedItem.SubItems[4].Text;
                checkBoxNew.Checked = listViewEntries.FocusedItem.Checked;
                // Remove currency formatting on "Price" field for easier data modification.
                decimal price = decimal.Parse(listViewEntries.FocusedItem.SubItems[5].Text,
                    System.Globalization.NumberStyles.Any);
                textBoxPrice.Text = price.ToString();
               
                // Set selectedIndex to match listView. 
                selectedIndex = listViewEntries.FocusedItem.Index;
            }
            else
            {
                selectedIndex = -1;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PreventCheck(object sender, ItemCheckEventArgs e)
        {
            // Only prevent user from changing checkboxes (program is allowed)
            if (!isAutomated)
            {
                // Change new value of check box to old value of checkbox.
                e.NewValue = e.CurrentValue;
                labelOutput.Text = "Go away human!";
            }
        }

        #endregion

        #region "Functions"

        /// <summary>
        /// Converts cars passed in to a ListViewItem and adds it to listViewEntries.
        /// </summary>
        /// <param name="newCar"></param>
        private void PopulateListView(List<Car> carList)
        {
            // Clear the listView.
            listViewEntries.Items.Clear();

            foreach (Car newCar in carList)
            {
                // Declare and instantiate a new
                ListViewItem carItem = new ListViewItem();

                isAutomated = true;
                carItem.Checked = newCar.NewStatus;
                carItem.SubItems.Add(newCar.IdentificationNumber.ToString());
                carItem.SubItems.Add(newCar.Make);
                carItem.SubItems.Add(newCar.Model);
                carItem.SubItems.Add(newCar.Year.ToString());
                carItem.SubItems.Add(newCar.Price.ToString("c"));

                // Add the carItem to the ListView.
                listViewEntries.Items.Add(carItem);
                isAutomated = false;
            }
            
        }

        /// <summary>
        /// Resets all input controls to their default state.
        /// </summary>
        private void SetDefaults()
        {
            // Set fields to their default state.
            comboBoxMake.SelectedIndex = -1;
            textBoxModel.Clear();
            comboBoxYear.SelectedIndex = -1;
            textBoxPrice.Clear();
            checkBoxNew.Checked = false;
            listViewEntries.SelectedItems.Clear();
            labelOutput.Text = String.Empty;
            selectedIndex = -1;

            // Set default focus to comboBoxMake.
            comboBoxMake.Focus();
        }
                
        /// <summary>
        /// Validates all input related to the car object.
        /// </summary>
        /// <param name="make">The car's make as a string</param>
        /// <param name="model">The car's model as a string</param>
        /// <param name="year">The car's manufacture year as a string</param>
        /// <param name="price">The car's price as a string</param>
        /// <returns>true if valid, false if not valid</returns>
        private bool IsCarValid(string make, string model, string year, string price)
        {
            bool isValid = true;
            decimal priceEntry;
            const int MinimumPrice = 0; // The minimum a vehicle can be priced at.

            // Check if make field is empty.
            if (make == String.Empty)
            {
                // If empty, output error.
                isValid = false;
                labelOutput.Text += "You must enter the car's make.\n";
            }

            // Check if model field is empty or contains only white space.
            if (model.Trim() == String.Empty)
            {
                // If empty, output error.
                isValid = false;
                labelOutput.Text += "You must enter the car's model.\n";
            }

            // Check if year field is empty.
            if (year == String.Empty)
            {
                // If empty, output error.
                isValid = false;
                labelOutput.Text += "You must enter the car's year.\n";
            }
            
            // Check if price field is empty or contains only white space.
            if (price.Trim() == String.Empty)
            {
                // If empty, output error.
                isValid = false;
                labelOutput.Text += "You must enter the car's price.\n";
            }
            // If not empty, try to parse the price as a decimal.
            else if (decimal.TryParse(price, out priceEntry))
            {
                // If it can parse as a decimal, check if it is less than 0.
                if (priceEntry < MinimumPrice)
                {
                    // If less than 0, output error.
                    isValid = false;
                    labelOutput.Text += "Price cannot be a negative number.\n";
                }
            }
            else
            {
                // If it is not an integer, output error.
                isValid = false;
                labelOutput.Text += "Price must be a number.\n";
            }

            // Return validation boolean.
            return isValid;
        }

        #endregion   

        /// <summary>
        /// Property that returns a single instance of this form for use with the 
        /// Singleton Design Pattern.
        /// Ensures there is only either zero or one instance of this form open.
        /// </summary>
        public static formCarInventory Instance
        {
            get
            {
                // If there is no currently existing instance...
                if (instance == null)
                {
                    // ...create a new instance.
                    instance = new formCarInventory();
                }

                // Return the new or existing instance.
                return instance;
            }
        }

        /// <summary>
        /// Upon the CarInventory instance closing, the contents of the instance 
        /// variable is destroyed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CarInventoryClosing(object sender, FormClosingEventArgs e)
        {
            instance = null;
        }
    }
}
