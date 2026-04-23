using System;

class Program
{
    static void PowerA3(double A, out double B)
    {
        B = A * A * A;
    }

    static void Main()
    {
        double[] numbers = { 2.0, 3.5, 1.2, 10.0, -4.0 };

        Console.WriteLine("Вычисление третьей степени числа:");
        Console.WriteLine("---------------------------------");

        foreach (double num in numbers)
        {
            double result; 

            PowerA3(num, out result);
            
            Console.WriteLine($"Число: {num, 5} | В кубе: {result, 8}");
        }
    }
}