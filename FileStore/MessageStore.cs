using System.IO;

namespace FileStore
{
    public class MessageStore
    {
        private readonly IStoreCache _cache;
        private readonly IStoreLogger _log;
        private readonly IStore _store;
        private readonly IFileLocator _fileLocator;
        private readonly IStoreWriter _writer;
        private readonly IStoreReader _reader;

        public MessageStore(DirectoryInfo workingDirectory)
        {
            WorkingDirectory = workingDirectory;

            var fileStore = new FileStore(new FileLocator(workingDirectory));
            var c = new StoreCache(fileStore, fileStore);
            _cache = c;
            var l = new StoreLogger(c, c);
            _log = l;
            _store = fileStore;
            _fileLocator = fileStore;
            _reader = l;
            _writer = l;
        }

        public void Save(int id, string message)
        {
            _writer.Save(id, message);
        }

        public Maybe<string> Read(int id)
        {
            return _reader.Read(id);
        }

        protected DirectoryInfo WorkingDirectory { get; }

        public virtual IStore Store
        {
            get { return _store; }
        }

        protected virtual IStoreCache Cache
        {
            get { return _cache; }
        }

        protected virtual IStoreLogger Log
        {
            get { return _log; }
        }

        protected virtual IFileLocator FileLocator
        {
            get { return _fileLocator; }
        }

        public virtual IStoreWriter Writer
        {
            get { return _writer; }
        }

        public IStoreReader Reader
        {
            get { return _reader; }
        }
    }
}
