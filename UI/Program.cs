using FileStore;

namespace UI;

public static class Program
{
    private const string Directory = "C:\\Users\\Andre\\Desktop";

    public static void Main(string[] args)
    {
        var logger = new Logger();
        var fileStorage = new FileStore.FileStore(
            new FileLocator(
                new DirectoryInfo(Directory)));
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