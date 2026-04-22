using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Определение расстояния между двумя точками M1(x1, y1) и M2(x2, y2)");

        Console.Write("Введите x1: ");
        double x1 = double.Parse(Console.ReadLine());
        Console.Write("Введите y1: ");
        double y1 = double.Parse(Console.ReadLine());

        Console.Write("Введите x2: ");
        double x2 = double.Parse(Console.ReadLine());
        Console.Write("Введите y2: ");
        double y2 = double.Parse(Console.ReadLine());

        double dx = x2 - x1;
        double dy = y2 - y1;

        double d = Math.Sqrt(Math.Pow(dx, 2) + Math.Pow(dy, 2));

        Console.WriteLine($"\nРасстояние между точками: {d:F3}");

        Console.WriteLine("\nНажмите любую клавишу для выхода...");
        Console.ReadKey();
    }
}