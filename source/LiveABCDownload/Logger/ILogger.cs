namespace Fun.Logger
{
     public enum LogType
        {
           Info,
           Debug,
           Error
        }

    interface ILogger
    {
        bool Log(LogType logType, string msg);
    }
}
