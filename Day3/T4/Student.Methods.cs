namespace UniversitySystem;

public partial class Student
{
    public void PrintInfo()
    {
        Console.WriteLine($"Студент: {Name}, Группа: {Group}, Средний балл: {GPA:F1}");
    }
}