/*
********************************************************
功能:Form1
說明:主畫面面
********************************************************
日期          作者       說明
2015.07.26    fij       初版
2015.07.26    fij       宣告event,將進度回報到Form1上的txtLog,txtResultLog
                              downloadFile.OnProgressChanged += DownloadFile_OnProgressChanged;
********************************************************
*/
using System;
using System.Configuration;
using System.IO;
using System.Net;
using System.Windows.Forms;
using Fun.Logger;
using System.Diagnostics;
using LiveABCDownload;
using System.Collections.Generic;

namespace AsyncAwaitTest
{
   
    public partial class FrmAsyncTest  :Form
    {   
        public FrmAsyncTest()
        {
            InitializeComponent();     
        }

        DownloadFile downloadFile;
        WindowLogger _windowLogHelper;
        WindowLogger _windowResultLogHelper;
        private void FrmAsyncTest_Load(object sender, EventArgs e)
        {
            _windowLogHelper = new WindowLogger(ref txtLog);
            _windowResultLogHelper = new WindowLogger(ref txtResultLog);

            downloadFile = new DownloadFile();
            //event使用2-2.註冊event:OnProgressChanged的處理,+=  Tab兩次,自動產生DownloadFile_OnProgressChanged
            downloadFile.OnProgressChanged += DownloadFile_OnProgressChanged;
            downloadFile.OnWindowLogger += DownloadFile_OnWindowLogger;
            downloadFile.OnWindowResultLogger += DownloadFile_OnWindowResultLogger;
        }

        //event使用2-1.與delegate相同簽名的function:ProgressChanged
        private void DownloadFile_OnProgressChanged(DownloadProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }


    
    


        private void DownloadFile_OnWindowLogger(string msg)
        {
            txtLog.Text = string.Format("{0}\r\n{1}", msg, txtLog.Text);

        }

        private void DownloadFile_OnWindowResultLogger(string msg)
        {
            txtResultLog.Text = string.Format("{0}\r\n{1}", msg, txtResultLog.Text );
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            long milliseconds = DateTime.Now.Millisecond;
            lblTimer.Text = string.Format("{0}.{1}", DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"), milliseconds);
        }

        


        private void btnDeclaimSync_Click(object sender, EventArgs e)
        {
            downloadFile.DownloadSync(baseMonth:dtpMonth.Value, folder:"課文講解", pageCount:5, downloadUrlKey:"LiveABC.Explain.DownloadList");
        }

        private void btnDeclaimAsync_Click(object sender, EventArgs e)
        {
            downloadFile.DownloadASync(baseMonth:dtpMonth.Value, folder: "課文講解",pageCount:5,downloadUrlKey:"LiveABC.Explain.DownloadList");
        }


        private void btnReadAsync_Click(object sender, EventArgs e)
        {
            downloadFile.DownloadASync(baseMonth:dtpMonth.Value, folder: "課文朗讀", pageCount:1, downloadUrlKey:"LiveABC.Declaim.DownloadList");
        }

        private void btnBroadcastAsync_Click(object sender, EventArgs e)
        {
            string baseUrl = string.Format("{0}",ConfigurationManager.AppSettings["LiveABC.BaseUrl"]);
            downloadFile.DownloadASync(baseMonth:dtpMonth.Value, folder:"線上廣播", pageCount:5, downloadUrlKey: "LiveABC.Broadcast.DownloadList", baseUrl: baseUrl);
        }
              

        private void btnAll_Click(object sender, EventArgs e)
        {
            btnDeclaimAsync_Click(this,null);
            btnBroadcastAsync_Click(this,null);
            btnReadAsync_Click(this,null);
        }

       
    }
}