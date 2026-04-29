using System;
using System.IO;

public class FileWatcher
{
    private readonly FileSystemWatcher _watcher;

    public FileWatcher(string folderPath)
    {
        Directory.CreateDirectory(folderPath);

        _watcher = new FileSystemWatcher(folderPath)
        {
            NotifyFilter = NotifyFilters.FileName,
            Filter       = "*.*",
            EnableRaisingEvents = false
        };

        _watcher.Created += OnCreated;
        _watcher.Deleted += OnDeleted;
    }

    public void Start()
    {
        _watcher.EnableRaisingEvents = true;
        Console.WriteLine($"Отслеживание запущено: {_watcher.Path}");
    }

    public void Stop()
    {
        _watcher.EnableRaisingEvents = false;
        Console.WriteLine("Отслеживание остановлено.");
    }

    private void OnCreated(object sender, FileSystemEventArgs e)
    {
        Console.WriteLine($"Файл {e.Name} создан");
    }

    private void OnDeleted(object sender, FileSystemEventArgs e)
    {
        Console.WriteLine($"Файл {e.Name} удален");
    }
}

class Program
{
    static void Main()
    {
        string watchDir = Path.Combine(Path.GetTempPath(), "WatcherDemo");

        var watcher = new FileWatcher(watchDir);
        watcher.Start();

        Console.WriteLine("Нажмите Enter для завершения...\n");

        string testFile = Path.Combine(watchDir, "test.txt");
        File.WriteAllText(testFile, "содержимое");
        System.Threading.Thread.Sleep(300);
        File.Delete(testFile);
        System.Threading.Thread.Sleep(300);

        Console.ReadLine();
        watcher.Stop();
    }
}