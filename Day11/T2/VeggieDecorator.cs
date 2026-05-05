public class VeggieDecorator : PizzaDecorator
{
    public VeggieDecorator(IPizza pizza) : base(pizza) { }

    public override string GetDescription()
    {
        return _pizza.GetDescription() + ", овощи";
    }

    public override double GetCost()
    {
        return _pizza.GetCost() + 40.00;
    }
}