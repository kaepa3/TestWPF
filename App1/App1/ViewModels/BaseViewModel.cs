using App1.Helpers;
using App1.Enums;
using App1.Event;
using System.Windows;
using System;
using System.Reflection;
using System.Collections.Generic;

namespace App1.ViewModels
{

    public delegate void ChangePageEventHandler(object sender, ChangePageEventArgs e);
    public class BaseViewModel : PageViewModelBase
    {
        readonly string VisiblePlefix = "_Visible";
        /// <summary>
        /// プロパティのキャッシュ（画面表示専用）
        /// </summary>

        public void ChangePage(object sender, ChangePageEventArgs args)
        {
            if (sender == null)
            {
                Logging.Error("Event null");
                return;
            }
            var propBefore= GetNowVisible();
            var propNext = GetPropertyInfo(CreateVisibleParam(args.NextPage));
            if (propBefore != null)
                propBefore.SetValue(this, Visibility.Hidden);
            if (propNext != null)
                propNext.SetValue(this, Visibility.Visible);
        }
        string CreateVisibleParam(PageKind kind)
        {
            return kind.ToKey() + VisiblePlefix;
        }
        PropertyInfo GetNowVisible()
        {
            PropertyInfo info  = null;
            foreach (PageKind v in Enum.GetValues(typeof(PageKind)))
            {
                var prop = GetPropertyInfo(CreateVisibleParam(v));
                if ((Visibility)prop.GetValue(this) == Visibility.Visible)
                {
                    info = prop;
                }
                break;
            }
            return info;
        }


        Visibility base_Visible = Visibility.Visible;
        public Visibility Base_Visible
        {
            get { return base_Visible; }
            set { SetProperty(ref base_Visible, value); }
        }

        Visibility readModel_Visible = Visibility.Collapsed;
        public Visibility ReadModel_Visible
        {
            get { return readModel_Visible; }
            set { SetProperty(ref readModel_Visible, value); }
        }

    }
}
