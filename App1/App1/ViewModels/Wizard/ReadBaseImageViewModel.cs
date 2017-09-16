using System;
using System.Windows.Input;
using System.Text;
using App1.Helpers;
using Controls.ViewModel;
using System.Windows.Media.Imaging;
using System.Windows.Media;
using System.Windows.Controls;

namespace App1.ViewModels.Wizard
{
    public class ReadBaseImageViewModel : ObservableObject
    {
        ICommand readImageCommand;
        public ICommand ReadImageCommand
        {
            get
            {
                return readImageCommand = readImageCommand ?? new DelegateCommand(
                () =>
                {
                    var bmpImage = new BitmapImage();
                    bmpImage.BeginInit();
                    bmpImage.CacheOption = BitmapCacheOption.OnLoad;
                    bmpImage.CreateOptions = BitmapCreateOptions.None;
                    bmpImage.UriSource = new Uri("Image/Model.png", UriKind.Relative);
                    bmpImage.EndInit();
                    bmpImage.Freeze();
                    ViewSource.ViewImage = bmpImage;

                },
                () => { return true; });
            }
        }
        ImageViewerViewModel viewSource = new ImageViewerViewModel();
        public ImageViewerViewModel ViewSource
        {
            get { return viewSource; }
            set { SetProperty(ref viewSource, value); }
        }
    }
}
