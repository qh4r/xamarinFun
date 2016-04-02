using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace App1.Helpers
{
    public sealed class RelayCommand<T> : ICommand where T : class
    {
        #region fields
        readonly Predicate<object> canExecute;
        readonly Action<T> execute;
        #endregion fields

        #region constructors
        public RelayCommand(Action<T> execute) : this(execute, null) { }

        public RelayCommand(Action<T> execute, Predicate<object> canExecute)
        {
            this.execute = execute;
            this.canExecute = canExecute;
        }

        #endregion constructors

        #region methods
        internal void RaiseCanExecuteChanged()
        {
            this.CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }

        #endregion methods

        #region ICommand events
        public event EventHandler CanExecuteChanged;
        #endregion ICommand events

        #region ICommand methods
        public bool CanExecute(object parameter)
        {
            return this.canExecute?.Invoke(parameter) ?? true;
        }

        public void Execute(object parameter)
        {
            this.execute?.Invoke(parameter as T);
        }

        #endregion ICommand methods
    }

    public sealed class RelayCommand : ICommand
    {
        #region fields
        readonly Predicate<object> canExecute;
        readonly Action execute;
        #endregion fields

        #region constructors
        public RelayCommand(Action execute) : this(execute, null) { }

        public RelayCommand(Action execute, Predicate<object> canExecute)
        {
            this.execute = execute;
            this.canExecute = canExecute;
        }

        #endregion constructors

        #region methods
        internal void RaiseCanExecuteChanged()
        {
            this.CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }

        #endregion methods

        #region ICommand events
        public event EventHandler CanExecuteChanged;
        #endregion ICommand events

        #region ICommand methods
        public bool CanExecute(object parameter)
        {
            return this.canExecute?.Invoke(parameter) ?? true;
        }

        public void Execute(object parameter)
        {
            this.execute?.Invoke();
        }

        #endregion ICommand methods
    }
}
