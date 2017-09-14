using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using App1.Helpers;
using App1.Enums;
using WpfApp2;

namespace App1.ViewModels
{
    public class StartingViewModel : PageViewModelBase
    {
        public event ChangePageEventHandler ChangePageEvent;
        ICommand modelStartCommand;
        public ICommand ModelStartCommand
        {
            get
            {
                return modelStartCommand = modelStartCommand ?? new DelegateCommand<PageKind>(
                (page) => {
                    ChangePageEvent?.Invoke(this, new Event.ChangePageEventArgs(page));
                },
                () => { return true; });
            }
        }
        
        ICommand newStartCommand;
        public ICommand NewStartCommand
        {
            get
            {
                return newStartCommand = newStartCommand ?? new DelegateCommand<PageKind>(
                (page) => {
                    ChangePageEvent?.Invoke(this, new Event.ChangePageEventArgs(page));
                },
                () => { return true; });
            }
        }

    }
}
