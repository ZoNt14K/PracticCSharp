public class QuickSort : ISortingStrategy
{
    public void Sort(int[] array)
    {
        Console.WriteLine("Используется: Quick Sort");
        Array.Sort(array);
    }
}