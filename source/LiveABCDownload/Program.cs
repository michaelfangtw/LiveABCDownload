using System;
using System.Windows.Forms;
using AsyncAwaitTest;

namespace AsyncAwaitDemo
{
    static class Program
    {
        /// <summary>
        /// 應用程式的主要進入點。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FrmAsyncTest());
        }
    }
}
