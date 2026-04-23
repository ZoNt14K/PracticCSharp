namespace UniversitySystem;

public partial class Student
{
    public string Name { get; set; }
    public string Group { get; set; }
    public double GPA { get; set; }

    public Student(string name, string group, double gpa)
    {
        Name = name;
        Group = group;
        GPA = gpa;
    }
}