using System;

class Program
{
    static void Main()
    {
        Console.Write("Введите первое целое число: ");
        string input1 = Console.ReadLine();
        int a = int.Parse(input1);

        Console.Write("Введите второе целое число: ");
        string input2 = Console.ReadLine();
        int b = int.Parse(input2);

        int sum = a + b;

        Console.WriteLine($"Сумма чисел {a} и {b} равна: {sum}");

        Console.WriteLine("\nНажмите любую клавишу для выхода...");
        Console.ReadKey();
    }
}