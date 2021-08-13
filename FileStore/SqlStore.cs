using System.IO;

namespace FileStore
{
    public class SqlStore : IStore
    {
        public FileInfo GetFileInfo(int id)
        {
            throw new System.NotSupportedException();
        }

        public Maybe<string> ReadAllext(int id)
        {
            // Read and return from database

            return new Maybe<string>();
        }

        public void WriteAllText(int id, string message)
        {
            // Write to database
        }
    }
}
