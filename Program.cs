using ceTe.DynamicPDF.Merger;
using System;
using System.Text.RegularExpressions;

namespace example_combine_pdfs_dotnet
{
    // This example combines PDFs with and without options.
    // It references the ceTe.DynamicPDF.CoreSuite.NET NuGet package.
    class Program
    {
        static void Main(string[] args)
        {
            CombinePDFs();

            CombinePDFsWithOptions();
        }

        // Combines PDF documents.
        // This code uses the DynamicPDF Merger for .NET product.
        // Use the ceTe.DynamicPDF.Merger namespace for the MergeDocument class.
        private static void CombinePDFs()
        {
            //Create MergeDocument object and append PDFs
            MergeDocument document = new MergeDocument(GetResourcePath("doc-a.pdf"));
            document.Append(GetResourcePath("doc-b.pdf"));
            document.Append(GetResourcePath("doc-c.pdf"), 1, 2);

            //Save merged document
            document.Draw("output-combined.pdf");
        }

        // Combines PDF documents with options.
        // This code uses the DynamicPDF Merger for .NET product.
        // Use the ceTe.DynamicPDF.Merger namespace for the MergeDocument class.
        private static void CombinePDFsWithOptions()
        {
            //Create MergeOptions with different settings
            MergeOptions options = MergeOptions.Append;
            options.Outlines = false;

            //Create MergeDocument object
            MergeDocument document = new MergeDocument();

            // Append a document with options
            document.Append(GetResourcePath("doc-with-outline.pdf"), options);

            //Save document
            document.Draw("output-with-options.pdf");
        }

        // This is a helper function to get a full path to a file in the Resources folder.
        public static string GetResourcePath(string inputFileName)
        {
            var exePath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().CodeBase);
            Regex appPathMatcher = new Regex(@"(?<!fil)[A-Za-z]:\\+[\S\s]*?(?=\\+bin)");
            var appRoot = appPathMatcher.Match(exePath).Value;
            return System.IO.Path.Combine(appRoot, "Resources", inputFileName);
        }
    }
}
