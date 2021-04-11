// Author: Kellen McComb
// Last Modified Date: January 28, 2021
// App Name: AverageUnitsShippedUpdated
// App Description: 
//  This program takes user input for number of units shipped and stores it in a 2-D array of
//  inputs. The input is validated to be a whole number between 0 and 5000 inclusive.
//  Each entry will increment the displayed day by 1. After 7 successful entries they are 
//  summed up, a calculated average is displayed for the particular employee, and the form starts
//  entering numbers into the next employee's field. When all 3 employees have 7 entries, the
//  total average is calculated and displayed, and the form entry controls are disabled until
//  the reset button is hit to clear the appropriate controls and allow for more input.



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
    public partial class formAverageUnitsShipped : Form
    {
        // Constant declarations:
        const int NumberOfEmployees = 3;
        const int NumberOfDays = 7;


        // Class-level variable declarations:
        int currentEmployee = 1;
        int currentDay = 1;
        int[,] entryArray = new int[NumberOfEmployees, NumberOfDays];

        // Arrays for output controls.
        TextBox[] employeeTextBoxes;
        Label[] employeeAverages;

        private static formAverageUnitsShipped instance;

        #region "Event Handlers"

        public formAverageUnitsShipped()
        {
            InitializeComponent();

            // Populate arrays of controls.
            employeeTextBoxes = new TextBox[] { textBoxEmployee1Entries, textBoxEmployee2Entries,
                textBoxEmployee3Entries };
            employeeAverages = new Label[] { labelAverageEmployee1, labelAverageEmployee2,
                labelAverageEmployee3 };
        }

        /// <summary>
        /// Validates that the user input field is a positive whole number between 0 and 5000 inclusive,
        /// and when input is successful it will append that value to the 2D array of past entries. 
        /// The current day is increased by 1. When the current day reaches 8, the 7 entered values are
        /// summed up and the average for that employee is calculated. The day is set to 1 and 
        /// inputs will now enter into the next employee's field, and the text for the current employee 
        /// entries is bolded. When all 3 employees have all 7 days populated, an overall average is calculated, 
        /// input controls are disabled, and focus is set to the reset button for convenience. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonEnterClick(object sender, EventArgs e)
        {
            // Constants and Variables.
            const int MinimumUnits = 0;
            const int MaximumUnits = 5000;

            // Validate user entry is a whole number.
            if (int.TryParse(textBoxEntryNumber.Text, out
                entryArray[currentEmployee - 1, currentDay - 1]))
            {
                // Validate entered number is between 0 and 5000.
                if (entryArray[currentEmployee - 1, currentDay - 1] >= MinimumUnits
                    && entryArray[currentEmployee - 1, currentDay - 1] <= MaximumUnits)
                {
                    // Enter the validated entry into the current employee's textbox.
                    employeeTextBoxes[currentEmployee - 1].Text +=
                            entryArray[currentEmployee - 1, currentDay - 1] + "\r\n";
                                      
                    // Clear the entry field.
                    textBoxEntryNumber.Clear();

                    // If we are at the end of the week:
                    if (currentDay++ >= NumberOfDays)
                    {
                        int employeeTotal = 0;

                        // Calculate the employee total for current employee.
                        for (int day = 0; day < NumberOfDays; day++)
                        {
                            employeeTotal += entryArray[currentEmployee - 1, day];
                        }

                        // Calculate and display employee's average.
                        employeeAverages[currentEmployee - 1].Text = "Average: " +
                            ((double)employeeTotal / (double)NumberOfDays).ToString("N2");
                                                
                        // Reset the day and go to the next employee.
                        currentDay = 1;
                        currentEmployee++;

                        // Bold the text of the current employee.
                        if (currentEmployee == 2)
                        {
                            labelEmployee1Prompt.Font = new Font(this.Font, FontStyle.Regular);
                            labelEmployee2Prompt.Font = new Font(this.Font, FontStyle.Bold);
                            labelEmployee3Prompt.Font = new Font(this.Font, FontStyle.Regular);
                        }
                        else if (currentEmployee == 3)
                        {
                            labelEmployee1Prompt.Font = new Font(this.Font, FontStyle.Regular);
                            labelEmployee2Prompt.Font = new Font(this.Font, FontStyle.Regular);
                            labelEmployee3Prompt.Font = new Font(this.Font, FontStyle.Bold);
                        }
                    }

                    // If all employee entries are finished:
                    if (currentEmployee > NumberOfEmployees)
                    {
                        int overallTotal = 0;

                        // Calculate the overall total for all employees.
                        foreach (int totalDay in entryArray)
                        {
                            overallTotal += totalDay;
                        }

                        // Calculate and display the overall average.
                        labelAverageOutput.Text = "Average per day: " + 
                            ((double)overallTotal / 
                            (((double)NumberOfDays) * (double)NumberOfEmployees)).ToString("N2");

                        // Disable entry controls.
                        textBoxEntryNumber.Enabled = false;
                        buttonEnter.Enabled = false;

                        // Set focus to reset button.
                        buttonReset.Focus();
                    }
                }
                else
                {
                    // The value entered is < 0 or > 5000.
                    MessageBox.Show("Entered value must be between " + MinimumUnits +
                        " and " + MaximumUnits + " inclusive.", "Invalid Entry!");
                    textBoxEntryNumber.SelectAll();
                    textBoxEntryNumber.Focus();
                }
            }
            else
            {
                // The value entered is not an integer.
                MessageBox.Show("Input must be a whole number.", "Invalid Entry!");
                textBoxEntryNumber.SelectAll();
                textBoxEntryNumber.Focus();
            }
        }

        /// <summary>
        /// Calls the ResetForm function which resets the form for new data entry.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonResetClick(object sender, EventArgs e)
        {
            ResetForm();
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

        #endregion

        #region "Other Functions"

        /// <summary>
        /// Resets the form for new data entry.
        /// </summary>
        private void ResetForm()
        {
            // Clear the input and output.
            textBoxEntryNumber.Clear();
            textBoxEmployee1Entries.Clear();
            textBoxEmployee2Entries.Clear();
            textBoxEmployee3Entries.Clear();
            labelAverageEmployee1.Text = String.Empty;
            labelAverageEmployee2.Text = String.Empty;
            labelAverageEmployee3.Text = String.Empty;
            labelAverageOutput.Text = String.Empty;

            // Reset global variables.
            currentDay = 1;
            currentEmployee = 1;
            //totalUnitsShipped = 0;
            
            // Set fonts of Employee labels to defaults.
            labelEmployee1Prompt.Font = new Font(this.Font, FontStyle.Bold);
            labelEmployee2Prompt.Font = new Font(this.Font, FontStyle.Regular);
            labelEmployee3Prompt.Font = new Font(this.Font, FontStyle.Regular);

            // Reset the current day displayed.
            labelDay.Text = "Day " + currentDay;

            // Re-enables any controls that may be disabled.
            textBoxEntryNumber.Enabled = true;
            buttonEnter.Enabled = true;

            // Set focus for easy data entry.
            textBoxEntryNumber.Focus();
        }

        #endregion

        /// <summary>
        /// Property that returns a single instance of this form for use with the 
        /// Singleton Design Pattern.
        /// Ensures there is only either zero or one instance of this form open.
        /// </summary>
        public static formAverageUnitsShipped Instance
        {
            get
            {
                // If there is no currently existing instance...
                if (instance == null)
                {
                    // ...create a new instance.
                    instance = new formAverageUnitsShipped();
                }

                // Return the new or existing instance.
                return instance;
            }
        }

        /// <summary>
        /// Upon the AverageUnitsShipped instance closing, the contents of the instance 
        /// variable is destroyed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AverageUnitsShippedClosing(object sender, FormClosingEventArgs e)
        {
            instance = null;
        }
    }
}
