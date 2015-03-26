using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Simulator.Model
{
    /// <summary>
    /// The exception that is thrown when an error occurs with the gravity simulator.
    /// </summary>
    [Serializable]
    public class GravitySimulatorException : Exception
    {
        #region Constructors
        /// <summary>
        /// Initialises a new instance of the GravitySimulatorException class.
        /// </summary>
        public GravitySimulatorException()
            : base()
        {
        }

        /// <summary>
        /// Initialises a new instance of the GravitySimulatorException class.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        public GravitySimulatorException(string message)
            : base(message)
        {            
        }
        #endregion // Constructors

        /// <summary>
        /// This feature is not implemented.
        /// </summary>
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
        }
    }
}
