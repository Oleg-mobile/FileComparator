using FileComparator.Models;

namespace FileComparator.Services
{
    public interface IComparerFileService
    {
        Dictionary<SomeFile, ComparerFileResult> Compare(IEnumerable<SomeFile> firstFolderFiles, IEnumerable<SomeFile> secondFolderFiles);
    }
}
