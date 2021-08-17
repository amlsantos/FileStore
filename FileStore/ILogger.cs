namespace FileStore
{
    public interface ILogger
    {
        public void Saving(int id, string message);
        public void Saved(int id, string message);
        public void Reading(int id);
        public void DidNotFound(int id);
        public void Returning(int id);
    }
}
