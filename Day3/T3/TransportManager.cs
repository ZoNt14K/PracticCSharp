namespace TransportSystem;

public class TransportManager
{
    private Transport[] _vehicles;

    public TransportManager(Transport[] vehicles)
    {
        _vehicles = vehicles;
    }

    public Transport GetFastestVehicle()
    {
        if (_vehicles == null || _vehicles.Length == 0) return null;

        Transport fastest = _vehicles[0];
        foreach (var v in _vehicles)
        {
            if (v.MaxSpeed > fastest.MaxSpeed) fastest = v;
        }
        return fastest;
    }

    public double GetTotalFuelConsumption()
    {
        double total = 0;
        foreach (var v in _vehicles)
        {
            total += v.FuelConsumption;
        }
        return total;
    }

    public void PrintAll()
    {
        foreach (var v in _vehicles) v.ShowInfo();
    }
}