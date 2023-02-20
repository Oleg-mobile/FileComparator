using FileComparator.Models;

namespace FileComparator
{
    public static class FileComparatorConsts
    {
        public static Dictionary<ComparerFileResult, ComparerPrintItem> DictionaryColors = new Dictionary<ComparerFileResult, ComparerPrintItem>()
        {
            {
                ComparerFileResult.Differences, 
                new ComparerPrintItem
                {
                    Color = Color.Red,
                    Print = sf => $"=> {sf.Name} - {sf.Size}B - {sf.Version}"
                }
            },
            {
                ComparerFileResult.Equals,
                new ComparerPrintItem
                {
                    Color = Color.Black,
                    Print = sf => $"{sf.Name} - {sf.Size}B - {sf.Version}"
                }
            }, 
            {
                ComparerFileResult.NotFound,
                new ComparerPrintItem
                {
                    Color = Color.Blue,
                    Print = sf => $"Нет в первом списке: {sf.Name}"
                }
            }
        };
    }
}
