using System.IO;

namespace FileStore
{
    public class FileStore : IFileLocator, IStoreWriter, IStoreReader
    {
        private readonly IFileLocator _fileLocator;

        public FileStore(IFileLocator fileLocator)
        {
            _fileLocator = fileLocator;
        }

        public void Save(int id, string message)
        {
            var path = GetFileInfo(id);

            File.WriteAllText(path.FullName, message);
        }

        public Maybe<string> Read(int id)
        {
            var path = GetFileInfo(id);

            if (!path.Exists)
                return new Maybe<string>();

            var file = File.ReadAllText(path.FullName);

            return new Maybe<string>(file);
        }

        public FileInfo GetFileInfo(int id)
        {
            return _fileLocator.GetFileInfo(id);
        }
    }
}
