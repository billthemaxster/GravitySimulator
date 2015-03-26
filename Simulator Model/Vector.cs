/*=============================================================================
 * Contains the Vector class, represent a vector.
 *  
 * Version: 0.1.1
 * Author: Martin Kennish
 * Date: 2014-10-16
 * 
 ============================================================================*/
using System;

namespace Simulator.Model
{
    /// <summary>
    /// Represents a three dimensional vector and provides functionality for 
    /// mathematical operations on it.
    /// </summary>
    public class Vector
    {
        #region Properties
        /// <summary>
        /// Gets or sets the x-component of the vector.
        /// </summary>
        public double X { get; set; }

        /// <summary>
        /// Gets or sets the y-component of the vector.
        /// </summary>
        public double Y { get; set; }

        /// <summary>
        /// Gets or sets the z-component of the vector.
        /// </summary>
        public double Z { get; set; }
        #endregion

        #region Constructors
        /// <summary>
        /// Initialises a new instance of the Vector class.
        /// </summary>
        public Vector()
        {
            this.X = 0;
            this.Y = 0;
            this.Z = 0;
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
        #endregion

        #region Operation On Vector
        /// <summary>
        /// Increase this vector by the value of a.
        /// </summary>
        /// <param name="a">The vector to add to this.</param>
        public void IncreaseBy(Vector a)
        {
            this.X += a.X;
            this.Y += a.Y;
            this.Z += a.Z;
        }

        /// <summary>
        /// Decrease this vector by the value of a.
        /// </summary>
        /// <param name="a">The vector to subtract from this.</param>
        public void DecreaseBy(Vector a)
        {
            this.X -= a.X;
            this.Y -= a.Y;
            this.Z -= a.Z;
        }

        /// <summary>
        /// Scales this vector by a scale factor.
        /// </summary>
        /// <param name="scaleFactor">The number to scale this by</param>
        public void Scale(double scaleFactor)
        {
            Vector scaled = this.Times(scaleFactor);

            this.X = scaled.X;
            this.Y = scaled.Y;
            this.Z = scaled.Z;
        }

        /// <summary>
        /// Returns a scaled version of this vector.
        /// </summary>
        /// <param name="scaleFactor">The number to scale this by</param>
        /// <returns>A scaled version of this vector</returns>
        public Vector Times(double scaleFactor)
        {
            Vector scaled = new Vector(this);

            scaled.X *= scaleFactor;
            scaled.Y *= scaleFactor;
            scaled.Y *= scaleFactor;

            return scaled;
        }

        /// <summary>
        /// Returns the magnitude of the vector
        /// </summary>
        /// <returns>The magnitude of this vector</returns>
        public double Magnitude()
        {
            return Math.Sqrt((this.X * this.X) + (this.Y * this.Y) + (this.Z * this.Z));
        }

        /// <summary>
        /// Returns the unit vector of this vector
        /// </summary>
        /// <returns>The unit vector of this</returns>
        public Vector Unit()
        {
            double mag = this.Magnitude();

            if (mag == 0)
            {
                return this;
            }

            return this.Times(1 / mag);
        }
        #endregion

        #region Operation on two Vectors
        /// <summary>
        /// Returns the scalar product of two vectors.
        /// </summary>
        public static double ScalarProduct(Vector a, Vector b)
        {
            return (a.X * b.X) + (a.Y * b.Y) + (a.Z * b.Z);
        }

        /// <summary>
        /// Returns the Vector product of two vectors.
        /// </summary>
        public static Vector VectorProduct(Vector a, Vector b)
        {
            Vector prod = new Vector();
            prod.X = (a.Y * b.Z) - (a.Z * b.Y);
            prod.Y = (a.Z * b.X) - (a.X * b.Z);
            prod.Z = (a.X * b.Y) - (a.Y * b.X);
            return prod;
        }

        /// <summary>
        /// Returns the sum of two vectors.
        /// </summary>
        public static Vector Add(Vector a, Vector b)
        {
            Vector addition = new Vector(a);
            addition.IncreaseBy(b);
            return addition;
        }

        /// <summary>
        /// Returns the difference between two vectors.
        /// </summary>
        public static Vector Subtract(Vector a, Vector b)
        {
            Vector subtract = new Vector(a);
            subtract.DecreaseBy(b);
            return subtract;
        }

        //////This would only work if the vector was a struct.
        ////public static Vector opertator +(Vector a, Vector b)
        ////{
        ////    return new Vector()
        ////    {
        ////        x = a.x + b.x;
        ////        y = a.y + b.y;
        ////        z = a.z + b.z;
        ////    }
        ////}
        #endregion

        #region Print Methods
        /// <summary>
        /// Converts this vector into a string.
        /// </summary>
        /// <returns>A string of this vector</returns>
        public override string ToString()
        {
            return "(" + this.X + ", " + this.Y + ", " + this.Z + ")";
        }

        /// <summary>
        /// Returns a CSV string of the vector.
        /// </summary>
        public string ToLog()
        {
            return this.X + ", " + this.Y + ", " + this.Z;
        }
        #endregion
    }
}
