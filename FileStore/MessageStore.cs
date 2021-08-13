using System;
using System.IO;

namespace FileStore
{
    public class MessageStore
    {
        private readonly StoreCache cache;
        private readonly StoreLogger log;
        private readonly FileStore fileStore;

        public MessageStore(DirectoryInfo workingDirectory)
        {
            if (workingDirectory == null)
                throw new ArgumentNullException("workingDirectory");
            if (!workingDirectory.Exists)
                throw new ArgumentException("Boo", "workingDirectory");

            this.WorkingDirectory = workingDirectory;
            this.cache = new StoreCache();
            this.log = new StoreLogger();
            this.fileStore = new FileStore();
        }

        public DirectoryInfo WorkingDirectory { get; set; }

        public void Save(int id, string message)
        {
            this.log.Saving(id);
            var file = this.fileStore.GetFileInfo(id, WorkingDirectory.FullName);
            this.fileStore.WriteAllText(file.FullName, message);
            this.cache.AddOrUpdate(id, message);
            this.log.Saved(id);
        }

        public Maybe<string> Read(int id)
        {
            log.Reading(id);
            var file = this.fileStore.GetFileInfo(id, WorkingDirectory.FullName);
            if (!file.Exists)
            {
                this.log.DidNotFound(id);
                return new Maybe<string>();
            }

            var message = this.cache.GetOrAdd(id, _ =>
                this.fileStore.ReadAllext(file.FullName));
            this.log.Returning(id);
            return new Maybe<string>(message);
        }
    }
}
