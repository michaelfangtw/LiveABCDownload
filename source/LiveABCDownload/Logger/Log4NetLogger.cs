using System;
using System.IO;
using log4net;
using log4net.Config;

namespace Fun.Logger
{
    public class Log4NetLogger:ILogger
    {
        static ILog log_info;
        static ILog log_error;
        public string  ConfigPath { get; set;}

        public Log4NetLogger (string log4NetConfigPath)
	    {
            ConfigPath = log4NetConfigPath;
            if (!File.Exists(ConfigPath)){
                throw new Exception(string.Format("Log4NetConfigPath not found!,ConfigPath={0}", ConfigPath));
            }
	    }

    
        public bool Log(LogType logType, string msg)
        {
            FileInfo f = new FileInfo(ConfigPath);
            try{          
                XmlConfigurator.Configure(f);
                switch (logType)
                {
                    case LogType.Error:
                        log_error = LogManager.GetLogger("logger_error");
                        log_error.Error(msg);
                        break;
                    case LogType.Info:
                        log_info = LogManager.GetLogger("logger");
                        log_info.Info(msg);
                        break;
                    case LogType.Debug:
                        log_info = LogManager.GetLogger("logger");
                        log_info.Debug(msg);
                        break;
                    default:
                        log_info = LogManager.GetLogger("logger");
                        log_info.Info(msg);
                        break;
                }
                    return true;
            }catch (Exception ex){
                throw new Exception(string.Format("Log,error={0}", ex.Message));
            }finally{            
                GC.Collect();
            }
        }


      
    }
    }

