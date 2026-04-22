using System;

class Program
{
    static void Main()
    {
        Console.Write("Введите натуральное число: ");
        string input = Console.ReadLine();

        if (long.TryParse(input, out long number) && number >= 0)
        {
            if (number == 0)
            {
                Console.WriteLine("Max: 0, Min: 0");
                return;
            }

            long maxDigit = -1;
            long minDigit = 10;

            while (number > 0)
            {
                long currentDigit = number % 10;

                if (currentDigit > maxDigit) maxDigit = currentDigit;

                if (currentDigit < minDigit) minDigit = currentDigit;

                number /= 10;
            }

            Console.WriteLine($"Наибольшая цифра: {maxDigit}");
            Console.WriteLine($"Наименьшая цифра: {minDigit}");
        }
        else
        {
            Console.WriteLine("Ошибка: введите корректное натуральное число.");
        }
    }
}