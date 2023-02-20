namespace FileComparator.Extentions
{
    public static class RichTextBoxExtention
    {
        public static void AppendText(this RichTextBox richTextBox, string text, Color color, bool isAppendLine = true)
        {
            richTextBox.SelectionColor = color;
            richTextBox.AppendText(text + (isAppendLine ? "\n" : ""));
        }
    }
}
