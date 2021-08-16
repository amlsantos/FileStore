using System.IO;

namespace FileStore
{
    public class FileStore : IStore, IFileLocator
    {
        private readonly IFileLocator _fileLocator;

        public FileStore(IFileLocator fileLocator)
        {
            this._fileLocator = fileLocator;
        }

        public virtual void WriteAllText(int id, string message)
        {
            var path = GetFileInfo(id);

            File.WriteAllText(path.FullName, message);
        }

        public virtual Maybe<string> ReadAllext(int id)
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
