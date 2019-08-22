using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;
using Microsoft.AspNetCore.Http;
using System.Text;

namespace HR_Server
{
    public class PdfParser : IParser
    {
        public string GetText(IFormFile cv)
        {
            StringBuilder resultText = new StringBuilder();

            StringBuilder text = new StringBuilder();
            using (PdfReader reader = new PdfReader(cv.OpenReadStream()))
            {
                for (int i = 1; i <= reader.NumberOfPages; i++)
                {
                    resultText.Append(PdfTextExtractor.GetTextFromPage(reader, i));
                }
            }

            return resultText.ToString();

        }
    }
}