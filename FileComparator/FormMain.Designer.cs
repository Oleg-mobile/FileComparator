namespace FileComparator
{
    partial class FormMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.labelFirstFolder = new System.Windows.Forms.Label();
            this.labelSecondFolder = new System.Windows.Forms.Label();
            this.openFileDialogFirstFolder = new System.Windows.Forms.OpenFileDialog();
            this.pictureBoxFirstFolder = new System.Windows.Forms.PictureBox();
            this.pictureBoxSecondFolder = new System.Windows.Forms.PictureBox();
            this.folderBrowserDialogFirst = new System.Windows.Forms.FolderBrowserDialog();
            this.richTextBoxFirstFolder = new System.Windows.Forms.RichTextBox();
            this.richTextBoxSecondFolder = new System.Windows.Forms.RichTextBox();
            this.labelFilesCountFirst = new System.Windows.Forms.Label();
            this.labelFilesCountSecond = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxFirstFolder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSecondFolder)).BeginInit();
            this.SuspendLayout();
            // 
            // labelFirstFolder
            // 
            this.labelFirstFolder.AutoSize = true;
            this.labelFirstFolder.Location = new System.Drawing.Point(67, 28);
            this.labelFirstFolder.Name = "labelFirstFolder";
            this.labelFirstFolder.Size = new System.Drawing.Size(85, 15);
            this.labelFirstFolder.TabIndex = 0;
            this.labelFirstFolder.Text = "Первая папка:";
            // 
            // labelSecondFolder
            // 
            this.labelSecondFolder.AutoSize = true;
            this.labelSecondFolder.Location = new System.Drawing.Point(720, 28);
            this.labelSecondFolder.Name = "labelSecondFolder";
            this.labelSecondFolder.Size = new System.Drawing.Size(83, 15);
            this.labelSecondFolder.TabIndex = 1;
            this.labelSecondFolder.Text = "Вторая папка:";
            // 
            // openFileDialogFirstFolder
            // 
            this.openFileDialogFirstFolder.FileName = "openFileDialog1";
            // 
            // pictureBoxFirstFolder
            // 
            this.pictureBoxFirstFolder.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxFirstFolder.Image")));
            this.pictureBoxFirstFolder.Location = new System.Drawing.Point(23, 28);
            this.pictureBoxFirstFolder.Name = "pictureBoxFirstFolder";
            this.pictureBoxFirstFolder.Size = new System.Drawing.Size(39, 26);
            this.pictureBoxFirstFolder.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxFirstFolder.TabIndex = 7;
            this.pictureBoxFirstFolder.TabStop = false;
            this.pictureBoxFirstFolder.Click += new System.EventHandler(this.pictureBoxFirstFolder_Click);
            // 
            // pictureBoxSecondFolder
            // 
            this.pictureBoxSecondFolder.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxSecondFolder.Image")));
            this.pictureBoxSecondFolder.Location = new System.Drawing.Point(675, 28);
            this.pictureBoxSecondFolder.Name = "pictureBoxSecondFolder";
            this.pictureBoxSecondFolder.Size = new System.Drawing.Size(39, 26);
            this.pictureBoxSecondFolder.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxSecondFolder.TabIndex = 8;
            this.pictureBoxSecondFolder.TabStop = false;
            this.pictureBoxSecondFolder.Click += new System.EventHandler(this.pictureBoxSecondFolder_Click);
            // 
            // richTextBoxFirstFolder
            // 
            this.richTextBoxFirstFolder.Location = new System.Drawing.Point(23, 60);
            this.richTextBoxFirstFolder.Name = "richTextBoxFirstFolder";
            this.richTextBoxFirstFolder.Size = new System.Drawing.Size(621, 367);
            this.richTextBoxFirstFolder.TabIndex = 9;
            this.richTextBoxFirstFolder.Text = "";
            // 
            // richTextBoxSecondFolder
            // 
            this.richTextBoxSecondFolder.Location = new System.Drawing.Point(675, 60);
            this.richTextBoxSecondFolder.Name = "richTextBoxSecondFolder";
            this.richTextBoxSecondFolder.Size = new System.Drawing.Size(620, 367);
            this.richTextBoxSecondFolder.TabIndex = 10;
            this.richTextBoxSecondFolder.Text = "";
            // 
            // labelFilesCountFirst
            // 
            this.labelFilesCountFirst.AutoSize = true;
            this.labelFilesCountFirst.Location = new System.Drawing.Point(24, 444);
            this.labelFilesCountFirst.Name = "labelFilesCountFirst";
            this.labelFilesCountFirst.Size = new System.Drawing.Size(123, 15);
            this.labelFilesCountFirst.TabIndex = 11;
            this.labelFilesCountFirst.Text = "Количество файлов: ";
            // 
            // labelFilesCountSecond
            // 
            this.labelFilesCountSecond.AutoSize = true;
            this.labelFilesCountSecond.Location = new System.Drawing.Point(675, 444);
            this.labelFilesCountSecond.Name = "labelFilesCountSecond";
            this.labelFilesCountSecond.Size = new System.Drawing.Size(123, 15);
            this.labelFilesCountSecond.TabIndex = 12;
            this.labelFilesCountSecond.Text = "Количество файлов: ";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1321, 489);
            this.Controls.Add(this.labelFilesCountSecond);
            this.Controls.Add(this.labelFilesCountFirst);
            this.Controls.Add(this.richTextBoxSecondFolder);
            this.Controls.Add(this.richTextBoxFirstFolder);
            this.Controls.Add(this.pictureBoxSecondFolder);
            this.Controls.Add(this.pictureBoxFirstFolder);
            this.Controls.Add(this.labelSecondFolder);
            this.Controls.Add(this.labelFirstFolder);
            this.Name = "FormMain";
            this.Text = "Сравниватель файлов";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxFirstFolder)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSecondFolder)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label labelFirstFolder;
        private Label labelSecondFolder;
        private OpenFileDialog openFileDialogFirstFolder;
        private PictureBox pictureBoxFirstFolder;
        private PictureBox pictureBoxSecondFolder;
        private FolderBrowserDialog folderBrowserDialogFirst;
        private RichTextBox richTextBoxFirstFolder;
        private RichTextBox richTextBoxSecondFolder;
        private Label labelFilesCountFirst;
        private Label labelFilesCountSecond;
    }
}