namespace Photo_cipher
{
    partial class ImportCompositions
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ImportCompositions));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.ButtonAllCompositons = new System.Windows.Forms.ToolStripButton();
            this.buttonImport = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NameComposition = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Import = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.NumberPhotos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Image = new System.Windows.Forms.DataGridViewImageColumn();
            this.KeyRight = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Concole = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(365, 516);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ButtonAllCompositons});
            this.toolStrip1.Location = new System.Drawing.Point(365, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(363, 25);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // ButtonAllCompositons
            // 
            this.ButtonAllCompositons.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.ButtonAllCompositons.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.ButtonAllCompositons.Image = ((System.Drawing.Image)(resources.GetObject("ButtonAllCompositons.Image")));
            this.ButtonAllCompositons.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ButtonAllCompositons.Name = "ButtonAllCompositons";
            this.ButtonAllCompositons.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ButtonAllCompositons.Size = new System.Drawing.Size(100, 22);
            this.ButtonAllCompositons.Text = "All compositions";
            this.ButtonAllCompositons.Click += new System.EventHandler(this.ButtonAllCompositons_Click);
            // 
            // buttonImport
            // 
            this.buttonImport.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.buttonImport.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonImport.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.buttonImport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonImport.Location = new System.Drawing.Point(365, 492);
            this.buttonImport.Name = "buttonImport";
            this.buttonImport.Size = new System.Drawing.Size(363, 24);
            this.buttonImport.TabIndex = 3;
            this.buttonImport.Text = "Import";
            this.buttonImport.UseVisualStyleBackColor = true;
            this.buttonImport.Click += new System.EventHandler(this.buttonImport_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.NameComposition,
            this.Import,
            this.NumberPhotos,
            this.Image,
            this.KeyRight});
            this.dataGridView1.Location = new System.Drawing.Point(365, 25);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(363, 468);
            this.dataGridView1.TabIndex = 4;
            this.dataGridView1.SelectionChanged += new System.EventHandler(this.dataGridView1_SelectionChanged);
            // 
            // Id
            // 
            this.Id.FillWeight = 35F;
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            // 
            // NameComposition
            // 
            this.NameComposition.HeaderText = "Name";
            this.NameComposition.Name = "NameComposition";
            // 
            // Import
            // 
            this.Import.FillWeight = 40F;
            this.Import.HeaderText = "Import";
            this.Import.Name = "Import";
            this.Import.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // NumberPhotos
            // 
            this.NumberPhotos.HeaderText = "NumberPhotos";
            this.NumberPhotos.Name = "NumberPhotos";
            // 
            // Image
            // 
            this.Image.HeaderText = "Image";
            this.Image.Name = "Image";
            this.Image.Visible = false;
            // 
            // KeyRight
            // 
            this.KeyRight.HeaderText = "KeyRight";
            this.KeyRight.Name = "KeyRight";
            this.KeyRight.Visible = false;
            // 
            // Concole
            // 
            this.Concole.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Concole.FormattingEnabled = true;
            this.Concole.Location = new System.Drawing.Point(365, 423);
            this.Concole.Name = "Concole";
            this.Concole.Size = new System.Drawing.Size(363, 69);
            this.Concole.TabIndex = 5;
            // 
            // ImportCompositions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(728, 516);
            this.Controls.Add(this.Concole);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.buttonImport);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "ImportCompositions";
            this.Text = "ImportCompositions";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton ButtonAllCompositons;
        private System.Windows.Forms.Button buttonImport;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn NameComposition;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Import;
        private System.Windows.Forms.DataGridViewTextBoxColumn NumberPhotos;
        private System.Windows.Forms.DataGridViewImageColumn Image;
        private System.Windows.Forms.DataGridViewTextBoxColumn KeyRight;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ListBox Concole;
    }
}