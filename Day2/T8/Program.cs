using System;
using System.Linq;

class Program
{
    static void Main()
    {
        Console.WriteLine("Введите строку для проверки на палиндром:");
        string input = Console.ReadLine();

        string cleanString = input.Replace(" ", "").ToLower();

        bool isPalindrome = CheckPalindrome(cleanString);

        if (isPalindrome)
        {
            Console.WriteLine("Результат: Строка является палиндромом.");
        }
        else
        {
            Console.WriteLine("Результат: Строка НЕ является палиндромом.");
        }
    }

    static bool CheckPalindrome(string str)
    {
        if (string.IsNullOrEmpty(str)) return true;

        int left = 0;
        int right = str.Length - 1;

        while (left < right)
        {
            if (str[left] != str[right])
            {
                return false;
            }
            left++;
            right--;
        }

        return true;
    }
}