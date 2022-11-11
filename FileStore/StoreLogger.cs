using System.Linq;

namespace FileStore;

public class StoreLogger : IStoreWriter, IStoreReader
{
    private readonly ILogger _logger;
    private readonly IStoreWriter _writer;
    private readonly IStoreReader _reader;

    public StoreLogger(
        ILogger logger,
        IStoreWriter writer,
        IStoreReader reader
    )
    {
        _logger = logger;
        _writer = writer;
        _reader = reader;
    }

    public void Save(int id, string message)
    {
        _logger.Saving(id, message);
        _writer.Save(id, message);
        _logger.Saved(id, message);
    }

    public Maybe<string> Read(int id)
    {
        _logger.Reading(id);

        var result = _reader.Read(id);
        if (result.Any())
            _logger.Returning(id);
        else
            _logger.DidNotFound(id);

        return result;
    }
}