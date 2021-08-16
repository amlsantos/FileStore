using System.IO;
using System.Linq;

namespace FileStore
{
    public class MessageStore
    {
        public void Save(int id, string message)
        {
            Logger.Saving(id);
            Store.WriteAllText(id, message);
            Cache.AddOrUpdate(id, message);
            Logger.Saved(id);
        }

        public Maybe<string> Read(int id)
        {
            Logger.Reading(id);
            var message = Cache.GetOrAdd(id,
                _ => Store.ReadAllext(id));

            if (message.Any())
                Logger.Returning(id);
            else
                Logger.DidNotFound(id);

            return message;
        }

        protected virtual IStore Store
        {
            get { return new FileStore(FileLocator); }
        }

        protected virtual IStoreCache Cache
        {
            get { return new StoreCache(); }
        }

        protected virtual StoreLogger Logger
        {
            get { return new DebugStoreLogger(); }
        }

        protected virtual IFileLocator FileLocator
        {
            get { return new FileLocator(new DirectoryInfo("C:\\Users\\Andre\\Desktop")); }
        }
    }
}
