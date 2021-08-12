using System.IO;

namespace FileStore
{
    public class FileStorage
    {
        public FileStorage(string workingDirectory)
        {
            this.WorkingDirectory = workingDirectory;
        }

        public string WorkingDirectory { get; set; }

        public void Save(int id, string message)
        {
            var path = this.GetFileName(id);

            if (!File.Exists(path))
                File.Create(path);

            File.WriteAllText(path, message);
        }

        public Maybe<string> Read(int id)
        {
            var path = this.GetFileName(id);

            if (!File.Exists(path))
                return new Maybe<string>();

            var message = File.ReadAllText(path);

            return new Maybe<string>(message);
        }

        public string GetFileName(int id)
        {
            return Path.Combine(this.WorkingDirectory, id + ".txt");
        }
    }
}
