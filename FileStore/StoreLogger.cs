using Serilog;
using System.Linq;

namespace FileStore
{
    public class StoreLogger : IStoreLogger, IStoreWriter, IStoreReader
    {
        private readonly IStoreWriter _writer;
        private readonly IStoreReader _reader;

        public StoreLogger(IStoreWriter writer, IStoreReader reader)
        {
            _writer = writer;
            _reader = reader;
        }

        public void Save(int id, string message)
        {
            Saving(id, message);
            _writer.Save(id, message);
            Saved(id, message);
        }

        public Maybe<string> Read(int id)
        {
            Reading(id);

            var result = _reader.Read(id);
            if (result.Any())
                Returning(id);
            else
                DidNotFound(id);

            return result;
        }

        public virtual void Saving(int id, string message)
        {
            Log.Information("Saving {message} {id}.", message, id);
        }

        public virtual void Saved(int id, string message)
        {
            Log.Information("Saved {message} {id}.", message, id);
        }

        public virtual void Reading(int id)
        {
            Log.Information("Reading message {id}.", id);
        }

        public virtual void DidNotFound(int id)
        {
            Log.Information("No message {id} found.", id);
        }

        public virtual void Returning(int id)
        {
            Log.Information("Returning message {id}.", id);
        }
    }
}
