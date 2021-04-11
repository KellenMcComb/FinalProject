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
        /// Opens a new text editor child window.
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
        /// If the active mdi window is the text editor, call the Cut event handler
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
        /// If the active mdi window is the text editor, call the Copy event handler
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
        /// If the active mdi window is the text editor, call the Paste event handler
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
        /// Create and display a Car Inventory Form instance as an MDI child.
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
    }
}
