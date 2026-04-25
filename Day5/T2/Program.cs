class Program
{
    static void Main()
    {
        Wheel[] standardWheels = { new Wheel(16), new Wheel(16), new Wheel(16), new Wheel(16) };
        Wheel[] sportWheels = { new Wheel(19), new Wheel(19), new Wheel(19), new Wheel(19) };

        Driver driver1 = new Driver("Алексей");
        Driver driver2 = new Driver("Виталий");

        Car[] cars = new Car[]
        {
            new Car("Geely Emgrand", standardWheels),
            new Car("BelGee X50", sportWheels)
        };

        cars[0].CurrentDriver = driver1;
        cars[1].CurrentDriver = driver2;

        Console.WriteLine("=== Проверка автопарка ===");
        foreach (var car in cars)
        {
            car.Drive();
            Console.WriteLine("---");
        }
    }
}