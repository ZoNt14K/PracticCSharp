public abstract class PizzaDecorator : IPizza
{
    protected IPizza _pizza;

    public PizzaDecorator(IPizza pizza)
    {
        _pizza = pizza;
    }

    public virtual string GetDescription()
    {
        return _pizza.GetDescription();
    }

    public virtual double GetCost()
    {
        return _pizza.GetCost();
    }
}