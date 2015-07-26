using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace AsyncAwaitTest
{
    partial class FrmAsyncTest
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置 Managed 資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器
        /// 修改這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.btnDeclaimAsync = new System.Windows.Forms.Button();
            this.lblTimer = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.txtLog = new System.Windows.Forms.TextBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.dtpMonth = new System.Windows.Forms.DateTimePicker();
            this.lblMonth = new System.Windows.Forms.Label();
            this.lblUrl = new System.Windows.Forms.Label();
            this.btnBroadcastAsync = new System.Windows.Forms.Button();
            this.btnReadAsync = new System.Windows.Forms.Button();
            this.btnAll = new System.Windows.Forms.Button();
            this.txtResultLog = new System.Windows.Forms.TextBox();
            this.brnDeclaimSync = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnDeclaimAsync
            // 
            this.btnDeclaimAsync.Location = new System.Drawing.Point(513, 13);
            this.btnDeclaimAsync.Name = "btnDeclaimAsync";
            this.btnDeclaimAsync.Size = new System.Drawing.Size(115, 29);
            this.btnDeclaimAsync.TabIndex = 1;
            this.btnDeclaimAsync.Text = "課文講解Async";
            this.btnDeclaimAsync.UseVisualStyleBackColor = true;
            this.btnDeclaimAsync.Click += new System.EventHandler(this.btnDeclaimAsync_Click);
            // 
            // lblTimer
            // 
            this.lblTimer.AutoSize = true;
            this.lblTimer.Font = new System.Drawing.Font("Consolas", 28.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTimer.Location = new System.Drawing.Point(12, 151);
            this.lblTimer.Name = "lblTimer";
            this.lblTimer.Size = new System.Drawing.Size(622, 56);
            this.lblTimer.TabIndex = 2;
            this.lblTimer.Text = "2015/07/15 22:00:00.000";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // txtLog
            // 
            this.txtLog.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtLog.Location = new System.Drawing.Point(0, 210);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtLog.Size = new System.Drawing.Size(661, 169);
            this.txtLog.TabIndex = 3;
            // 
            // progressBar1
            // 
            this.progressBar1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.progressBar1.Location = new System.Drawing.Point(0, 385);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(778, 23);
            this.progressBar1.TabIndex = 4;
            // 
            // dtpMonth
            // 
            this.dtpMonth.CustomFormat = "yyyy/MM";
            this.dtpMonth.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpMonth.Location = new System.Drawing.Point(183, 20);
            this.dtpMonth.Name = "dtpMonth";
            this.dtpMonth.Size = new System.Drawing.Size(115, 25);
            this.dtpMonth.TabIndex = 5;
            // 
            // lblMonth
            // 
            this.lblMonth.AutoSize = true;
            this.lblMonth.Location = new System.Drawing.Point(12, 27);
            this.lblMonth.Name = "lblMonth";
            this.lblMonth.Size = new System.Drawing.Size(165, 15);
            this.lblMonth.TabIndex = 6;
            this.lblMonth.Text = "LiveABC(互動英語)年月:";
            // 
            // lblUrl
            // 
            this.lblUrl.Location = new System.Drawing.Point(0, 0);
            this.lblUrl.Name = "lblUrl";
            this.lblUrl.Size = new System.Drawing.Size(100, 23);
            this.lblUrl.TabIndex = 18;
            // 
            // btnBroadcastAsync
            // 
            this.btnBroadcastAsync.Location = new System.Drawing.Point(513, 58);
            this.btnBroadcastAsync.Name = "btnBroadcastAsync";
            this.btnBroadcastAsync.Size = new System.Drawing.Size(115, 29);
            this.btnBroadcastAsync.TabIndex = 13;
            this.btnBroadcastAsync.Text = "線上廣播Async";
            this.btnBroadcastAsync.UseVisualStyleBackColor = true;
            this.btnBroadcastAsync.Click += new System.EventHandler(this.btnBroadcastAsync_Click);
            // 
            // btnReadAsync
            // 
            this.btnReadAsync.Location = new System.Drawing.Point(513, 102);
            this.btnReadAsync.Name = "btnReadAsync";
            this.btnReadAsync.Size = new System.Drawing.Size(115, 29);
            this.btnReadAsync.TabIndex = 17;
            this.btnReadAsync.Text = "課文朗讀Async";
            this.btnReadAsync.UseVisualStyleBackColor = true;
            this.btnReadAsync.Click += new System.EventHandler(this.btnReadAsync_Click);
            // 
            // btnAll
            // 
            this.btnAll.Location = new System.Drawing.Point(311, 4);
            this.btnAll.Name = "btnAll";
            this.btnAll.Size = new System.Drawing.Size(133, 49);
            this.btnAll.TabIndex = 19;
            this.btnAll.Text = "DownloadAllAsync";
            this.btnAll.UseVisualStyleBackColor = true;
            this.btnAll.Click += new System.EventHandler(this.btnAll_Click);
            // 
            // txtResultLog
            // 
            this.txtResultLog.Location = new System.Drawing.Point(12, 62);
            this.txtResultLog.Multiline = true;
            this.txtResultLog.Name = "txtResultLog";
            this.txtResultLog.Size = new System.Drawing.Size(432, 69);
            this.txtResultLog.TabIndex = 20;
            // 
            // brnDeclaimSync
            // 
            this.brnDeclaimSync.Location = new System.Drawing.Point(644, 14);
            this.brnDeclaimSync.Name = "brnDeclaimSync";
            this.brnDeclaimSync.Size = new System.Drawing.Size(108, 28);
            this.brnDeclaimSync.TabIndex = 0;
            this.brnDeclaimSync.Text = "課文講解Sync";
            this.brnDeclaimSync.UseVisualStyleBackColor = true;
            this.brnDeclaimSync.Click += new System.EventHandler(this.btnDeclaimSync_Click);
            // 
            // FrmAsyncTest
            // 
            this.ClientSize = new System.Drawing.Size(778, 408);
            this.Controls.Add(this.txtResultLog);
            this.Controls.Add(this.btnAll);
            this.Controls.Add(this.btnReadAsync);
            this.Controls.Add(this.btnBroadcastAsync);
            this.Controls.Add(this.lblUrl);
            this.Controls.Add(this.lblMonth);
            this.Controls.Add(this.dtpMonth);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.txtLog);
            this.Controls.Add(this.lblTimer);
            this.Controls.Add(this.btnDeclaimAsync);
            this.Controls.Add(this.brnDeclaimSync);
            this.Name = "FrmAsyncTest";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.FrmAsyncTest_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Button btnDeclaimAsync;
        private Label lblTimer;
        private Timer timer1;
        private TextBox txtLog;
        private ProgressBar progressBar1;
        private DateTimePicker dtpMonth;
        private Label lblMonth;
        private Label lblUrl;
        private Button btnBroadcastAsync;
        private Button btnReadAsync;
        private Button btnAll;
        private TextBox txtResultLog;
        private Button brnDeclaimSync;
    }
}

