using System;
using System.Threading;
using System.Windows.Input;
using PaulozziCo.MetroShell.Utilities;

namespace PaulozziCo.MetroShell.Model
{
    public abstract class CommandBase : ICommand
    {
        #region Fields

        private EventHandler canExecuteChanged;

        #endregion

        #region Events

        public event EventHandler CanExecuteChanged
        {
            add
            {
                EventHandler handler2;
                EventHandler canExecuteChanged = this.canExecuteChanged;
                do
                {
                    handler2 = canExecuteChanged;
                    EventHandler handler3 = (EventHandler)Delegate.Combine(handler2, value);
                    canExecuteChanged = Interlocked.CompareExchange<EventHandler>(ref this.canExecuteChanged, handler3, handler2);
                }
                while (canExecuteChanged != handler2);
            }
            remove
            {
                EventHandler handler2;
                EventHandler canExecuteChanged = this.canExecuteChanged;
                do
                {
                    handler2 = canExecuteChanged;
                    EventHandler handler3 = (EventHandler)Delegate.Remove(handler2, value);
                    canExecuteChanged = Interlocked.CompareExchange<EventHandler>(ref this.canExecuteChanged, handler3, handler2);
                }
                while (canExecuteChanged != handler2);
            }
        }

        #endregion

        #region Constructors

        protected CommandBase()
        {
        }

        #endregion

        #region Protected Methods

        protected virtual bool CanExecuteCore(object parameter)
        {
            return true;
        }

        protected abstract void ExecuteCore(object parameter);

        protected void OnCanExecuteChanged()
        {
            if (this.canExecuteChanged != null)
            {
                this.canExecuteChanged(this, EventArgs.Empty);
            }
        }

        #endregion

        #region Private Methods

        bool ICommand.CanExecute(object parameter)
        {
            return this.CanExecuteCore(parameter);
        }

        void ICommand.Execute(object parameter)
        {
            this.ExecuteCore(parameter);
        }

        #endregion

    }

    public abstract class CommandBase<TParameter> : CommandBase
    {
        #region Constructors

        protected CommandBase()
        {
        }

        #endregion

        #region Protected Methods

        protected sealed override bool CanExecuteCore(object parameter)
        {
            Parameter.ThrowIfNotNullAndNotOfType<TParameter>(parameter, "parameter");
            return this.CanExecuteCore((TParameter)parameter);
        }

        protected virtual bool CanExecuteCore(TParameter parameter)
        {
            return base.CanExecuteCore(parameter);
        }

        protected sealed override void ExecuteCore(object parameter)
        {
            Parameter.ThrowIfNotNullAndNotOfType<TParameter>(parameter, "parameter");
            this.ExecuteCore((TParameter)parameter);
        }

        protected abstract void ExecuteCore(TParameter parameter);

        #endregion

    }
}
