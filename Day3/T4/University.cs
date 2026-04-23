namespace UniversitySystem;

public class University
{
    private Student[] _students;

    public University(Student[] students)
    {
        _students = students;
    }

    public Student[] GetTopStudents()
    {
        return Array.FindAll(_students, s => s.GPA > 4.5);
    }

    public Student[] GetStudentsByGroup(string groupName)
    {
        return Array.FindAll(_students, s => s.Group == groupName);
    }
}