using System;
using System.Collections.Concurrent;

namespace FileStore
{
    public class StoreCache : IStoreCache
    {
        private readonly ConcurrentDictionary<int, Maybe<string>> _cache;

        public StoreCache()
        {
            this._cache = new ConcurrentDictionary<int, Maybe<string>>();
        }

        public virtual void Save(int id, string message)
        {
            var m = new Maybe<string>(message);

            _cache.AddOrUpdate(id, m, (i, s) => m);
        }

        public virtual Maybe<string> GetOrAdd(int id, Func<int, Maybe<string>> messageFactory)
        {
            return _cache.GetOrAdd(id, messageFactory);
        }
    }
}
