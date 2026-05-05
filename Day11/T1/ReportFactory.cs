public abstract class ReportFactory
{
    // Фабричный метод
    public abstract IReport CreateReport();

    // Дополнительная бизнес-логика (необязательно)
    public void ExecuteReportGeneration()
    {
        var report = CreateReport();
        report.Generate();
    }
}