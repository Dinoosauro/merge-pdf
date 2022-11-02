// Credits: This is an implementation of https://stackoverflow.com/a/17640332/11719546. 
// Since I have used online PDF mergers in the past, I wanted to have a simple, offline solution that can work everywhere.
using PdfSharp.Pdf;
using PdfSharp.Pdf.IO;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("pdf-merger | Starting...");
        Console.WriteLine("Merging PDF...");
        PdfDocument document = new PdfDocument();
        for (int i = 0; (i < args.Length - 1); i++)
        {
            var readPdf = PdfReader.Open(args[i], PdfDocumentOpenMode.Import);
            document.Version = readPdf.Version;
            foreach (PdfPage page in readPdf.Pages)
            {
                document.AddPage(page);
            }
        }
        System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
        document.Save(args[args.Length - 1]);
        Console.WriteLine("Merged and saved: " + args[args.Length - 1]);
    }
}