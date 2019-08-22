using Microsoft.AspNetCore.Http;

namespace HR_Server
{
    public interface IParser
    {
        string GetText(IFormFile cv);
    }
}