using System;

public class PdfReport : IReport
{
    public void Generate()
    {
        Console.WriteLine("Генерация отчета в формате PDF...");
    }
}