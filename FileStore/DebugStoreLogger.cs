using System;

namespace FileStore
{
    public class DebugStoreLogger : StoreLogger
    {
        public override void Saving(int id)
        {
            Console.WriteLine($"Saving message {id}.", id);
        }

        public override void Saved(int id)
        {
            Console.WriteLine($"Saved message {id}.", id);
        }

        public override void Reading(int id)
        {
            Console.WriteLine($"Reading message {id}.", id);
        }

        public override void DidNotFound(int id)
        {
            Console.WriteLine($"No message {id} found.", id);
        }

        public override void Returning(int id)
        {
            Console.WriteLine($"Returning message {id}.", id);
        }
    }
}
