using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Photo_cipher
{
    public partial class ImportCompositions : Form
    {
        private readonly string PathFolder;
        private readonly string Key;
        private readonly string nameFolderKeys;

        public List<int> indexes = new List<int>();

        public ImportCompositions(string PathFolder, string Key ,string NameFolderKeys )
        {
            InitializeComponent();
            this.PathFolder = PathFolder;
            this.Key = Key;
            nameFolderKeys = NameFolderKeys;
            Concole.Items.Add("Importer have been runed");
            var folders = Directory.GetDirectories(PathFolder);
            Concole.Items.Add("folder have been finded");
            foreach (var folder in folders)
            {
                try {
                    string Name = new StreamReader(folder + "\\Text.txt").ReadToEnd();
                    var NumberPhoto = Directory.GetFiles(folder, "*jpg", SearchOption.TopDirectoryOnly);
                    dataGridView1.Rows.Add(
                        folder.Split('\\').Last(),
                        Librari.DeShifrovka(Name, Key),
                        false,
                        NumberPhoto.Length,
                        new Bitmap(NumberPhoto.First()),
                        new StreamReader(folder + $"\\{nameFolderKeys}\\0Key.txt").ReadToEnd()
                    );
                }
                catch (Exception)
                {
                    Concole.Items.Add($"failed to get into the folder \"{folder.Split('\\').Last()}\"");
                    continue;
                }
            }
        }

        private void ButtonAllCompositons_Click(object sender, EventArgs e)
        {
            bool TrueFalse = false;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if ((bool)row.Cells[2].Value == false)
                {
                    TrueFalse = true;
                    break;
                }
            }

            foreach (DataGridViewRow row in dataGridView1.Rows)
                row.Cells[2].Value = TrueFalse;
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count < 1)
                return;

            int index = dataGridView1.SelectedRows[0].Index;

            NewImage newImage = new NewImage((Image)dataGridView1[4,index].Value);
            string RightKey = (string)dataGridView1[5, index].Value;
            try
            {
                newImage.DeShifrovkaImage(Key, RightKey);
                pictureBox1.Image = newImage.image;
            }
            catch (Exception)
            {
                pictureBox1.Image = pictureBox1.ErrorImage;
            }
        }

        private void buttonImport_Click(object sender, EventArgs e)
        {
            foreach(DataGridViewRow row in dataGridView1.Rows)
                if ((bool)row.Cells[2].Value == true)
                    indexes.Add(Int32.Parse(row.Cells[0].Value.ToString()));
        }
    }
}
