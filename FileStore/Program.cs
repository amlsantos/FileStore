using System.IO;

namespace FileStore
{
    class Program
    {
        static void Main(string[] args)
        {
            var workingDirectory = "C:\\Users\\Andre\\Desktop";
            var fileStorage = new MessageStore(new DirectoryInfo(workingDirectory));

            fileStorage.Save(2, "my 2nd message");

            var message = fileStorage.Read(2);
        }
    }
}
