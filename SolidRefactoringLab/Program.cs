using System;

namespace SolidRefactoringLab
{
    // the contract every formatter has to follow, so we can add new formats without touching old code
    public interface IReportFormatter
    {
        void FormatReport();
    }

    // handles PDF formatting
    public class PdfFormatter : IReportFormatter
    {
        public void FormatReport()
        {
            Console.WriteLine("Formatting report as a PDF...");
        }
    }

    // handles Word formatting
    public class WordFormatter : IReportFormatter
    {
        public void FormatReport()
        {
            Console.WriteLine("Formatting report as a Word Document...");
        }
    }

    // handles plain text formatting
    public class PlainTextFormatter : IReportFormatter
    {
        public void FormatReport()
        {
            Console.WriteLine("Formatting report as plain text...");
        }
    }

    // this one just runs the report, it doesn't care what format it is or how it gets saved
    public class ReportManager
    {
        private readonly IReportFormatter _formatter;

        public string? ReportData { get; set; }

        // we get handed a formatter here instead of making one ourselves
        public ReportManager(IReportFormatter formatter)
        {
            _formatter = formatter;
        }

        public void GenerateReport()
        {
            // just tell the formatter to do its thing, no if/else needed
            _formatter.FormatReport();
        }
    }

    // saving files is the only thing this class does
    public class ReportSaver
    {
        public void SaveToFile(string filename)
        {
            Console.WriteLine($"Saving report data to {filename}...");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // 1. pick which formatter we want (swap this out for WordFormatter or PlainTextFormatter to change formats)
            IReportFormatter formatter = new PdfFormatter();

            // 2. hand it over to the manager and generate the report
            ReportManager manager = new ReportManager(formatter);
            manager.GenerateReport();

            // 3. use the saver to save the file
            ReportSaver saver = new ReportSaver();
            saver.SaveToFile("Q1_Report.pdf");
        }
    }
}