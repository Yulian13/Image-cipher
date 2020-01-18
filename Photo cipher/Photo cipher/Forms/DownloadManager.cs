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
        string GetLink => textBoxLink.Text;

        bool downloading {
            set
            {
                buttonDownload.Enabled = value;
                progressDownload.Visible = value;
                buttonCheckingName.Enabled = !value;
                textBoxName.Enabled = !value;

                progressDownload.Value = 0;

                if (!value)
                {
                    textBoxLink.Text = "";
                    textBoxName.Text = "";
                    labelProgress.Text = "";
                }
            }
        }

        const string Path = "D:\\Anime\\No need";

        public DownloadManager()
        {
            InitializeComponent();

            downloading = false;
        }

        private void buttonChecking_Click(object sender, EventArgs e)
        {
            ParserWorker<string> parserName = new ParserWorker<string>
            (
                new HabraParserName(),
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
            string LinkImg = GetLink + "1/";

            ParserWorker<SimpleObjectImg> parser = new ParserWorker<SimpleObjectImg>
            (
                new HabraParserImg(),
                new HabraSettings(LinkImg)
            );
            parser.OnNewData += Parser_OnNewData;
            parser.OnError += _OnError;
            parser.Start();
        }

        private void Parser_OnNewData(object arg1, SimpleObjectImg result)
        {

            string newPath = $"{Path}\\{textBoxName.Text}";
            try
            {
                Directory.CreateDirectory(newPath);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }

            downloading = true;
            progressDownload.Maximum = result.number;
            buttonDownload.Enabled = false;

            backgroundWorker1.RunWorkerAsync(result);
        }

        private void backgroundWorker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            SimpleObjectImg result = (SimpleObjectImg)e.Argument;

            string newPath = $"{Path}\\{textBoxName.Text}";

            var wc = new WebClient();

            for(int i = 1; i<=result.number; i++)
            {
               string PathImg = String.Format("{0}\\{1:d2}.jpg", newPath, i);
               backgroundWorker1.ReportProgress(i);
               try
                {
                    wc.DownloadFile($"{result.LinkImg}{i}.jpg", PathImg);
                }
                catch (Exception)
                {
                    try
                    {
                        wc.DownloadFile($"{result.LinkImg}{i}.png", PathImg);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
        }

        private void _ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
            labelProgress.Text = $"{e.ProgressPercentage}/{progressDownload.Maximum}";

            progressDownload.Value = e.ProgressPercentage;
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            MessageBox.Show("Composition have been downloaded");

            downloading = false;
        }
    }
}
