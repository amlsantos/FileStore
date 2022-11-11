using System.IO;

namespace FileStore;

class Program
{
    static void Main(string[] args)
    {
        var logger = new Logger();
        var fileStorage = new FileStore(
            new FileLocator(
                new DirectoryInfo("C:\\Users\\Andre\\Desktop")));
        var cache = new StoreCache(
            fileStorage,
            fileStorage);
        var log = new StoreLogger(
            logger,
            cache,
            cache);
        var msgStore = new MessageStore(
            log,
            log,
            fileStorage);

        msgStore.Save(1, "my 1rst message");
        var msg = msgStore.Read(1);
    }
}