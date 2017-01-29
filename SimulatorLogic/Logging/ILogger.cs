using SimulatorLogic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulatorLogic.Logging
{
    interface ILogger : IDisposable
    {
        Task LogAsync(List<CelestialBody> bodies, double timeElapsed);
        void Log(List<CelestialBody> bodies, double timeElapsed);
    }
}
