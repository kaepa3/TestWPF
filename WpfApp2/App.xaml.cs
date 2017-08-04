using System.Windows;
using NLog;

namespace WpfApp2
{
    /// <summary>
    /// App.xaml の相互作用ロジック
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {

            //  ログの初期化
            var log = LogManager.GetLogger("app_log");
            App1.Logging.Initialize(new WinlLog(log));
            App1.Logging.info("起動");
        }
    }
}
