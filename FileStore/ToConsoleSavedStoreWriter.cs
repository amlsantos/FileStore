using System;

namespace FileStore
{
    public class ToConsoleSavedStoreWriter : IStoreWriter
    {
        public void Save(int id, string message) => Console.WriteLine($"Saved {message} {id}", message, id);
    }
}
