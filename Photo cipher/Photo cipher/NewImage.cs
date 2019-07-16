using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Photo_cipher
{
    public class NewImage
    {
        public Bitmap image;

        public string RightKey;

        public int Width;
        public int Height;

        Random rndm;

        public NewImage(Image image, Random random = null, string rightKey = "")
        {
            this.image = new Bitmap(image);
            RightKey = rightKey;
            Width = image.Width;
            Height = image.Height;
            rndm = random;
        }

        public NewImage(Photo photo) : this(Librari.byteArrayToImage(photo.Image), null, photo.RightKey) { }

        public Image ShifrovkaImage()
        {
            if (rndm == null) rndm = new Random();

            LockBitmap Image = new LockBitmap(image);
            Image.LockBits();

            for (int i = 0; i < Height; i++)
            {
                int Move = rndm.Next(33, Width - 1);
                RightKey += (char)Move;
                Color[] NewPixels = new Color[Width];
                for (int j = 0; j < Width; j++)
                    NewPixels[j] = Image.GetPixel(j, i);

                for (int j = 0; j < Width; j++)
                    Image.SetPixel(j, i, NewPixels[(j > Move) ? j - Move : (Width - 1) - (Move - j)]);
            }

            Image.UnlockBits();

            return image;
        }

        public Image DeShifrovkaImage(string Key)
        {
            if (rndm == null) rndm = new Random();

            LockBitmap Image = new LockBitmap(image);
            Image.LockBits();

            string s = Librari.DeShifrovka(RightKey, Key);
            int h = s.Length;
            char[] MovesRight = s.ToCharArray();
            for (int i = 0; i < Height; i++)
            {
                int Move = Width - MovesRight[(i > MovesRight.Length - 1) ? MovesRight.Length - 1 : i];
                Color[] NewPixels = new Color[Width];
                for (int j = 0; j < Width; j++)
                    NewPixels[j] = Image.GetPixel(j, i);
                for (int j = 0; j < Width; j++)
                    Image.SetPixel(j, i, NewPixels[(j > Move) ? j - Move : (Width - 1) - (Move - j)]);
            }

            Image.UnlockBits();

            return image;
        }
    }
}
