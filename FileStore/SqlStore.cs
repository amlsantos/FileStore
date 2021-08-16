namespace FileStore
{
    public class SqlStore : IStore
    {
        public Maybe<string> ReadAllext(int id)
        {
            // Read and return from database

            return new Maybe<string>();
        }

        public void Save(int id, string message)
        {
            // Write to database
        }
    }
}
