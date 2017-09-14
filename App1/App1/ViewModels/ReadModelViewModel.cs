using App1.Helpers;
using App1.Model;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace App1.ViewModels
{
    class ReadModelViewModel : PageViewModelBase
    {
        ObservableCollection<SaveModelClass> listSource = new ObservableCollection<SaveModelClass>();
        public ObservableCollection<SaveModelClass> ListSource
        {
            get { return listSource; }
            set { SetProperty(ref listSource, value); }
        }
    }
}
