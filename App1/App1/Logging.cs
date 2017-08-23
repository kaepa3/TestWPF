using System;
using App1.Interfaces;

namespace App1
{
    public static class Logging
    {
        /// <summary>
        /// ログの実態
        /// </summary>
        static ILog logging = null;
        /// <summary>
        /// ログの初期化
        /// </summary>
        /// <param name="logger"></param>
        public static void Initialize(ILog logger)
        {
            logging = logger;
        }
        /// <summary>
        /// 情報ログの出力
        /// </summary>
        /// <param name="str"></param>
        public static void info(string str)
        {
            logging.Info(str);
        }
        /// <summary>
        /// エラーログの出力
        /// </summary>
        /// <param name="str"></param>
        public static void Error(string str)
        {
            logging.Error(str);
        }

    }
}

