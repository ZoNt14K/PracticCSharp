public class Product
{
    public string Name { get; set; }
    public decimal Price { get; set; }

    public override string ToString() => $"{Name} — {Price} руб.";
}

class Program
{
    static void Main()
    {
        ListManager<Product> manager = new ListManager<Product>();

        manager.AddItem(new Product { Name = "Laptop", Price = 1500 });
        manager.AddItem(new Product { Name = "Mouse", Price = 25 });
        manager.AddItem(new Product { Name = "Keyboard", Price = 100 });

        Console.WriteLine("До сортировки:");
        manager.PrintAll();

        manager.SortItems((p1, p2) => p1.Price.CompareTo(p2.Price));

        Console.WriteLine("\nПосле сортировки по цене:");
        manager.PrintAll();

        var expensive = manager.FindFirstMatch(p => p.Price > 1000);
        Console.WriteLine($"\nНайден дорогой товар: {expensive?.Name}");
    }
}