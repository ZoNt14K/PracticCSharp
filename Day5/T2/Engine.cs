public class Engine
{
    public string Type { get; set; }
    public Engine(string type) => Type = type;

    public void Start() => Console.WriteLine($"Двигатель {Type} заведен.");
}