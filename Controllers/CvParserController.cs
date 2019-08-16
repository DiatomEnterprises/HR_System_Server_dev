using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HR_Server.Controllers
{
    [Route("api/parser")]
    [ApiController]
    public class CvParserController : ControllerBase
    {
        [HttpPost("")]
        public async Task<IActionResult> Parse([FromBody] string cvFile)
        {
            return await Task.FromResult(new OkResult());
        }
    }
}