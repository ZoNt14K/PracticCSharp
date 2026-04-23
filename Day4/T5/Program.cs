using System;

namespace PolymorphismTask
{
    public abstract class Shape
    {
        public string Name { get; set; }

        protected Shape(string name)
        {
            Name = name;
        }

        public abstract double CalculateArea();

        public virtual void DisplayInfo()
        {
            Console.WriteLine($"Фигура: {Name}");
        }
    }

    public class Circle : Shape
    {
        public double Radius { get; set; }

        public Circle(double radius) : base("Круг")
        {
            Radius = radius;
        }

        public override double CalculateArea()
        {
            return Math.PI * Math.Pow(Radius, 2);
        }

        public override void DisplayInfo()
        {
            Console.WriteLine($"Радиус: {Radius}, Площадь: {CalculateArea():F2}");
        }
    }

    public class Rectangle : Shape
    {
        public double Width { get; set; }
        public double Height { get; set; }

        public Rectangle(double width, double height) : base("Прямоугольник")
        {
            Width = width;
            Height = height;
        }

        public override double CalculateArea()
        {
            return Width * Height;
        }

        public override void DisplayInfo()
        {
            base.DisplayInfo();
            Console.WriteLine($"Стороны: {Width}x{Height}, Площадь: {CalculateArea():F2}");
        }
    }

    class Program
    {
        static void Main()
        {
            Shape[] shapes = new Shape[]
            {
                new Circle(5),
                new Rectangle(10, 4)
            };

            foreach (var shape in shapes)
            {
                shape.DisplayInfo();
                Console.WriteLine("---");
            }
        }
    }
}