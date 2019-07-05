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
        string Key;
        int numberPhoto;
        public int NumberPhoto
        {
            get => numberPhoto;
            set
            {
                numberPhoto = value;
                LabelTest.Text = $"Page: {NumberPhoto + 1}/{ReadyPhotos.Length}";
                pictureBox1.Image = (originDeshifrovka) ? NewImages[numberPhoto].image : 
                    Librari.byteArrayToImage(composition.Photos.ElementAt<Photo>(NumberPhoto).Image);
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

            toolStripProgressBar1.Maximum = composition.NumberPhotos;
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
            if (!Close)
            {
                LabelProgress.Text = $"{e.ProgressPercentage}/{NewImages.Length}";
                toolStripProgressBar1.Value++;
            }
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            toolStripProgressBar1.Visible = false;
            LabelProgress.Visible = false;
        }

        private void buttonForward_Click(object sender, EventArgs e)
        {
            if (NumberPhoto < composition.NumberPhotos-1 && ReadyPhotos[NumberPhoto+1] == true)
                NumberPhoto++;
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
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
            int Width = panel1.Width - 20;
            int Height = (int)(((double)pictureBox1.Image.Height / pictureBox1.Image.Width) * Width);
            Size size = new Size(Width, Height);
            Image newImage = new Bitmap(NewImages[NumberPhoto].image, size);
            pictureBox1.Image = newImage;
            pictureBox1.Size = size;
        }

        private void toolStripButtonOriginalDeshifrovka_Click(object sender, EventArgs e)
        {
            originDeshifrovka = !originDeshifrovka;
            toolStripButtonOriginalDeshifrovka.Text = (originDeshifrovka) ? "origin" : "Deshifrovka" ;
            NumberPhoto = NumberPhoto;
        }

        private void Watching_FormClosing(object sender, FormClosingEventArgs e) => Close = true;
    }
}
