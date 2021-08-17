using System.IO;

namespace FileStore
{
    class Program
    {
        static void Main(string[] args)
        {
            var fileStorage = new MessageStore(new DirectoryInfo("C:\\Users\\Andre\\Desktop"));

            fileStorage.Save(2, "my 2nd message");
            fileStorage.Read(2);
        }
    }
}
