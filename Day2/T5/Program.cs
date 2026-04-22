using System;
using System.Linq;

class Program
{
    static void Main()
    {
        int[][] jaggedArray = new int[5][];
        Random rand = new Random();

        for (int i = 0; i < jaggedArray.Length; i++)
        {
            int cols = rand.Next(2, 7);
            jaggedArray[i] = new int[cols];
            
            for (int j = 0; j < cols; j++)
            {
                jaggedArray[i][j] = rand.Next(1, 10); 
            }
        }

        Console.WriteLine("Массив до преобразования:");
        PrintJaggedArray(jaggedArray);

        for (int i = 0; i < jaggedArray.Length; i++)
        {
            int rowSum = 0;
            foreach (int value in jaggedArray[i])
            {
                rowSum += value;
            }

            for (int j = 0; j < jaggedArray[i].Length; j++)
            {
                jaggedArray[i][j] = rowSum;
            }
        }

        Console.WriteLine("\nМассив после заполнения суммами строк:");
        PrintJaggedArray(jaggedArray);
    }

    static void PrintJaggedArray(int[][] array)
    {
        for (int i = 0; i < array.Length; i++)
        {
            Console.Write($"Строка {i}: ");
            foreach (int item in array[i])
            {
                Console.Write($"{item, 4} ");
            }
            Console.WriteLine();
        }
    }
}