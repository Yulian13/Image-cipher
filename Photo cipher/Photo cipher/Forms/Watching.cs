using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Photo_cipher.Forms
{
    public partial class Watching : Form
    {
        static Image[] originImage;
        static Image[] NewImages;
        static bool[] ReadyPhotos;
        bool close = false;

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

            this.Key = new string(Key.ToCharArray());
            this.Text = Librari.DeShifrovka(composition.Name, this.Key);
            originImage = new Image[composition.Photos.Count];
            NewImages   = new Image[composition.Photos.Count];
            ReadyPhotos = new bool [composition.Photos.Count];

            ProgressBarProgress.Maximum = ReadyPhotos.Length;
            ProgressBarView.Maximum = ReadyPhotos.Length;
            backgroundWorker1.RunWorkerAsync(composition);

            while (ReadyPhotos[0] != true) { }
            NumberPhoto = 0;
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            Image error = pictureBox1.ErrorImage;
            int i = 0;
            foreach(Photo photo in (e.Argument as Composition).Photos)
            {
                if (close) return; // Crutch
                try
                {
                    NewImages[i] = new NewImage(photo).DeShifrovkaImage(Key);
                    originImage[i] = Librari.byteArrayToImage(photo.Image);
                }
                catch (Exception)
                {
                    NewImages[i] = error;
                }
                ReadyPhotos[i] = true;
                backgroundWorker1.ReportProgress(++i);
            }

        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (close) return; // Crutch

            LabelProgress.Text = $"{e.ProgressPercentage}/{NewImages.Length}";
            ProgressBarProgress.Value++;
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (close) return; // Crutch

            ProgressBarProgress.Visible = false;
            LabelProgress.Visible = false;
        }

        private void buttonForward_Click(object sender, EventArgs e)
        {
            panel1.VerticalScroll.Value = 0;
            if (NumberPhoto < NewImages.Length-1 && ReadyPhotos[NumberPhoto+1] == true)
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
            if (e.Button == MouseButtons.XButton1)
                buttonForward_Click(null,null);
            else if (e.Button == MouseButtons.XButton2)
                buttonBack_Click(null, null);
            else if(e.Button == MouseButtons.Left)
            {
                if (e.Location.X < pictureBox1.Width / 2)
                    buttonBack_Click(null, null);
                else
                    buttonForward_Click(null, null);
            }
        }

        private void pictureBox1_SizeChanged(object sender, EventArgs e)
        {
            Image image = (originDeshifrovka) ? NewImages[numberPhoto] :
                    originImage[numberPhoto];
            LabelView.Margin = new Padding((int)(toolStrip1.Width * 0.4),3,0,2);
            if (NormalZoom)
            {
                int Width = panel1.Width - 20;
                int Height = (int)(((double)image.Height / image.Width) * Width);
                Size newSize = new Size(Width, Height);
                pictureBox1.Image = new Bitmap(image, newSize);
                pictureBox1.Size = new Size(newSize.Width, newSize.Height+statusStrip1.Height);
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
            pictureBox1.SizeMode = (NormalZoom) ? PictureBoxSizeMode.Normal : PictureBoxSizeMode.Zoom;
            pictureBox1.Image = NewImages[NumberPhoto];
            ButtonZoomNormal.Text = (NormalZoom) ? "Zoom" : "Normal" ;
            pictureBox1_SizeChanged(null,null);
        }

        private void Watching_FormClosing(object sender, FormClosingEventArgs e)
        {
            close = true;
            for(int i = 0; i < NewImages.Length; i++)
            {
                NewImages[i].Dispose();
                originImage[i].Dispose();
            }
        }
    }
}
