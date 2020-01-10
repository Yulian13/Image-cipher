using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows.Forms;
using AngleSharp.Dom;
using AngleSharp.Html.Parser;

namespace Photo_cipher.Forms
{
    public partial class DownloadManager : Form
    {
        public DownloadManager()
        {
            InitializeComponent();
        }

        private void buttonDownload_Click(object sender, EventArgs e)
        {
            var client = new WebClient();
            client.DownloadStringCompleted += Client_DownloadStringCompleted;
            client.DownloadStringAsync(new Uri(textBoxLink.Text));
        }

        private void Client_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            var wc = (WebClient)sender;
            var parser = new HtmlParser();
            var document = parser.ParseDocument(e.Result);
            List<string> src = new List<string>();

            foreach (IElement element in document.QuerySelectorAll("img").Where(ele => ele.ClassName == "fit-horizontal"))
            {
                src.Add(element.GetAttribute("src"));
            }
            int i = 1;
            foreach (string link in src)
            {
                wc.DownloadFile(link, $"images\\Image.jpg");
            }
            textBoxEnd.Text = "Finish";
        }
    }
}
