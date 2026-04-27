public class User
{
    public int Id { get; set; }
    public string Name { get; set; }
    public override string ToString() => $"ID: {Id}, Name: {Name}";
}

class Program
{
    static void Main()
    {
        var userRepo = new MemoryRepository<User>();

        var manager = new RepositoryManager<User>(userRepo);

        manager.Add(new User { Id = 1, Name = "Alice" });
        manager.Add(new User { Id = 2, Name = "Bob" });
        manager.Add(new User { Id = 3, Name = "Charlie" });

        User found = manager.Find(u => u.Name.StartsWith("B"));
        Console.WriteLine($"Результат поиска: {found}\n");

        manager.DisplayAll();
    }
}