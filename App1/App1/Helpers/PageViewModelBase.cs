using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;

namespace App1.Helpers
{
    public class PageViewModelBase : ObservableObject
    {
        protected Dictionary<string, PropertyInfo> propCashe = new Dictionary<string, PropertyInfo>();
        protected PropertyInfo GetPropertyInfo(string key)
        {
            PropertyInfo propInfo;
            if (false == propCashe.TryGetValue(key, out propInfo))
            {
                propInfo = this.GetType().GetProperty(key, BindingFlags.Public | BindingFlags.Instance);
                propCashe.Add(key, propInfo);
            }
            return propInfo;
        }
    }
}
