public class Car
{
    public string Model { get; set; }

    private Engine _engine; 

    private Wheel[] _wheels; 

    public Driver CurrentDriver { get; set; }

    public Car(string model, Wheel[] wheels)
    {
        Model = model;
        _engine = new Engine("V8"); 
        _wheels = wheels; 
    }

    public void Drive()
    {
        if (CurrentDriver == null)
        {
            Console.WriteLine($"Автомобиль {Model} не может ехать: нет водителя.");
            return;
        }

        if (_wheels.Length < 4)
        {
            Console.WriteLine($"Автомобиль {Model} не может ехать: не хватает колес.");
            return;
        }

        _engine.Start();
        Console.WriteLine($"Водитель {CurrentDriver.Name} ведет автомобиль {Model} на {_wheels.Length} колесах.");
    }
}