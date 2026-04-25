    public class Bird : Animal, ICanFly
    {
        public Bird(string name) : base(name) { }

        public override void Eat() => Console.WriteLine($"{Name} клюет зерно.");
    
        public void Fly() => Console.WriteLine($"{Name} машет крыльями и летит!");
    }