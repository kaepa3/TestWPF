using System;
using System.Collections.Generic;
using System.Text;
using App1.Helpers;
using App1.Enums;
namespace App1.Model
{
    public class WizardSelectPage : ObservableObject
    {
        object content;
        public object Content
        {
            get { return content; }
            set { SetProperty(ref content, value); }
        }

        WizardPage page;

        public WizardPage Page
        {
            get { return page; }
            set { SetProperty(ref page, value); }
        }

    }
}
