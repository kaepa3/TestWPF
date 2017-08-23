using App1.Helpers;
using App1.Model;
using System.Collections.Generic;

namespace App1.ViewModels
{
    class ReadModelViewModel : PageViewModelBase
    {
        List<SaveModelClass> listSource = null;
        public List<SaveModelClass> ListSource
        {
            get { return listSource; }
            set { SetProperty(ref listSource, value); }
        }
    }    
}
