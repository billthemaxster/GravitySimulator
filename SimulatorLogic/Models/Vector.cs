using SimulatorLogic.Logic;
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

        public double Magnitude
        {
            get
            {
                double sumOfSquares = X * X;
                sumOfSquares += Y * Y;
                sumOfSquares += Z * Z;

                return Math.Sqrt(sumOfSquares);
            }
        }

        public Vector UnitVector
        {
            get
            {
                double magnitude = Magnitude;

                if (magnitude == 0 || magnitude == 1)
                {
                    return this;
                }

                return Scale(this, 1 / magnitude);
            }
        }

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

        public override bool Equals(object obj)
        {
            if (obj == null || obj.GetType() != typeof(Vector))
            {
                return false;
            }

            Vector other = (Vector)obj;

            return this.X.Equals(other.X)
                && this.Y.Equals(other.Y)
                && this.Z.Equals(other.Z);
        }

        public override int GetHashCode()
        {
            int hashCode = 13;

            unchecked
            {
                hashCode += X.GetHashCode() * 17;
                hashCode += Y.GetHashCode() * 23;
                hashCode += Z.GetHashCode() * 29;

            }

            return hashCode;
        }

        public void Add(Vector vector)
        {
            X += vector.X;
            Y += vector.Y;
            Z += vector.Z;
        }

        public void Subtract(Vector vector)
        {
            X -= vector.X;
            Y -= vector.Y;
            Z -= vector.Z;
        }

        public void Scale(double scaleFactor)
        {
            X *= scaleFactor;
            Y *= scaleFactor;
            Z *= scaleFactor;
        }

        public static Vector Add(Vector a, Vector b)
        {
            return new Vector()
            {
                X = a.X + b.X,
                Y = a.Y + b.Y,
                Z = a.Z + b.Z
            };
        }

        public static Vector Subtract(Vector a, Vector b)
        {
            return new Vector()
            {
                X = a.X - b.X,
                Y = a.Y - b.Y,
                Z = a.Z - b.Z
            };
        }

        public static Vector Scale(Vector a, double scaleFactor)
        {
            return new Vector()
            {
                X = a.X * scaleFactor,
                Y = a.Y * scaleFactor,
                Z = a.Z * scaleFactor
            };
        }
        
        public static double ScalarProduct(Vector a, Vector b)
        {
            return (a.X * b.X) + (a.Y * b.Y) + (a.Z * b.Z);
        }

        public static Vector VectorProduct(Vector a, Vector b)
        {
            Vector prod = new Vector();

            prod.X = (a.Y * b.Z) - (a.Z * b.Y);
            prod.Y = (a.Z * b.X) - (a.X * b.Z);
            prod.Z = (a.X * b.Y) - (a.Y * b.X);

            return prod;
        }
    }
}
