using Simulator.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Simulator.Interface
{
    /// <summary>
    /// Delegate used to save a celestial body.
    /// </summary>
    /// <param name="savedBody">The body being saved</param>
    public delegate void SaveBodyDelegate(CelestialBody savedBody);

    public partial class CelestialBodyDetailsForm : Form
    {

        public event SaveBodyDelegate SaveBody;

        /// <summary>
        /// Gets or sets the simulator form.
        /// </summary>
        private MainSimulatorInterfaceForm SimulatorForm { get; set; }

        /// <summary>
        /// Gets or sets the body to display.
        /// </summary>
        private CelestialBody DisplayBody { get; set; }

        private string InitialName { get; set; }

        /// <summary>
        /// Initialises a new instance of the CelestialBodyDetailsForm class.
        /// </summary>
        public CelestialBodyDetailsForm()
        {
            this.DisplayBody = new CelestialBody();
            this.InitializeComponent();
        }

        /// <summary>
        /// Initialises a new instance of the CelestialBodyDetailsForm class.
        /// </summary>
        /// <param name="displayBody">The body to display</param>
        public CelestialBodyDetailsForm(CelestialBody displayBody)
        {
            this.InitialName = displayBody.Name;

            this.InitializeComponent();

            txtName.Text = displayBody.Name;
            txtMass.Text = displayBody.Mass.ToString();
            vePosition.Value = displayBody.Position;
            veVelocity.Value = displayBody.Velocity;
            veAccel.Value = displayBody.Acceleration;
        }

        /// <summary>
        /// Saves the celestial body in the simulator form.
        /// </summary>
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (this.ParseDisplayBody())
            {
                OnSaveBody();
            }

            this.Close();
        }

        /// <summary>
        /// Sets the values of the display body from the form.
        /// </summary>
        private bool ParseDisplayBody()
        {
            try
            {
                this.DisplayBody.Name = txtName.Text;
                this.DisplayBody.Mass = double.Parse(txtMass.Text);
                this.DisplayBody.Position = vePosition.Value;
                this.DisplayBody.Velocity = veVelocity.Value;
                this.DisplayBody.Acceleration = veAccel.Value;
                return true;
            }
            catch (Exception)
            {
                MessageBox.Show("The body cannot be saved as some of the values are invalid.");
                return false;
            }
        }

        /// <summary>
        /// Only allows positive doubles to be entered into the mass text box.
        /// </summary>
        private void txtMass_KeyPress(object sender, KeyPressEventArgs e)
        {
            string txtValue = (sender as TextBox).Text;
            if (e.KeyChar == 'e' || e.KeyChar == 'E' || e.KeyChar == '\b' ||
                (e.KeyChar == '-' && (string.IsNullOrEmpty(txtValue) ||
                txtValue.ToUpper()[txtValue.Length - 1] == 'E')))
            {
                return;
            }

            double component;
            txtValue += e.KeyChar;
            if (!double.TryParse(txtValue, out component))
            {
                e.Handled = true;                
            }
        }

        /// <summary>
        /// Raises the SaveBody event.
        /// </summary>
        private void OnSaveBody()
        {
            if (this.SaveBody != null)
            {
                SaveBody(this.DisplayBody);
            }
        }
    }
}
