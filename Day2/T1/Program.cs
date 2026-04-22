using System;

class Program
{
    static void Main()
    {
        const int size = 15;
        int[] arr = new int[size];
        Random rand = new Random();

        Console.WriteLine("Исходный массив:");
        for (int i = 0; i < size; i++)
        {
            arr[i] = rand.Next(1, 101);
            Console.Write(arr[i] + " ");
        }

        int maxIndex = 0;
        for (int i = 1; i < size; i++)
        {
            if (arr[i] > arr[maxIndex])
            {
                maxIndex = i;
            }
        }

        Console.WriteLine($"\n\nНаибольший элемент: {arr[maxIndex]} (находится на позиции {maxIndex})");

        (arr[0], arr[maxIndex]) = (arr[maxIndex], arr[0]);

        Console.WriteLine("Массив после перестановки:");
        foreach (var item in arr)
        {
            Console.Write(item + " ");
        }
    }
}