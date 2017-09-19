using System;
using System.Collections.Generic;
using System.Text;
using WpfApp2.View.Wizard;
using System.Windows.Media;

namespace App1.Model.Wizard
{
    public class WizardConfig
    {
        public ImageSource MaterImage{ get; set; }



        public void SaveConfig(WizardSelectPage content)
        {
            switch (content.Page)
            {
                case Enums.WizardPage.ReadBaseImage:
                    UpdateReadBaseImage((ReadBaseImage)content.Content);
                    break;

                default:
                    Logging.info("設定なしエラー:" + content.Page.ToString());
                    break;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="page"></param>
        void UpdateReadBaseImage(ReadBaseImage view)
        {
            var data = view.DataContext as ViewModels.Wizard.ReadBaseImageViewModel;
            this.MaterImage = data.ViewSource.ViewImage;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="content"></param>
        public void CreateConfig(WizardSelectPage content)
        {
            switch (content.Page)
            {
                case Enums.WizardPage.ReadBaseImage:
                    CreateReadBaseImage((ReadBaseImage)content.Content);
                    break;
                case Enums.WizardPage.SearchPieceView:
                    CreateSearchPieceView((SearchPieceView)content.Content);

                    break;

                default:
                    Logging.info("設定なしエラー:" + content.Page.ToString());
                    break;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="view"></param>
        void CreateReadBaseImage(ReadBaseImage view)
        {
            var data = view.DataContext as ViewModels.Wizard.ReadBaseImageViewModel;
            if (this.MaterImage != null)
            {
                data.ViewSource.ViewImage = this.MaterImage;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        void CreateSearchPieceView(SearchPieceView view)
        {
            var data = view.DataContext as ViewModels.Wizard.SearchPieceViewModel;
            if (this.MaterImage != null)
            {
                data.ViewSource.ViewImage = this.MaterImage;
            }

        }
    }
}
