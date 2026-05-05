public class PdfReportFactory : ReportFactory
{
    public override IReport CreateReport()
    {
        return new PdfReport();
    }
}