using System;

class Program
{
    static void Main()
    {
        Console.Write("Введите количество строк: ");
        int rows = int.Parse(Console.ReadLine());
        
        Console.Write("Введите количество столбцов (минимум 2): ");
        int cols = int.Parse(Console.ReadLine());

        if (cols < 2)
        {
            Console.WriteLine("Ошибка: в массиве должен быть хотя бы второй столбец.");
            return;
        }

        int[,] matrix = new int[rows, cols];
        Random rand = new Random();

        Console.WriteLine("\nИсходная матрица:");
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                matrix[i, j] = rand.Next(1, 11);
                Console.Write($"{matrix[i, j], 4}");
            }
            Console.WriteLine();
        }

        long product = 1; 
        for (int i = 0; i < rows; i++)
        {
            product *= matrix[i, 1];
        }

        Console.WriteLine($"\nПроизведение элементов второго столбца: {product}");

        long absProduct = Math.Abs(product);
        if (absProduct >= 100 && absProduct <= 999)
        {
            Console.WriteLine("Да, произведение является трехзначным числом.");
        }
        else
        {
            Console.WriteLine("Нет, произведение не является трехзначным числом.");
        }
    }
}