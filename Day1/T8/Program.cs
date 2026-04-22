using System;

class Program
{
    static void Main()
    {
        Console.Write("Введите целое число N (1 <= N <= 10): ");
        if (int.TryParse(Console.ReadLine(), out int n) && n >= 1 && n <= 10)
        {
            long sum = 0;

            for (int i = n; i <= 2 * n; i++)
            {
                sum += (long)i * i;
            }
            Console.WriteLine($"Результат: {sum}");
        }
        else
        {
            Console.WriteLine("Ошибка: введите число от 1 до 10.");
        }
    }
}