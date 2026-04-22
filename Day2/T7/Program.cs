using System;

class Program
{
    static void Main()
    {
        Console.Write("Введите первую строку: ");
        string str1 = Console.ReadLine();

        Console.Write("Введите вторую строку: ");
        string str2 = Console.ReadLine();

        string result = string.Concat(str1, " ", str2);

        Console.WriteLine("\nРезультат соединения:");
        Console.WriteLine(result);

        string[] words = { "Программирование", "на", "C#", "—", "это", "интересно!" };
        string sentence = string.Concat(words);
        Console.WriteLine("\nПример из массива:");
        Console.WriteLine(sentence);
    }
}