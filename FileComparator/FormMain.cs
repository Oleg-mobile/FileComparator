﻿using System.Collections;
using System.Diagnostics;

namespace FileComparator
{
    public partial class FormMain : Form
    {
        private readonly IList<SomeFile> _firstFolderFiles = new List<SomeFile>();
        private readonly IList<SomeFile> _secondFolderFiles = new List<SomeFile>();
        private string pathToFirstDirectory = string.Empty;

        public FormMain()
        {
            InitializeComponent();
        }

        private void pictureBoxFirstFolder_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(pathToFirstDirectory))
            {
                folderBrowserDialogFirst.SelectedPath = pathToFirstDirectory;
            }

            if (folderBrowserDialogFirst.ShowDialog() != DialogResult.OK)
                return;

            pathToFirstDirectory = folderBrowserDialogFirst.SelectedPath;
            labelFirstFolder.Text = pathToFirstDirectory;

            richTextBoxFirstFolder.Clear();

            InitFolder(pathToFirstDirectory, _firstFolderFiles);

            foreach (var someFile in _firstFolderFiles)
            {
                richTextBoxFirstFolder.AppendText(someFile.Name + " - " + someFile.Size + "B - " + someFile.Version + Environment.NewLine);
            }

            labelFilesCountFirst.Text = $"Количество файлов: {_firstFolderFiles.Count}";
        }

        private void InitFolder(string pathToDirectory, IList<SomeFile> someFiles)
        {
            var directoryInfo = new DirectoryInfo(pathToDirectory);
            someFiles.Clear();

            foreach (var fileInfo in directoryInfo.EnumerateFiles())  // GetFiles() - выгружает сразу все файлы, EnumerateFiles() - выгружает по одному
            {
                var versionInfo = FileVersionInfo.GetVersionInfo(pathToDirectory + "\\" + fileInfo.Name);

                var someFile = new SomeFile
                {
                    Name = fileInfo.Name,
                    Size = fileInfo.Length,
                    Version = versionInfo.FileVersion
                };

                someFiles.Add(someFile);
            }
        }

        private void pictureBoxSecondFolder_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialogFirst.ShowDialog() != DialogResult.OK) 
                return;

            richTextBoxSecondFolder.Clear();
            _secondFolderFiles.Clear();

            string pathToSecondDirectory = folderBrowserDialogFirst.SelectedPath;

            if (pathToSecondDirectory == pathToFirstDirectory)
            {
                MessageBox.Show("Каталоги совпадают");
                //return;
            }

            labelSecondFolder.Text = pathToSecondDirectory;

            var SecondDirectoryInfo = new DirectoryInfo(pathToSecondDirectory);

            InitFolder(pathToSecondDirectory, _secondFolderFiles);

            foreach (var someFile in _secondFolderFiles)
            {
                if (_firstFolderFiles.Any(f => f.Name == someFile.Name && (f.Size != someFile.Size || f.Version != someFile.Version)))
                {
                    richTextBoxSecondFolder.SelectionColor = Color.Red;
                    richTextBoxSecondFolder.AppendText("=> " + someFile.Name + " - " + someFile.Size + "B - " + someFile.Version + Environment.NewLine);

                    continue;
                }

                if (!_firstFolderFiles.Any(f => f.Name == someFile.Name))
                {
                    richTextBoxSecondFolder.SelectionColor = Color.Blue;
                    richTextBoxSecondFolder.AppendText("Нет в первом списке: " + someFile.Name + Environment.NewLine);

                    continue;
                }

                richTextBoxSecondFolder.SelectionColor = Color.Black;
                richTextBoxSecondFolder.AppendText(someFile.Name + " - " + someFile.Size + "B - " + someFile.Version + Environment.NewLine);
            }

            // Есть в первом списке, но нет во втором
            var difference = _firstFolderFiles.Where(f => !_secondFolderFiles.Any(s => s.Name == f.Name));
            foreach (SomeFile file in difference)
            {
                richTextBoxFirstFolder.SelectionColor = Color.Blue;
                richTextBoxFirstFolder.AppendText("Нет во втором списке: " + file.Name + Environment.NewLine);
            }

            labelFilesCountSecond.Text = $"Количество файлов: {_secondFolderFiles.Count}";
        }
    }
}
