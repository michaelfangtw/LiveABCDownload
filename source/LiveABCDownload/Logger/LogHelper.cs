/*
 * 名稱:Logger.cs
 * 說明:處理log,區分err,info...
 * 日期         作者            版本      說明
 * 2015.07.08   MichaelFang     1.0 
 */

using System.Windows.Forms;

namespace Fun.Logger
{
    /// <summary>
    /// Logger 的摘要描述
    /// </summary>
    public class LogHelper
    {
         ILogger Logger { get; set; }
        
        public LogHelper(string log4NetConfig)
        {
            ILogger logger = new Log4NetLogger(log4NetConfig);
            //使用屬性注入logger
            //必要時可替換logger
            Logger = logger;            
        }

        public LogHelper(ref TextBox textBox)
        {
            ILogger logger = new WindowLogger(ref textBox);
            //使用屬性注入logger
            //必要時可替換logger
            Logger = logger;

        }
        public bool Log(LogType logType, string msg)
        {
            return Logger.Log(logType, msg);
        }
      
    }
}