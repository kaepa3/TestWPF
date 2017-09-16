using System;
using System.Collections.Generic;
using System.Text;
using App1.Helpers;
using App1.Model;
using MaterialDesignThemes.Wpf;
using System.Windows.Input;
using App1.Enums;
using System.Collections.ObjectModel;
namespace App1.ViewModels.Wizard
{
    public class WizardWindowViewModel : ObservableObject
    {
        public WizardWindowViewModel()
        {
            ListSource = new List<WizardSelectPage>()
            {
                {
                    new WizardSelectPage{
                        Page = WizardPage.ReadBaseImage,
                        Content = new WpfApp2.View.Wizard.ReadBaseImage(){ DataContext = new ReadBaseImageViewModel()}
                    }
                }
            };
        }


        List<WizardSelectPage> listSource = new List<WizardSelectPage>();
        public List<WizardSelectPage> ListSource
        {
            get { return listSource; }
            set { SetProperty(ref listSource, value); }
        }


        PackIconKind wizardIcon;
        public PackIconKind WizardIcon
        {
            get { return wizardIcon; }
            set
            {
                SetProperty(ref wizardIcon, value);
            }
        }

        string text;
        public string Text
        {
            get { return text; }
            set
            {
                SetProperty(ref text, value);
            }
        }

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
            set
            {
                foreach (var v in ListSource)
                {
                    if (v.Page == page)
                    {
                        Content = v.Content;
                        break;
                    }
                }
                SetProperty(ref page, value);
            }
        }

    }
}
