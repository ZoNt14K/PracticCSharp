public class Intern : Employee
{
    public decimal Stipend { get; set; }

    public Intern(string name, decimal stipend) 
        : base(name, "Стажер")
    {
        Stipend = stipend;
    }

    public override decimal CalculateSalary() => Stipend;
}