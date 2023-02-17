using FileComparator.Models;

namespace FileComparator.Services
{
    public class ComparerFileService : IComparerFileService
    {
        public Dictionary<SomeFile, ComparerFileResult> Compare(IEnumerable<SomeFile> firstFolderFiles, IEnumerable<SomeFile> secondFolderFiles)
        {
            var result = new Dictionary<SomeFile, ComparerFileResult>();

            foreach (var someFile in firstFolderFiles)
            {
                Compare(secondFolderFiles, result, someFile);
            }

            return result;
        }

        private static void Compare(IEnumerable<SomeFile> secondFolderFiles, Dictionary<SomeFile, ComparerFileResult> result, SomeFile someFile)
        {
            foreach (var secondFile in secondFolderFiles)
            {
                if (someFile.Name == secondFile.Name)
                {
                    result.Add(someFile, someFile.Equals(secondFile) ? ComparerFileResult.Equals : ComparerFileResult.Differences);
                    return;
                }
            }

            result.Add(someFile, ComparerFileResult.NotFound);
        }
    }
}
