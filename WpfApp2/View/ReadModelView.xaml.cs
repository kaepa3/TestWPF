using System.Windows.Controls;
using App1.ViewModels;
using System.Linq;
using System;
namespace WpfApp2.View
{
    /// <summary>
    /// ReadModelView.xaml の相互作用ロジック
    /// </summary>
    public partial class ReadModelView : UserControl
    {
        public ReadModelView()
        {
            InitializeComponent();
            var vm = this.DataContext as ReadModelViewModel;
            foreach (var i in Enumerable.Range(0, 10)) {
                string path = System.IO.Path.GetFullPath(String.Format("result/{0:D2}/base.png", i));
                vm.ListSource.Add(new App1.Model.SaveModelClass()
                {
                    ImagePath = path,
                    MakeTime = DateTime.Now,
                    Infomation = (i + 1).ToString() + "番目"
                });
            }
        }
    }
}
