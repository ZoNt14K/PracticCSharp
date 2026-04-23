using System;

class A
{
    public int a;
    public int b;

    public A(int a, int b)
    {
        this.a = a;
        this.b = b;
    }

    public int GetSum()
    {
        return a + b;
    }

    public double GetResult()
    {
        if (a == 0) return 0;
        return Math.Sin(b) / (3 * a);
    }
}

class Program
{
    static void Main()
    {
        A item = new A(78, 35);

        Console.WriteLine($"Сумма: {item.GetSum()}");
        Console.WriteLine($"Результат: {item.GetResult():F4}");
    }
}