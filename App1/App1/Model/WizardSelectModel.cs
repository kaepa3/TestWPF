using MaterialDesignThemes.Wpf;
using App1.Helpers;

namespace App1.Model
{
    public class WizardSelectModel : ObservableObject
    {
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
    }
}
