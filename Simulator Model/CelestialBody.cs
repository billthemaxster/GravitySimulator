/*=============================================================================
 * Contains the Celestial Body class, represent an orbiting body.
 *  
 * Version: 0.1.1
 * Author: Martin Kennish
 * Date: 2014-10-16
 * 
 ============================================================================*/
using System;
using System.Collections;
using System.Collections.Generic;

namespace Simulator.Model
{
    /// <summary>
    /// Represents a celestial body and its movement under gravitational force.
    /// </summary>
    public class CelestialBody
    {
        #region Properties
        /// <summary>
        /// Gets or sets the position of the Celestial Body.
        /// </summary>
        public Vector Position { get; set; }

        /// <summary>
        /// Gets or sets the velocity of the celestial body.
        /// </summary>
        public Vector Velocity { get; set; }

        /// <summary>
        /// Gets or sets the acceleration of the celestial body.
        /// </summary>
        public Vector Acceleration { get; set; }

        /// <summary>
        /// Gets or sets the mass of celestial body.
        /// </summary>
        public double Mass { get; set; }

        /// <summary>
        /// Gets or sets the name of the celestial body.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The value of the gravitational constant.
        /// </summary>
        public const double G = 6.6738E-11;
        #endregion

        #region Constructors
        /// <summary>
        /// Initialises a new instance of the CelestialBody class.
        /// </summary>
        public CelestialBody()
        {
            this.Position = new Vector();
            this.Velocity = new Vector();
            this.Acceleration = new Vector();
            this.Mass = 0;
            this.Name = GenerateUniqueBodyName();
        }

        /// <summary>
        /// Initialises a new instance of the CelestialBody class, taking a 
        /// position and a mass.
        /// </summary>
        /// <param name="pIn">Initial position of the celestial body</param>
        /// <param name="mIn">The mass of the celestial body</param>
        public CelestialBody(Vector pIn, double mIn)
        {
            this.Position = new Vector(pIn);
            this.Mass = mIn;
            this.Velocity = new Vector();
            this.Acceleration = new Vector();
            this.Name = GenerateUniqueBodyName();
        }

        /// <summary>
        /// Initialises a new instance of the CelestialBody class.
        /// </summary>
        /// <param name="pIn">Initial position of the celestial body</param>
        /// <param name="vIn">Initial velocity of the celestial body</param>
        /// <param name="aIn">Initial acceleration of the celestial body</param>
        /// <param name="mIn">The mass of the celestial body</param>
        public CelestialBody(Vector pIn, Vector vIn, Vector aIn, double mIn)
        {
            this.Position = new Vector(pIn);
            this.Velocity = new Vector(vIn);
            this.Acceleration = new Vector(aIn);
            this.Mass = mIn;
            this.Name = GenerateUniqueBodyName();
        }

        /// <summary>
        /// Initialises a new instance of the CelestialBody class.
        /// </summary>
        /// <param name="pIn">Initial position of the celestial body</param>
        /// <param name="vIn">Initial velocity of the celestial body</param>
        /// <param name="mIn">The mass of the celestial body</param>
        /// <param name="nIn">The name of the celestial body</param>
        public CelestialBody(Vector pIn, Vector vIn, double mIn, string nIn)
        {
            this.Position = new Vector(pIn);
            this.Velocity = new Vector(vIn);
            this.Acceleration = new Vector();
            this.Mass = mIn;
            this.Name = nIn;
        }

        /// <summary>
        /// Initialises a new instance of the CelestialBody class.
        /// </summary>
        /// <param name="pIn">Initial position of the celestial body</param>
        /// <param name="vIn">Initial velocity of the celestial body</param>
        /// <param name="aIn">Initial acceleration of the celestial body</param>
        /// <param name="mIn">The mass of the celestial body</param>
        /// <param name="nIn">The name of the celestial body</param>
        public CelestialBody(Vector pIn, Vector vIn, Vector aIn, double mIn, string nIn)
        {
            this.Position = new Vector(pIn);
            this.Velocity = new Vector(vIn);
            this.Acceleration = new Vector(aIn);
            this.Mass = mIn;
            this.Name = nIn;
        }

        /// <summary>
        /// Initialises a new instance of the CelestialBody class, cloning a celestial body.
        /// </summary>
        /// <param name="bodyIn">The celestial body to clone</param>
        public CelestialBody(CelestialBody bodyIn)
        {
            this.Position = new Vector(bodyIn.Position);
            this.Velocity = new Vector(bodyIn.Velocity);
            this.Acceleration = new Vector(bodyIn.Acceleration);
            this.Mass = bodyIn.Mass;
            this.Name = bodyIn.Name;
        }
        #endregion

        #region Single Body Movement
        /// <summary>
        /// Calculates the distance between this body and another.
        /// </summary>
        /// <param name="otherBody">The body to calculate the distance from</param>
        /// <returns>The distance to the other body</returns>
        public Vector DistBetweenBodies(CelestialBody otherBody)
        {
            return Vector.Subtract(this.Position, otherBody.Position);
        }

        /// <summary>
        /// Calculates the acceleration between two bodies.
        /// </summary>
        /// <param name="otherBody">The body that causes the gravitational acceleration </param>
        /// <returns>The acceleration on this body</returns>
        public Vector AccelBetweenBodies(CelestialBody otherBody)
        {
            // Calculate the distance between the two bodies and find the unit vector, and the magnitude of it squared
            Vector distance = this.DistBetweenBodies(otherBody);
            Vector accelBetween = new Vector();
            if (distance.Magnitude() == 0)
            {
                return accelBetween;
            }

            double distanceSquared = distance.Magnitude() * distance.Magnitude();
            Vector distanceUnit = distance.Unit();

            // Calculate the gravitational acceleration on this body and return it
            accelBetween = distanceUnit.Times((-1.0 * CelestialBody.G * otherBody.Mass) / distanceSquared);
            return accelBetween;
        }

        /// <summary>
        /// Updates the position and velocity of the celestial body using the 
        /// Euler-Cromer algorithm:
        /// v_(n+1) = v_n + a_n*t
        /// x_(n+1) = x_n + v_(n+1)*t 
        /// </summary>
        /// <param name="deltaTime">The change in time</param>
        public void Update(double deltaTime)
        {
            this.Velocity.IncreaseBy(this.Acceleration.Times(deltaTime)); // v_(n+1) = v_n + a_n*t

            this.Position.IncreaseBy(this.Velocity.Times(deltaTime)); // x_(n+1) = x_n + v_(n+1)*t 
            return;
        }
        #endregion

        #region Multi Body Movement
        /// <summary>
        /// Moves an array of Celestial bodies under the force of gravity.
        /// </summary>
        /// <param name="bodies">An list of celestial bodies</param>
        /// <param name="deltaTime">The time step</param>
        /// <returns>The updated list of celestial bodies</returns>
        public static List<CelestialBody> Update(List<CelestialBody> bodies, double deltaTime)
        {
            foreach (CelestialBody i in bodies)
            {
                Vector totalAccel = new Vector();

                foreach (CelestialBody j in bodies)
                {
                    if (i != j)
                    {
                        Vector accel = new Vector();
                        accel = i.AccelBetweenBodies(j);
                        totalAccel.IncreaseBy(accel);
                    }
                }

                i.Acceleration = totalAccel;
            }

            foreach (CelestialBody k in bodies)
            {
                k.Update(deltaTime);
            }

            return bodies;
        }

        /// <summary>
        /// Takes a list of celestial bodies, rephrases it so that the bodies are 
        /// at the in the Centre of Mass frame of reference.
        /// </summary>
        /// <param name="bodies">The List of celestial bodies</param>
        /// <returns>A list of celestial bodies in the centre of mass frame</returns>
        public static List<CelestialBody> CentreOfMass(List<CelestialBody> bodies)
        {
            Vector postionCOM = new Vector();
            Vector velocityCOM = new Vector();
            double totalMass = 0;

            foreach (CelestialBody body in bodies)
            {
                totalMass += body.Mass;
            }

            totalMass = 1 / totalMass;

            foreach (CelestialBody body in bodies)
            {
                postionCOM.IncreaseBy(body.Position.Times(totalMass * body.Mass));
                velocityCOM.IncreaseBy(body.Velocity.Times(totalMass * body.Mass));
            }

            foreach (CelestialBody body in bodies)
            {
                body.Position.DecreaseBy(postionCOM);
                body.Velocity.DecreaseBy(velocityCOM);
            }

            return bodies;
        }
        #endregion

        #region Print Methods
        /// <summary>
        /// A string of the properties of the Celestial Body. In the Form: 
        /// "Name, Position, Velocity, Acceleration, Mass".
        /// </summary>
        /// <returns>The properties of the Celestial Body</returns>
        public override string ToString()
        {
            return this.Name + ", " + this.Position + ", " + this.Velocity + ", " + this.Acceleration + ", " + this.Mass;
        }

        /// <summary>
        /// Returns a CSV string of the Celestial Body. In the form: 
        /// "pX,pY,pZ,vX,vY,vZ,aX,aY,aZ.
        /// </summary>
        /// <returns>A comma separated variable string of the Celestial Body</returns>
        public string ToLog()
        {
            return this.Position.ToLog() + "," + this.Velocity.ToLog() + "," + this.Acceleration.ToLog();
        }
        #endregion // Print Methods

        #region Uniqueness
        /// <summary>
        /// The list of registered names.
        /// </summary>
        private static List<string> _RegisteredNames;

        /// <summary>
        /// The random number generator.
        /// </summary>
        private static int _BodyCount;

        /// <summary>
        /// Gets or sets the list of registered names.
        /// </summary>
        private static List<string> RegisteredNames 
        {
            get
            {
                if (_RegisteredNames == null)
                {
                    _RegisteredNames = new List<string>();
                }

                return _RegisteredNames;
            }
            set
            {
                _RegisteredNames = value;
            }
        }

        /// <summary>
        /// Whether the name is unique.
        /// </summary>
        private static bool IsUniqueName(string name)
        {
            return !RegisteredNames.Contains(name);
        }

        /// <summary>
        /// Generates a name for a celestial body. in the form "body_###".
        /// </summary>
        private static string GenerateUniqueBodyName()
        {
            string randName = string.Empty;
            do
            {
                _BodyCount++;
                randName = "body_" + _BodyCount;
            }
            while (!IsUniqueName(randName));
            
            return randName;            
        }
        #endregion // Uniqueness
    }
}