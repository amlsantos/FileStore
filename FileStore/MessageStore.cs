using System;
using System.IO;

namespace FileStore
{
    public class MessageStore
    {
        public MessageStore(DirectoryInfo workingDirectory)
        {
            if (workingDirectory == null)
                throw new ArgumentNullException("workingDirectory");
            if (!workingDirectory.Exists)
                throw new ArgumentException("Boo", "workingDirectory");

            this.WorkingDirectory = workingDirectory;
        }

        public DirectoryInfo WorkingDirectory { get; set; }

        public void Save(int id, string message)
        {
            Logger.Saving(id);
            var file = Store.GetFileInfo(id, WorkingDirectory.FullName);
            Store.WriteAllText(file.FullName, message);
            Cache.AddOrUpdate(id, message);
            Logger.Saved(id);
        }

        public Maybe<string> Read(int id)
        {
            Logger.Reading(id);
            var file = Store.GetFileInfo(id, WorkingDirectory.FullName);
            if (!file.Exists)
            {
                Logger.DidNotFound(id);
                return new Maybe<string>();
            }

            var message = Cache.GetOrAdd(id, _ => Store.ReadAllext(file.FullName));
            Logger.Returning(id);

            return new Maybe<string>(message);
        }

        protected virtual FileStore Store
        {
            get { return new FileStore(); }
        }

        public virtual StoreCache Cache
        {
            get { return new StoreCache(); }
        }

        public virtual StoreLogger Logger
        {
            get { return new DebugStoreLogger(); }
        }
    }
}
