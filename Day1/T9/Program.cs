using System;

class Tabulation
{
    static void Main()
    {
        double A = 0.1;
        double B = 2.1;
        int M = 20;

        double H = (B - A) / M;
        
        double x = A;
        int n = M + 1;

        Console.WriteLine("-----------------------------");
        Console.WriteLine("|    x    |      y          |");
        Console.WriteLine("-----------------------------");

        for (int i = 1; i <= n; i++)
        {
            double y = x * Math.Exp(-x);

            Console.WriteLine($"| {x:F2}  |  {y:F6}  |");

            x = x + H;
        }

        Console.WriteLine("-----------------------------");
    }
}