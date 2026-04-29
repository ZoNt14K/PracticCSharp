using System;
using System.Collections.Generic;
using System.IO;

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
}

public class UserFileWriter
{
    private readonly string _path;

    public UserFileWriter(string path)
    {
        _path = path;
    }

    public void WriteUsers(List<User> users)
    {
        using var writer = new StreamWriter(_path, append: false);
        foreach (var user in users)
            writer.WriteLine($"{user.Name},{user.Age},{user.Email}");
    }
}

class Program
{
    static void Main()
    {
        var users = new List<User>
        {
            new User("Иван",  25, "ivan@example.com"),
            new User("Ольга", 30, "olga@example.com"),
            new User("Пётр",  22, "petr@example.com"),
        };

        var writer = new UserFileWriter("file.data");
        writer.WriteUsers(users);

        Console.WriteLine("Файл записан. Содержимое file.data:");
        Console.WriteLine(File.ReadAllText("file.data"));
    }
}