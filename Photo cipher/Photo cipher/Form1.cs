using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Photo_cipher
{
    public partial class Form1 : Form
    {
        static PhotoContext db;
        static Composition composition;

        float RatioSize;

        string NameImages, NameKeys;        
        string Key;

        private bool rightKey = true;
        public bool RightKey {
            get => rightKey;
            set
            {
                if (RightKey == value)
                    return;
                rightKey = value;
                if (RightKey)
                {
                    buttonAdd.Enabled    = true;
                    buttonDelete.Enabled = true;
                    buttonOpen.Enabled   = true;
                }
                else
                {
                    buttonAdd.Enabled    = false;
                    buttonDelete.Enabled = false;
                    buttonOpen.Enabled   = false;
                }
            }
        }

        public Form1()
        {
            InitializeComponent();

            RatioSize = (float)pictureBox1.Width / pictureBox1.Height;

            db = new PhotoContext(); //@"Data Source=WIN-TUCQMTTP77C;Initial Catalog=Composition;Integrated Security=True;AttachDbFileName=D:\Anime\DataBase\Testing.mdf"
            db.Photos.Load();
            db.Compositions.Load();
            if(db.Compositions.Count() == 0)
                db.Compositions.Add(new Composition() {Name = "Crutch", NumberPhotos = 12 });// Crutch
            dataGridView1.DataSource = db.Compositions.Local.ToBindingList();

            toolStripButtonChangeKey_Click(null, null);
        }

        #region Adding

        private void buttonAdd_Click(object sender, EventArgs e)
        {

            FolderBrowserDialog FilePath = new FolderBrowserDialog();
            if (FilePath.ShowDialog() != DialogResult.OK)
                return;
            buttonAdd.Enabled = false;

            backgroundWorkerAdding.RunWorkerAsync(FilePath.SelectedPath);
        }

        private void backgroundWorkerAdding_DoWork(object sender, DoWorkEventArgs e)
        {
            string FilePath = (string)e.Argument;
            string[] imagesPath = Directory.GetFiles(FilePath, "*jpg", SearchOption.TopDirectoryOnly);
            if (imagesPath.Length == 0)
                imagesPath = Directory.GetFiles(FilePath, "*png", SearchOption.TopDirectoryOnly);

            Image[] Images = null;

            try
            {
                Images = new Image[imagesPath.Length];
                for (int i = 0; i < imagesPath.Length; i++)
                {
                    Images[i] = Image.FromFile(imagesPath[i]);
                    if (Images[i].Size.Height < 32 && Images[i].Size.Width < 32)
                        throw new Exception($"Image №{i} is too small");
                }
            }
            catch (OutOfMemoryException)
            {
                MessageBox.Show("Error");
                return;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }

            string[] Files = FilePath.Split('\\');
            string DirectoryName = Librari.Shifrovka(Files[Files.Length - 1], Key);
            Files = null;

            Random rndm = new Random();
            composition = new Composition() { Name = DirectoryName, NumberPhotos = Images.Length };

            for (int a = 0; a < Images.Length; a++)
            {
                if (backgroundWorkerAdding.CancellationPending == true)
                {
                    e.Cancel = true;
                    break;
                }

                backgroundWorkerAdding.ReportProgress(Images.Length);

                NewImage myBitmaps = new NewImage(Images[a], rndm);

                myBitmaps.ShifrovkaImage();

                Photo photo = new Photo() {
                    Image = Librari.imageToByteArray(myBitmaps.image),
                    RightKey = Librari.Shifrovka(myBitmaps.RightKey, Key),
                    Composition = composition
                };
                composition.Photos.Add(photo);

                backgroundWorkerAdding.ReportProgress(Images.Length);

            }
        }

        private void backgroundWorkerAdding_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Visible = true;
            buttonCancel.Visible = true;
            progressBar1.Maximum = e.ProgressPercentage * 2;
            progressBar1.Value++;
        }

        private void backgroundWorkerAdding_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

            progressBar1.Value = 0;
            progressBar1.Visible = false;
            buttonCancel.Visible = false;

            if (e.Error != null)
            {
                MessageBox.Show("Error!: " + e.Error.Message);
            }
            else if(e.Cancelled == false)
            {
                foreach (var photo in composition.Photos)
                    db.Photos.Add(photo);
                db.Compositions.Add(composition);

                foreach(var prov in db.Compositions)
                {
                    if (prov.Name == "Crutch")
                        db.Compositions.Remove(prov);
                    break;
                } // Crutch

                db.SaveChanges();

                MessageBox.Show("Composition have been added");
            }
            buttonAdd.Enabled = true;
            composition = null;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you really want to cancel adding?", "Canceling",
            MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2,
            MessageBoxOptions.DefaultDesktopOnly);

            if(result == DialogResult.Yes) 
                backgroundWorkerAdding.CancelAsync();
        }

        #endregion

        private void toolStripButtonChangeKey_Click(object sender, EventArgs e)
        {
            GetKey Key = new GetKey();
            Key.ShowDialog();
            this.Key = Key.maskedTextBox1.Text;

            NameImages = Librari.Shifrovka("Images", this.Key);
            NameKeys = Librari.Shifrovka("Keys", this.Key);

            if(sender != null & e != null)
                dataGridView1_SelectionChanged(null, null);
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count < 1)
                return;

            int index = dataGridView1.SelectedRows[0].Index;
            int id = 0;
            bool converted = Int32.TryParse(dataGridView1[0, index].Value.ToString(), out id);
            if (converted == false)
                return;

            try
            {
                Composition composition = db.Compositions.Find(id);
                labelNameComposistion.Text = Librari.DeShifrovka(composition.Name, Key);
                Photo photo = composition.Photos.ElementAt<Photo>(0);
                NewImage newImage = new NewImage(new Bitmap(Librari.byteArrayToImage(photo.Image)), null);
                newImage.DeShifrovkaImage(Key, photo.RightKey);

                float newRatioSize = (float)newImage.image.Width / newImage.image.Height;
                pictureBox1.Size = new Size(250,400);
                if (RatioSize < newRatioSize)
                    pictureBox1.Height = (int)(pictureBox1.Height * RatioSize / newRatioSize);
                else
                    pictureBox1.Width = (int)(pictureBox1.Width / RatioSize * newRatioSize);
                pictureBox1.Image = new Bitmap(newImage.image, pictureBox1.Size);
                RightKey = true;
            }
            catch(System.Security.Cryptography.CryptographicException) {
                labelNameComposistion.Text = "Key is wrong: ";
                pictureBox1.Image = pictureBox1.ErrorImage;
                RightKey = false;
            }
            catch (Exception)
            {
                labelNameComposistion.Text = "Error";
                pictureBox1.Image = pictureBox1.ErrorImage;
                RightKey = false;
            }

        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {            
            DialogResult result = MessageBox.Show("Do you really want to delete it?", "Deleting",
            MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2,
            MessageBoxOptions.DefaultDesktopOnly);


            if (result == DialogResult.OK || dataGridView1.SelectedRows.Count < 1)
                return;

            int index = dataGridView1.SelectedRows[0].Index;
            int id = 0;
            bool converted = Int32.TryParse(dataGridView1[0, index].Value.ToString(), out id);
            if (converted == false)
                return;

            Composition composition = db.Compositions.Find(id);
            db.Compositions.Remove(composition);
            foreach (var photo in db.Photos)
                if (photo.CompositionId == null)
                    db.Photos.Remove(photo);

            db.SaveChanges();

            MessageBox.Show("Composition have been Deleted");
        }

        private void buttonOpen_Click(object sender, EventArgs e)
        {
            int index = dataGridView1.SelectedRows[0].Index;
            int id = 0;
            bool converted = Int32.TryParse(dataGridView1[0, index].Value.ToString(), out id);
            if (converted == false)
                return;

            Watching watching = new Watching(db.Compositions.Find(id),Key);
            watching.Show();
        }

        private void ButtonReset_Click(object sender, EventArgs e)
        {
            this.Key = null;
            dataGridView1_SelectionChanged(null, null);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'compositionDataSet.Compositions' table. You can move, or remove it, as needed.
            this.compositionsTableAdapter.Fill(this.compositionDataSet.Compositions);

        }
    }
}
