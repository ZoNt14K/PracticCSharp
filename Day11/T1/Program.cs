using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<ReportFactory> factories = new List<ReportFactory>
        {
            new PdfReportFactory(),
            new ExcelReportFactory(),
            new WordReportFactory()
        };

        Console.WriteLine("Запуск системы генерации отчетов:");
        
        foreach (var factory in factories)
        {
            factory.ExecuteReportGeneration();
        }
    }
}