using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Программа расчета по двум формулам");
        Console.Write("Введите значение угла alpha (в градусах): ");
        
        if (double.TryParse(Console.ReadLine(), out double alphaDegrees))
        {
            double alpha = alphaDegrees * Math.PI / 180.0;

            double numerator1 = Math.Sin(Math.PI / 2.0 + 3 * alpha);
            double denominator1 = 1 - Math.Sin(3 * alpha - Math.PI);
            double z1 = numerator1 / denominator1;

            double angle2 = (5.0 / 4.0) * Math.PI + (3.0 / 2.0) * alpha;
            double z2 = 1.0 / Math.Tan(angle2);

            Console.WriteLine($"\nРезультаты для alpha = {alphaDegrees}°:");
            Console.WriteLine($"z1 = {z1:F4}");
            Console.WriteLine($"z2 = {z2:F4}");

            if (Math.Abs(z1 - z2) < 0.0001)
            {
                Console.WriteLine("\nРезультаты совпадают.");
            }
            else
            {
                Console.WriteLine("\nРезультаты различаются.");
            }
        }
        else
        {
            Console.WriteLine("Ошибка: введено некорректное число.");
        }
    }
}