namespace FileStore
{
    class Program
    {
        static void Main(string[] args)
        {
            var workingDirectory = "C:\\Users\\Andre\\Desktop";
            var fileStorage = new FileStorage(workingDirectory);

            fileStorage.Save(12, "message");
        }
    }
}
