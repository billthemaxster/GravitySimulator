using Simulator.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator.Interface.ViewModel
{
    public class ListedCelestialBody
    {
        /// <summary>
        /// Gets the CelestialBody being displayed.
        /// </summary>
        public CelestialBody Body { get; private set; }

        /// <summary>
        /// Gets the name of the listed celestial body.
        /// </summary>
        public string Name
        {
            get
            {
                return this.Body.Name;
            }
        }

        /// <summary>
        /// Initialises a new instance of the ListedCelestialBody class.
        /// </summary>
        /// <param name="body">The body to display in a list</param>
        public ListedCelestialBody(CelestialBody body)
        {
            this.Body = body;
        }

        /// <summary>
        /// Displays the name of the body.
        /// </summary>
        public override string ToString()
        {
            return this.Body.Name;
        }

    }
}
