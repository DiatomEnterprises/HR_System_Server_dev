using DocumentFormat.OpenXml.Packaging;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace HR_Server
{
    public class DocxParser : IParser
    {
        public string GetText(IFormFile cv)
        {
            string resultText = null;

            using (var readStream = cv.OpenReadStream())
            {
                using (WordprocessingDocument wordDoc = WordprocessingDocument.Open(readStream as Stream, false))
                {
                    using (StreamReader sr = new StreamReader(wordDoc.MainDocumentPart.GetStream()))
                    {
                        resultText = sr.ReadToEnd();
                    }

                }
            }

            return resultText;
        }
    }
}