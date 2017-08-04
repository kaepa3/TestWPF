using System;
using System.Windows;
using System.Windows.Input;


namespace App1.Commands
{
    class SuperCommand :  ICommand
    {
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public event EventHandler CanExecuteChanged;
        public void Execute(object parameter)
        {
            var text  =parameter as string;
            if(!string.IsNullOrEmpty(text))
            {
                text = "dekita";
            }
        }
     
    }

}
