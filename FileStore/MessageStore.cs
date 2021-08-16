using System.IO;
using System.Linq;

namespace FileStore
{
    public class MessageStore : IStoreWriter
    {
        public void Save(int id, string message)
        {
            new ToConsoleSavingStoreWriter().Save(id, message);
            Store.Save(id, message);
            Cache.Save(id, message);
            new ToConsoleSavedStoreWriter().Save(id, message);
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

        protected virtual IStoreLogger Logger
        {
            get { return new ToConsoleStoreLogger(); }
        }

        protected virtual IFileLocator FileLocator
        {
            get { return new FileLocator(new DirectoryInfo("C:\\Users\\Andre\\Desktop")); }
        }
    }
}
