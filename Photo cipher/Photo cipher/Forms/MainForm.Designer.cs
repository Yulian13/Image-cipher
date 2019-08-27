namespace Photo_cipher.Forms
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.buttonAdd = new System.Windows.Forms.Button();
            this.buttonOpen = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.DropDownInstrument = new System.Windows.Forms.ToolStripDropDownButton();
            this.keyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changeKeyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changeCompositionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changeCompositionsNameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changeCompositionsKeyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DownButtonMigration = new System.Windows.Forms.ToolStripDropDownButton();
            this.buttonExport = new System.Windows.Forms.ToolStripMenuItem();
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
            this.backgroundWorkerExport = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorkerChangeKey = new System.ComponentModel.BackgroundWorker();
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
            this.DropDownInstrument,
            this.DownButtonMigration});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(526, 25);
            this.toolStrip1.TabIndex = 6;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // DropDownInstrument
            // 
            this.DropDownInstrument.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.DropDownInstrument.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.keyToolStripMenuItem,
            this.changeCompositionToolStripMenuItem});
            this.DropDownInstrument.Image = ((System.Drawing.Image)(resources.GetObject("DropDownInstrument.Image")));
            this.DropDownInstrument.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.DropDownInstrument.Name = "DropDownInstrument";
            this.DropDownInstrument.Size = new System.Drawing.Size(83, 22);
            this.DropDownInstrument.Text = "Instruments";
            // 
            // keyToolStripMenuItem
            // 
            this.keyToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.changeKeyToolStripMenuItem,
            this.resetToolStripMenuItem});
            this.keyToolStripMenuItem.Name = "keyToolStripMenuItem";
            this.keyToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.keyToolStripMenuItem.Text = "Key";
            // 
            // changeKeyToolStripMenuItem
            // 
            this.changeKeyToolStripMenuItem.Name = "changeKeyToolStripMenuItem";
            this.changeKeyToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
            this.changeKeyToolStripMenuItem.Text = "Change Key";
            this.changeKeyToolStripMenuItem.Click += new System.EventHandler(this.toolStripButtonChangeKey_Click);
            // 
            // resetToolStripMenuItem
            // 
            this.resetToolStripMenuItem.Name = "resetToolStripMenuItem";
            this.resetToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
            this.resetToolStripMenuItem.Text = "Reset";
            this.resetToolStripMenuItem.Click += new System.EventHandler(this.ButtonReset_Click);
            // 
            // changeCompositionToolStripMenuItem
            // 
            this.changeCompositionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.changeCompositionsNameToolStripMenuItem,
            this.changeCompositionsKeyToolStripMenuItem});
            this.changeCompositionToolStripMenuItem.Name = "changeCompositionToolStripMenuItem";
            this.changeCompositionToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.changeCompositionToolStripMenuItem.Text = "Change composition";
            // 
            // changeCompositionsNameToolStripMenuItem
            // 
            this.changeCompositionsNameToolStripMenuItem.Name = "changeCompositionsNameToolStripMenuItem";
            this.changeCompositionsNameToolStripMenuItem.Size = new System.Drawing.Size(226, 22);
            this.changeCompositionsNameToolStripMenuItem.Text = "Change composition\'s name";
            this.changeCompositionsNameToolStripMenuItem.Click += new System.EventHandler(this.changeCompositionsNameToolStripMenuItem_Click);
            // 
            // changeCompositionsKeyToolStripMenuItem
            // 
            this.changeCompositionsKeyToolStripMenuItem.Name = "changeCompositionsKeyToolStripMenuItem";
            this.changeCompositionsKeyToolStripMenuItem.Size = new System.Drawing.Size(226, 22);
            this.changeCompositionsKeyToolStripMenuItem.Text = "Change composition\'s key";
            this.changeCompositionsKeyToolStripMenuItem.Click += new System.EventHandler(this.changeCompositionsKeyToolStripMenuItem_Click);
            // 
            // DownButtonMigration
            // 
            this.DownButtonMigration.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.DownButtonMigration.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.buttonExport,
            this.importToolStripMenuItem});
            this.DownButtonMigration.Image = ((System.Drawing.Image)(resources.GetObject("DownButtonMigration.Image")));
            this.DownButtonMigration.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.DownButtonMigration.Name = "DownButtonMigration";
            this.DownButtonMigration.Size = new System.Drawing.Size(72, 22);
            this.DownButtonMigration.Text = "Migration";
            // 
            // buttonExport
            // 
            this.buttonExport.Name = "buttonExport";
            this.buttonExport.Size = new System.Drawing.Size(110, 22);
            this.buttonExport.Text = "Export";
            this.buttonExport.Click += new System.EventHandler(this.buttonExport_Click);
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
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
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
            this.dataGridView1.Size = new System.Drawing.Size(245, 312);
            this.dataGridView1.TabIndex = 9;
            this.dataGridView1.SelectionChanged += new System.EventHandler(this.dataGridView1_SelectionChanged);
            this.dataGridView1.DoubleClick += new System.EventHandler(this.buttonOpen_Click);
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
            this.buttonCancel.Anchor = System.Windows.Forms.AnchorStyles.Right;
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
            // backgroundWorkerExport
            // 
            this.backgroundWorkerExport.WorkerReportsProgress = true;
            this.backgroundWorkerExport.WorkerSupportsCancellation = true;
            this.backgroundWorkerExport.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerExport_DoWork);
            this.backgroundWorkerExport.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorkerExport_ProgressChanged);
            this.backgroundWorkerExport.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerExport_RunWorkerCompleted);
            // 
            // backgroundWorkerChangeKey
            // 
            this.backgroundWorkerChangeKey.WorkerReportsProgress = true;
            this.backgroundWorkerChangeKey.WorkerSupportsCancellation = true;
            this.backgroundWorkerChangeKey.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerChangeKey_DoWork);
            this.backgroundWorkerChangeKey.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorkerChangeKey_ProgressChanged);
            this.backgroundWorkerChangeKey.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerChangeKey_RunWorkerCompleted);
            // 
            // idDataGridViewTextBoxColumn
            // 
            this.idDataGridViewTextBoxColumn.DataPropertyName = "Id";
            this.idDataGridViewTextBoxColumn.HeaderText = "Id";
            this.idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            this.idDataGridViewTextBoxColumn.ReadOnly = true;
            this.idDataGridViewTextBoxColumn.Visible = false;
            this.idDataGridViewTextBoxColumn.Width = 30;
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn.HeaderText = "Name";
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            this.nameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // numberPhotosDataGridViewTextBoxColumn
            // 
            this.numberPhotosDataGridViewTextBoxColumn.DataPropertyName = "NumberPhotos";
            this.numberPhotosDataGridViewTextBoxColumn.FillWeight = 50F;
            this.numberPhotosDataGridViewTextBoxColumn.HeaderText = "Number";
            this.numberPhotosDataGridViewTextBoxColumn.Name = "numberPhotosDataGridViewTextBoxColumn";
            this.numberPhotosDataGridViewTextBoxColumn.ReadOnly = true;
            this.numberPhotosDataGridViewTextBoxColumn.Width = 55;
            // 
            // MainForm
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
            this.MinimumSize = new System.Drawing.Size(542, 504);
            this.Name = "MainForm";
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
        private System.Windows.Forms.ToolStripDropDownButton DownButtonMigration;
        private System.Windows.Forms.ToolStripMenuItem buttonExport;
        private System.Windows.Forms.ToolStripMenuItem importToolStripMenuItem;
        private System.Windows.Forms.ToolStripDropDownButton DropDownInstrument;
        private System.Windows.Forms.ToolStripMenuItem keyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem changeKeyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem resetToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem changeCompositionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem changeCompositionsNameToolStripMenuItem;
        private System.ComponentModel.BackgroundWorker backgroundWorkerExport;
        private System.Windows.Forms.ToolStripMenuItem changeCompositionsKeyToolStripMenuItem;
        private System.ComponentModel.BackgroundWorker backgroundWorkerChangeKey;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn numberPhotosDataGridViewTextBoxColumn;
    }
}

