namespace FileStore
{
    class Program
    {
        static void Main(string[] args)
        {
            var fileStorage = new MessageStore();

            fileStorage.Save(2, "my 2nd message");
            fileStorage.Read(2);
        }
    }
}
