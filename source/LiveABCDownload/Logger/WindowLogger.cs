using System;
using System.Windows.Forms;

namespace Fun.Logger
{
    class WindowLogger:ILogger
    {
        public TextBox textBox { get; set; }
        public WindowLogger(ref TextBox textBox)
        {
            this.textBox = textBox;
        }



        public bool Log(LogType logType, string msg)
        {
            textBox.Text = string.Format("{1}\t[{2}]\t{3}\t\r\n{0}\r\n", textBox.Text, DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"), logType.ToString().ToUpper(), msg);
            return true;
        }
    }
}
