public class ArraySorter
{
    private ISortingStrategy _strategy;

    public ArraySorter(ISortingStrategy strategy)
    {
        _strategy = strategy;
    }

    public void SetStrategy(ISortingStrategy strategy)
    {
        _strategy = strategy;
    }

    public void SortArray(int[] array)
    {
        if (_strategy == null)
        {
            Console.WriteLine("Стратегия не установлена!");
            return;
        }
        _strategy.Sort(array);
    }
}