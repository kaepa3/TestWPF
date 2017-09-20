using System;
using System.Collections.Generic;
using System.Text;
using App1.Helpers;
using Controls.ViewModel;
using System.Windows.Input;
using System.Windows;

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

        ICommand searchPieceCommand;
        /// <summary>
        /// 基準ピース検索のコマンド
        /// </summary>
        public ICommand SearchPieceCommand
        {
            get
            {
                return searchPieceCommand = searchPieceCommand ?? new DelegateCommand(
                () =>
                {
                    List<Rect> rectList = new List<Rect>()
                    {
                        new Rect(430, 90, 420, 820),
                        new Rect(900, 90, 420, 820),
                        new Rect(1370, 90, 420, 820),
                        new Rect(430, 915, 420, 820),
                        new Rect(900, 915, 420, 820),
                        new Rect(1370, 915, 420, 820),
                        new Rect(430, 1730, 420, 820),
                        new Rect(900, 1730, 420, 820),
                        new Rect(1370, 1730, 420, 820)
                    };
                    foreach (var v in rectList)
                    {
                        var marker = new Controls.ViewModel.Markers.ResizeMarkerVM(v);
                        ViewSource.Markers.Add(marker);
                    }
                },
                () => { return true; });
            }
        }
    }
}
