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
        NewImage[] NewImage;
        string Key;
        int numberPhoto;
        public int NumberPhoto {
            get {
                return numberPhoto;
            }
            set {
                numberPhoto = value;
                pictureBox1_Paint(NewImage[numberPhoto].image);
            }
        }

        float RatioSize => (float)this.Width / this.Height;
        Size SizePictureBox => new Size(this.Width - 83, this.Height - 85);

        public Watching(Composition composition, string Key)
        {
            InitializeComponent();

            this.composition = composition;
            this.Key = Key;
            this.Text = Librari.DeShifrovka(composition.Name, Key);

            NewImage = new NewImage[composition.NumberPhotos];
            int i = 0;
            foreach(var photo in composition.Photos)
            {
                NewImage[i] = new NewImage(Librari.byteArrayToImage(photo.Image));
                NewImage[i++].DeShifrovkaImage(Key,photo.RightKey);
            }
        }

        private void Watching_SizeChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Paint(Image sender, PaintEventArgs e = null)
        {
            pictureBox1.Image = sender;
        }

        private void buttonForward_Click(object sender, EventArgs e)
        {
            if (NumberPhoto < composition.NumberPhotos-1)
                NumberPhoto++;
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            if (NumberPhoto > 0)
                NumberPhoto--;
        }
    }
}
