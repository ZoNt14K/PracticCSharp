public class OrderEventArgs : EventArgs
{
    public int OrderId { get; }
    public double Amount { get; }

    public OrderEventArgs(int id, double amount)
    {
        OrderId = id;
        Amount = amount;
    }
}
