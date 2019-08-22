using Independentsoft.Office.Odf;
using Microsoft.AspNetCore.Http;

namespace HR_Server
{
    public class OdtParser : IParser
    {
        public string GetText(IFormFile cv)
        {
            string resultText = null;

            using (var readStream = cv.OpenReadStream())
            {
                resultText = new TextDocument(readStream).ToText();
            }

            return resultText;
        }
    }
}