namespace FileStore;

public interface IStoreWriter
{
    public void Save(int id, string message);
}