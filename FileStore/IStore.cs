using System.IO;

namespace FileStore
{
    public interface IStore
    {
        public FileInfo GetFileInfo(int id, string workingDirectory);
        public string ReadAllext(string path);
        public void WriteAllText(string path, string message);
    }
}