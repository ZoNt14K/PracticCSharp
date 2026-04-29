class Program
{
    static void Main()
    {
        int[] data1 = { 5, 2, 8, 1, 9 };
        int[] data2 = { 10, 55, 2, 34, 12 };

        ArraySorter sorter = new ArraySorter(new BubbleSort());
        sorter.SortArray(data1);

        sorter.SetStrategy(new QuickSort());
        sorter.SortArray(data2);
        
        Console.WriteLine("Массив отсортирован.");
    }
}