using System;

namespace LabWork;

class Program
{
    static void Main(string[] args)
    {
        Person[] students = 
        {
            new Person("Иван", 19),
            new Person("Алексей", 21),
            new Person("Мария", 20)
        };

        int maxAge = ArrayUtils.GetMaxValue(students);

        Console.WriteLine($"Максимальный возраст в группе: {maxAge}");
        
        Console.WriteLine("\nНажмите любую клавишу...");
        Console.ReadKey();
    }
}