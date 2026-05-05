public class CheeseDecorator : PizzaDecorator
{
    public CheeseDecorator(IPizza pizza) : base(pizza) { }

    public override string GetDescription()
    {
        return _pizza.GetDescription() + ", сыр";
    }

    public override double GetCost()
    {
        return _pizza.GetCost() + 50.00;
    }
}