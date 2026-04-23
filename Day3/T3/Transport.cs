namespace TransportSystem;

public abstract class Transport
{
    public string Model { get; set; }
    public int MaxSpeed { get; set; }
    public double FuelConsumption { get; set; }

    protected Transport(string model, int maxSpeed, double fuelConsumption)
    {
        Model = model;
        MaxSpeed = maxSpeed;
        FuelConsumption = fuelConsumption;
    }

    public abstract void ShowInfo();
}