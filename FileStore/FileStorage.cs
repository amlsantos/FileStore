using Serilog;
using System.IO;
using System.Runtime.Caching;

namespace FileStore
{
    public class FileStorage
    {
        public FileStorage(string workingDirectory, MemoryCache cache)
        {
            this.WorkingDirectory = workingDirectory;
            this.Cache = cache;
        }

        public string WorkingDirectory { get; set; }
        public MemoryCache Cache { get; set; }

        public void Save(int id, string message)
        {
            Log.Information("Saving message {id},", id);

            var path = this.GetFileName(id);

            if (!File.Exists(path))
                File.Create(path).Close();

            File.WriteAllText(path, message);

            Cache.Add(new CacheItem(path, message), new CacheItemPolicy());

            Log.Information("Saved message {id},", id);
        }

        public Maybe<string> Read(int id)
        {
            Log.Debug("Reading message {id},", id);

            var path = this.GetFileName(id);

            if (!File.Exists(path))
            {
                Log.Debug("No message {id} found.", id);
                return new Maybe<string>();
            }

            var messageInCache = Cache.GetCacheItem(path);
            var message = (messageInCache == null) ?
                File.ReadAllText(path) :
                messageInCache.Value.ToString();

            Log.Debug("Returning message {id},", id);

            return new Maybe<string>(message);
        }

        public string GetFileName(int id)
        {
            return Path.Combine(this.WorkingDirectory, id + ".txt");
        }
    }
}
