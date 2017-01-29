using SimulatorLogic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulatorLogic.Logic
{
    // Are static methods thread safe?
    public static class CelestialBodyLogic
    {
        private const double GravitationalConstant = 6.6738E-11;
        public static Vector DistanceBetweenBodies(CelestialBody first, CelestialBody second)
        {
            return VectorLogic.Subtract(first.Postition, second.Postition);
        }

        public static Vector AccelerationBetweenBodies(CelestialBody first, CelestialBody second)
        {
            Vector distance = DistanceBetweenBodies(first, second);
            var magnitudeOfDistance = VectorLogic.Magnitude(distance);

            if (magnitudeOfDistance == 0)
            {
                return new Vector();
            }

            double distanceSquared = magnitudeOfDistance * magnitudeOfDistance;

            Vector unitVectorOfDistance = VectorLogic.Unit(distance);

            double scaleFactor = (-1.0 * GravitationalConstant * second.Mass) / distanceSquared;

            return VectorLogic.Scale(unitVectorOfDistance, scaleFactor);
        }

        public static CelestialBody Update(CelestialBody body, double timeStep)
        {
            Vector velocityChange = VectorLogic.Scale(body.Acceleration, timeStep);
            body.Velocity = VectorLogic.Add(body.Velocity, velocityChange);

            Vector positionChange = VectorLogic.Scale(body.Velocity, timeStep);
            body.Postition = VectorLogic.Add(body.Postition, positionChange);

            return body;
        }

        public static List<CelestialBody> UpdateMultipleBodies(List<CelestialBody> bodies, double timeStep)
        {
            foreach(CelestialBody firstBody in bodies)
            {
                // Reset the acceleration
                firstBody.Acceleration = new Vector();

                foreach (CelestialBody secondBody in bodies)
                {
                    if (!firstBody.Equals(secondBody))
                    {
                        Vector acceleration = AccelerationBetweenBodies(firstBody, secondBody);
                        firstBody.Acceleration = VectorLogic.Add(firstBody.Acceleration, acceleration);
                    }
                }
            }

            List<CelestialBody> newBodies = new List<CelestialBody>();

            foreach (CelestialBody body in bodies)
            {
                newBodies.Add(Update(body, timeStep));
            }

            return newBodies;
        }

        public static List<CelestialBody> UpdateCentreOfMass(List<CelestialBody> bodies)
        {
            Vector positionCOM = new Vector();
            Vector velocityCOM = new Vector();
            double totalMass = 0;

            foreach (CelestialBody body in bodies)
            {
                totalMass += body.Mass;
            }

            double invertedTotalMass = 1 / totalMass;

            foreach (CelestialBody body in bodies)
            {
                double bodyScaleFactor = body.Mass * invertedTotalMass;

                Vector positionChange = VectorLogic.Scale(body.Postition, bodyScaleFactor);
                positionCOM = VectorLogic.Add(body.Postition, positionChange);

                Vector velocityChange = VectorLogic.Scale(body.Velocity, bodyScaleFactor);
                velocityCOM = VectorLogic.Add(body.Velocity, velocityChange);

            }

            foreach(CelestialBody body in bodies)
            {
                body.Postition = VectorLogic.Subtract(body.Postition, positionCOM);
                body.Velocity = VectorLogic.Subtract(body.Velocity, velocityCOM);
            }

            return bodies;
        }
    }
}
