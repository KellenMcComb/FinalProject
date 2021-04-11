
namespace FinalProject
{
    partial class formAverageUnitsShipped
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.labelUnitsPrompt = new System.Windows.Forms.Label();
            this.textBoxEntryNumber = new System.Windows.Forms.TextBox();
            this.labelDay = new System.Windows.Forms.Label();
            this.textBoxEmployee1Entries = new System.Windows.Forms.TextBox();
            this.labelAverageOutput = new System.Windows.Forms.Label();
            this.buttonEnter = new System.Windows.Forms.Button();
            this.buttonReset = new System.Windows.Forms.Button();
            this.buttonClose = new System.Windows.Forms.Button();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.textBoxEmployee2Entries = new System.Windows.Forms.TextBox();
            this.textBoxEmployee3Entries = new System.Windows.Forms.TextBox();
            this.labelAverageEmployee1 = new System.Windows.Forms.Label();
            this.labelAverageEmployee2 = new System.Windows.Forms.Label();
            this.labelAverageEmployee3 = new System.Windows.Forms.Label();
            this.labelEmployee1Prompt = new System.Windows.Forms.Label();
            this.labelEmployee2Prompt = new System.Windows.Forms.Label();
            this.labelEmployee3Prompt = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelUnitsPrompt
            // 
            this.labelUnitsPrompt.Location = new System.Drawing.Point(12, 40);
            this.labelUnitsPrompt.Name = "labelUnitsPrompt";
            this.labelUnitsPrompt.Size = new System.Drawing.Size(52, 23);
            this.labelUnitsPrompt.TabIndex = 1;
            this.labelUnitsPrompt.Text = "&Units:";
            this.toolTip.SetToolTip(this.labelUnitsPrompt, "The number of units shipped");
            // 
            // textBoxEntryNumber
            // 
            this.textBoxEntryNumber.Location = new System.Drawing.Point(53, 37);
            this.textBoxEntryNumber.Name = "textBoxEntryNumber";
            this.textBoxEntryNumber.Size = new System.Drawing.Size(56, 23);
            this.textBoxEntryNumber.TabIndex = 2;
            this.toolTip.SetToolTip(this.textBoxEntryNumber, "Enter the units shipped for the specified day");
            // 
            // labelDay
            // 
            this.labelDay.AutoSize = true;
            this.labelDay.Location = new System.Drawing.Point(12, 13);
            this.labelDay.Name = "labelDay";
            this.labelDay.Size = new System.Drawing.Size(36, 15);
            this.labelDay.TabIndex = 0;
            this.labelDay.Text = "Day 1";
            this.toolTip.SetToolTip(this.labelDay, "The day of the week");
            // 
            // textBoxEmployee1Entries
            // 
            this.textBoxEmployee1Entries.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.textBoxEmployee1Entries.Location = new System.Drawing.Point(12, 94);
            this.textBoxEmployee1Entries.Multiline = true;
            this.textBoxEmployee1Entries.Name = "textBoxEmployee1Entries";
            this.textBoxEmployee1Entries.ReadOnly = true;
            this.textBoxEmployee1Entries.Size = new System.Drawing.Size(111, 159);
            this.textBoxEmployee1Entries.TabIndex = 4;
            this.textBoxEmployee1Entries.TabStop = false;
            this.toolTip.SetToolTip(this.textBoxEmployee1Entries, "Displays the units shipped for all days entered so far for the particular employe" +
        "e");
            // 
            // labelAverageOutput
            // 
            this.labelAverageOutput.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelAverageOutput.Location = new System.Drawing.Point(12, 289);
            this.labelAverageOutput.Name = "labelAverageOutput";
            this.labelAverageOutput.Size = new System.Drawing.Size(345, 23);
            this.labelAverageOutput.TabIndex = 12;
            this.labelAverageOutput.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.toolTip.SetToolTip(this.labelAverageOutput, "Displays the calculated average units shipped");
            // 
            // buttonEnter
            // 
            this.buttonEnter.Location = new System.Drawing.Point(12, 315);
            this.buttonEnter.Name = "buttonEnter";
            this.buttonEnter.Size = new System.Drawing.Size(104, 23);
            this.buttonEnter.TabIndex = 13;
            this.buttonEnter.Text = "&Enter";
            this.toolTip.SetToolTip(this.buttonEnter, "Enter to process the current units shipped");
            this.buttonEnter.UseVisualStyleBackColor = true;
            this.buttonEnter.Click += new System.EventHandler(this.ButtonEnterClick);
            // 
            // buttonReset
            // 
            this.buttonReset.Location = new System.Drawing.Point(133, 315);
            this.buttonReset.Name = "buttonReset";
            this.buttonReset.Size = new System.Drawing.Size(104, 23);
            this.buttonReset.TabIndex = 14;
            this.buttonReset.Text = "&Reset";
            this.toolTip.SetToolTip(this.buttonReset, "Click to reset this form to allow new entries");
            this.buttonReset.UseVisualStyleBackColor = true;
            this.buttonReset.Click += new System.EventHandler(this.ButtonResetClick);
            // 
            // buttonClose
            // 
            this.buttonClose.Location = new System.Drawing.Point(254, 315);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(104, 23);
            this.buttonClose.TabIndex = 15;
            this.buttonClose.Text = "Clo&se";
            this.toolTip.SetToolTip(this.buttonClose, "Click to close the window");
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.ButtonCloseClick);
            // 
            // textBoxEmployee2Entries
            // 
            this.textBoxEmployee2Entries.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.textBoxEmployee2Entries.Location = new System.Drawing.Point(129, 94);
            this.textBoxEmployee2Entries.Multiline = true;
            this.textBoxEmployee2Entries.Name = "textBoxEmployee2Entries";
            this.textBoxEmployee2Entries.ReadOnly = true;
            this.textBoxEmployee2Entries.Size = new System.Drawing.Size(111, 159);
            this.textBoxEmployee2Entries.TabIndex = 7;
            this.textBoxEmployee2Entries.TabStop = false;
            this.toolTip.SetToolTip(this.textBoxEmployee2Entries, "Displays the units shipped for all days entered so far for the particular employe" +
        "e");
            // 
            // textBoxEmployee3Entries
            // 
            this.textBoxEmployee3Entries.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.textBoxEmployee3Entries.Location = new System.Drawing.Point(246, 94);
            this.textBoxEmployee3Entries.Multiline = true;
            this.textBoxEmployee3Entries.Name = "textBoxEmployee3Entries";
            this.textBoxEmployee3Entries.ReadOnly = true;
            this.textBoxEmployee3Entries.Size = new System.Drawing.Size(111, 159);
            this.textBoxEmployee3Entries.TabIndex = 10;
            this.textBoxEmployee3Entries.TabStop = false;
            this.toolTip.SetToolTip(this.textBoxEmployee3Entries, "Displays the units shipped for all days entered so far for the particular employe" +
        "e");
            // 
            // labelAverageEmployee1
            // 
            this.labelAverageEmployee1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelAverageEmployee1.Location = new System.Drawing.Point(13, 260);
            this.labelAverageEmployee1.Name = "labelAverageEmployee1";
            this.labelAverageEmployee1.Size = new System.Drawing.Size(111, 23);
            this.labelAverageEmployee1.TabIndex = 5;
            this.labelAverageEmployee1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.toolTip.SetToolTip(this.labelAverageEmployee1, "Displays the calculated average units shipped for the particular employee");
            // 
            // labelAverageEmployee2
            // 
            this.labelAverageEmployee2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelAverageEmployee2.Location = new System.Drawing.Point(130, 260);
            this.labelAverageEmployee2.Name = "labelAverageEmployee2";
            this.labelAverageEmployee2.Size = new System.Drawing.Size(111, 23);
            this.labelAverageEmployee2.TabIndex = 8;
            this.labelAverageEmployee2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.toolTip.SetToolTip(this.labelAverageEmployee2, "Displays the calculated average units shipped for the particular employee");
            // 
            // labelAverageEmployee3
            // 
            this.labelAverageEmployee3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelAverageEmployee3.Location = new System.Drawing.Point(247, 260);
            this.labelAverageEmployee3.Name = "labelAverageEmployee3";
            this.labelAverageEmployee3.Size = new System.Drawing.Size(111, 23);
            this.labelAverageEmployee3.TabIndex = 11;
            this.labelAverageEmployee3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.toolTip.SetToolTip(this.labelAverageEmployee3, "Displays the calculated average units shipped for the particular employee");
            // 
            // labelEmployee1Prompt
            // 
            this.labelEmployee1Prompt.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelEmployee1Prompt.Location = new System.Drawing.Point(12, 68);
            this.labelEmployee1Prompt.Name = "labelEmployee1Prompt";
            this.labelEmployee1Prompt.Size = new System.Drawing.Size(111, 23);
            this.labelEmployee1Prompt.TabIndex = 3;
            this.labelEmployee1Prompt.Text = "Employee 1";
            this.labelEmployee1Prompt.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelEmployee2Prompt
            // 
            this.labelEmployee2Prompt.Location = new System.Drawing.Point(129, 68);
            this.labelEmployee2Prompt.Name = "labelEmployee2Prompt";
            this.labelEmployee2Prompt.Size = new System.Drawing.Size(111, 23);
            this.labelEmployee2Prompt.TabIndex = 6;
            this.labelEmployee2Prompt.Text = "Employee 2";
            this.labelEmployee2Prompt.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelEmployee3Prompt
            // 
            this.labelEmployee3Prompt.Location = new System.Drawing.Point(246, 68);
            this.labelEmployee3Prompt.Name = "labelEmployee3Prompt";
            this.labelEmployee3Prompt.Size = new System.Drawing.Size(111, 23);
            this.labelEmployee3Prompt.TabIndex = 9;
            this.labelEmployee3Prompt.Text = "Employee 3";
            this.labelEmployee3Prompt.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // formAverageUnitsShipped
            // 
            this.AcceptButton = this.buttonEnter;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonReset;
            this.ClientSize = new System.Drawing.Size(369, 358);
            this.Controls.Add(this.labelAverageEmployee3);
            this.Controls.Add(this.labelEmployee3Prompt);
            this.Controls.Add(this.textBoxEmployee3Entries);
            this.Controls.Add(this.labelAverageEmployee2);
            this.Controls.Add(this.labelEmployee2Prompt);
            this.Controls.Add(this.textBoxEmployee2Entries);
            this.Controls.Add(this.labelAverageEmployee1);
            this.Controls.Add(this.labelEmployee1Prompt);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.buttonReset);
            this.Controls.Add(this.buttonEnter);
            this.Controls.Add(this.labelAverageOutput);
            this.Controls.Add(this.textBoxEmployee1Entries);
            this.Controls.Add(this.labelDay);
            this.Controls.Add(this.textBoxEntryNumber);
            this.Controls.Add(this.labelUnitsPrompt);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(385, 397);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(385, 397);
            this.Name = "formAverageUnitsShipped";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Average Units Shipped";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AverageUnitsShippedClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelUnitsPrompt;
        private System.Windows.Forms.TextBox textBoxEntryNumber;
        private System.Windows.Forms.Label labelDay;
        private System.Windows.Forms.TextBox textBoxPastEntries;
        private System.Windows.Forms.Label labelAverageOutput;
        private System.Windows.Forms.Button buttonEnter;
        private System.Windows.Forms.Button buttonReset;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBoxEmployee1Entries;
        private System.Windows.Forms.TextBox textBoxEmployee2Entries;
        private System.Windows.Forms.TextBox textBoxEmployee3Entries;
        private System.Windows.Forms.Label labelEmployee1Prompt;
        private System.Windows.Forms.Label labelAverageEmployee1;
        private System.Windows.Forms.Label labelAverageEmployee2;
        private System.Windows.Forms.Label labelEmployee2Prompt;
        private System.Windows.Forms.Label labelAverageEmployee3;
        private System.Windows.Forms.Label labelEmployee3Prompt;
    }
}

