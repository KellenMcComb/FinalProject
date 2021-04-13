// Author: Kellen McComb
// Last Modified:   April 13, 2021
//
// Original Author: Kyle Chapman
// Start Date: January 24, 2021
//
// Description:
//  A form that allows entry of 7 days of temperature values.
//  Each week an average is calculated. After week 1, the average temperature
//  value is compared to the average temperature value from the previous week
//  and a message is generated based on this. Functionality to reset and exit
//  the form is also available.
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
    public partial class formWeeklyTemperature : Form
    {
        public formWeeklyTemperature()
        {
            InitializeComponent();
        }

        #region "Variable Declarations"
        // Variable declarations
        // Declare an array referring to the list of textboxes on the form.
        // This allows these to be quickly validated and/or cleared iteratively.
        TextBox[] inputTextBoxArray;

        int week = 1;
        double totalTemperature = 0;
        double lastWeeksAverage = 0;

        private static formWeeklyTemperature instance;

        #endregion

        #region "Event Handlers"
        /// <summary>
        /// When the form loads, assign values to the arrays based on the textboxes on the form.
        /// Note that assigning this would not work before the form was loaded, so it is done on load.
        /// </summary>
        private void FormLoad(object sender, EventArgs e)
        {
            inputTextBoxArray = new TextBox[] {textBoxDay1, textBoxDay2, textBoxDay3, textBoxDay4, textBoxDay5, textBoxDay6, textBoxDay7 };
            SetDefaults();
        }

        /// <summary>
        /// If all of the array of textboxes is valid, ButtonCalculateClick will:
        ///     1. clear the results textbox, 
        ///     2. calculate the average temperature, 
        ///     3. when beyond week 1 it outputs a message that states whether or not the average is 
        ///         warmer than, colder than, or the same temperature as the previous week's average,
        ///     4. increment the week by 1,
        ///     5. display the week's average and stores it for the next week
        ///     6. disables input controls until the form is reset to prevent funky stuff from happening,
        ///     7. and sets focus to the reset button for QoL / ease of use.
        /// </summary>
        private void ButtonCalculateClick(object sender, EventArgs e)
        {
            // Note that this code is DONE, but it is very dependent on the completion of ValidateTextbox and ValidateTextboxArray, functions included below.
            // This event handler should not need to be modified at all. PROBABLY.

            // Variable declaration.
            double averageTemperature = 0;

            // Check if the Textboxes contents are all valid.
            if (ValidateTextboxArray(inputTextBoxArray))
            {
                // Clear the error messages.
                textBoxResult.Clear();

                // Make sure totalTemperature has been incremented to include all entered values.
                // I chose to do it as part of ValidateTextbox but you could also do it here.

                // Textboxes are valid; calculate the average temperature!
                averageTemperature = Math.Round(totalTemperature / inputTextBoxArray.Length, 2);

                // Check if it's after week 1.
                if (week > 1)
                {
                    // Determine whether this week is warmer or colder and output a message.
                    if (averageTemperature > lastWeeksAverage)
                    {
                        textBoxResult.Text = "The week " + week + " average of " + averageTemperature + " is higher than the previous average of " + lastWeeksAverage + ".";
                    }
                    else if (averageTemperature < lastWeeksAverage)
                    {
                        textBoxResult.Text = "The week " + week + " average of " + averageTemperature + " is lower than the previous average of " + lastWeeksAverage + ".";
                    }
                    else
                    {
                        textBoxResult.Text = "The week " + week + " average of " + averageTemperature + " is the same as last week's average.";
                    }
                }

                // Increment the week.
                week += 1;
                labelWeek.Text = "Week " + week;

                // Display the week's average, and store it for next week.
                textBoxAverageOutput.Text = averageTemperature.ToString();
                lastWeeksAverage = averageTemperature;

                // Disable input controls until the form is reset.
                buttonCalculate.Enabled = false;
                SetControlsEnabled(inputTextBoxArray, false);
                buttonReset.Focus();
            }
        }

        /// <summary>
        /// Resets the form to its default state by calling SetDefaults()
        /// </summary>
        private void ButtonResetClick(object sender, EventArgs e)
        {
            SetDefaults();
        }

        /// <summary>
        /// Closes the active instance.
        /// </summary>
        public void ButtonCloseClick(object sender, EventArgs e)
        {
            Close();
        }
        #endregion

        #region "Functions"

        /// <summary>
        /// This clears the text property of all controls in the array of controls that is passed in
        /// </summary>
        /// <param name="controlArray">An array of controls with a text property to clear</param>
        private void ClearControls(Control[] controlArray)
        {
            foreach (Control controlToClear in controlArray)
            {
                controlToClear.Text = String.Empty;
            }
        }

        /// <summary>
        /// This enables or disables all controls in an array of controls that is passed in
        /// </summary>
        /// <param name="controlArray">An array of controls to enable or disable</param>
        /// <param name="enabledStatus">true to enable, false to disable</param>
        private void SetControlsEnabled(Control[] controlArray, bool enabledStatus)
        {
            foreach (Control controlToSet in controlArray)
            {
                controlToSet.Enabled = enabledStatus;
            }
        }

        /// <summary>
        /// Clears input and output, re-enables controls, sets the form to its default state
        /// </summary>
        private void SetDefaults()
        {
            // Clear input and output fields.
            ClearControls(inputTextBoxArray); // Calls a function to empty all input textboxes.

            // Clears the average temperature textbox and the result textbox.
            textBoxAverageOutput.Clear();
            textBoxResult.Clear();

            // Resets total temperature to 0.
            totalTemperature = 0;

            // Re-enable controls that were disabled upon calculating.
            buttonCalculate.Enabled = true;
            SetControlsEnabled(inputTextBoxArray, true);

            // Set focus in some kind of useful way.
            textBoxDay1.Focus();
        }

        /// <summary>
        /// This validates a single textbox on the form
        /// </summary>
        /// <param name="textBoxInput">Textbox to validate</param>
        /// <returns>true if the textbox is valid, false if not</returns>
        private bool ValidateTextbox(TextBox textBoxInput)
        {
            // Variable declaration.
            double inputTemperature;

            // Check whether textBoxInput.Text is a valid number.
            if (double.TryParse(textBoxInput.Text, out inputTemperature))
            {
                // If valid:
                // Increment the total temperature by the validated value.
                totalTemperature += inputTemperature;

                // Return true.
                return true;
            }
            else
            {
                // If not valid:
                // Display appropriate error message.
                textBoxResult.Text += "The entered value of '" + textBoxInput.Text + "' is not valid. " +
                    "Please enter a numeric temperature.\r\n";

                // Reset the running total temperature to 0.
                totalTemperature = 0;

                // Return false.
                return false;
            }
        }

        /// <summary>
        /// This checks validity for all textboxes in the array that is passed in
        /// </summary>
        /// <param name="textBoxArray">An array of textboxes, all of which will be validated</param>
        /// <returns>true if all textboxes in the array are valid, false if not</returns>
        private bool ValidateTextboxArray(TextBox[] textBoxArray)
        {
            // Variable declaration.
            bool isValid = true;

            // TODO: Complete this function.
            // For every textbox in textBoxArray, use the ValidateTextbox function to check if it's valid.
            for (int boxCounter = 0; boxCounter < textBoxArray.Length; boxCounter++)
            {
                isValid = ValidateTextbox(textBoxArray[boxCounter]) && isValid;
            }
            
            // If they are ALL valid, return true.
            // If not, return false.
            return isValid;
        }

        #endregion

        /// <summary>
        /// Property that returns a single instance of this form for use with the 
        /// Singleton Design Pattern.
        /// Ensures there is only either zero or one instance of this form open.
        /// </summary>
        public static formWeeklyTemperature Instance
        {
            get
            {
                // If there is no currently existing instance...
                if (instance == null)
                {
                    // ...create a new instance.
                    instance = new formWeeklyTemperature();
                }

                // Return the new or existing instance.
                return instance;
            }
        }

        /// <summary>
        /// Upon the WeeklyTemperature instance closing, the contents of the instance 
        /// variable is destroyed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WeeklyTemperatureClosing(object sender, FormClosingEventArgs e)
        {
            instance = null;
        }
    }
}
