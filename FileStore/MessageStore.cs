using System;
using System.IO;

namespace FileStore;

public class MessageStore
{
    private readonly IFileLocator _fileLocator;
    private readonly IStoreWriter _writer;
    private readonly IStoreReader _reader;

    public MessageStore(
        IStoreWriter writer,
        IStoreReader reader,
        IFileLocator fileLocator
    )
    {
        if (writer == null)
            throw new ArgumentNullException("writer");
        if (reader == null)
            throw new ArgumentNullException("reader");
        if (fileLocator == null)
            throw new ArgumentNullException("fileLocator");

        _writer = writer;
        _reader = reader;
        _fileLocator = fileLocator;
    }

    public void Save(int id, string message)
    {
        _writer.Save(id, message);
    }

    public Maybe<string> Read(int id)
    {
        return _reader.Read(id);
    }

    public FileInfo GetFileInfo(int id)
    {
        return _fileLocator.GetFileInfo(id);
    }
}