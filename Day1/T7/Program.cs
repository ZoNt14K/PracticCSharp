using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Результат цикла for:");
        for (int i = 1; i <= 101; i += 2)
        {
            Console.Write(i + " ");
        }
        Console.WriteLine("\n");

        Console.WriteLine("Результат цикла while:");
        int j = 1;
        while (j <= 101)
        {
            Console.Write(j + " ");
            j += 2;
        }
        Console.WriteLine("\n");

        Console.WriteLine("Результат цикла do...while:");
        int k = 1;
        do
        {
            Console.Write(k + " ");
            k += 2;
        } while (k <= 101);
        Console.WriteLine("\n");

        Console.WriteLine("Программа завершена. Нажмите любую клавишу...");
        Console.ReadKey();
    }
}