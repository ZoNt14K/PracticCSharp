using System;

class Program
{
    static void Main()
    {
        Console.Write("Введите расстояние в сантиметрах: ");

        if (int.TryParse(Console.ReadLine(), out int centimeters))
        {
            int meters = centimeters / 100;
            
            Console.WriteLine($"Число полных метров: {meters}");
        }
        else
        {
            Console.WriteLine("Ошибка: введите корректное целое число.");
        }
    }
}