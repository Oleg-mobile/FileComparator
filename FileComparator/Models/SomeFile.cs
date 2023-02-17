namespace FileComparator.Models
{
    public class SomeFile
    {
        public string? Name { get; set; }
        public string? Version { get; set; }
        public long Size { get; set; }

        public override bool Equals(object? obj)
        {
            return obj is SomeFile file &&
                   Name == file.Name &&
                   Version == file.Version &&
                   Size == file.Size;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Name, Version, Size);
        }
    }
}
