namespace FileStore
{
    public interface IStoreCache
    {
        void Save(int id, string message);
        Maybe<string> Read(int id);
    }
}
