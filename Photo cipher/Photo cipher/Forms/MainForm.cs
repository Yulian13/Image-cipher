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

namespace Photo_cipher.Forms
{
    public partial class MainForm : Form
    {
        static PhotoContext db;
        static Composition composition;

        float RatioSize;

        string Key;
        const string NameFolderCompositions = "CompositionImage";
        const string NameFolderKeys         = "Keys";
        private const string Connect = @"Data Source=WIN-TUCQMTTP77C;Initial Catalog=Composition;
                Integrated Security=True;AttachDbFileName=D:\Anime\DataBase\Composition.mdf";

        int NowId {
            get
            {
                if (dataGridView1.SelectedRows.Count < 1)
                    return -1;

                int index = dataGridView1.SelectedRows[0].Index;
                int id = 0;
                bool converted = Int32.TryParse(dataGridView1[0, index].Value.ToString(), out id);
                if (converted == false)
                    return -1;
                return id;
            }
        }

        bool usedBackgroundWorker = false;
        public bool UsedBackgroundWorker
        {
            get => usedBackgroundWorker;
            set
            {
                usedBackgroundWorker = value;

                progressBar1.Visible = usedBackgroundWorker;
                buttonCancel.Visible = usedBackgroundWorker;

                buttonAdd.Enabled = !usedBackgroundWorker;
                buttonExport.Enabled = !usedBackgroundWorker;
                changeCompositionsKeyToolStripMenuItem.Enabled = !usedBackgroundWorker;

                if (!usedBackgroundWorker) progressBar1.Value = 0;
            }
        }

        private bool rightKey = true;
        public bool RightKey {
            get => rightKey;
            set
            {
                if (RightKey == value)
                    return;

                rightKey = value;

                buttonOpen.Enabled = rightKey;
                buttonExport.Enabled = rightKey;
                changeCompositionToolStripMenuItem.Enabled = rightKey;
            }
        }


        public MainForm()
        {
            InitializeComponent();

            RatioSize = (float)pictureBox1.Width / pictureBox1.Height;

            try
            {
                db = new PhotoContext(Connect);
                db.Compositions.Load();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex}");
                return;
            }
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
            backgroundWorkerAdding.RunWorkerAsync(FilePath.SelectedPath);
            UsedBackgroundWorker = true;

        }

        private void backgroundWorkerAdding_DoWork(object sender, DoWorkEventArgs e)
        {
            string Key = new string(this.Key.ToCharArray());
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
            if (Images.Length == 0) throw new Exception("there isn't images");

            string[] Files = FilePath.Split('\\');
            string DirectoryName = Librari.Shifrovka(Files.Last(), Key);
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
            progressBar1.Maximum = e.ProgressPercentage * 2;
            progressBar1.Value++;
        }

        private void backgroundWorkerAdding_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

            if (e.Error != null)
            {
                MessageBox.Show("Error!: " + e.Error.Message);
            }
            else if(e.Cancelled == false)
            {
                foreach (var photo in composition.Photos)
                    db.Photos.Add(photo);
                db.Compositions.Add(composition);

                db.SaveChanges();

                composition.IdFirstPhoto = composition.Photos.First().Id;

                if (db.Compositions.First().Name == "Crutch")
                    db.Compositions.Remove(db.Compositions.First());// Crutch

                db.SaveChanges();

                MessageBox.Show("Composition have been added");
            }

            UsedBackgroundWorker = false;

            composition = null;
        }

        #endregion

        #region Export

        private void buttonExport_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog DirectoryPath = new FolderBrowserDialog();
            if (DirectoryPath.ShowDialog() != DialogResult.OK)
                return;

            backgroundWorkerExport.RunWorkerAsync(DirectoryPath.SelectedPath);
            UsedBackgroundWorker = true;
        }

        private void backgroundWorkerExport_DoWork(object sender, DoWorkEventArgs e)
        {
            List<int> SelectedCompositions = dataGridView1.SelectedRows.Cast<DataGridViewRow>().Select(i => i.Index).ToList();
            e.Result = SelectedCompositions.Count;
            int NameId = 0;
            string DirectoryPath = e.Argument.ToString();
            string path = DirectoryPath +
                ((DirectoryPath.EndsWith("\\")) ? NameFolderCompositions : $"\\{NameFolderCompositions}");
            foreach (var index in SelectedCompositions)
            {
                if (dataGridView1.SelectedRows.Count < 1)
                    return;
                int id = 0;
                bool converted = Int32.TryParse(dataGridView1[0, index].Value.ToString(), out id);
                if (converted == false)
                    return;

                Directory.CreateDirectory(path);

                while (true)
                {
                    if (Directory.Exists(path + $"\\{NameId}"))
                        NameId++;
                    else
                        break;
                }
                Directory.CreateDirectory(path + $"\\{NameId}\\{NameFolderKeys}");

                string FilePath = path + $"\\{NameId}";

                Composition composition = db.Compositions.Find(id);

                File.WriteAllText(FilePath + "\\Text.txt", composition.Name);

                if (backgroundWorkerExport.CancellationPending == true)
                {
                    e.Cancel = true;
                    break;
                }

                int namberImage = 0;
                foreach (Photo photo in composition.Photos)
                {
                    Image image = Librari.byteArrayToImage(photo.Image);
                    image.Save(FilePath + $"\\{namberImage}image.jpg");
                    File.WriteAllText(FilePath + $"\\{NameFolderKeys}\\{namberImage}Key.txt", photo.RightKey);
                    namberImage++;
                }
                backgroundWorkerExport.ReportProgress(SelectedCompositions.Count);
            }
        }

        private void backgroundWorkerExport_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Maximum = e.ProgressPercentage;
            progressBar1.Value++;
        }

        private void backgroundWorkerExport_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                MessageBox.Show("Error!: " + e.Error.Message);
            }
            else if (e.Cancelled == false)
            {
                string message = ((int)e.Result > 1) ? "Compositions" : "Composition";
                MessageBox.Show($"{message} have been Export");
            }

            UsedBackgroundWorker = false;
        }

        #endregion

        #region Change Key

        private void changeCompositionsKeyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GetKey key = new GetKey();
            if (key.ShowDialog() != DialogResult.OK)
                return;
            string newKey = new string(key.GetText.ToCharArray());

            backgroundWorkerChangeKey.RunWorkerAsync(newKey);
            UsedBackgroundWorker = true;
        }

        private void backgroundWorkerChangeKey_DoWork(object sender, DoWorkEventArgs e)
        {

            string newKey = e.Argument.ToString();
            string Key = new string(this.Key.ToCharArray());

            int numberMove = 0;
            List<int> indexes = dataGridView1.SelectedRows.Cast<DataGridViewRow>().Select(i => i.Index).ToList();
            e.Result = indexes.Count;

            foreach(int id in indexes)
                numberMove += Int32.Parse(dataGridView1[2,id].Value.ToString());
            numberMove *= 2;

            Random random = new Random();
            foreach(int id in indexes)
            {
                int Id = Int32.Parse(dataGridView1[0, id].Value.ToString());
                composition = db.Compositions.Find(Id);
                NewImage[] newImages = new NewImage[composition.NumberPhotos];
                composition.Name = Librari.Shifrovka(Librari.DeShifrovka(composition.Name,Key),newKey);
                int i = 0;
                foreach(Photo photo in composition.Photos)
                {
                    newImages[i] = new NewImage(photo,random);
                    newImages[i].DeShifrovkaImage(Key);
                    backgroundWorkerChangeKey.ReportProgress(numberMove);
                    if (backgroundWorkerExport.CancellationPending == true)
                    {
                        e.Cancel = true;
                        break;
                    }


                    newImages[i].ShifrovkaImage();
                    photo.RightKey = Librari.Shifrovka(newImages[i].RightKey,newKey);
                    photo.Image = Librari.imageToByteArray(newImages[i].image);
                    backgroundWorkerChangeKey.ReportProgress(numberMove);
                    if (backgroundWorkerExport.CancellationPending == true)
                    {
                        e.Cancel = true;
                        break;
                    }

                    i++;
                }
                composition = null;
            }
        }

        private void backgroundWorkerChangeKey_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Maximum = e.ProgressPercentage;
            progressBar1.Value++;
        }

        private void backgroundWorkerChangeKey_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                MessageBox.Show("Error!: " + e.Error.Message);
            }
            else if (e.Cancelled == true)
            {
                db = new PhotoContext(Connect);
            }
            else
            {
                string message = ((int)e.Result > 1) ? "Compositions" : "Composition";
                MessageBox.Show($"{message} has changed the key");
                db.SaveChanges();
            }

            UsedBackgroundWorker = false;
            dataGridView1_SelectionChanged(null,null);
        }

        #endregion

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you really want to cancel adding?", "Canceling",
            MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2,
            MessageBoxOptions.DefaultDesktopOnly);

            if(result == DialogResult.Yes)
            {
                backgroundWorkerAdding.CancelAsync();
                backgroundWorkerExport.CancelAsync();
                backgroundWorkerChangeKey.CancelAsync();
            }
        }

        private void toolStripButtonChangeKey_Click(object sender, EventArgs e)
        {
            GetKey Key = new GetKey();
            Key.ShowDialog();
            this.Key = new string(Key.GetText.ToCharArray());

            if(sender != null & e != null)
                dataGridView1_SelectionChanged(null, null);
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            int id = NowId;
            if (id < 0) return;

            try
            {
                Composition composition = db.Compositions.Find(id);
                labelNameComposistion.Text = Librari.DeShifrovka(composition.Name, Key);
                Photo photo = db.Photos.Find(composition.IdFirstPhoto);
                Image newImage = new NewImage(photo).DeShifrovkaImage(Key);

                float newRatioSize = (float)newImage.Width / newImage.Height;
                pictureBox1.Size = new Size(250,400);
                if (RatioSize < newRatioSize)
                    pictureBox1.Height = (int)(pictureBox1.Height * RatioSize / newRatioSize);
                else
                    pictureBox1.Width = (int)(pictureBox1.Width / RatioSize * newRatioSize);
                pictureBox1.Image = new Bitmap(newImage, pictureBox1.Size);
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

            int id = NowId;
            if (id < 0) return;

            Composition composition = db.Compositions.Find(id);
            db.Photos.RemoveRange(composition.Photos);
            db.Compositions.Remove(composition);

            db.SaveChanges();

            dataGridView1_SelectionChanged(null,null);
            MessageBox.Show("Composition have been Deleted");
        }

        private void buttonOpen_Click(object sender, EventArgs e)
        {
            int id = NowId;
            if (id < 0) return;

            Watching watching = new Watching(db.Compositions.Find(id),Key);
            watching.Show();
        }

        private void ButtonReset_Click(object sender, EventArgs e)
        {
            this.Key = null;
            dataGridView1_SelectionChanged(null, null);
        }

        private void buttonImport_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog DirectoryPath = new FolderBrowserDialog();
            if (DirectoryPath.ShowDialog() != DialogResult.OK)
                return;

            string path = DirectoryPath.SelectedPath +
                ((DirectoryPath.SelectedPath.EndsWith("\\")) ? NameFolderCompositions : $"\\{NameFolderCompositions}");

            if (!Directory.Exists(path))
            {
                MessageBox.Show($"There is no folder is \"{NameFolderCompositions}\"");
                return;
            }

            ImportCompositions importer = new ImportCompositions(path,Key,NameFolderKeys);
            DialogResult result = importer.ShowDialog();
            if (result != DialogResult.OK || importer.indexes.Count==0) return;

            foreach(int index in importer.indexes)
            {
                string[] NumberPhoto = Directory.GetFiles(path + $"\\{index}", "*jpg", SearchOption.TopDirectoryOnly);
                Composition composition = new Composition() {
                    Name = new StreamReader(path + $"\\{index}\\Text.txt").ReadToEnd(),
                    NumberPhotos = NumberPhoto.Length,
                };

                for(int i = 0; i<NumberPhoto.Length; i++)
                {
                    string pathRightKey = path + $"\\{index}\\{NameFolderKeys}\\{i}Key.txt";
                    Photo photo = new Photo()
                    {
                        Image = Librari.imageToByteArray(new Bitmap(path + $"\\{index}\\{i}image.jpg")),
                        RightKey = new StreamReader(pathRightKey).ReadToEnd(),
                        Composition = composition
                    };
                    db.Photos.Add(photo);
                }
                db.Compositions.Add(composition);
                db.SaveChanges();
                composition.IdFirstPhoto = composition.Photos.First().Id;                
            }

            db.SaveChanges();
            MessageBox.Show("All is ready");
        }

        private void changeCompositionsNameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int id = NowId;
            if (id < 0) return;

            Composition composition = db.Compositions.Find(id);
            EnterString enter = new EnterString(Librari.DeShifrovka(composition.Name, Key));

            if (enter.ShowDialog() != DialogResult.OK) return;

            composition.Name = Librari.Shifrovka(enter.GetName, Key);
            labelNameComposistion.Text = enter.GetName;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'compositionDataSet.Compositions' table. You can move, or remove it, as needed.
            this.compositionsTableAdapter.Fill(this.compositionDataSet.Compositions);
        }

    }
}
