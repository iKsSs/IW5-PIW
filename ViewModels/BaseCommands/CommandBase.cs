using System;
using System.Windows.Input;

namespace ViewModels.BaseCommands
{
    public abstract class CommandBase : ICommand
    {

        public virtual bool CanExecute(object parameter)
        {
            return true;
        }

        public abstract void Execute(object parameter);

        public event EventHandler CanExecuteChanged;
    }
}
