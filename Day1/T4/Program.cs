using System;

class Program
{
    static void Main()
    {
        Console.Write("Введите значение x: ");

        if (double.TryParse(Console.ReadLine(), out double x))
        {
            double y;

            if (x < 1)
            {
                y = 1;
            }
            else if (x >= 1 && x <= 2)
            {
                y = Math.Pow(x, 2) * Math.Log(x);
            }
            else
            {
                y = Math.Exp(2 * x) * Math.Cos(5 * x);
            }

            Console.WriteLine($"При x = {x}, значение y = {y:F4}");
        }
        else
        {
            Console.WriteLine("Ошибка: введено не число.");
        }
    }
}