class Program
{
    static void Main()
    {
        Animal[] zoo = new Animal[]
        {
            new Bird("Орел"),
            new Fish("Лосось"),
            new Bird("Синица"),
            new Fish("Щука"),
            new Bird("Попугай")
        };

        Console.WriteLine("=== Все животные в зоопарке ===");
        foreach (var animal in zoo)
        {
            animal.Eat();
        }

        Console.WriteLine("\n=== Фильтрация: Только те, кто умеет летать ===");

        foreach (var animal in zoo)
        {
            if (animal is ICanFly flyer)
            {
                Console.Write($"Найдена птица {animal.Name}: ");
                flyer.Fly();
            }
        }

        Console.WriteLine("\n=== Фильтрация: Только те, кто умеет плавать ===");
        foreach (var animal in zoo)
        {
            if (animal is ICanSwim swimmer)
            {
                Console.Write($"{animal.Name}: ");
                swimmer.Swim();
            }
        }
    }
}