using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulatorLogic.Models
{
    public class Vector
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }

        /// <summary>
        /// Initialises a new instance of the Vector class.
        /// </summary>
        public Vector()
        {
        }

        /// <summary>
        /// Initialises a new instance of the Vector class. 
        /// </summary>
        public Vector(double xIn, double yIn, double zIn)
        {
            this.X = xIn;
            this.Y = yIn;
            this.Z = zIn;
        }

        /// <summary>
        /// Initialises a new instance of the Vector class, cloning an already 
        /// existing vector.
        /// </summary>
        /// <param name="a">The vector to clone</param>
        public Vector(Vector a)
        {
            this.X = a.X;
            this.Y = a.Y;
            this.Z = a.Z;
        }
    }
}
