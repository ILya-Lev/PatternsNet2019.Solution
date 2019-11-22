using System;
using System.IO;

namespace Structural.Proxy
{
    public interface IFile
    {
        string Name { get; }
        DateTime CreatedAt { get; }
        string GetContent();
    }

    public class RealFile : IFile
    {
        private readonly string _content;
        public DateTime CreatedAt { get; }
        public string Name { get; }

        public RealFile(string fullName)
        {
            Name = Path.GetFileName(fullName);
            CreatedAt = File.GetCreationTime(fullName);

            _content = File.Exists(fullName)
                ? File.ReadAllText(fullName)
                : string.Empty;
        }

        public string GetContent() => _content;
    }

    public class ProxyFile : IFile
    {
        private string _content = null;

        private readonly Lazy<RealFile> _lazyRealFile;
        public DateTime CreatedAt { get; }
        public string Name { get; }

        public ProxyFile(string fullPath, Func<string, RealFile> realFileGenerator)
        {
            Name = Path.GetFileName(fullPath);
            CreatedAt = File.GetCreationTime(fullPath);

            _lazyRealFile = new Lazy<RealFile>(() => realFileGenerator(fullPath));
        }

        public string GetContent()
        {
            return _content ??= _lazyRealFile.Value.GetContent();
        }
    }
}