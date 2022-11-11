using Serilog;

namespace FileStore;

public class Logger : ILogger
{
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