namespace FileStore
{
    public interface IStore
    {
        public Maybe<string> ReadAllext(int id);
        public void WriteAllText(int id, string message);
    }
}