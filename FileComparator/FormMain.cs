using FileComparator.Extentions;
using FileComparator.Models;
using FileComparator.Services;
using System.Diagnostics;

namespace FileComparator
{
    public partial class FormMain : Form
    {
        private readonly IList<SomeFile> _firstFolderFiles = new List<SomeFile>();
        private readonly IList<SomeFile> _secondFolderFiles = new List<SomeFile>();
        private readonly IComparerFileService _comparerFileService = new ComparerFileService();
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
                richTextBoxFirstFolder.AppendText($"{someFile.Name} - {someFile.Size}B - {someFile.Version}\n");
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
                return;
            }

            labelSecondFolder.Text = pathToSecondDirectory;

            InitFolder(pathToSecondDirectory, _secondFolderFiles);
            var comparerFileResults = _comparerFileService.Compare(_secondFolderFiles, _firstFolderFiles);

            PrintComparerFileResults(comparerFileResults);
            PrintFilesNotFoundSecondFolder();

            labelFilesCountSecond.Text = $"Количество файлов: {_secondFolderFiles.Count}";
        }

        private void PrintComparerFileResults(Dictionary<SomeFile, ComparerFileResult> comparerFileResults)
        {
            foreach (var comparerFileResult in comparerFileResults)
            {
                var someFile = comparerFileResult.Key;
                var comparerPrintItem = FileComparatorConsts.DictionaryColors[comparerFileResult.Value];
                richTextBoxSecondFolder.AppendText(comparerPrintItem.Print(someFile), comparerPrintItem.Color);
            }
        }

        private void PrintFilesNotFoundSecondFolder()
        {
            richTextBoxSecondFolder.AppendText("\n");
            var difference = _firstFolderFiles.Where(f => !_secondFolderFiles.Any(s => s.Name == f.Name));
            foreach (SomeFile file in difference)
            {
                richTextBoxSecondFolder.AppendText($"Нет во втором списке: {file.Name}", Color.Green);
            }
        }
    }
}
