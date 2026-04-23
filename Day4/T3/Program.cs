using System;

class Program
{
    static long Factorial(int n)
    {
        if (n < 0)
        {
            throw new ArgumentException("Факториал не определен для отрицательных чисел.");
        }

        if (n == 0 || n == 1)
        {
            return 1;
        }

        return n * Factorial(n - 1);
    }

    static void Main()
    {
        try
        {
            Console.Write("Введите число для вычисления факториала: ");
            int number = int.Parse(Console.ReadLine());

            long result = Factorial(number);
            Console.WriteLine($"Factorial({number}) → {result}");
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Ошибка: {ex.Message}");
        }
        catch (FormatException)
        {
            Console.WriteLine("Ошибка: Введено не целое число.");
        }
        catch (StackOverflowException)
        {
            Console.WriteLine("Ошибка: Число слишком велико (переполнение стека).");
        }
    }
}