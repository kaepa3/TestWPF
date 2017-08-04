using System;
using App1.Interfaces;

namespace App1
{
	public static class Logging
	{
        static ILog logging= null;
        public static void Initialize(ILog logger)
        {
            logging = logger;
        }
        
        public static void info( string str)
        {
            logging.Info(str);
        }
    }
}

