namespace LabWork;

public static class ArrayUtils
{
    public static int GetMaxValue(Person[] people)
    {
        if (people == null || people.Length == 0) return 0;

        int max = people[0].Age;
        foreach (var p in people)
        {
            if (p.Age > max)
            {
                max = p.Age;
            }
        }
        return max;
    }
}