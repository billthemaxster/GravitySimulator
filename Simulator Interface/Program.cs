using System;
using System.Windows.Forms;

namespace Simulator.Interface
{
    /// <summary>
    /// The launch point for the gravity simulator application.
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        public static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainSimulatorInterfaceForm());
        }
    }
}
