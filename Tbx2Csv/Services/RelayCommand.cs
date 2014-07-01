namespace Tbx2Csv.Services
{
    using System;
    using System.Diagnostics;
    using System.Windows.Input;

    public class RelayCommand : ICommand
    {
        #region const and fields
        /// <summary>
        ///     Feld Execute
        /// </summary>
        private readonly Action<object> m_execute;

        /// <summary>
        ///     Feld CanExecute
        /// </summary>
        private readonly Predicate<object> m_canExecute;
        #endregion

        #region ctor

        /// <summary>
        ///     Ctor
        /// </summary>
        /// <param name="execute">execute</param>
        public RelayCommand(Action<object> execute) : this(execute, null)
        {
        }

        /// <summary>
        ///     Ctor 
        /// </summary>
        /// <param name="execute">execute</param>
        /// <param name="canExecute">canExecute</param>
        public RelayCommand(Action<object> execute, Predicate<object> canExecute)
        {
            if (execute == null)
            {
                throw new ArgumentException("execute");
            }

            this.m_execute = execute;
            this.m_canExecute = canExecute;
        }
        #endregion

        #region public members

        /// <summary>
        ///     CanExecute
        /// </summary>
        /// <param name="parameter">Parameter</param>
        /// <returns>true/false can execute</returns>
        [DebuggerStepThrough]
        public bool CanExecute(object parameter)
        {
            return this.m_canExecute == null ? true : this.m_canExecute(parameter);
        }

        /// <summary>
        ///     CanExecuteChanged
        /// </summary>
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        /// <summary>
        ///     Execute
        /// </summary>
        /// <param name="parameter">Parameter</param>
        public void Execute(object parameter)
        {
            this.m_execute(parameter);
        }

        #endregion
    }
}
