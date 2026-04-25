public class Manager : Employee
{
    public decimal BaseSalary { get; set; }
    public decimal Bonus { get; set; }

    public Manager(string name, decimal baseSalary, decimal bonus) 
        : base(name, "Менеджер")
    {
        BaseSalary = baseSalary;
        Bonus = bonus;
    }

    public override decimal CalculateSalary() => BaseSalary + Bonus;
}