using System;
using System.Linq;

namespace ExtensionMethodsTask
{
    public static class StringExtensions
    {
        public static int CountVowels(this string str)
        {
            if (string.IsNullOrEmpty(str)) return 0;

            char[] vowels = { 'a', 'e', 'i', 'o', 'u', 'y', 'а', 'е', 'ё', 'и', 'о', 'у', 'ы', 'э', 'ю', 'я' };
            
            int count = 0;
            string lowerStr = str.ToLower();

            foreach (char c in lowerStr)
            {
                if (vowels.Contains(c))
                {
                    count++;
                }
            }

            return count;
        }
    }

    class Program
    {
        static void Main()
        {
            string text = "Программирование на C# — это круто!";

            int vowelCount = text.CountVowels();

            Console.WriteLine($"Текст: {text}");
            Console.WriteLine($"Количество гласных: {vowelCount}");

            Console.WriteLine("Hello".CountVowels());
        }
    }
}