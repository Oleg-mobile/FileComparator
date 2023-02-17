using FileComparator.Models;

namespace FileComparator.Services
{
    public class InformationPrinter
    {
        public void PrintToRichTextBox(ComparerFileResult result, SomeFile someFile)
        {
            //switch (result)
            //{
            //    case ComparerFileResult.Differences:
            //        richTextBoxSecondFolder.SelectionColor = Color.Red;
            //        richTextBoxSecondFolder.AppendText("=> " + someFile.Name + " - " + someFile.Size + "B - " + someFile.Version + Environment.NewLine);
            //        break;
            //    case ComparerFileResult.NotFound:
            //        richTextBoxSecondFolder.SelectionColor = Color.Blue;
            //        richTextBoxSecondFolder.AppendText("Нет в первом списке: " + someFile.Name + Environment.NewLine);
            //        break;
            //    case ComparerFileResult.Equals:
            //        richTextBoxSecondFolder.SelectionColor = Color.Black;
            //        richTextBoxSecondFolder.AppendText(someFile.Name + " - " + someFile.Size + "B - " + someFile.Version + Environment.NewLine);
            //        break;
            //}
        }
    }
}
