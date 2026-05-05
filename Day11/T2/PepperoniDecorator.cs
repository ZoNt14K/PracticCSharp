public class PepperoniDecorator : PizzaDecorator
{
    public PepperoniDecorator(IPizza pizza) : base(pizza) { }

    public override string GetDescription()
    {
        return _pizza.GetDescription() + ", пепперони";
    }

    public override double GetCost()
    {
        return _pizza.GetCost() + 80.00;
    }
}