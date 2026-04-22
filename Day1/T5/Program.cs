using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Введите первое вещественное число:");
        double a = double.Parse(Console.ReadLine());

        Console.WriteLine("Введите второе вещественное число:");
        double b = double.Parse(Console.ReadLine());

        if (a > b)
        {
            Console.WriteLine($"Максимальное число: {a}");
        }
        else if (b > a)
        {
            Console.WriteLine($"Максимальное число: {b}");
        }
        else
        {
            Console.WriteLine("Числа равны.");
        }
    }
}