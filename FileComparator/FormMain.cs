using System.Diagnostics;

namespace FileComparator
{
    public partial class FormMain : Form
    {
        private List<SomeFile> listFilesInFirstFolder = new List<SomeFile>();
        private List<SomeFile> listFilesInSecondFolder = new List<SomeFile>();
        private string pathToFirstDirectory = string.Empty;

        public FormMain()
        {
            InitializeComponent();
        }

        private void buttonCompare_Click(object sender, EventArgs e)
        {
        }

        private void pictureBoxFirstFolder_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialogFirst.ShowDialog() != DialogResult.OK) return;

            richTextBoxFirstFolder.Clear();
            listFilesInFirstFolder.Clear();

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

                listFilesInFirstFolder.Add(someFile);

                richTextBoxFirstFolder.AppendText(someFile.Name + " - " + someFile.Size + "B - " + someFile.Version + Environment.NewLine);
            }

            labelFilesCountFirst.Text = $"Количество файлов: {listFilesInFirstFolder.Count}";
        }

        private void pictureBoxSecondFolder_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialogFirst.ShowDialog() != DialogResult.OK) return;

            richTextBoxSecondFolder.Clear();
            listFilesInSecondFolder.Clear();

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

                listFilesInSecondFolder.Add(someFile);

                if (listFilesInFirstFolder.Exists(f => f.Name == someFile.Name && f.Size != someFile.Size))  // TODO добавить ещё условие - сравнение по версии
                {
                    richTextBoxSecondFolder.SelectionColor = Color.Red;
                    richTextBoxSecondFolder.AppendText("=> " + someFile.Name + " - " + someFile.Size + "B - " + someFile.Version + Environment.NewLine);

                    continue;
                }

                if (!listFilesInFirstFolder.Exists(f => f.Name == someFile.Name))
                {
                    richTextBoxSecondFolder.SelectionColor = Color.Blue;
                    richTextBoxSecondFolder.AppendText("Нет в первом списке: " + someFile.Name + Environment.NewLine);

                    continue;
                }

                richTextBoxSecondFolder.SelectionColor = Color.Black;
                richTextBoxSecondFolder.AppendText(someFile.Name + " - " + someFile.Size + "B - " + someFile.Version + Environment.NewLine);
            }

            labelFilesCountSecond.Text = $"Количество файлов: {listFilesInSecondFolder.Count}";
        }
    }
}
