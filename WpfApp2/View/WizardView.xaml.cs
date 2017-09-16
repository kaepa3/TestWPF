using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using App1.ViewModels;

namespace WpfApp2.View
{
    /// <summary>
    /// WizardView.xaml の相互作用ロジック
    /// </summary>
    public partial class WizardView : UserControl
    {
        public WizardView()
        {
            InitializeComponent();
            var vm = this.DataContext as WizardViewViewModel;
            foreach (var i in Enumerable.Range(0, 10))
            {
                Guid g = System.Guid.NewGuid();
                string pass = g.ToString("N").Substring(0, 8);
                vm.ListSource.Add(new App1.Model.WizardSelectModel()
                {
                    WizardIcon = RandomEnumValue(),
                    Text = pass
                });
            }
        }

        static readonly System.Random _Random = new System.Random();
        public static MaterialDesignThemes.Wpf.PackIconKind RandomEnumValue()
        {
            return Enum
                .GetValues(typeof(MaterialDesignThemes.Wpf.PackIconKind))
                .Cast<MaterialDesignThemes.Wpf.PackIconKind>()
                .OrderBy(x => _Random.Next())
                .FirstOrDefault();
        }

    }
}
