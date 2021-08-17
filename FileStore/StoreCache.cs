using System.Collections.Concurrent;
using System.Linq;

namespace FileStore
{
    public class StoreCache : IStoreCache, IStoreWriter, IStoreReader
    {
        private readonly ConcurrentDictionary<int, Maybe<string>> _cache;
        private readonly IStoreWriter _writer;
        private readonly IStoreReader _reader;

        public StoreCache(IStoreWriter writer, IStoreReader reader)
        {
            this._cache = new ConcurrentDictionary<int, Maybe<string>>();
            this._writer = writer;
            this._reader = reader;
        }

        public virtual void Save(int id, string message)
        {
            _writer.Save(id, message);
            var m = new Maybe<string>(message);
            _cache.AddOrUpdate(id, m, (i, s) => m);
        }

        public virtual Maybe<string> Read(int id)
        {
            Maybe<string> result;

            if (_cache.TryGetValue(id, out result))
                return result;

            result = _reader.Read(id);
            if (result.Any())
                _cache.AddOrUpdate(id, result, (i, s) => result);

            return result;
        }
    }
}
