/*=============================================================================
 * Contains the DelegateCommand class, stores delegates to use on command.
 *  
 * Version: 0.2.0
 * Author: Martin Kennish
 * Date: 2014-11-04
 * 
 ============================================================================*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Simulator.Model
{
    public class DelegateCommand : ICommand
    {
        #region Properties
        /// <summary>
        /// Whether the command can be executed.
        /// </summary>
        private readonly Func<bool> _CanExecute;

        /// <summary>
        /// The command to execute.
        /// </summary>
        private readonly Action _Execute;
        #endregion

        #region Constructors
        /// <summary>
        /// Initialises a new instance of the DelegateCommand class, sets the
        /// execute command, it is always executable.
        /// </summary>
        /// <param name="execute">The command to execute</param>
        public DelegateCommand(Action execute)
            : this(execute, null)
        {
        }

        /// <summary>
        /// Initialises a new instance of the DelegateCommand class.
        /// </summary>
        /// <param name="execute">The command to execute</param>
        /// <param name="canExecute">Whether the command can be executed</param>
        public DelegateCommand(Action execute, Func<bool> canExecute)
        {
            this._Execute = execute;
            this._CanExecute = canExecute;
        }
        #endregion

        #region Executions
        /// <summary>
        /// Checks whether the command can be executed.
        /// </summary>
        public bool CanExecute(object parameter)
        {
            if (this._CanExecute != null)
            {
                return this._CanExecute();
            }

            return true;
        }

        /// <summary>
        /// Executes the command.
        /// </summary>
        public void Execute(object parameter)
        {
            this._Execute();
        }
        #endregion

        private List<EventHandler> _CanExecuteChanged = new List<EventHandler>();

        public event EventHandler CanExecuteChanged
        {
            add
            {
                _CanExecuteChanged.Add(value);
                CommandManager.RequerySuggested += value;
            }
            remove
            {
                _CanExecuteChanged.Remove(value);
                CommandManager.RequerySuggested -= value;
            }
        }
    }
}
