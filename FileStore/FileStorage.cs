using System.Collections.Concurrent;
using System.IO;
using System.Runtime.Caching;

namespace FileStore
{
    public class FileStorage
    {
        private readonly ConcurrentDictionary<int, string> cache;
        private readonly StoreLogger log;

        public FileStorage(string workingDirectory)
        {
            this.WorkingDirectory = workingDirectory;
            this.cache = new ConcurrentDictionary<int, string>();
            this.log = new StoreLogger();
        }

        public string WorkingDirectory { get; set; }
        public MemoryCache Cache { get; set; }

        public void Save(int id, string message)
        {
            log.Saving(id);
            var path = this.GetFileName(id);

            if (!File.Exists(path))
                File.Create(path).Close();

            File.WriteAllText(path, message);
            Cache.Add(new CacheItem(path, message), new CacheItemPolicy());
            log.Saved(id);
        }

        public Maybe<string> Read(int id)
        {
            log.Reading(id);
            var path = this.GetFileName(id);

            if (!File.Exists(path))
            {
                log.DidNotFound(id);
                return new Maybe<string>();
            }

            var messageInCache = Cache.GetCacheItem(path);
            var message = (messageInCache == null) ?
                File.ReadAllText(path) :
                messageInCache.Value.ToString();

            log.Returning(id);
            return new Maybe<string>(message);
        }

        public string GetFileName(int id)
        {
            return Path.Combine(this.WorkingDirectory, id + ".txt");
        }
    }
}
