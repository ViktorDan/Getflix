using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace WebAppsMedGithub.Models
{
    public class MyLogger
    {
        private static readonly log4net.ILog log 
            = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public static void LoggDa()
        {
            log.Info("Hello logging world!");
            Console.WriteLine("Hit enter");
            //Console.ReadLine();
        }
    }
}