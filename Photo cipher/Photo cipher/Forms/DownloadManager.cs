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

            Directory.CreateDirectory(Path);
        }

        private void buttonChecking_Click(object sender, EventArgs e)
        {
            buttonCheckingName.Enabled = false;

            ParserWorker<string> parserName = new ParserWorker<string>(
                                                new HabraParserNHentaiName(),
                                                new HabraSettings(GetLink)
                                             );
            parserName.OnNewData += ParserName_OnNewData; ;

            parserName.Start();
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

            ParserWorker<string> parser = new ParserWorker<string>(
                                              new HabraParserNhentaiImg(LinkImg),
                                              new HabraSettings(LinkImg)
                                           );
            parser.OnNewData += Parser_OnNewData;
            parser.Start();
        }

        private void Parser_OnNewData(object arg1, string result)
        {
            int i = 1;
            string newPath = $"{Path}\\{textBoxName.Text}";
            Directory.CreateDirectory(newPath);

            var wc = new WebClient();
            while (true)
            {
                try
                {
                    wc.DownloadFile($"{result}{i}.jpg", String.Format("{0}\\{1:d2}.jpg", newPath, i));
                }
                catch (WebException)
                {
                    try
                    {
                        wc.DownloadFile($"{result}{i}.png", String.Format("{0}\\{1:d2}.jpg", newPath, i));
                    }
                    catch (WebException)
                    {
                        break;
                    }
                }
                label2.Text = $"{i}";
                i++;
            }
            label2.Text = "Finish";
        }
    }
}
