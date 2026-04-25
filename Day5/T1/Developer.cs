public class Developer : Employee
{
    public decimal HourlyRate { get; set; }
    public int HoursWorked { get; set; }

    public Developer(string name, decimal hourlyRate, int hoursWorked) 
        : base(name, "Разработчик")
    {
        HourlyRate = hourlyRate;
        HoursWorked = hoursWorked;
    }

    public override decimal CalculateSalary() => HourlyRate * HoursWorked;
}