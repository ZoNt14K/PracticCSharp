using System;
using TransportSystem;

class Program
{
    static void Main()
    {
        Transport[] fleet = new Transport[]
        {
            new Car("Tesla Model 3", 225, 0),
            new Truck("Volvo FH16", 90, 30.5),
            new Car("BMW M5", 305, 12.4),
            new Truck("MAN TGX", 85, 28.2)
        };

        TransportManager manager = new TransportManager(fleet);

        Console.WriteLine("Весь транспорт предприятия:");
        manager.PrintAll();

        Transport fastest = manager.GetFastestVehicle();
        Console.WriteLine($"\nСамый быстрый транспорт: {fastest?.Model} ({fastest?.MaxSpeed} км/ч)");

        double totalFuel = manager.GetTotalFuelConsumption();
        Console.WriteLine($"Общий расход топлива парка: {totalFuel} л/100км");

        Console.ReadKey();
    }
}