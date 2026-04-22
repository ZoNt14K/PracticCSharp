using System;

class Program
{
    static void Main()
    {
        Console.Write("Введите четырехзначное число: ");
        
        if (int.TryParse(Console.ReadLine(), out int number))
        {
            int n = Math.Abs(number);

            if (n >= 1000 && n <= 9999)
            {
                int d1 = n / 1000;
                int d2 = (n / 100) % 10;
                int d3 = (n / 10) % 10;
                int d4 = n % 10;

                int sum = d1 + d2 + d3 + d4;

                Console.WriteLine($"Цифры числа: {d1}, {d2}, {d3}, {d4}");
                Console.WriteLine($"Сумма цифр: {sum}");
            }
            else
            {
                Console.WriteLine("Ошибка: введено не четырехзначное число.");
            }
        }
    }
}