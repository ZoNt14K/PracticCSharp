class Program
{
    static void Main(string[] args)
    {
        Employee[] employees = new Employee[]
        {
            new Manager("Александр", 3500, 800), 

            new Developer("Дмитрий", 30, 160),   

            new Intern("Иван", 800)              
        };

        Console.WriteLine("--- Ведомость начисления заработной платы (BYN) ---");
        
        foreach (var emp in employees)
        {
            emp.GetInfo();
        }
        
        decimal totalPayroll = 0;
        foreach (var emp in employees)
        {
            totalPayroll += emp.CalculateSalary();
        }

        Console.WriteLine("---------------------------------------------------");
        Console.WriteLine($"Итого к выплате: {totalPayroll:0.00} BYN");
    }
}