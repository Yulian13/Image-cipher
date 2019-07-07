using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Photo_cipher
{
    public partial class Watching : Form
    {
        Composition composition;
        static NewImage[] NewImages;
        static bool[] ReadyPhotos;
        bool Close = false;

        bool originDeshifrovka = true;
        bool NormalZoom = true;
        string Key;
        int numberPhoto;
        public int NumberPhoto
        {
            get => numberPhoto;
            set
            {
                numberPhoto = value;
                LabelView.Text = $"Page: {NumberPhoto + 1}/{ReadyPhotos.Length}";
                ProgressBarView.Value = numberPhoto + 1;
                pictureBox1_SizeChanged(null, null);
            }
        }

        public Watching(Composition composition, string Key)
        {
            InitializeComponent();

            this.composition = composition;
            this.Key = Key;
            this.Text = Librari.DeShifrovka(composition.Name, Key);
            NewImages = new NewImage[composition.NumberPhotos];
            ReadyPhotos = new bool[composition.NumberPhotos];

            ProgressBarView.Maximum     = composition.NumberPhotos;
            ProgressBarProgress1.Maximum = composition.NumberPhotos;
            backgroundWorker1.RunWorkerAsync(composition);

            while (ReadyPhotos[0] != true) { }
            NumberPhoto = 0;
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            int i = 0;
            foreach(Photo photo in (e.Argument as Composition).Photos)
            {
                NewImages[i] = new NewImage(Librari.byteArrayToImage(photo.Image));
                NewImages[i].DeShifrovkaImage(Key,photo.RightKey);
                ReadyPhotos[i] = true;
                backgroundWorker1.ReportProgress(++i);
            }

        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (Close)
                return;
            LabelProgress1.Text = $"{e.ProgressPercentage}/{NewImages.Length}";
            ProgressBarProgress1.Value++;
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (Close)
                return;
            ProgressBarProgress1.Visible = false;
            LabelProgress1.Visible = false;
            statusStrip1.Visible = false;
        }

        private void buttonForward_Click(object sender, EventArgs e)
        {
            panel1.VerticalScroll.Value = 0;
            if (NumberPhoto < composition.NumberPhotos-1 && ReadyPhotos[NumberPhoto+1] == true)
                NumberPhoto++;
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            panel1.VerticalScroll.Value = 0;
            if (NumberPhoto > 0)
                NumberPhoto--;
        }

        private void Watching_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Location.X < pictureBox1.Width / 2)
                buttonBack_Click(null, null);
            else
                buttonForward_Click(null, null);
        }

        private void pictureBox1_SizeChanged(object sender, EventArgs e)
        {
            Image image = (originDeshifrovka) ? NewImages[numberPhoto].image :
                    Librari.byteArrayToImage(composition.Photos.ElementAt<Photo>(NumberPhoto).Image);
            LabelProgress1.Margin = new Padding((int)(toolStrip1.Width * 0.4),3,0,2);
            if (NormalZoom)
            {
                int Width = panel1.Width - 20;
                int Height = (int)(((double)image.Height / image.Width) * Width);
                Size newSize = new Size(Width, Height);
                pictureBox1.Image = new Bitmap(image, newSize);
                pictureBox1.Size = newSize;
            }
            else
            {
                pictureBox1.Size = new Size(panel1.Width - 20, panel1.Height - 20);
                pictureBox1.Image = image;
            }
        }

        private void toolStripButtonOriginalDeshifrovka_Click(object sender, EventArgs e)
        {
            originDeshifrovka = !originDeshifrovka;
            toolStripButtonOriginalDeshifrovka.Text = (originDeshifrovka) ? "origin" : "Deshifrovka" ;
            NumberPhoto = NumberPhoto;
        }

        private void ButtonZoomNormal_Click(object sender, EventArgs e)
        {
            NormalZoom = !NormalZoom;
            pictureBox1.SizeMode = (NormalZoom) ? PictureBoxSizeMode.CenterImage : PictureBoxSizeMode.Zoom;
            pictureBox1.Image = NewImages[NumberPhoto].image;
            ButtonZoomNormal.Text = (NormalZoom) ? "Zoom" : "Normal" ;
            pictureBox1_SizeChanged(null,null);
        }

        private void Watching_FormClosing(object sender, FormClosingEventArgs e) => Close = true;
    }
}
