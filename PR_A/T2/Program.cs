using System;

class Program
{
    static void Main()
    {
        Console.Write("Введите двузначное число: ");

        if (int.TryParse(Console.ReadLine(), out int number))
        {
            int absNumber = Math.Abs(number);
            
            if (absNumber >= 10 && absNumber <= 99)
            {
                int firstDigit = absNumber / 10;

                int lastDigit = absNumber % 10;

                Console.WriteLine($"Первая цифра: {firstDigit}");
                Console.WriteLine($"Последняя цифра: {lastDigit}");
            }
            else
            {
                Console.WriteLine("Ошибка: нужно ввести именно двузначное число.");
            }
        }
    }
}