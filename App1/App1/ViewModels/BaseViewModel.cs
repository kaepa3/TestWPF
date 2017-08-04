using App1.Helpers;
using App1.Commands;
using System.Windows.Input;
namespace App1.ViewModels
{
    public class BaseViewModel : ObservableObject
    {
        /// <summary>
        /// Private backing field to hold the title
        /// </summary>
        string title = "nanzansy";
        /// <summary>
        /// Public property to set and get the title of the item
        /// </summary>
        public string Title
        {
            get { return title; }
            set { SetProperty(ref title, value); }
        }

        private ICommand okclickCommand;
        public ICommand OkclickCommand
        {
            get { return okclickCommand = okclickCommand ?? new DelegateCommand(() => Title = "yokudekita", () => { return true; }); }
        }
    }
}
