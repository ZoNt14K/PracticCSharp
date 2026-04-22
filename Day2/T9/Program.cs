using System;
using System.Text;

class Program
{
    static void Main()
    {
        StringBuilder sb = new StringBuilder("мир!");

        Console.WriteLine($"До вставки: {sb}");

        string prefix = "Привет, ";
        sb.Insert(0, prefix);

        Console.WriteLine($"После вставки: {sb}");

        int year = 2026;
        sb.Insert(0, year + " год: ");
        
        Console.WriteLine($"Еще одна вставка в начало: {sb}");
    }
}