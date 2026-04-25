    public class Fish : Animal, ICanSwim
    {
        public Fish(string name) : base(name) { }

        public override void Eat() => Console.WriteLine($"{Name} ест планктон.");

        public void Swim() => Console.WriteLine($"{Name} шевелит плавниками и плывет.");
    }