using System;
using System.Collections.Generic;
using System.Linq;

using System.Globalization;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;
using App1.Enums;
namespace WpfApp2.Converter
{
    public class WizardPageToDescriptionConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var type= (WizardPage)value ;
            string description = "サポートされていません";
            switch (type)
            {
                case WizardPage.ReadBaseImage:
                    description = "検査の基準になる画像を設定します。";
                    break;
                case WizardPage.SearchPieceView:
                    description = "基準となるピースを選択してください";
                    break;
                default:
                    break;
            }
            return description;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Binding.DoNothing;
        }
    }
}
