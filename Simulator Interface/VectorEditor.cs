using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Simulator.Model;

namespace Simulator.Interface
{
    public partial class VectorEditor : UserControl
    {
        /// <summary>
        /// The vector displayed by the editor.
        /// </summary>
        private Vector _Value;

        /// <summary>
        /// Gets or sets the Vector to be displayed by the editor.
        /// </summary>
        public Vector Value
        {
            get
            {
                return _Value;
            } 
            set 
            {
                txtX.Text = value.X.ToString();
                txtY.Text = value.Y.ToString();
                txtZ.Text = value.Z.ToString();
                this._Value = value;
            }
        }

        /// <summary>
        /// The label for the vector.
        /// </summary>
        public string Label
        {
            get
            {
                return lblLabel.Text;
            }
            set
            {
                lblLabel.Text = value;
            }
        }

        /// <summary>
        /// Initialises a new instance of the VectorEditor class.
        /// </summary>
        public VectorEditor()
        {
            InitializeComponent();

            this._Value = new Vector();
        }

        /// <summary>
        /// Sets the newly entered x component of the display vector.
        /// </summary>
        private void txtX_TextChanged(object sender, EventArgs e)
        {

            double x;
            if (double.TryParse(txtX.Text, out x))
            {
                this.Value.X = x;
            }
            else if (string.IsNullOrEmpty(txtX.Text))
            {
                this.Value.X = 0;
            }
            else
            {
                MessageBox.Show("The x-component of the " + lblLabel.Text + " vector cannot be parsed into an integer.");
            }
        }

        /// <summary>
        /// Sets the newly entered y component of the display vector.
        /// </summary>
        private void txtY_TextChanged(object sender, EventArgs e)
        {
            double y;
            if (double.TryParse(txtY.Text, out y))
            {
                this.Value.Y = y;
            }
            else if (string.IsNullOrEmpty(txtY.Text))
            {
                this.Value.Y = 0;
            }
            else
            {
                MessageBox.Show("The y-component of the " + lblLabel.Text + " vector cannot be parsed into an integer.");
            }
        }

        /// <summary>
        /// Sets the newly entered z component of the display vector.
        /// </summary>
        private void txtZ_TextChanged(object sender, EventArgs e)
        {
            double z;
            if (double.TryParse(txtZ.Text, out z))
            {
                this.Value.Z = z;
            }
            else if (string.IsNullOrEmpty(txtZ.Text))
            {
                this.Value.Z = 0;
            }
            else
            {
                MessageBox.Show("The z-component of the " + lblLabel.Text + " vector cannot be parsed into an integer.");
            }
        }

        /// <summary>
        /// Only allows integers to be entered into a text box.
        /// </summary>
        /// <param name="e">The key that has been pressed</param>
        private void txtComponent_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != '\b')
            {
                double component;
                string txtValue = (sender as TextBox).Text + e.KeyChar;
                if (!double.TryParse(txtValue, out component))
                {
                    e.Handled = true;
                }
            }
        }
    }
}
