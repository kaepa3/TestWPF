using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLog;
using NLog.Config;
using App1;
using System.Reflection;
using System.Diagnostics;

namespace WpfApp2
{
    public class WinLog : App1.Interfaces.ILog
    {
        private NLog.Logger log;
        public WinLog( NLog.Logger logger)
        {
            log = logger;
        }
        public void Info(string str)
        {
            log.Info(str);
        }
        public void Error(string str)
        {
            log.Error(AddCallString(str));
        }

        /// <summary>
        /// 呼び出し元メソッドの取得
        /// </summary>
        /// <param name="logtext"></param>
        /// <returns></returns>
        private static string AddCallString(string logtext)
        {
            try
            {
                StackFrame callerFrame = new StackFrame(2);
                if (callerFrame != null)
                {
                    MethodBase callerMethod = callerFrame.GetMethod();
                    if (callerMethod != null)
                    {
                        logtext += "\tclass:" + callerMethod.DeclaringType.Name + "\tmethod:" + callerMethod;
                    }
                }
            }
            catch (Exception)
            {
                //何もしない
            }
            return logtext;
        }
    }

}
