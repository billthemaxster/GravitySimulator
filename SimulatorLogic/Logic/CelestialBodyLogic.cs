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
            return Vector.Subtract(first.Postition, second.Postition);
        }

        public static Vector AccelerationBetweenBodies(CelestialBody first, CelestialBody second)
        {
            Vector distance = DistanceBetweenBodies(first, second);
            var magnitudeOfDistance = distance.Magnitude;

            if (magnitudeOfDistance == 0)
            {
                return new Vector();
            }

            double distanceSquared = magnitudeOfDistance * magnitudeOfDistance;

            Vector unitVectorOfDistance = distance.UnitVector;

            double scaleFactor = (-1.0 * GravitationalConstant * second.Mass) / distanceSquared;

            return Vector.Scale(unitVectorOfDistance, scaleFactor);
        }

        public static CelestialBody Update(CelestialBody body, double timeStep)
        {
            Vector velocityChange = Vector.Scale(body.Acceleration, timeStep);
            body.Velocity.Add(velocityChange);

            Vector positionChange = Vector.Scale(body.Velocity, timeStep);
            body.Postition.Add(positionChange);

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
                        firstBody.Acceleration.Add(acceleration);
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

                Vector positionChange = Vector.Scale(body.Postition, bodyScaleFactor);
                positionCOM.Add(positionChange);

                Vector velocityChange = Vector.Scale(body.Velocity, bodyScaleFactor);
                velocityCOM.Add(velocityChange);
            }

            foreach(CelestialBody body in bodies)
            {
                body.Postition.Subtract(positionCOM);
                body.Velocity.Subtract(velocityCOM);
            }

            return bodies;
        }
    }
}
