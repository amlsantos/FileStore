namespace FileStore;

public class CompositeStoreWriter : IStoreWriter
{
    private readonly IStoreWriter[] _writers;

    public CompositeStoreWriter(params IStoreWriter[] writers)
    {
        _writers = writers;
    }

    public void Save(int id, string message)
    {
        foreach (var writer in _writers)
        {
            writer.Save(id, message);
        }
    }
}