using System;
using UniversitySystem;

class Program
{
    static void Main()
    {
        Student[] studentsArray = new Student[]
        {
            new Student("Иван Иванов", "40тп", 4.8),
            new Student("Мария Петрова", "швея", 2.2),
            new Student("Алексей Сидоров", "40тп", 4.6),
            new Student("Елена Козлова", "40тп", 3.9)
        };

        University university = new University(studentsArray);

        Console.WriteLine("Студенты с GPA выше 4.5:");
        foreach (var s in university.GetTopStudents())
        {
            s.PrintInfo();
        }
        
        string targetGroup = "40тп";
        Console.WriteLine($"\nСтуденты группы {targetGroup}:");
        foreach (var s in university.GetStudentsByGroup(targetGroup))
        {
            s.PrintInfo();
        }

        Console.ReadKey();
    }
}