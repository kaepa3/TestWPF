using System.Windows;
using NLog;
using System.Threading.Tasks;
using System;
using System.Linq;
using WpfApp2.View;

namespace WpfApp2
{
    /// <summary>
    /// App.xaml の相互作用ロジック
    /// </summary>
    public partial class App : Application
    {
        protected override async void OnStartup(StartupEventArgs e)
        {
        
            //  ログの初期化
            var log = LogManager.GetLogger("app_log");
            App1.Logging.Initialize(new WinLog(log));
            App1.Logging.info("起動");
            Splash wnd = new Splash();
            wnd.Show();
            await RunTaskSync();
            wnd.Close();
            base.OnStartup(e);
        }

        public Task RunTaskSync()
        {
            return Task.Run(() => RunInitial());
        }

        public void RunInitial()
        {
            System.Threading.Thread.Sleep(500);
            var lang = new Language.Language();
            lang.SetLanguage("ja-jp", this);
            return;
        }

    }
}
