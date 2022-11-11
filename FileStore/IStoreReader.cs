namespace FileStore;

public interface IStoreReader
{
    Maybe<string> Read(int id);
}