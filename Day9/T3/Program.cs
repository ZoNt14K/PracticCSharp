using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public class User
{
    public string Name  { get; set; }
    public int    Age   { get; set; }
    public string Email { get; set; }

    public User(string name, int age, string email)
    {
        Name  = name;
        Age   = age;
        Email = email;
    }

    public override string ToString() => $"{Name}, {Age} лет, {Email}";
}

public class UserFileReader
{
    private readonly string _path;

    public UserFileReader(string path)
    {
        _path = path;
    }

    public List<User> ReadUsers()
    {
        var users = new List<User>();

        foreach (var line in File.ReadLines(_path))
        {
            if (string.IsNullOrWhiteSpace(line)) continue;

            var parts = line.Split(',');
            if (parts.Length != 3) continue;

            if (!int.TryParse(parts[1].Trim(), out int age)) continue;

            users.Add(new User(parts[0].Trim(), age, parts[2].Trim()));
        }

        return users;
    }
}

public class UserProcessor
{
    private readonly List<User> _users;

    public UserProcessor(List<User> users)
    {
        _users = users;
    }

    public User FindUserByEmail(string email)
    {
        return _users.FirstOrDefault(u =>
            string.Equals(u.Email, email, StringComparison.OrdinalIgnoreCase));
    }
}

class Program
{
    static void Main()
    {
        string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "file.data");

        if (!File.Exists(filePath))
        {
            File.WriteAllLines(filePath, new[]
            {
                "Иван,25,ivan@example.com",
                "Ольга,30,olga@example.com",
                "Пётр,22,petr@example.com"
            });
            Console.WriteLine("file.data не найден — создан автоматически.\n");
        }

        var reader = new UserFileReader(filePath);
        var users  = reader.ReadUsers();

        Console.WriteLine($"Загружено пользователей: {users.Count}");
        foreach (var u in users)
            Console.WriteLine($"  {u}");

        Console.WriteLine();

        var processor = new UserProcessor(users);

        string searchEmail = "olga@example.com";
        var found = processor.FindUserByEmail(searchEmail);

        if (found != null)
            Console.WriteLine($"Найден по email «{searchEmail}»: {found}");
        else
            Console.WriteLine($"Пользователь с email «{searchEmail}» не найден.");

        string missingEmail = "ghost@example.com";
        var notFound = processor.FindUserByEmail(missingEmail);

        if (notFound != null)
            Console.WriteLine($"Найден: {notFound}");
        else
            Console.WriteLine($"Пользователь с email «{missingEmail}» не найден.");
    }
}