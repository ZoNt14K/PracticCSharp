using System;

class Program
{
    static double CalculateArea(double radius)
    {
        return Math.PI * Math.Pow(radius, 2);
    }

    static double CalculateArea(double length, double width)
    {
        return length * width;
    }

    static void Main()
    {
        double circleRadius = 5.0;
        double circleArea = CalculateArea(circleRadius);
        Console.WriteLine($"Площадь круга с радиусом {circleRadius}: {circleArea:F2}");

        double rectLength = 4.0;
        double rectWidth = 6.0;
        double rectArea = CalculateArea(rectLength, rectWidth);
        Console.WriteLine($"Площадь прямоугольника {rectLength}x{rectWidth}: {rectArea:F1}");
    }
}