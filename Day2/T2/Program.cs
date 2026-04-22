using System;

class Program
{
    static void Main()
    {
        int[] numbers = new int[100];
        Random rand = new Random();

        for (int i = 0; i < numbers.Length; i++)
        {
            numbers[i] = rand.Next(1, 201);
        }

        Console.WriteLine("Массив в обратном порядке (по 6 чисел):");
        int count = 0;
        for (int i = numbers.Length - 1; i >= 0; i--)
        {
            Console.Write($"{numbers[i], 4} ");
            count++;
            if (count % 6 == 0) Console.WriteLine();
        }
        Console.WriteLine("\n");

        Array.Sort(numbers);
        Console.WriteLine("Массив отсортирован для поиска.");

        Console.Write("Введите число k для поиска: ");
        if (int.TryParse(Console.ReadLine(), out int k))
        {
            int resultIndex = BinarySearch(numbers, k);

            if (resultIndex != -1)
                Console.WriteLine($"Число {k} найдено в отсортированном массиве на индексе: {resultIndex}");
            else
                Console.WriteLine($"Число {k} в массиве не найдено.");
        }
    }

    static int BinarySearch(int[] array, int target)
    {
        int left = 0;
        int right = array.Length - 1;

        while (left <= right)
        {
            int mid = left + (right - left) / 2;

            if (array[mid] == target)
                return mid;
            
            if (array[mid] < target)
                left = mid + 1;
            else
                right = mid - 1;
        }

        return -1;
    }
}