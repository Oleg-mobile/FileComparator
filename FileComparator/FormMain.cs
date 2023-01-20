using System.Diagnostics;

namespace FileComparator
{
    public partial class FormMain : Form
    {
        private readonly List<SomeFile> _listFilesInFirstFolder = new List<SomeFile>();
        private readonly List<SomeFile> _listFilesInSecondFolder = new List<SomeFile>();
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

            if (folderBrowserDialogFirst.ShowDialog() != DialogResult.OK) return;

            richTextBoxFirstFolder.Clear();
            _listFilesInFirstFolder.Clear();

            pathToFirstDirectory = folderBrowserDialogFirst.SelectedPath;
            labelFirstFolder.Text = pathToFirstDirectory;

            var firstDirectoryInfo = new DirectoryInfo(pathToFirstDirectory);

            foreach (var fileInfo in firstDirectoryInfo.EnumerateFiles())  // GetFiles() - выгружает сразу все файлы, EnumerateFiles() - выгружает по одному
            {
                var versionInfo = FileVersionInfo.GetVersionInfo(pathToFirstDirectory + "\\" + fileInfo.Name);

                var someFile = new SomeFile
                {
                    Name = fileInfo.Name,
                    Size = fileInfo.Length,
                    Version = versionInfo.FileVersion
                };

                _listFilesInFirstFolder.Add(someFile);

                richTextBoxFirstFolder.AppendText(someFile.Name + " - " + someFile.Size + "B - " + someFile.Version + Environment.NewLine);
            }

            labelFilesCountFirst.Text = $"Количество файлов: {_listFilesInFirstFolder.Count}";
        }

        private void pictureBoxSecondFolder_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialogFirst.ShowDialog() != DialogResult.OK) return;

            richTextBoxSecondFolder.Clear();
            _listFilesInSecondFolder.Clear();

            string pathToSecondDirectory = folderBrowserDialogFirst.SelectedPath;

            if (pathToSecondDirectory == pathToFirstDirectory)
            {
                MessageBox.Show("Каталоги совпадают");
                return;
            }

            labelSecondFolder.Text = pathToSecondDirectory;

            var SecondDirectoryInfo = new DirectoryInfo(pathToSecondDirectory);

            foreach (var fileInfo in SecondDirectoryInfo.EnumerateFiles())
            {
                var versionInfo = FileVersionInfo.GetVersionInfo(pathToSecondDirectory + "\\" + fileInfo.Name);

                var someFile = new SomeFile
                {
                    Name = fileInfo.Name,
                    Size = fileInfo.Length,
                    Version = versionInfo.FileVersion
                };

                _listFilesInSecondFolder.Add(someFile);

                if (_listFilesInFirstFolder.Exists(f => f.Name == someFile.Name && (f.Size != someFile.Size || f.Version != someFile.Version)))
                {
                    richTextBoxSecondFolder.SelectionColor = Color.Red;
                    richTextBoxSecondFolder.AppendText("=> " + someFile.Name + " - " + someFile.Size + "B - " + someFile.Version + Environment.NewLine);

                    continue;
                }

                if (!_listFilesInFirstFolder.Exists(f => f.Name == someFile.Name))
                {
                    richTextBoxSecondFolder.SelectionColor = Color.Blue;
                    richTextBoxSecondFolder.AppendText("Нет в первом списке: " + someFile.Name + Environment.NewLine);

                    continue;
                }

                richTextBoxSecondFolder.SelectionColor = Color.Black;
                richTextBoxSecondFolder.AppendText(someFile.Name + " - " + someFile.Size + "B - " + someFile.Version + Environment.NewLine);
            }

            // Есть в первом списке, но нет во втором
            var difference = _listFilesInFirstFolder.Where(f => !_listFilesInSecondFolder.Any(s => s.Name == f.Name));
            foreach (SomeFile file in difference)
            {
                richTextBoxFirstFolder.SelectionColor = Color.Blue;
                richTextBoxFirstFolder.AppendText("Нет во втором списке: " + file.Name + Environment.NewLine);
            }

            labelFilesCountSecond.Text = $"Количество файлов: {_listFilesInSecondFolder.Count}";
        }
    }
}
