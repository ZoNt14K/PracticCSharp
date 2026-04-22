using System;

class Program
{
    static void Main()
    {
        Console.Write("Введите набранное количество баллов (0-100): ");
        
        if (int.TryParse(Console.ReadLine(), out int score))
        {
            if (score < 0 || score > 100)
            {
                Console.WriteLine("Ошибка: баллы должны быть в диапазоне от 0 до 100.");
            }
            else if (score >= 90)
            {
                Console.WriteLine("Оценка: отлично");
            }
            else if (score >= 70)
            {
                Console.WriteLine("Оценка: хорошо");
            }
            else if (score >= 50)
            {
                Console.WriteLine("Оценка: удовлетворительно");
            }
            else
            {
                Console.WriteLine("Оценка: неудовлетворительно");
            }
        }
        else
        {
            Console.WriteLine("Ошибка: введите целое число.");
        }
    }
}