using System;

public class WordReport : IReport
{
    public void Generate()
    {
        Console.WriteLine("Генерация отчета в формате Word...");
    }
}