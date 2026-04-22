using System;

class Program
{
    static void Main()
    {
        double x = 3.5;

        double cosX = Math.Cos(x);
        double term1 = Math.Pow(cosX, 2);

        double numerator = Math.Sqrt(Math.Pow(x, 3)) + 1;

        double denominator = Math.Sin(x) + Math.Exp(Math.Log(2 * x));

        double y = term1 - (numerator / denominator);

        Console.WriteLine($"При x = {x}");
        Console.WriteLine($"Значение y = {y:F4}");

        Console.ReadKey();
    }
}