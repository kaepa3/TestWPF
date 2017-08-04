using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLog;
using NLog.Config;
using App1;
namespace WpfApp2
{
    public class WinlLog : App1.Interfaces.ILog
    {
        private NLog.Logger log;
        public WinlLog( NLog.Logger logger)
        {
            log = logger;
        }
        public void Info(string str)
        {
            log.Info(str);
        }
    }

}
