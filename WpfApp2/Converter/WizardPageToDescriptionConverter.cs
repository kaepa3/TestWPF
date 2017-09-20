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
        static Dictionary<WizardPage, string> messageList  = new Dictionary<WizardPage, string>()
        {
            {WizardPage.ReadBaseImage,  "検査の基準になる画像を設定します。"},
            {WizardPage.BasePieceView,  "基準となるピースを選択してください。"},
            {WizardPage.SearchPieceView,  "類似するピースを検索します。"},
        };
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var type= (WizardPage)value ;
            string description = "サポートされていません";
            if (messageList.ContainsKey(type))
            {
                description = messageList[type];
            }
            return description;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Binding.DoNothing;
        }
    }
}
