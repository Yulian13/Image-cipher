namespace Photo_cipher.Forms
{
    partial class DownloadManager
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.textBoxLink = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonCheckingName = new System.Windows.Forms.Button();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.buttonDownload = new System.Windows.Forms.Button();
            this.labelProgress = new System.Windows.Forms.Label();
            this.progressDownload = new System.Windows.Forms.ProgressBar();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.SuspendLayout();
            // 
            // textBoxLink
            // 
            this.textBoxLink.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxLink.Location = new System.Drawing.Point(12, 28);
            this.textBoxLink.Multiline = true;
            this.textBoxLink.Name = "textBoxLink";
            this.textBoxLink.Size = new System.Drawing.Size(316, 39);
            this.textBoxLink.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Add Link";
            // 
            // buttonCheckingName
            // 
            this.buttonCheckingName.Location = new System.Drawing.Point(12, 73);
            this.buttonCheckingName.Name = "buttonCheckingName";
            this.buttonCheckingName.Size = new System.Drawing.Size(75, 23);
            this.buttonCheckingName.TabIndex = 2;
            this.buttonCheckingName.Text = "Checking";
            this.buttonCheckingName.UseVisualStyleBackColor = true;
            this.buttonCheckingName.Click += new System.EventHandler(this.buttonChecking_Click);
            // 
            // textBoxName
            // 
            this.textBoxName.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxName.Location = new System.Drawing.Point(12, 102);
            this.textBoxName.Multiline = true;
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(316, 92);
            this.textBoxName.TabIndex = 3;
            // 
            // buttonDownload
            // 
            this.buttonDownload.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonDownload.Location = new System.Drawing.Point(12, 200);
            this.buttonDownload.Name = "buttonDownload";
            this.buttonDownload.Size = new System.Drawing.Size(75, 23);
            this.buttonDownload.TabIndex = 4;
            this.buttonDownload.Text = "Download";
            this.buttonDownload.UseVisualStyleBackColor = true;
            this.buttonDownload.Click += new System.EventHandler(this.buttonDownload_Click);
            // 
            // labelStatus
            // 
            this.labelProgress.AutoSize = true;
            this.labelProgress.Location = new System.Drawing.Point(93, 78);
            this.labelProgress.Name = "labelStatus";
            this.labelProgress.Size = new System.Drawing.Size(35, 13);
            this.labelProgress.TabIndex = 5;
            this.labelProgress.Text = "label2";
            // 
            // progressDownload
            // 
            this.progressDownload.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressDownload.Location = new System.Drawing.Point(135, 72);
            this.progressDownload.Name = "progressDownload";
            this.progressDownload.Size = new System.Drawing.Size(193, 23);
            this.progressDownload.TabIndex = 6;
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.WorkerSupportsCancellation = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker_DoWork);
            this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this._ProgressChanged);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // DownloadManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(340, 233);
            this.Controls.Add(this.progressDownload);
            this.Controls.Add(this.labelProgress);
            this.Controls.Add(this.buttonDownload);
            this.Controls.Add(this.textBoxName);
            this.Controls.Add(this.buttonCheckingName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxLink);
            this.MinimumSize = new System.Drawing.Size(356, 272);
            this.Name = "DownloadManager";
            this.Text = "DownloadManager";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxLink;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonCheckingName;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.Button buttonDownload;
        private System.Windows.Forms.Label labelProgress;
        private System.Windows.Forms.ProgressBar progressDownload;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}