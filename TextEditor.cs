// Author:          Kellen McComb
// Last Modified:   April 13, 2021
// Description:
//  Basic text editor that is used as an MDI child form for NETD2202's Final Project.

using System;
using System.IO;
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
    public partial class formTextEditor : Form
    {
        // Filepath of the active file.
        string filePath = String.Empty;

        public formTextEditor()
        {
            InitializeComponent();
        }

        #region "Event Handlers"

        /// <summary>
        /// Creates a "new" text editor window by clearing the text editor, 
        /// clearing the filepath, and updating (clearing) the title.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void FileNew(object sender, EventArgs e)
        {
            // Clear the textbox and filepath variable.
            textBoxEditor.Clear();
            filePath = String.Empty;
            // Update title (now cleared).
            UpdateTitle();
        }

        /// <summary>
        /// Opens a text file.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void FileOpen(object sender, EventArgs e)
        {
            // Create OpenFileDialog instance and set its default filter.
            OpenFileDialog openDialog = new OpenFileDialog();
            openDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";

            // If the user selects a document to open and hits "OK"
            if (openDialog.ShowDialog() == DialogResult.OK)
            {
                // Change the filepath to the opened document's filepath.
                filePath = openDialog.FileName;

                // Instantiate a FileStream object and StreamReader object.
                FileStream fileToOpen = new FileStream(filePath, FileMode.Open,
                    FileAccess.Read);
                StreamReader reader = new StreamReader(fileToOpen);

                // Read all of the text of the file to open and change the textBoxEditor 
                // text to that.
                textBoxEditor.Text = reader.ReadToEnd();

                // Close the StreamReader.
                reader.Close();

                // Update the application title to reflect current filepath.
                UpdateTitle();
            }
            else
            {
                // Otherwise, close the blank text editor form.
                this.Close();               
            }
        }

        /// <summary>
        /// Saves the document to the current filepath if it exists, else runs "FileSaveAs".
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void FileSave(object sender, EventArgs e)
        {
            // If there is no selected filepath...
            if (filePath == String.Empty)
            {
                // ...call FileSaveAs event handler to allow user to select one.
                FileSaveAs(sender, e);

                // Alternative: simulate a FileSaveAs click.
                // menuFileSaveAs.PerformClick(); 
            }
            // If there is a selected filepath...
            else
            {
                // ...save the document.
                SaveTextFile(filePath);
            }
        }


        /// <summary>
        /// Saves document as user selected name and location.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void FileSaveAs(object sender, EventArgs e)
        {
            // Create SaveFileDialog instance and set its default filter.
            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";

            // If the user selects a filepath/name and hits "OK".
            if(saveDialog.ShowDialog() == DialogResult.OK)
            {
                // Set the filepath.
                filePath = saveDialog.FileName;
                // Save it to the selected filepath.
                SaveTextFile(filePath);
                // Update the application title to reflect current filepath.
                UpdateTitle();
            }
        }

        /// <summary>
        /// Closes the active text editor window.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void FileClose(object sender, EventArgs e)
        {
            // Me close form.
            Close();
        }

        /// <summary>
        /// Sets the text of the clipboard to the currently selected text.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void EditCopy(object sender, EventArgs e)
        {
            // If there is some text selected...
            if (textBoxEditor.SelectedText != string.Empty)
            {
                // ...copy it to clipboard.
                Clipboard.SetText(textBoxEditor.SelectedText);
            }
        }

        /// <summary>
        /// Sets the text of the clipboard to the currently selected text, then deletes
        /// the currently selected text.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void EditCut(object sender, EventArgs e)
        {
            // If there is some text selected...
            if (textBoxEditor.SelectedText != string.Empty)
            {
                // ...copy it to clipboard and delete it.
                Clipboard.SetText(textBoxEditor.SelectedText);
                textBoxEditor.SelectedText = string.Empty;
            }
            
        }

        /// <summary>
        /// Pastes the contents of the clipboard.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void EditPaste(object sender, EventArgs e)
        {
            // If there's text in the clipboard...
            if (Clipboard.ContainsText())
            {
                // ...paste it.
                textBoxEditor.Paste();

                // Alternative method that abides by the "rules" given to me by 
                // "the man" (i.e. follows word document guidelines but isn't as cool).
                // textBoxEditor.Text = textBoxEditor.Text.Insert
                //     (textBoxEditor.SelectionStart, Clipboard.GetText());
            }
        }

        /// <summary>
        /// Selects all of the text in the document.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EditSelectAll(object sender, EventArgs e)
        {
            // Select all text in the document.
            textBoxEditor.SelectAll();
        }

        

        #endregion
        #region "Other Functions"

        /// <summary>
        /// Updates the application title to include the filepath, if it exists.
        /// </summary>
        public void UpdateTitle()
        {
            // Set default title for application.
            this.Text = "Kellen's Text Editor";

            // If there is a designated filepath...
            if (filePath != String.Empty)
            {
                // ...append the filepath to the default title.
                this.Text += " - " + filePath;
            }
        }

        /// <summary>
        /// Save the contents of the textbox to a text file.
        /// </summary>
        /// <param name="path">The path of the file to write to</param>
        public void SaveTextFile(string path)
        {
            // Instantiate a FileStream object and StreamWriter object.
            FileStream myFile = new FileStream(path, FileMode.Create,
                    FileAccess.Write);
            StreamWriter writer = new StreamWriter(myFile);

            // Write the current document's text to the file.
            writer.Write(textBoxEditor.Text);

            // Close the writer.
            writer.Close();
        }

        #endregion


    }
}
