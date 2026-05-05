using System;

public class ExcelReport : IReport
{
    public void Generate()
    {
        Console.WriteLine("Генерация отчета в формате Excel...");
    }
}