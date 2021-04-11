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
    public partial class formMain : Form
    {
        public formMain()
        {
            InitializeComponent();
        }


        /// <summary>
        /// Creates a new text editor child window.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FileNew(object sender, EventArgs e)
        {
            formTextEditor textEditorInstance = new formTextEditor();
            textEditorInstance.MdiParent = this;
            textEditorInstance.Show();
        }

        /// <summary>
        /// Opens a saved text editor document.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FileOpen(object sender, EventArgs e)
        {
            // If there is an active window:
            if (this.MdiChildren.Length > 0)
            {
                // If a text editor window is the currently active window...
                if (this.ActiveMdiChild.GetType() == typeof(formTextEditor))
                {
                    // ...call the text editor's Open event handler.
                    formTextEditor textEditorInstance =
                        (formTextEditor)this.ActiveMdiChild;
                    textEditorInstance.FileOpen(sender, e);
                }
                // If a text editor is not the active window:
                else
                {
                    // Create a new text editor window.
                    formTextEditor textEditorInstance = new formTextEditor();
                    textEditorInstance.MdiParent = this;
                    textEditorInstance.Show();

                    // Set focus to the new window and call the Open event handler.
                    textEditorInstance.Focus();
                    textEditorInstance.FileOpen(sender, e);
                }
            }
            // If there are no active windows:
            else
            {
                // Create a new text editor window.
                formTextEditor textEditorInstance = new formTextEditor();
                textEditorInstance.MdiParent = this;
                textEditorInstance.Show();

                // Set focus to the new window and call the Open event handler.
                textEditorInstance.Focus();
                textEditorInstance.FileOpen(sender, e);
            }
        }

        /// <summary>
        /// Saves the currently selected text editor, or calls the "Save As" event
        /// handler if the file has not already been saved.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FileSave(object sender, EventArgs e)
        {
            // If there is an active window:
            if (this.MdiChildren.Length > 0)
            {
                // If the text editor window is the currently active window...
                if (this.ActiveMdiChild.GetType() == typeof(formTextEditor))
                {
                    // ...call the text editor's FileSave event handler.
                    formTextEditor textEditorInstance =
                        (formTextEditor)this.ActiveMdiChild;
                    textEditorInstance.FileSave(sender, e);
                }
                // If the text editor is not the active window...
                else
                {
                    // ...display an appropriate message.
                    MessageBox.Show("The Save operation is not supported by the " +
                        "currently selected window.", "Operation Not Supported");
                }
            }
            else
            {
                MessageBox.Show("You must have an open text editor window to save.",
                    "Operation Not Supported");
            }
        }

        /// <summary>
        /// Saves the currently selected text editor as user selected name 
        /// and location.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FileSaveAs(object sender, EventArgs e)
        {
            // If there is an active window:
            if (this.MdiChildren.Length > 0)
            {
                // If the text editor window is the currently active window...
                if (this.ActiveMdiChild.GetType() == typeof(formTextEditor))
                {
                    // ...call the text editor's FileSaveAs event handler.
                    formTextEditor textEditorInstance = 
                        (formTextEditor)this.ActiveMdiChild;
                    textEditorInstance.FileSaveAs(sender, e);
                }
                // If the text editor is not the active window...
                else
                {
                    // ...display an appropriate message.
                    MessageBox.Show("The Save As operation is not supported by the " +
                        "currently selected window.", "Operation Not Supported");
                }
            }
            else
            {
                MessageBox.Show("You must have an open text editor window to save.",
                    "Operation Not Supported");
            }
        }

        /// <summary>
        /// Closes the currently selected text editor window.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FileClose(object sender, EventArgs e)
        {
            // If there is an active window:
            if (this.MdiChildren.Length > 0)
            {
                
                // If the text editor window is the currently active window...
                if (this.ActiveMdiChild.GetType() == typeof(formTextEditor))
                {
                    // ...call the text editor's close event handler.
                    formTextEditor textEditorInstance =
                        (formTextEditor)this.ActiveMdiChild;
                    textEditorInstance.FileClose(sender, e);
                }

                // If the Car Inventory window is the currently active window...
                else if (this.ActiveMdiChild.GetType() == typeof(formCarInventory))
                {
                    // ...call the window's close event handler.
                    formCarInventory carInventoryInstance =
                        (formCarInventory)this.ActiveMdiChild;
                    carInventoryInstance.ButtonCloseClick(sender, e);
                }

                // If the Average Units Shipped window is the currently active window...
                else if (this.ActiveMdiChild.GetType() == typeof(formAverageUnitsShipped))
                {
                    // ...call the window's close event handler.
                    formAverageUnitsShipped unitsShippedInstance =
                        (formAverageUnitsShipped)this.ActiveMdiChild;
                    unitsShippedInstance.ButtonCloseClick(sender, e);
                }

                // If the Weekly Temperature window is the currently active window...
                else if (this.ActiveMdiChild.GetType() == typeof(formWeeklyTemperature))
                {
                    // ...call the Car Inventory's close event handler.
                    formWeeklyTemperature temperatureInstance =
                        (formWeeklyTemperature)this.ActiveMdiChild;
                    temperatureInstance.ButtonCloseClick(sender, e);
                }

                // If any window specified above is not the active window...
                else
                {
                    // ...display an appropriate message.
                    MessageBox.Show("The Close operation is not supported by the " +
                        "currently selected window.", "Operation Not Supported");
                }
            }
            else
            {
                MessageBox.Show("To close a window, a window must first be open.",
                    "Operation Not Supported");
            }
        }

        /// <summary>
        /// Exits the entire application.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void FileExit(object sender, EventArgs e)
        {
            // Me close form.
            Close();
        }

        /// <summary>
        /// If the active mdi window is a text editor, copy and delete the
        /// selected text.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EditCut(object sender, EventArgs e)
        {
            // If there is an active window:
            if (this.MdiChildren.Length > 0)
            {
                // If the text editor window is the currently active window...
                if (this.ActiveMdiChild.GetType() == typeof(formTextEditor))
                {
                    // ...call the text editor's Cut event handler.
                    formTextEditor textEditorInstance = (formTextEditor)this.ActiveMdiChild;
                    textEditorInstance.EditCut(sender, e);
                }
                // If the text editor is not the active window...
                else
                {
                    // ...display an appropriate message.
                    MessageBox.Show("The Cut operation is not supported by the currently " +
                        "selected window.", "Operation Not Supported");
                }
            }
        }

        /// <summary>
        /// If the active mdi window is a text editor, copy the selected text.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EditCopy(object sender, EventArgs e)
        {
            // If there is an active window:
            if(this.MdiChildren.Length > 0)
            {
                // If the text editor window is the currently active window...
                if (this.ActiveMdiChild.GetType() == typeof(formTextEditor))
                {
                    // ...call the text editor's Copy event handler.
                    formTextEditor textEditorInstance = (formTextEditor)this.ActiveMdiChild;
                    textEditorInstance.EditCopy(sender, e);
                }
                // If the text editor is not the active window...
                else
                {
                    // ...display an appropriate message.
                    MessageBox.Show("The Copy operation is not supported by the currently " +
                        "selected window.", "Operation Not Supported");
                }
            }
        }

        /// <summary>
        /// If the active mdi window is a text editor, paste the contents of
        /// the clipboard.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EditPaste(object sender, EventArgs e)
        {
            // If there is an active window:
            if (this.MdiChildren.Length > 0)
            {
                // If the text editor window is the currently active window...
                if (this.ActiveMdiChild.GetType() == typeof(formTextEditor))
                {
                    // ...call the text editor's Paste event handler.
                    formTextEditor textEditorInstance = (formTextEditor)this.ActiveMdiChild;
                    textEditorInstance.EditPaste(sender, e);
                }
                // If the text editor is not the active window...
                else
                {
                    // ...display an appropriate message.
                    MessageBox.Show("The Paste operation is not supported by the currently " +
                        "selected window.", "Operation Not Supported");
                }
            }
        }


        /// <summary>
        /// Changes the window layout to "Cascade".
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WindowCascade(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.Cascade);
        }

        /// <summary>
        /// Changes the window layout to "Tile Horizontal".
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WindowTileHorizontal(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileHorizontal);
        }

        /// <summary>
        /// Changes the window layout to "Tile Vertical".
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WindowTileVertical(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileVertical);
        }

        /// <summary>
        /// Create and display a Car Inventory instance as an MDI child.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WindowCarList(object sender, EventArgs e)
        {
            // Create/call Car Inventory Form instance called listInstance.
            formCarInventory listInstance = formCarInventory.Instance;

            // Set it as an MDI child.
            listInstance.MdiParent = this;

            // Display the window.
            listInstance.Show();

            // Set focus to the new window.
            listInstance.Focus();
        }

        /// <summary>
        /// Create and display a Average Units Shipped instance as an MDI child.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WindowAverageUnits(object sender, EventArgs e)
        {
            // Create/call Car Inventory Form instance called listInstance.
            formAverageUnitsShipped shippedInstance = formAverageUnitsShipped.Instance;

            // Set it as an MDI child.
            shippedInstance.MdiParent = this;

            // Display the window.
            shippedInstance.Show();

            // Set focus to the new window.
            shippedInstance.Focus();
        }

        /// <summary>
        /// Create and display a Weekly Temperature instance as an MDI child.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WindowWeeklyTemperature(object sender, EventArgs e)
        {
            // Create/call Car Inventory Form instance called listInstance.
            formWeeklyTemperature temperatureInstance = formWeeklyTemperature.Instance;

            // Set it as an MDI child.
            temperatureInstance.MdiParent = this;

            // Display the window.
            temperatureInstance.Show();

            // Set focus to the new window.
            temperatureInstance.Focus();
        }

        /// <summary>
        /// Displays the "About" information for the program.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void HelpAbout(object sender, EventArgs e)
        {
            // Show the about info in a messagebox.
            MessageBox.Show("Multi-Purpose Tool\n" + "By Kellen McComb\n\n" +
                "For NETD 2202\n" + "April 2021", "About This Application");
        }

        
    }
}
