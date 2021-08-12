using System;
using System.Collections.Concurrent;
using System.IO;

namespace FileStore
{
    public class FileStorage
    {
        private readonly ConcurrentDictionary<int, string> cache;
        private readonly StoreLogger log;

        public FileStorage(DirectoryInfo workingDirectory)
        {
            if (workingDirectory == null)
                throw new ArgumentNullException("workingDirectory");
            if (!workingDirectory.Exists)
                throw new ArgumentException("Boo", "workingDirectory");

            this.WorkingDirectory = workingDirectory;
            this.cache = new ConcurrentDictionary<int, string>();
            this.log = new StoreLogger();
        }

        public DirectoryInfo WorkingDirectory { get; set; }

        public void Save(int id, string message)
        {
            this.log.Saving(id);
            var file = this.GetFileInfo(id);
            File.WriteAllText(file.FullName, message);
            this.cache.AddOrUpdate(id, message, (i, m) => message);
            this.log.Saved(id);
        }

        public Maybe<string> Read(int id)
        {
            log.Reading(id);
            var file = this.GetFileInfo(id);

            if (!file.Exists)
            {
                this.log.DidNotFound(id);
                return new Maybe<string>();
            }

            var message = this.cache
                .GetOrAdd(id, _ => File.ReadAllText(file.FullName));
            this.log.Returning(id);
            return new Maybe<string>(message);
        }

        public DirectoryInfo GetFileInfo(int id)
        {
            return new DirectoryInfo(
                Path.Combine(
                    this.WorkingDirectory.FullName,
                    id + ".txt"));
        }
    }
}
