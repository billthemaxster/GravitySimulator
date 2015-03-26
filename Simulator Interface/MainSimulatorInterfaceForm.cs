using Simulator.Interface.ViewModel;
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
    public partial class MainSimulatorInterfaceForm : Form
    {
        #region Properties
        /// <summary>
        /// The celestial bodies that have not been selected to simulate.
        /// </summary>
        public List<CelestialBody> PossibleBodies { get; set; }

        /// <summary>
        /// The celestial bodies that have been selected to simulate.
        /// </summary>
        public List<CelestialBody> SelectedBodies { get; set; }
        #endregion //Properties

        #region Constructors
        /// <summary>
        /// Initialises a new instance of the MainSimulatorIntefaceForm class.
        /// </summary>
        public MainSimulatorInterfaceForm()
        {
            InitializeComponent();

            this.SelectedBodies = new List<CelestialBody>();
            this.PossibleBodies = GravitySimulator.GetPossibleBodies();
            foreach (CelestialBody body in this.PossibleBodies)
            {
                lbPossible.Items.Add(new ListedCelestialBody(body));
            }
        }
        #endregion // Constructors

        #region UI Event Methods
        /// <summary>
        /// Adds the selected celestial body in the possible bodies list to the
        /// included bodies list.
        /// </summary>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            ListedCelestialBody selectedListBody;
            if (lbPossible.SelectedItem != null)
            {
                selectedListBody = (ListedCelestialBody)lbPossible.SelectedItem;
            }
            else if (PossibleBodies.Count != 0)
            {
                selectedListBody = (ListedCelestialBody)lbPossible.Items[0];
            }
            else
            {
                return;
            }

            CelestialBody selectedBody = selectedListBody.Body;

            lbSelected.Items.Add(lbPossible.SelectedItem);
            SelectedBodies.Add(selectedBody);

            lbPossible.Items.Remove(lbPossible.SelectedItem);
            PossibleBodies.Remove(selectedBody);

            this.SortLists();
        }

        /// <summary>
        /// Removes the selected celestial body from the included bodies list.
        /// </summary>
        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (lbSelected.SelectedItem != null)
            {
                ListedCelestialBody selectedListBody = (ListedCelestialBody)lbSelected.SelectedItem;
                CelestialBody selectedBody = selectedListBody.Body;

                lbPossible.Items.Add(selectedListBody);
                this.PossibleBodies.Add(selectedBody);
                lbSelected.Items.Remove(selectedListBody);
                this.SelectedBodies.Remove(selectedBody);

                this.SortLists();
            }
        }

        /// <summary>
        /// Opens a new CelestialBodyDetailsForm, 
        /// </summary>
        private void btnCreate_Click(object sender, EventArgs e)
        {
            CelestialBodyDetailsForm detailsForm = new CelestialBodyDetailsForm();
            detailsForm.SaveBody += detailsForm_SaveBody;

            detailsForm.Show();
        }

        /// <summary>
        /// Changes the selected index of the list boxes, only one list box may 
        /// have an item selected.
        /// </summary>
        /// <param name="sender">The list box that has a new selected index</param>
        private void ListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ////This has an error, I can't be bothered to fix it...
            ////2015-3-23: What the hell is the error!? Document properly, DICKHEAD
            ListBox senderBox = (ListBox)sender;

            if (senderBox == lbSelected && lbPossible.SelectedItem != null)
            {
                lbPossible.ClearSelected();
            }
            else if (senderBox == lbPossible && lbSelected.SelectedItem != null)
            {
                lbSelected.ClearSelected();
            }
        }

        /// <summary>
        /// Opens an editor form for the selected body.
        /// </summary>
        private void btnEdit_Click(object sender, EventArgs e)
        {
            ListedCelestialBody selectedListBody;
            if (lbPossible.SelectedItem != null)
            {
                selectedListBody = (ListedCelestialBody)lbPossible.SelectedItem;
            }
            else if (lbSelected.SelectedItem != null)
            {
                selectedListBody = (ListedCelestialBody)lbSelected.SelectedItem;
            }
            else
            {
                MessageBox.Show("Cannot open an editor as there is no selected body.");
                return;
            }

            CelestialBody selectedBody = selectedListBody.Body;
            CelestialBodyDetailsForm detailsForm = new CelestialBodyDetailsForm(selectedBody);

            detailsForm.Show();
        }

        /// <summary>
        /// Runs a simulation of the selected bodies.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRun_Click(object sender, EventArgs e)
        {

        }
        #endregion // UI Event Methods

        #region Event Methods
        /// <summary>
        /// Saves the body of in a details form, if it already exists in one of
        /// the lists then it will be updated, otherwise, it will add the body to
        /// the possible bodies list.
        /// </summary>
        /// <param name="savedBody">The body being saved.</param>
        private void detailsForm_SaveBody(CelestialBody savedBody)
        {
            if (this.ReplaceBody(this.PossibleBodies, savedBody))
            {
            }
            else if (this.ReplaceBody(this.SelectedBodies, savedBody))
            {
            }
            else
            {
                this.PossibleBodies.Add(savedBody);
            }

            this.SortLists();
        }
        #endregion //Event Methods

        #region Private Methods
        /// <summary>
        /// Sorts the bodies being displayed in the lists into alphaebetical order 
        /// by their name.
        /// </summary>
        private void SortLists()
        {
            lbPossible.Items.Clear();
            this.PossibleBodies = this.PossibleBodies.OrderBy(b => b.Position.Magnitude()).ToList();
            foreach (CelestialBody possibleBody in this.PossibleBodies)
            {
                lbPossible.Items.Add(new ListedCelestialBody(possibleBody));
            }

            this.lbSelected.Items.Clear();
            this.SelectedBodies = this.SelectedBodies.OrderBy(b => b.Position.Magnitude()).ToList();
            foreach (CelestialBody selectedBody in this.SelectedBodies)
            {
                lbSelected.Items.Add(new ListedCelestialBody(selectedBody));
            }
        }

        /// <summary>
        /// Replaces a body in a list if one exists with the same name. 
        /// </summary>
        /// <returns>Whether a body has been replaced</returns>
        private bool ReplaceBody(List<CelestialBody> bodies, CelestialBody savedBody)
        {
            var replacableBodies = (from b in bodies
                          where b.Name == savedBody.Name
                          select b).ToList();
            if (replacableBodies.Count > 0)
            {
                CelestialBody replacableBody = replacableBodies.Single();
                this.PossibleBodies.Remove(replacableBody);
                this.PossibleBodies.Add(savedBody);
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion // Private Methods


    }
}
