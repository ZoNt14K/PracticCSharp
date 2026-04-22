using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Введите числа K и N через пробел:");
        string[] input = Console.ReadLine().Split();
        
        if (input.Length >= 2)
        {
            int k = int.Parse(input[0]);
            int n = int.Parse(input[1]);

            for (int i = 0; i < n; i++)
            {
                Console.Write(k + " ");
            }
        }
    }
}