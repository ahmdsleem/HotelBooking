using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Reservoom.Commands
{
    // class command base and the most important thing that all commands are going to have to do is implement ICommand.
    // I amke it an abstract, so anything that inherits from commandBase will have to implement execute.
    public abstract class CommandBase : ICommand
    {
        // import and implement ICommand interface
        // we do need to raise CanExecuteChanged, to enable submit button
        public event EventHandler CanExecuteChanged;

        // method tell us if the command can execute
        // if it return false : it's mean the button of the view is will be disable
        public virtual bool CanExecute(object? parameter)
        {
            return true;
        }

        public abstract void Execute(object? parameter);
        // what we put here will be executed when the button is clicked,
        // so this method give us a clean way to raise the can execute changed event
        protected void OnCanExecutedChanged()
        {
            CanExecuteChanged?.Invoke(this, new EventArgs());
        }
    }
}
