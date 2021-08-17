namespace FileStore
{
    public class SqlStore : IStore
    {
        public Maybe<string> Read(int id)
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
