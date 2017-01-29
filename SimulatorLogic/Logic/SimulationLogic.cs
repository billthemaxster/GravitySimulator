using SimulatorLogic.Logging;
using SimulatorLogic.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulatorLogic.Logic
{
    public class SimulationLogic
    {
        private List<CelestialBody> Bodies { get; set; }
        private double TimeStep { get; set; } 
        private double SimulationLength { get; set; }
        private long StepsBetweenLog { get; set; }
        private string LogLocation { get; set; }

        public Dictionary<string, string> Errors;

        public SimulationLogic(List<CelestialBody> bodies, double timeStep, double simulationLength, long stepsBetweenLog)
        {
            Bodies = bodies;
            TimeStep = timeStep;
            SimulationLength = simulationLength;
            StepsBetweenLog = stepsBetweenLog;
            Errors = new Dictionary<string, string>();

            // Set LogLocation from a config variable.
        }

        public void Simulate()
        {
            if (!IsSimulationValid())
            {
                // Stop the simulation from happening and let
                throw new InvalidOperationException("The simulation is not valid, please see the errors.");
            }

            long maxSteps = (long)(SimulationLength / TimeStep);

            using(ILogger logger = null)
            {
                for (long stepsTaken = 0; stepsTaken < maxSteps; stepsTaken++)
                {
                    Bodies = CelestialBodyLogic.UpdateMultipleBodies(Bodies, TimeStep);

                    if (stepsTaken % 10 == 0)
                    {
                        Bodies = CelestialBodyLogic.UpdateCentreOfMass(Bodies);
                    }

                    if (stepsTaken % StepsBetweenLog == 0)
                    {
                        logger.Log(Bodies, stepsTaken * TimeStep);
                    }
                }

                // Not 100% sure it'll be exactly simulation length here, need to check the math.
                logger.Log(Bodies, SimulationLength);
            }
        }

        private bool IsSimulationValid()
        {
            if (Bodies == null)
            {
                Errors.Add("Bodies", "Cannot have a null list of bodies.");
            }
            else
            {
                if (Bodies.Count < 2)
                {
                    Errors.Add("Bodies", "Two or more bodies are required for a simulation.");
                }
            }

            if (TimeStep <= 0)
            {
                Errors.Add("TimeStep", "Time step must be greater than zero.");
            }

            if (SimulationLength <= 0)
            {
                Errors.Add("SimulationLength", "Simulation length must be greater than zero.");
            }

            if (StepsBetweenLog == 0)
            {
                Errors.Add("PrintResolution", "Print Resolution must be greater than zero.");
            }

            return Errors.Count <= 0;
        }

    }
}
