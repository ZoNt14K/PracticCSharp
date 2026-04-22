using System;

namespace T1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Вычисление площади круга.");
            Console.WriteLine("Введите исходные данные:");

            Console.Write("Радиус (см) —> ");

            if (double.TryParse(Console.ReadLine(), out double radius))
            {
                double area = Math.PI * Math.Pow(radius, 2);

                Console.WriteLine($"Площадь круга: {area:F2} кв.см.");
            }
            else
            {
                Console.WriteLine("Ошибка: введено некорректное число.");
            }

            Console.WriteLine("\nНажмите любую клавишу для выхода...");
            Console.ReadKey();
        }
    }
}