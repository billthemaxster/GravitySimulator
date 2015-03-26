using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator.Model
{
    /// <summary>
    /// Event Arguments for a simulator error.
    /// </summary>
    public class SimulatorErrorEventArgs : EventArgs
    {
        /// <summary>
        /// Gets or sets the errors of this event.
        /// </summary>
        public Dictionary<string, string> Errors { get; set; }

        /// <summary>
        /// Initialises a new instance of the SimulatorErrorEventArgs class.
        /// </summary>
        public SimulatorErrorEventArgs(Dictionary<string, string> errors)
        {
            this.Errors = errors;
        }
    }
}
