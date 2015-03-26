/*=============================================================================
 * Contains the ListExtensions class, provides extension methods for the generic
 * list class.
 *  
 * Version: 0.1.0
 * Author: Martin Kennish
 * Date: 2014-10-16
 * 
 ============================================================================*/
using System.Collections.Generic;

namespace Simulator.Model
{
    /// <summary>
    /// Extension methods for the List generic class.
    /// </summary>
    public static class ListExtensions
    {
        /// <summary>
        /// Creates an log output string for a list of celestial bodies.
        /// </summary>
        /// <param name="bodies">The list of celestial bodies to log</param>
        /// <returns>A CSV output string of the list of bodies.</returns>
        public static string ToLog(this List<CelestialBody> bodies)
        {
            string output = string.Empty;

            foreach (CelestialBody body in bodies)
            {
                output += body.ToLog() + ",";
            }

            return output;
        }
    }
}
