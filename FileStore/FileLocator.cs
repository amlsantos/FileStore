using System;
using System.IO;

namespace FileStore;

public class FileLocator : IFileLocator
{
    private readonly DirectoryInfo _workingDirectory;

    public FileLocator(DirectoryInfo workingDirectory)
    {
        if (workingDirectory == null)
            throw new ArgumentNullException("workingDirectory");
        if (!workingDirectory.Exists)
            throw new ArgumentException("Boo", "workingDirectory");

        _workingDirectory = workingDirectory;
    }

    public FileInfo GetFileInfo(int id)
    {
        return new FileInfo(
            Path.Combine(_workingDirectory.FullName, id + ".txt")); ;
    }
}