/*
********************************************************
功能:LiveABCAsyncDownload
說明:LiveABC下載類別
********************************************************
日期          作者       說明
2015.07.26    fij       初版
2015.07.26    fij       async,await 進行檔案下載
                        event,delegate 讓form1,可顯示進度
********************************************************
*/

using Fun.Logger;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Net;

namespace LiveABCDownload
{
    /// <summary>
    /// LiveABCMp3List
    /// </summary>
    /// 

    
    //event-1:建立委派EventHandler
    public delegate void ProgressChangedEventHandler(DownloadProgressChangedEventArgs e);

    public delegate void WindowLoggerEventHandler(string msg);
    public delegate void WindowResultLoggerEventHandler(string msg);


    public class DownloadFile
    {
        //event-2:宣告委派變數=相同簽名的方法
        public event ProgressChangedEventHandler OnProgressChanged;

        //log
        public event WindowLoggerEventHandler OnWindowLogger;
        public event WindowResultLoggerEventHandler OnWindowResultLogger;

        LogHelper _logHelper;
        public DownloadFile()
        {
            _logHelper = new LogHelper(Log4NetConfigPath);
        }
        private string Log4NetConfigPath
        {
            get { return ConfigurationManager.AppSettings["Log4NetConfigPath"]; }
        }
        private string DownloadPath
        {
            get { return ConfigurationManager.AppSettings["DownloadPath"]; }
        }

        public void DownloadSync(DateTime baseMonth, string folder,int pageCount,string downloadUrlKey)
        {
            //get the downloadlist with LiveABCDownloadList
            var yyyymm = baseMonth.ToString("yyyyMM");

            DownloadListBase downloadListBase = new DownloadListBase();            
            IEnumerable<string> downloadList = downloadListBase.Get(yyyymm, pageCount, downloadUrlKey);

            var total = 0;
            var fail = 0;
            var success = 0;
            var sw = new Stopwatch();
            sw.Start();

            foreach (var downloadUrl in downloadList)
            {
                var downloadPath = Path.Combine(DownloadPath, yyyymm, folder);
                if (!Directory.Exists(downloadPath)) Directory.CreateDirectory(downloadPath);
                var fileName = Path.GetFileName(new Uri(downloadUrl).LocalPath);
                try
                {
                    var client = new WebClient();
                    client.Headers.Add("User-Agent: IE");
                    client.DownloadFile(new Uri(downloadUrl), Path.Combine(downloadPath, fileName));
                    success++;
                    Mylogger(LogType.Info, string.Format("{0},url={1},OK", folder, downloadUrl));
                }
                catch (Exception ex)
                {
                    fail++;
                    Mylogger(LogType.Error, string.Format("{0},url={1},錯誤:{2}", folder, downloadUrl, ex.Message));
                }
                total++;
            }
            Mylogger(LogType.Info, string.Format("{0},total:{1},success:{2},fail:{3}", folder, total, success, fail));

            sw.Stop();
            var elapsed = sw.Elapsed;
            Mylogger(LogType.Info, string.Format("{0},共費時:{1}", folder, elapsed));

        }

        ////event-3.定義
        //protected virtual void ProgressChanged(DownloadProgressChangedEventArgs e) 
        //{
        //    if (OnProgressChanged != null)
        //    { 
        //        OnProgressChanged(e);
        //    }
        //}

        /// <summary>
        /// 非同步下載
        /// </summary>
        /// <param name="baseMonth"></param>
        /// <param name="area"></param>
        async public void DownloadASync(DateTime baseMonth, string folder, int pageCount,string downloadUrlKey,string baseUrl= "")
        {
            //get the downloadlist with LiveABCDownloadList
            var yyyymm = baseMonth.ToString("yyyyMM");
            DownloadListBase downladListBase = new DownloadListBase();
            IEnumerable<string> downloadList = downladListBase.Get(yyyymm,pageCount, downloadUrlKey);

            var total = 0;
            var fail = 0;
            var success = 0;
            var sw = new Stopwatch();
            sw.Start();
            //progressBar1.Value = 0;

            foreach (var url in downloadList)
            {
                var downloadPath = Path.Combine(DownloadPath, yyyymm, folder);
                var downloadUrl=url;
                if (baseUrl != "") downloadUrl = string.Format("{0}/{1}", baseUrl, url);
                if (!Directory.Exists(downloadPath)) Directory.CreateDirectory(downloadPath);

                var fileName = "";
                if (downloadUrl.IndexOf("?") == -1)
                {
                    fileName= Path.GetFileName(new Uri(downloadUrl).LocalPath);
                }
                else {
                    fileName = downloadUrl.Substring(downloadUrl.LastIndexOf("=") + 1);                    
                }


                Mylogger(LogType.Info, string.Format("{0},url={1},Downloading", folder, downloadUrl));
                var filepath = Path.Combine(downloadPath, fileName);
                try
                {
                    var client = new WebClient();
                    client.Headers.Add("User-Agent: IE");
                    client.DownloadProgressChanged += (s, e) =>
                    {
                        //event-3.觸發event
                        OnProgressChanged(e);
                    };
                    await client.DownloadFileTaskAsync(new Uri(downloadUrl), filepath);
                    success++;
                    Mylogger(LogType.Info, string.Format("{0},url={1},Done", folder, downloadUrl));
                }
                catch (Exception ex)
                {
                    fail++;
                    Mylogger(LogType.Error, string.Format("{0},url={1},錯誤:{2}", folder, downloadUrl, ex.Message));
                    if (File.Exists(Path.Combine(downloadPath, fileName)))
                    {
                        if (new FileInfo(filepath).Length == 0)
                        {
                            File.Delete(filepath);
                        }
                    }
                }
                total++;
            }
            MyResultlogger(LogType.Debug, string.Format("{0},{1},total:{2},success:{3},fail:{4}", folder, yyyymm,total, success, fail));

            sw.Stop();
            var elapsed = sw.Elapsed;
            MyResultlogger(LogType.Info, string.Format("{0},{1},共費時:{2}", folder, yyyymm,elapsed));
        }


        private void Mylogger(LogType logtype, string msg)
        {
            if (msg == null) return;
            _logHelper.Log(logtype, msg);            
            OnWindowLogger(msg);
        }


        private void MyResultlogger(LogType logtype, string msg)
        {
            if (msg == null) return;
            _logHelper.Log(logtype, msg);
            OnWindowResultLogger(msg);
        }

    }
}
