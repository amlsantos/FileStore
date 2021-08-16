using System;

namespace FileStore
{
    public class ToConsoleSavingStoreWriter : IStoreWriter
    {
        public void Save(int id, string message) => Console.WriteLine($"Saving {message} {id}", message, id);
    }
}
