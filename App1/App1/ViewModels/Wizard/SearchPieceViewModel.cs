using System;
using System.Collections.Generic;
using System.Text;
using App1.Helpers;
using Controls.ViewModel;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Controls;

namespace App1.ViewModels.Wizard
{
    public class SearchPieceViewModel : ObservableObject
    {

        ImageViewerViewModel viewSource = new ImageViewerViewModel();
        public ImageViewerViewModel ViewSource
        {
            get { return viewSource; }
            set { SetProperty(ref viewSource, value); }
        }

        ICommand searchBasePieceCommand;
        /// <summary>
        /// 基準ピース検索のコマンド
        /// </summary>
        public ICommand SearchBasePieceCommand
        {
            get
            {
                return searchBasePieceCommand = searchBasePieceCommand ?? new DelegateCommand(
                () =>
                {

                    var marker = new Controls.ViewModel.Markers.ResizeMarkerVM();
                    marker.Geom = new RectangleGeometry(new System.Windows.Rect(0, 0, 100, 100));
                    ViewSource.Markers.Add(marker);
                },
                () => { return true; });
            }
        }
    }
}
