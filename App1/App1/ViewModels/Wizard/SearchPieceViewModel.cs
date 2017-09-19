using System;
using System.Collections.Generic;
using System.Text;
using App1.Helpers;
using Controls.ViewModel;

namespace App1.ViewModels.Wizard
{
    public class SearchPieceViewModel :ObservableObject
    {

        ImageViewerViewModel viewSource = new ImageViewerViewModel();
        public ImageViewerViewModel ViewSource
        {
            get { return viewSource; }
            set { SetProperty(ref viewSource, value); }
        }
    }
}
