using System;
using System.Collections.Generic;
using System;
using System.Linq;
using System.Windows;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp2.Language
{
    public class Language
    {
        public void SetLanguage(string cultureCode, App app)
        {
            SetLanguage(cultureCode, app.Resources);
        }


        public void SetLanguage(string cultureCode, ResourceDictionary dic)
        {
            var dictionary = new ResourceDictionary();
            dictionary.Source = new Uri(@"/Localization;component/Resources/Resource." + cultureCode + ".xaml", UriKind.Relative);
            var num = dic.MergedDictionaries.Where(x => x.Source == dictionary.Source).Count();
            //  重複の削除
            int i = 0;
            while (i < dic.MergedDictionaries.Count)
            {
                if (dic.MergedDictionaries[i].Source.OriginalString == dictionary.Source.OriginalString)
                {
                    dic.MergedDictionaries.RemoveAt(i);
                }
                else
                {
                    i++;
                }
            }
            dic.MergedDictionaries.Add(dictionary);
        }
    }
}
