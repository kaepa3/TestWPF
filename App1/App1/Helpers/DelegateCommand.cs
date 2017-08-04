using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
namespace App1.Helpers
{
    public class DelegateCommand : ICommand
    {
        System.Action execute;
        System.Func<bool> canExecute;

        public bool CanExecute(object parameter)
        {
            return canExecute();
        }

        public event System.EventHandler CanExecuteChanged;
        public void Execute(object parameter)
        {
            execute();
        }

        public DelegateCommand(System.Action execute, System.Func<bool> canExecute)
        {
            this.execute = execute;
            this.canExecute = canExecute;
        }
    }
}
