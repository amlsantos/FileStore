using System.IO;

namespace FileStore
{
    public interface IStore
    {
        public Maybe<string> ReadAllext(int id);
        public void WriteAllText(int id, string message);
        public FileInfo GetFileInfo(int id);
    }
}