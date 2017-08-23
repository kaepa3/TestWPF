using System.Windows;
using App1.Event;
using App1.ViewModels;
namespace WpfApp2
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    { 
        public MainWindow()
        {
            InitializeComponent();
            StartingPage.ViewModel.ChangePageEvent += new ChangePageEventHandler(this.ViewModel.ChangePage);
        }


    }
}
