using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Введите строку для анализа:");
        string input = Console.ReadLine();

        int vowelsCount = 0;
        int consonantsCount = 0;

        string vowels = "аеёиоуыэюя";
        string consonants = "бвгджзйклмнпрстфхцчшщ";

        string lowerInput = input.ToLower();

        foreach (char symbol in lowerInput)
        {
            if (vowels.Contains(symbol))
            {
                vowelsCount++;
            }
            else if (consonants.Contains(symbol))
            {
                consonantsCount++;
            }
        }

        Console.WriteLine($"\nРезультаты анализа:");
        Console.WriteLine($"Гласных букв: {vowelsCount}");
        Console.WriteLine($"Согласных букв: {consonantsCount}");
    }
}