using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Введите коэффициенты A, B и C:");
        double a = double.Parse(Console.ReadLine());
        double b = double.Parse(Console.ReadLine());
        double c = double.Parse(Console.ReadLine());

        double d = Math.Pow(b, 2) - 4 * a * c;

        bool hasRealRoots = d >= 0;

        if (hasRealRoots)
        {
            Console.WriteLine("Истина: уравнение имеет вещественные корни.");
        }
        else
        {
            Console.WriteLine("Ложь: уравнение не имеет вещественных корней.");
        }
    }
}