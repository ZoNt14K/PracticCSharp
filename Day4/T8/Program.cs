using System;

class Program
{

    static double GetSquare(ref double number)
    {
        number = number * number;
        return number;
    }

    static int GetSquare(ref int number)
    {
        number = number * number;
        return number;
    }

    static void Main()
    {
        double num = 3.0;
        Console.WriteLine($"До вызова (double): {num}");
        
        GetSquare(ref num);
        
        Console.WriteLine($"После вызова (double): {num}");
        Console.WriteLine("-------------------------");

        int intNum = 4;
        Console.WriteLine($"До вызова (int): {intNum}");
        
        int result = GetSquare(ref intNum);
        
        Console.WriteLine($"Результат метода: {result}");
        Console.WriteLine($"После вызова (int): {intNum}");
    }
}