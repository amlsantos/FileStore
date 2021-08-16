using System.IO;

namespace FileStore
{
    public interface IFileLocator
    {
        public FileInfo GetFileInfo(int id);
    }
}
