using System;
using System.IO;

public class FileManager
{
    public void CreateWriteRead(string path, string text)
    {
        File.WriteAllText(path, text);
        Console.WriteLine("[1] Файл создан. Содержимое:");
        Console.WriteLine(File.ReadAllText(path));
    }

    public void SafeDelete(string path)
    {
        if (File.Exists(path))
        {
            File.Delete(path);
            Console.WriteLine($"[2] Файл удалён: {path}");
        }
        else
        {
            Console.WriteLine($"[2] Файл не найден, удаление пропущено: {path}");
        }
    }

    public void CopyFile(string source, string destination)
    {
        File.Copy(source, destination, overwrite: true);
        Console.WriteLine($"[4] Файл скопирован: {destination}");
        Console.WriteLine($"    Копия существует: {File.Exists(destination)}");
    }

    public void MoveFile(string source, string destDir)
    {
        Directory.CreateDirectory(destDir);
        string destination = Path.Combine(destDir, Path.GetFileName(source));
        File.Move(source, destination, overwrite: true);
        Console.WriteLine($"[5] Файл перемещён в: {destination}");
    }

    public void RenameToIo(string path)
    {
        string dir       = Path.GetDirectoryName(path) ?? ".";
        string nameNoExt = Path.GetFileNameWithoutExtension(path);
        string newPath   = Path.Combine(dir, nameNoExt + ".io");
        File.Move(path, newPath, overwrite: true);
        Console.WriteLine($"[6] Файл переименован: {path} → {newPath}");
    }

    public void DeleteNonExistent(string path)
    {
        try
        {
            if (!File.Exists(path))
                throw new FileNotFoundException($"Файл не найден: {path}");
            File.Delete(path);
        }
        catch (FileNotFoundException ex)
        {
            Console.WriteLine($"[7] Ошибка: {ex.Message}");
        }
    }

    public void DeleteByExtension(string dir, string extension)
    {
        string[] files = Directory.GetFiles(dir, $"*{extension}");
        foreach (string f in files)
        {
            File.Delete(f);
            Console.WriteLine($"[9] Удалён: {f}");
        }
        Console.WriteLine($"[9] Итого удалено файлов: {files.Length}");
    }

    public void ListFiles(string dir)
    {
        Console.WriteLine($"[10] Файлы в '{dir}':");
        foreach (string f in Directory.GetFiles(dir))
            Console.WriteLine($"     {Path.GetFileName(f)}");
    }

    public void DenyWriteThenTry(string path)
    {
        if (!File.Exists(path)) File.WriteAllText(path, "исходный текст");

        File.SetAttributes(path, FileAttributes.ReadOnly);
        Console.WriteLine("[11] Файл переведён в режим «только чтение».");

        try
        {
            File.WriteAllText(path, "новый текст");
        }
        catch (UnauthorizedAccessException ex)
        {
            Console.WriteLine($"[11] Ожидаемая ошибка записи: {ex.Message}");
        }
        finally
        {
            File.SetAttributes(path, FileAttributes.Normal);
        }
    }
}

public class FileInfoProvider
{
    public void PrintInfo(string path)
    {
        var fi = new FileInfo(path);
        Console.WriteLine("[3] Информация о файле:");
        Console.WriteLine($"    Имя           : {fi.Name}");
        Console.WriteLine($"    Размер        : {fi.Length} байт");
        Console.WriteLine($"    Дата создания : {fi.CreationTime:dd.MM.yyyy HH:mm:ss}");
        Console.WriteLine($"    Последнее изм.: {fi.LastWriteTime:dd.MM.yyyy HH:mm:ss}");
        Console.WriteLine($"    Только чтение : {fi.IsReadOnly}");
    }

    public void CompareBySize(string path1, string path2)
    {
        long size1 = new FileInfo(path1).Length;
        long size2 = new FileInfo(path2).Length;
        Console.WriteLine("[8] Сравнение файлов по размеру:");
        Console.WriteLine($"    {Path.GetFileName(path1)}: {size1} байт");
        Console.WriteLine($"    {Path.GetFileName(path2)}: {size2} байт");

        if (size1 > size2)
            Console.WriteLine($"    Больше: {Path.GetFileName(path1)}");
        else if (size1 < size2)
            Console.WriteLine($"    Больше: {Path.GetFileName(path2)}");
        else
            Console.WriteLine("    Файлы одинакового размера.");
    }

    public void CheckPermissions(string path)
    {
        Console.WriteLine("[12] Права доступа к файлу:");

        bool canRead = false;
        try { using var _ = File.OpenRead(path); canRead = true; } catch { }
        Console.WriteLine($"    Чтение  : {(canRead  ? "разрешено" : "запрещено")}");

        bool canWrite = false;
        try { using var _ = File.OpenWrite(path); canWrite = true; } catch { }
        Console.WriteLine($"    Запись  : {(canWrite ? "разрешено" : "запрещено")}");

        bool readOnly = (File.GetAttributes(path) & FileAttributes.ReadOnly) != 0;
        Console.WriteLine($"    ReadOnly: {(readOnly ? "да" : "нет")}");
    }
}

class Program
{
    static void Main()
    {
        string workDir  = Path.Combine(Path.GetTempPath(), "FileOpsDemo");
        Directory.CreateDirectory(workDir);

        string iaFile   = Path.Combine(workDir, "lukovski.ia");
        string copyFile = Path.Combine(workDir, "lukovski_copy.ia");
        string moveDir  = Path.Combine(workDir, "moved");

        var fm  = new FileManager();
        var fip = new FileInfoProvider();

        Console.WriteLine("══════════════════════════════════════════════════\n");

        fm.CreateWriteRead(iaFile, "Привет! Это тестовый файл.\nСтрока два.");
        Console.WriteLine();

        fip.PrintInfo(iaFile);
        Console.WriteLine();

        fm.CopyFile(iaFile, copyFile);
        Console.WriteLine();

        fip.CompareBySize(iaFile, copyFile);
        Console.WriteLine();

        fm.DenyWriteThenTry(iaFile);
        Console.WriteLine();

        fip.CheckPermissions(iaFile);
        Console.WriteLine();

        fm.MoveFile(copyFile, moveDir);
        Console.WriteLine();

        fm.RenameToIo(iaFile);
        Console.WriteLine();

        fm.ListFiles(workDir);
        Console.WriteLine();

        fm.DeleteNonExistent(Path.Combine(workDir, "ghost.ia"));
        Console.WriteLine();

        fm.SafeDelete(Path.Combine(moveDir, "lukovski_copy.ia"));
        Console.WriteLine();

        File.WriteAllText(Path.Combine(workDir, "a.ia"), "a");
        File.WriteAllText(Path.Combine(workDir, "b.ia"), "b");
        File.WriteAllText(Path.Combine(workDir, "c.ia"), "c");

        fm.DeleteByExtension(workDir, ".ia");

        Console.WriteLine("\n══════════════════════════════════════════════════");
        Console.WriteLine("Все задания выполнены.");
    }
}