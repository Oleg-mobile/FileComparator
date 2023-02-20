namespace FileComparator.Models
{
    public class ComparerPrintItem
    {
        public Color Color { get; set; }
        public Func<SomeFile, string> Print { get; set; }
    }
}
