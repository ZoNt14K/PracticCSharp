using System;

class Program
{
    static void Main(string[] args)
    {
        IPizza myPizza = new BasicPizza();
        Console.WriteLine($"{myPizza.GetDescription()} | Цена: {myPizza.GetCost()}");

        myPizza = new CheeseDecorator(myPizza);
        Console.WriteLine($"{myPizza.GetDescription()} | Цена: {myPizza.GetCost()}");

        myPizza = new PepperoniDecorator(myPizza);
        Console.WriteLine($"{myPizza.GetDescription()} | Цена: {myPizza.GetCost()}");

        myPizza = new VeggieDecorator(myPizza);
        
        Console.WriteLine("\nИтоговый заказ:");
        Console.WriteLine($"Состав: {myPizza.GetDescription()}");
        Console.WriteLine($"К оплате: {myPizza.GetCost()} руб.");
    }
}