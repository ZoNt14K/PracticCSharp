namespace TransportSystem;

public sealed class Car : Transport
{
    public Car(string model, int maxSpeed, double fuelConsumption) 
        : base(model, maxSpeed, fuelConsumption) { }

    public override void ShowInfo()
    {
        Console.WriteLine($"[Легковой] Модель: {Model}, Скорость: {MaxSpeed} км/ч, Расход: {FuelConsumption} л/100км");
    }
}

public sealed class Truck : Transport
{
    public Truck(string model, int maxSpeed, double fuelConsumption) 
        : base(model, maxSpeed, fuelConsumption) { }

    public override void ShowInfo()
    {
        Console.WriteLine($"[Грузовик] Модель: {Model}, Скорость: {MaxSpeed} км/ч, Расход: {FuelConsumption} л/100км");
    }
}