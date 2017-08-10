using System.Windows;
using NLog;
using System.Threading.Tasks;

namespace WpfApp2
{
    /// <summary>
    /// App.xaml の相互作用ロジック
    /// </summary>
    public partial class App : Application
    {
        private async void Application_Startup(object sender, StartupEventArgs e)
        {
            //  ログの初期化
            var log = LogManager.GetLogger("app_log");
            App1.Logging.Initialize(new WinlLog(log));
            App1.Logging.info("起動");
            var mainWindow = new MainWindow(); //←起動したい画面クラス名
            Splash wnd = new Splash();
            wnd.Show();
            var result = await RunTaskSync(wnd);
            wnd.Close();
            mainWindow.Show();
        }

        public Task<string> RunTaskSync(Splash wnd)
        {
            return Task.Run<string>(() => Run(wnd));
        }

        public string Run(Splash wnd)
        {
            System.Threading.Thread.Sleep(1000);
            return "kido";
        }
    }
}
