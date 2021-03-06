﻿
using System.Windows.Input;
using System.Collections.ObjectModel;
using App1.Model;
using App1.Helpers;
using App1.Enums;

namespace App1.ViewModels
{
    public class WizardViewViewModel : PageViewModelBase
    {

        ObservableCollection<WizardSelectModel> listSource = new ObservableCollection<WizardSelectModel>();
        public ObservableCollection<WizardSelectModel> ListSource
        {
            get { return listSource; }
            set { SetProperty(ref listSource, value); }
        }

        
        ICommand beginWizardCommand;
        public ICommand BeginWizardCommand
        {
            get
            {
                return beginWizardCommand = beginWizardCommand ?? new DelegateCommand<WizardSelectModel>(
                (item) => {
                    //  エラーチェック
                    if (item == null)
                        return;

                    var wnd = new WpfApp2.View.Wizard.WizardWindow();
                    var datacontext = new Wizard.WizardWindowViewModel()
                    {
                        WizardIcon = item.WizardIcon,
                        Text = item.Text,
                        PageIndexes = new System.Collections.Generic.List<WizardPage>
                        {
                            WizardPage.ReadBaseImage,
                            WizardPage.BasePieceView,
                            WizardPage.SearchPieceView,
                        },
                        Config = new Model.Wizard.WizardConfig()
                    };
                    datacontext.GoFirstPage();
                    wnd.DataContext = datacontext;
                    wnd.ShowDialog();
                },
                () => { return true; });
            }
        }
    }
}
