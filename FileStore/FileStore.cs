using System;
using System.IO;

namespace FileStore
{
    public class FileStore : IStore
    {
        private readonly DirectoryInfo _workingDirectory;

        public FileStore(DirectoryInfo workingDirectory)
        {
            if (workingDirectory == null)
                throw new ArgumentNullException("workingDirectory");
            if (!workingDirectory.Exists)
                throw new ArgumentException("Boo", "workingDirectory");

            this._workingDirectory = workingDirectory;
        }

        public virtual void WriteAllText(int id, string message)
        {
            var path = GetFileInfo(id).FullName;

            File.WriteAllText(path, message);
        }

        public virtual Maybe<string> ReadAllext(int id)
        {
            var path = GetFileInfo(id);

            if (!path.Exists)
                return new Maybe<string>();

            var file = File.ReadAllText(path.FullName);

            return new Maybe<string>(file);
        }

        public virtual FileInfo GetFileInfo(int id)
        {
            return new FileInfo(
                Path.Combine(_workingDirectory.FullName, id + ".txt"));
        }
    }
}
