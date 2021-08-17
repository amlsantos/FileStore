namespace FileStore
{
    public interface IStore
    {
        public void Save(int id, string message);
        public Maybe<string> Read(int id);
    }
}