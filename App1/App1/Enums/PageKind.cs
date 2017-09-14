using System;
using System.Collections.Generic;
using System.Text;

namespace App1.Enums
{
    public enum PageKind
    {
        Base,
        WizardView,
        ReadModel
    }

    static class PageKindExtension
    {
        // Gender に対する拡張メソッドの定義
        public static string ToKey(this PageKind kind)
        {
            string[] names = { "Base", "WizardView", "ReadModel" };
            return names[(int)kind];
        }
    }
}
