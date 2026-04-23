using System;

public class MathUtils
{
    public static long CalculateFactorial(int n)
    {
        if (n < 0)
        {
            throw new ArgumentException("Число должно быть неотрицательным.");
        }

        long result = 1;
        for (int i = 1; i <= n; i++)
        {
            result *= i;
        }
        return result;
    }

    public static void Main(string[] args)
    {
        int number = 5;
        long fact = MathUtils.CalculateFactorial(number);

        Console.WriteLine($"Факториал {number} равен: {fact}");
    }
}