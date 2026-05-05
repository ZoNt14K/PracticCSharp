public class BasicPizza : IPizza
{
    public string GetDescription()
    {
        return "Классическое тесто";
    }

    public double GetCost()
    {
        return 300.00; // Базовая цена
    }
}