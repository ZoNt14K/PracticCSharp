using System;

class Program
{
    static void Main()
    {
        Console.Write("Введите размер матрицы N (N < 10): ");
        if (!int.TryParse(Console.ReadLine(), out int n) || n >= 10 || n <= 0)
        {
            Console.WriteLine("Ошибка: N должно быть целым числом от 1 до 9.");
            return;
        }

        Console.Write("Введите начало диапазона a: ");
        int a = int.Parse(Console.ReadLine());

        Console.Write("Введите конец диапазона b: ");
        int b = int.Parse(Console.ReadLine());

        int[,] matrix = new int[n, n];
        Random rand = new Random();

        Console.WriteLine("\nИсходная матрица:");
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                matrix[i, j] = rand.Next(a, b + 1);
                Console.Write($"{matrix[i, j], 5}");
            }
            Console.WriteLine();
        }

        int positiveCount = 0;
        Console.WriteLine("\nРезультаты вычислений:");

        for (int i = 0; i < n; i++)
        {
            int rowSum = 0;
            for (int j = 0; j < n; j++)
            {
                if (matrix[i, j] > 0)
                {
                    positiveCount++;
                }

                rowSum += matrix[i, j];
            }
            Console.WriteLine($"Сумма элементов в строке {i + 1}: {rowSum}");
        }

        Console.WriteLine($"\nОбщее количество положительных чисел: {positiveCount}");
    }
}