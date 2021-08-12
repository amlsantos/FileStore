using System.Runtime.Caching;

namespace FileStore
{
    class Program
    {
        static void Main(string[] args)
        {
            var workingDirectory = "C:\\Users\\Andre\\Desktop";
            var fileStorage = new FileStorage(
                workingDirectory,
                new MemoryCache("FileStorage"));

            fileStorage.Save(1, "my message");

            var message = fileStorage.Read(1);
        }
    }
}
