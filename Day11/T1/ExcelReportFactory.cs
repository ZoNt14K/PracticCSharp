public class ExcelReportFactory : ReportFactory
{
    public override IReport CreateReport()
    {
        return new ExcelReport();
    }
}