using System;
using System.Windows.Forms;

using Simulator.Model;

namespace Simulator.Interface
{
    #region Delegates
    /// <summary>
    /// Event Handler for the SimulatorPreStartEvent.
    /// </summary>
    /// <param name="simulator">The simulator that is about to start.</param>
    public delegate void SimulatorPreStartDelegate(GravitySimulator simulator);
    #endregion // Delegates

    /// <summary>
    /// Pop up form that asks the user for the properties of the simulation.
    /// </summary>
    public partial class SimulatorPropertiesPopupForm : Form
    {
        #region Constructors
        /// <summary>
        /// Initialises a new instance of the SimulatorPropertiesPopupForm class.
        /// </summary>
        /// <param name="simulator">The simulator to set the properties for</param>
        public SimulatorPropertiesPopupForm(GravitySimulator simulator)
        {
            this.InitializeComponent();

            this.Simulator = simulator;
            cbDurationUnit.DataSource = Enum.GetValues(typeof(TimeUnit));
        }
        #endregion // Constructors

        #region Events
        /// <summary>
        /// Raised on when the simulator is about to start.
        /// </summary>
        public event SimulatorPreStartDelegate SimulatorPreStart;
        #endregion // Events

        #region Enums
        /// <summary>
        /// Enumeration for the time units available.
        /// </summary>
        private enum TimeUnit
        {
            Seconds,
            Minutes,
            Hours,
            Days,
            Months,
            Years
        }
        #endregion //Enums

        #region Properties
        /// <summary>
        /// Gets or sets the simulator to set the properties for.
        /// </summary>
        private GravitySimulator Simulator { get; set; }

        /// <summary>
        /// Gets or sets the TimeStep for the simulation.
        /// </summary>
        private double TimeStep { get; set; }

        /// <summary>
        /// Gets or sets the duration of the simulation.
        /// </summary>
        private double Duration { get; set; }

        /// <summary>
        /// Gets or sets the print resolution of the simulation.
        /// </summary>
        private int PrintResolution { get; set; }
        #endregion // Properties
                
        #region UI Event Methods
        /// <summary>
        /// Handles the key press event for a text box that only allows decimal input.
        /// </summary>
        /// <param name="sender">The text box that a key was pressed in</param>
        /// <param name="e">The key press event</param>
        private void txtDouble_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '.' && e.KeyChar != '\b')
            {
                e.Handled = true;
            }
        }

        /// <summary>
        /// Handles the key press event for a text box that only allows integer input.
        /// </summary>
        /// <param name="sender">The text box that a key was pressed in</param>
        /// <param name="e">The key press event</param>
        private void txtInteger_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        /// <summary>
        /// Sets the properties of the simulation and then runs it.
        /// </summary>
        /// <param name="sender">The Run button</param>
        /// <param name="e">The click event</param>
        private void btnRun_Click(object sender, EventArgs e)
        {
            if (!this.ValidateAndSet())
            {
                MessageBox.Show("Simulation cannot be run with current properties.");
            }
            else
            {
                this.Simulator.TimeStep = this.TimeStep;
                this.Simulator.SimulationLength = this.Duration;
                this.Simulator.PrintResolution = this.PrintResolution;

                this.OnPreStart();
                this.Close();
            }
        }

        #endregion // UI Event Methods

        #region Methods
        /// <summary>
        /// Validates and sets the pop up form properties.
        /// </summary>
        /// <returns>Whether the form is valid.</returns>
        private bool ValidateAndSet()
        {
            bool valid = true;
            double timeStep;
            if (double.TryParse(txtTimeStep.Text, out timeStep))
            {
                this.TimeStep = timeStep;
            }
            else
            {
                valid &= false;
            }

            double duration;
            if (double.TryParse(txtDuration.Text, out duration))
            {
                double unitMultiplier = 0.0;

                switch ((TimeUnit)cbDurationUnit.SelectedValue)
                {
                    case TimeUnit.Seconds:
                        unitMultiplier = 1.0;
                        break;
                    case TimeUnit.Minutes:
                        unitMultiplier = 60;
                        break;
                    case TimeUnit.Hours:
                        unitMultiplier = 3600;
                        break;
                    case TimeUnit.Days:
                        unitMultiplier = 24 * 3600;
                        break;
                    case TimeUnit.Months:
                        unitMultiplier = 30 * 24 * 3600;
                        break;
                    case TimeUnit.Years:
                        unitMultiplier = 365 * 24 * 3600;
                        break;
                    default:
                        valid &= false;
                        break;
                }

                this.Duration = duration * unitMultiplier;
            }
            else
            {
                valid &= false;
            }

            int printResolution;
            if (int.TryParse(txtResolution.Text, out printResolution))
            {
                this.PrintResolution = printResolution;
            }
            else
            {
                valid &= false;
            }

            return valid;
        }

        /// <summary>
        /// Raises a SimulatorPreStart event.
        /// </summary>
        private void OnPreStart()
        {
            if (this.SimulatorPreStart != null)
            {
                this.SimulatorPreStart(this.Simulator);
            }
        }
        #endregion // Methods
    }
}
