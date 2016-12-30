using System;
using System.Collections.Generic;
using System.Text;

//[assembly: log4net.Config.XmlConfigurator(Watch = true)]
 
   public class LogHelper
    {
        public static void SetConfig()
        {
            log4net.Config.XmlConfigurator.Configure();
        }

        /// <summary>
        /// 输出日志到Log4Net
        /// </summary>
        /// <param name="t"></param>
        /// <param name="ex"></param>
        #region static void WriteLog(Type t, Exception ex)

        public static void WriteLog(Type t, Exception ex)
        {
            log4net.ILog log = log4net.LogManager.GetLogger(t);
            log.Error("Error", ex);
        }

 

        #endregion

        /// <summary>
        /// 输出日志到Log4Net
        /// </summary>
        /// <param name="t"></param>
        /// <param name="msg"></param>
        #region static void WriteLog( string msg)

        public static void WriteLog(string msg)
        {
            log4net.ILog log = log4net.LogManager.GetLogger("OA");
            log.Info(Environment.NewLine + msg);
        }

        #endregion


    }
 