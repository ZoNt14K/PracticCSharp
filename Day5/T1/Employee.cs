public abstract class Employee
{
    public string Name { get; set; }
    public string Position { get; set; }

    protected Employee(string name, string position)
    {
        Name = name;
        Position = position;
    }

    public abstract decimal CalculateSalary();

    public virtual void GetInfo()
    {
        // Выводим с точностью до 2 знаков и припиской валюты
        Console.WriteLine($"{Position}: {Name} | Зарплата: {CalculateSalary():0.00} BYN");
    }
}