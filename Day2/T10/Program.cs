using System;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        Console.Write("Введите строку для проверки: ");
        string input = Console.ReadLine();

        string pattern = @"^\d+$";

        if (Regex.IsMatch(input, pattern))
        {
            Console.WriteLine("Результат: Строка состоит только из цифр.");
        }
        else
        {
            Console.WriteLine("Результат: В строке есть посторонние символы или она пуста.");
        }
    }
}