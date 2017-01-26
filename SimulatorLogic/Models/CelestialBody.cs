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

    }
}
