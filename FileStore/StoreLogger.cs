using Serilog;

namespace FileStore
{
    public class StoreLogger
    {
        public void Saving(int id)
        {
            Log.Information("Saving message {id}.", id);
        }

        public void Saved(int id)
        {
            Log.Information("Saved message {id}.", id);
        }

        public void Reading(int id)
        {
            Log.Information("Reading message {id}.", id);
        }

        public void DidNotFound(int id)
        {
            Log.Information("No message {id} found.", id);
        }

        public void Returning(int id)
        {
            Log.Information("Returning message {id}.", id);
        }
    }
}
