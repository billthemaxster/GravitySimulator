using SimulatorLogic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulatorLogic.Logic
{
    public static class VectorLogic
    {
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

        public static double Magnitude(Vector vector)
        {
            double sumOfSquares = vector.X * vector.X;
            sumOfSquares += vector.Y * vector.Y;
            sumOfSquares += vector.Z * vector.Z;

            return Math.Sqrt(sumOfSquares);
        }

        public static Vector Unit(Vector vector)
        {
            double magnitude = Magnitude(vector);

            if (magnitude == 0)
            {
                return vector;
            }

            return Scale(vector, 1 / magnitude);
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
