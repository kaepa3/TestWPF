using System;
using System.Collections.Generic;
using App1.Helpers;
using App1.Model;
using MaterialDesignThemes.Wpf;
using System.Windows.Input;
using App1.Enums;
using App1.Model.Wizard;
namespace App1.ViewModels.Wizard
{
    public class WizardWindowViewModel : ObservableObject
    {
        /// <summary>
        /// 
        /// </summary>
        public WizardWindowViewModel()
        {
            PageSource = new List<WizardSelectPage>()
            {
                {
                    new WizardSelectPage{
                        Page = WizardPage.ReadBaseImage,
                        Content = new WpfApp2.View.Wizard.ReadBaseImage(){ DataContext = new ReadBaseImageViewModel()}
                    }
                },
                {
                    new WizardSelectPage{
                        Page = WizardPage.BasePieceView,
                        Content = new WpfApp2.View.Wizard.BasePieceView(){ DataContext = new BasePieceViewModel()}
                    }
                },
                {
                    new WizardSelectPage{
                        Page = WizardPage.SearchPieceView,
                        Content = new WpfApp2.View.Wizard.SearchPieceView(){ DataContext = new SearchPieceViewModel()}
                    }
                }
            };
        }
        List<WizardSelectPage> pageSource = new List<WizardSelectPage>();
        /// <summary>
        /// 
        /// </summary>
        public List<WizardSelectPage> PageSource
        {
            get { return pageSource; }
            set { SetProperty(ref pageSource, value); }
        }
        PackIconKind wizardIcon;
        /// <summary>
        /// 
        /// </summary>
        public PackIconKind WizardIcon
        {
            get { return wizardIcon; }
            set
            {
                SetProperty(ref wizardIcon, value);
            }
        }

        string text;
        /// <summary>
        /// 
        /// </summary>
        public string Text
        {
            get { return text; }
            set
            {
                SetProperty(ref text, value);
            }
        }

        WizardSelectPage pageContent;
        /// <summary>
        /// 
        /// </summary>
        public WizardSelectPage PageContent
        {
            get { return pageContent; }
            set { SetProperty(ref pageContent, value); }
        }

        List<WizardPage> pageIndexes = new List<WizardPage>();
        /// <summary>
        /// 
        /// </summary>
        public List<WizardPage> PageIndexes
        {
            get { return pageIndexes; }
            set { SetProperty(ref pageIndexes, value); }
        }
        WizardConfig config;
        /// <summary>
        /// 
        /// </summary>
        public WizardConfig Config
        {
            get { return config; }
            set { config = value; }
        }

        ICommand moveNextCommand;
        /// <summary>
        /// 次へのコマンド
        /// </summary>
        public ICommand MoveNextCommand
        {
            get
            {
                return moveNextCommand = moveNextCommand ?? new DelegateCommand(
                () =>
                {
                    ChangePage(() => { return GetNextPage(); });
                },
                () => { return true; });
            }
        }

        ICommand moveBeforeCommand;
        /// <summary>
        /// 次へのコマンド
        /// </summary>
        public ICommand MoveBeforeCommand
        {
            get
            {
                return moveBeforeCommand = moveBeforeCommand ?? new DelegateCommand(
                () =>
                {
                    ChangePage(() => { return GetBeforePage(); });
                },
                () => { return true; });
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        WizardPage GetNextPage()
        {
            var nextPage = WizardPage.Non;
            bool getFlg = false;

            foreach (var v in PageIndexes)
            {
                if (getFlg)
                {
                    nextPage = v;
                    break;
                }
                else if (v == PageContent.Page)
                {
                    getFlg = true;
                }
            }
            return nextPage;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        WizardPage GetBeforePage()
        {
            var beforePage = WizardPage.Non;
            var buffer = WizardPage.Non;

            foreach (var v in PageIndexes)
            {
                if (v == PageContent.Page)
                {
                    beforePage = buffer;
                    break;
                }
                buffer = v;
            }
            return beforePage;
        }

        WizardSelectPage GetPageContent(WizardPage page)
        {
            foreach (var v in PageSource)
            {
                if (page == v.Page)
                {
                    return v;
                }
            }
            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        public void GoFirstPage()
        {
            if (PageIndexes.Count != 0)
            {
                ChangePage(() => { return PageIndexes[0]; });
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="nextPageAction"></param>
        void ChangePage(Func<WizardPage> nextPageAction)
        {
            var page = GetPageContent(nextPageAction());
            if (page != null)
            {
                if (PageContent != null)
                {
                    config.SaveConfig(PageContent);
                }
                config.CreateConfig(page);
                PageContent = page;
            }

        }
    }
}
