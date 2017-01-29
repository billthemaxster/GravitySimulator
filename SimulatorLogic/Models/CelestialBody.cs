using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulatorLogic.Models
{
    public class CelestialBody
    {
        public Vector Postition { get; set; }
        public Vector Velocity { get; set; }
        public Vector Acceleration { get; set; }
        public double Mass { get; set; }

        public CelestialBody()
        {
            Postition = new Vector();
            Velocity = new Vector();
            Acceleration = new Vector();
        }

        public CelestialBody(Vector position, double mass, Vector velocity = null, Vector acceleration = null)
        {
            Postition = new Vector(position);
            Mass = mass;

            Velocity = velocity == null 
                ? new Vector()
                : new Vector(velocity);
            Acceleration = acceleration == null 
                ? new Vector() 
                : new Vector(acceleration);
        }

        public CelestialBody(CelestialBody celestialBody)
        {
            Postition = new Vector(celestialBody.Postition);
            Velocity = new Vector(celestialBody.Velocity);
            Acceleration = new Vector(celestialBody.Acceleration);

            Mass = celestialBody.Mass;
        }
    }
}
