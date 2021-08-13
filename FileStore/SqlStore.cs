using System.IO;

namespace FileStore
{
    public class SqlStore : IStore
    {
        public FileInfo GetFileInfo(int id, string workingDirectory)
        {
            throw new System.NotSupportedException();
        }

        public string ReadAllext(string path)
        {
            // Read and return from database

            return string.Empty;
        }

        public void WriteAllText(string path, string message)
        {
            // Write to database
        }
    }
}
