/*=============================================================================
 * Contains the Simulator class, simulates the movement of celestial bodies 
 * under the force of gravity.
 *  
 * Version: 0.2.0
 * Author: Martin Kennish
 * Date: 2015-03-23
 * 
 ============================================================================*/

using System;
using System.Collections.Generic;
using System.IO;

namespace Simulator.Model
{
    #region Delegate
    /// <summary>
    /// Event handler for a data logging event.
    /// </summary>
    /// <param name="sender">The object that raised the event</param>
    public delegate void DataLogEventHandler(object sender, EventArgs e);

    /// <summary>
    /// Event handler for a simulator error.
    /// </summary>
    /// <param name="sender">The simulator that raised the event</param>
    /// <param name="e">The error details</param>
    public delegate void SimulatorErrorHandler(object sender, SimulatorErrorEventArgs e);
    #endregion // Delegate

    /// <summary>
    /// Represents a gravity simulator takes a list of celestial bodies, the 
    /// length of time to simulate for, the time step and the logging resolution.
    /// </summary>
    public class GravitySimulator
    {
        #region Properties
        /// <summary>
        /// Gets or sets the list of Bodies to simulate.
        /// </summary>
        public List<CelestialBody> Bodies { get; set; }

        /// <summary>
        /// Gets or sets the time step of the simulation.
        /// </summary>
        public double TimeStep { get; set; }

        /// <summary>
        /// Gets or sets the length of the simulation.
        /// </summary>
        public double SimulationLength { get; set; }

        /// <summary>
        /// Gets or sets the printing resolution of the simulation. The number
        /// of steps between each logging of data.
        /// </summary>
        public int PrintResolution { get; set; }
        #endregion // Properties

        #region Events
        /// <summary>
        /// Raised on the logging of data.
        /// </summary>
        public event DataLogEventHandler DataLog;

        /// <summary>
        /// Raised on a simulator error.
        /// </summary>
        public event SimulatorErrorHandler SimulatorError;
        #endregion // Events

        #region Constructors
        /// <summary>
        /// Initialises a new instance of the GravitySimulator class.
        /// </summary>
        /// <param name="bodies">The bodies to conduct the simulation for.</param>
        public GravitySimulator(List<CelestialBody> bodies)
        {
            this.Bodies = bodies;
        }
        #endregion

        #region Simulation
        /// <summary>
        /// Runs a simulation on the bodies in the simulator for the simulation
        /// length making time steps and recording the properties of the bodies 
        /// to a log file.
        /// </summary>
        public void Simulate()
        {
            if (!this.ValidateSimulation())
            {
                return; // Maybe throw an exception or something instead
            }
            int maxSteps = (int)(this.SimulationLength / this.TimeStep);

            using (StreamWriter file = new StreamWriter(@"D:\My documents\Documents\Dropbox\Programming\C#\Gravity Simulator\Outputs\output.txt"))
            {
                for (int stepsTaken = 0; stepsTaken < maxSteps; stepsTaken++)
                {
                    this.Bodies = CelestialBody.Update(this.Bodies, TimeStep);

                    if (stepsTaken % 10 == 0)
                    {
                        this.Bodies = CelestialBody.CentreOfMass(this.Bodies);
                    }

                    if (stepsTaken % this.PrintResolution == 0)
                    {
                        file.WriteLine(Bodies.ToLog());
                    }
                }

                file.WriteLine(Bodies.ToLog());
            }
        }

        /// <summary>
        /// Validates whether the simulation has the parameters required to run.
        /// </summary>
        private bool ValidateSimulation()
        {
            Dictionary<string, string> errors = new Dictionary<string, string>();

            if (this.Bodies == null)
            {
                errors.Add("Bodies", "Cannot have a null list of bodies.");
            }
            else
            {
                if (this.Bodies.Count < 2)
                {
                    errors.Add("Bodies", "Two or more bodies are required for a simulation.");
                }
            }

            if (this.TimeStep <= 0)
            {
                errors.Add("TimeStep", "Time step must be greater than zero.");
            }

            if (this.SimulationLength <= 0)
            {
                errors.Add("SimulationLength", "Simulation length must be greater than zero.");
            }

            if (this.PrintResolution == 0)
            {
                errors.Add("PrintResolution", "Print Resolution must be greater than zero.");
            }

            if (errors.Count > 0)
            {
                OnSimulatorError(errors);
                return false;
            }

            return true;
        }
        #endregion // Simulation

        #region Event Methods
        /// <summary>
        /// Raises a data log event.
        /// </summary>
        public void OnDataLog()
        {
            if (DataLog != null)
            {
                DataLog(this, new EventArgs());
            }
        }

        /// <summary>
        /// Raises an error event.
        /// </summary>
        /// <param name="errors">The errors on the simulator</param>
        public void OnSimulatorError(Dictionary<string, string> errors)
        {
            if (SimulatorError != null)
            {
                SimulatorError(this, new SimulatorErrorEventArgs(errors));
            }
        }

        #endregion // Event Methods

        #region Body Creation
        /// <summary>
        /// Gets the initial list of the possible bodies.
        /// </summary>
        public static List<CelestialBody> GetPossibleBodies()
        {
            List<CelestialBody> possibleBodies = new List<CelestialBody>();

            CelestialBody sun = new CelestialBody(new Vector(1.47635e8, -3.40751e8, -1.39236e7), new Vector(1.04959e-2, 4.03244e-3, -2.43139e-4), 1.9885544e30, "Sun");
            possibleBodies.Add(sun);

            CelestialBody merc = new CelestialBody(new Vector(1.80585e10, -6.53053e10, -6.96528e9), new Vector(3.72057e4, 1.54346e4, -2.15210e3), 3.302e23, "Mercury");
            possibleBodies.Add(merc);

            CelestialBody venus = new CelestialBody(new Vector(-7.31461e9, 1.07011e11, 1.88774e9), new Vector(-3.50454e4, -2.61301e3, 1.98705e3), 4.4865e24, "Venus");
            possibleBodies.Add(venus);

            CelestialBody earth = new CelestialBody(new Vector(-2.61204e10, 1.44403e11, -1.87104e7), new Vector(-2.97976e4, -5.42782e3, -6.47817e-1), 5.97219e24, "Earth");
            possibleBodies.Add(earth);

            CelestialBody luna = new CelestialBody(new Vector(-2.60981e10, 1.44047e11, 8.09868e6), new Vector(-2.87019e4, -5.33509e3, 4.86809e1), 7.349e22, "Luna");
            possibleBodies.Add(luna);

            CelestialBody mars = new CelestialBody(new Vector(-2.26110e11, 1.03901e11, 7.72389e9), new Vector(-9.21979e3, -1.99329e4, -1.91406e2), 6.4185e23, "Mars");
            possibleBodies.Add(mars);

            CelestialBody ceres = new CelestialBody(new Vector(-3.78855e11, 3.21408e9, 6.99772e10), new Vector(-8.71587e2, -1.91545e4, -4.39682e2), 9.43e20, "Ceres");
            possibleBodies.Add(ceres);

            CelestialBody jupiter = new CelestialBody(new Vector(-1.98937e11, 7.50450e11, 1.32280e9), new Vector(-1.27877e4, -2.72680e3, 2.97581e2), 1.89813e27, "Jupiter");
            possibleBodies.Add(jupiter);

            CelestialBody io = new CelestialBody(new Vector(-1.99329e11, 7.50604e11, 1.32249e9), new Vector(-1.90796e4, -1.88963e4, -3.84319e2), 893.3E20, "Io");
            possibleBodies.Add(io);

            CelestialBody europa = new CelestialBody(new Vector(-1.99596e11, 7.50299e11, 1.30813e9), new Vector(-9.79229e3, -1.60130e4, -2.48699e2), 1565e20, "Europa");
            possibleBodies.Add(europa);

            CelestialBody ganymede = new CelestialBody(new Vector(-1.99458e11, 7.51387e11, 1.35130e9), new Vector(-2.22746e4, -7.99968e3, -2.41146e1), 2634e20, "Ganymede");
            possibleBodies.Add(ganymede);

            CelestialBody callisto = new CelestialBody(new Vector(-2.00336e11, 7.49177e11, 1.26335e9), new Vector(-7.26676e3, -8.73385e3, 1.80937e2), 2403e20, "Callisto");
            possibleBodies.Add(callisto);

            CelestialBody saturn = new CelestialBody(new Vector(-1.02986e12, -1.05882e12, 5.93967e10), new Vector(6.39883e3, -6.76088e3, -1.36599e2), 5.68319e26, "Saturn");
            possibleBodies.Add(saturn);

            CelestialBody uranus = new CelestialBody(new Vector(2.93900e12, 5.86472e11, -3.58977e10), new Vector(-1.38242e3, 6.36091e3, 4.15569e1), 8.68103e25, "Uranus");
            possibleBodies.Add(uranus);

            CelestialBody neptune = new CelestialBody(new Vector(4.04878e12, -1.92894e12, -5.35856e10), new Vector(2.30082e3, 4.93877e3, -1.54438e2), 1.0241e26, "Neptune");
            possibleBodies.Add(neptune);

            CelestialBody pluto = new CelestialBody(new Vector(9.36147e11, -4.77623e12, 2.40297e11), new Vector(5.42982e3, -4.79380e1, -1.54580e3), 1.307e22, "Pluto");
            possibleBodies.Add(pluto);

            CelestialBody charon = new CelestialBody(new Vector(9.36160e11, -4.7762e12, 2.40300e11), new Vector(5.51640e3, -8.03499e1, -1.74887e3), 1.53e21, "Charon");
            possibleBodies.Add(charon);

            return possibleBodies;
        }
        #endregion // Body Creation
    }
}
