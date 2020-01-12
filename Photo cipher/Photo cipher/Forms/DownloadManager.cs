using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Windows.Forms;
using AngleSharp.Dom;
using AngleSharp.Html.Parser;
using Photo_cipher.Parser;
using Photo_cipher.Parser.Habra;
using System.IO;

namespace Photo_cipher.Forms
{
    public partial class DownloadManager : Form
    {
        public string GetLink => textBoxLink.Text;

        const string Path = "D:\\Anime\\No need";

        public DownloadManager()
        {
            InitializeComponent();

            buttonDownload.Enabled = false;
            progressDownload.Visible = false;
        }

        private void buttonChecking_Click(object sender, EventArgs e)
        {
            if (!GetLink.Contains("nhentai.net"))
            {
                _OnError(null);
                return;
            }

            buttonCheckingName.Enabled = false;
            ParserWorker<string> parserName = new ParserWorker<string>(
                                                    new HabraParserNHentaiName(),
                                                    new HabraSettings(GetLink)
                                                 );
            parserName.OnNewData += ParserName_OnNewData;
            parserName.OnError += _OnError;

            parserName.Start();
        }

        private void _OnError(object obj)
        {
            MessageBox.Show("Link is wrong");
        }

        private void ParserName_OnNewData(object arg1, string result)
        {
            textBoxName.Text = result;

            buttonDownload.Enabled = true;
        }

        private void buttonDownload_Click(object sender, EventArgs e)
        {
            buttonDownload.Enabled = false;
            textBoxName.Enabled = false;

            string LinkImg = GetLink + "1/";

            ParserWorker<SimpleObjectImg> parser = new ParserWorker<SimpleObjectImg>(
                                              new HabraParserNhentaiImg(LinkImg),
                                              new HabraSettings(LinkImg)
                                           );
            parser.OnNewData += Parser_OnNewData;
            parser.OnError += _OnError;
            parser.Start();
        }

        private void Parser_OnNewData(object arg1, SimpleObjectImg result)
        {
            progressDownload.Visible = true;
            progressDownload.Maximum = result.number;

            backgroundWorker1.RunWorkerAsync(result);
        }

        private void backgroundWorker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            SimpleObjectImg result = (SimpleObjectImg)e.Argument;

            string newPath = $"{Path}\\{textBoxName.Text}";
            Directory.CreateDirectory(newPath);

            var wc = new WebClient();

            for(int i = 1; i<=result.number; i++)
            {
                string PathImg = String.Format("{0}\\{1:d2}.jpg", newPath, i);
                try
                {
                    wc.DownloadFile($"{result.Name}{i}.jpg", PathImg);
                }
                catch (Exception)
                {
                    try
                    {
                        wc.DownloadFile($"{result.Name}{i}.png", PathImg);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }

                backgroundWorker1.ReportProgress(i);
            }
        }

        private void _ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
            labelStatus.Text = $"{e.ProgressPercentage}";

            progressDownload.Value = e.ProgressPercentage;
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            labelStatus.Text = "Finish";
            progressDownload.Visible = false;
        }
    }
}
