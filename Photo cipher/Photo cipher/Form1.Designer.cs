namespace Photo_cipher
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.buttonAdd = new System.Windows.Forms.Button();
            this.buttonOpen = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.ButtonChangeKey = new System.Windows.Forms.ToolStripButton();
            this.ButtonReset = new System.Windows.Forms.ToolStripButton();
            this.DownButtonMigration = new System.Windows.Forms.ToolStripDropDownButton();
            this.exportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.labelNameComposistion = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.compositionsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.compositionDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.compositionDataSet = new Photo_cipher.CompositionDataSet();
            this.backgroundWorkerAdding = new System.ComponentModel.BackgroundWorker();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.compositionsTableAdapter = new Photo_cipher.CompositionDataSetTableAdapters.CompositionsTableAdapter();
            this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numberPhotosDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.compositionsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.compositionDataSetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.compositionDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonAdd
            // 
            this.buttonAdd.Location = new System.Drawing.Point(271, 53);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(140, 23);
            this.buttonAdd.TabIndex = 1;
            this.buttonAdd.Text = "Add";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // buttonOpen
            // 
            this.buttonOpen.Location = new System.Drawing.Point(271, 110);
            this.buttonOpen.Name = "buttonOpen";
            this.buttonOpen.Size = new System.Drawing.Size(140, 23);
            this.buttonOpen.TabIndex = 3;
            this.buttonOpen.Text = "Open";
            this.buttonOpen.UseVisualStyleBackColor = true;
            this.buttonOpen.Click += new System.EventHandler(this.buttonOpen_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(15, 53);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(250, 400);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ButtonChangeKey,
            this.ButtonReset,
            this.DownButtonMigration});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(526, 25);
            this.toolStrip1.TabIndex = 6;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // ButtonChangeKey
            // 
            this.ButtonChangeKey.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.ButtonChangeKey.Image = ((System.Drawing.Image)(resources.GetObject("ButtonChangeKey.Image")));
            this.ButtonChangeKey.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ButtonChangeKey.Name = "ButtonChangeKey";
            this.ButtonChangeKey.Size = new System.Drawing.Size(74, 22);
            this.ButtonChangeKey.Text = "Change Key";
            this.ButtonChangeKey.Click += new System.EventHandler(this.toolStripButtonChangeKey_Click);
            // 
            // ButtonReset
            // 
            this.ButtonReset.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.ButtonReset.Image = ((System.Drawing.Image)(resources.GetObject("ButtonReset.Image")));
            this.ButtonReset.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ButtonReset.Name = "ButtonReset";
            this.ButtonReset.Size = new System.Drawing.Size(39, 22);
            this.ButtonReset.Text = "Reset";
            this.ButtonReset.Click += new System.EventHandler(this.ButtonReset_Click);
            // 
            // DownButtonMigration
            // 
            this.DownButtonMigration.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.DownButtonMigration.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exportToolStripMenuItem,
            this.importToolStripMenuItem});
            this.DownButtonMigration.Image = ((System.Drawing.Image)(resources.GetObject("DownButtonMigration.Image")));
            this.DownButtonMigration.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.DownButtonMigration.Name = "DownButtonMigration";
            this.DownButtonMigration.Size = new System.Drawing.Size(72, 22);
            this.DownButtonMigration.Text = "Migration";
            // 
            // exportToolStripMenuItem
            // 
            this.exportToolStripMenuItem.Name = "exportToolStripMenuItem";
            this.exportToolStripMenuItem.Size = new System.Drawing.Size(110, 22);
            this.exportToolStripMenuItem.Text = "Export";
            this.exportToolStripMenuItem.Click += new System.EventHandler(this.buttonExport_Click);
            // 
            // importToolStripMenuItem
            // 
            this.importToolStripMenuItem.Name = "importToolStripMenuItem";
            this.importToolStripMenuItem.Size = new System.Drawing.Size(110, 22);
            this.importToolStripMenuItem.Text = "Import";
            this.importToolStripMenuItem.Click += new System.EventHandler(this.buttonImport_Click);
            // 
            // buttonDelete
            // 
            this.buttonDelete.Location = new System.Drawing.Point(271, 82);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(139, 23);
            this.buttonDelete.TabIndex = 7;
            this.buttonDelete.Text = "Delete";
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // labelNameComposistion
            // 
            this.labelNameComposistion.AutoSize = true;
            this.labelNameComposistion.Location = new System.Drawing.Point(12, 29);
            this.labelNameComposistion.Name = "labelNameComposistion";
            this.labelNameComposistion.Size = new System.Drawing.Size(28, 13);
            this.labelNameComposistion.TabIndex = 8;
            this.labelNameComposistion.Text = "Text";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn,
            this.nameDataGridViewTextBoxColumn,
            this.numberPhotosDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.compositionsBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(271, 139);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(248, 312);
            this.dataGridView1.TabIndex = 9;
            this.dataGridView1.SelectionChanged += new System.EventHandler(this.dataGridView1_SelectionChanged);
            // 
            // compositionsBindingSource
            // 
            this.compositionsBindingSource.DataMember = "Compositions";
            this.compositionsBindingSource.DataSource = this.compositionDataSetBindingSource;
            // 
            // compositionDataSetBindingSource
            // 
            this.compositionDataSetBindingSource.DataSource = this.compositionDataSet;
            this.compositionDataSetBindingSource.Position = 0;
            // 
            // compositionDataSet
            // 
            this.compositionDataSet.DataSetName = "CompositionDataSet";
            this.compositionDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // backgroundWorkerAdding
            // 
            this.backgroundWorkerAdding.WorkerReportsProgress = true;
            this.backgroundWorkerAdding.WorkerSupportsCancellation = true;
            this.backgroundWorkerAdding.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerAdding_DoWork);
            this.backgroundWorkerAdding.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorkerAdding_ProgressChanged);
            this.backgroundWorkerAdding.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerAdding_RunWorkerCompleted);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(271, 24);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(189, 23);
            this.progressBar1.TabIndex = 10;
            this.progressBar1.Visible = false;
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(466, 24);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(50, 23);
            this.buttonCancel.TabIndex = 11;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Visible = false;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // compositionsTableAdapter
            // 
            this.compositionsTableAdapter.ClearBeforeFill = true;
            // 
            // idDataGridViewTextBoxColumn
            // 
            this.idDataGridViewTextBoxColumn.DataPropertyName = "Id";
            this.idDataGridViewTextBoxColumn.HeaderText = "Id";
            this.idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            this.idDataGridViewTextBoxColumn.ReadOnly = true;
            this.idDataGridViewTextBoxColumn.Width = 25;
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn.HeaderText = "Name";
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            this.nameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // numberPhotosDataGridViewTextBoxColumn
            // 
            this.numberPhotosDataGridViewTextBoxColumn.DataPropertyName = "NumberPhotos";
            this.numberPhotosDataGridViewTextBoxColumn.HeaderText = "NumberPhotos";
            this.numberPhotosDataGridViewTextBoxColumn.Name = "numberPhotosDataGridViewTextBoxColumn";
            this.numberPhotosDataGridViewTextBoxColumn.ReadOnly = true;
            this.numberPhotosDataGridViewTextBoxColumn.Width = 80;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(526, 465);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.labelNameComposistion);
            this.Controls.Add(this.buttonDelete);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.buttonOpen);
            this.Controls.Add(this.buttonAdd);
            this.MaximumSize = new System.Drawing.Size(542, 504);
            this.MinimumSize = new System.Drawing.Size(542, 504);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.compositionsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.compositionDataSetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.compositionDataSet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Button buttonOpen;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton ButtonChangeKey;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.Label labelNameComposistion;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.BindingSource compositionDataSetBindingSource;
        private CompositionDataSet compositionDataSet;
        private System.Windows.Forms.BindingSource compositionsBindingSource;
        private CompositionDataSetTableAdapters.CompositionsTableAdapter compositionsTableAdapter;
        private System.ComponentModel.BackgroundWorker backgroundWorkerAdding;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.ToolStripButton ButtonReset;
        private System.Windows.Forms.ToolStripDropDownButton DownButtonMigration;
        private System.Windows.Forms.ToolStripMenuItem exportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn numberPhotosDataGridViewTextBoxColumn;
    }
}

