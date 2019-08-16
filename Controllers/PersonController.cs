using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using HR_Server.Contexts;
using HR_Server.Model;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;

namespace HR_Server.Controllers
{
    [Route("api/person")]
    [ApiController]
    [EnableCors("AllowOrigin")]
    public class PersonController : ControllerBase
    {
        readonly HrDbContext _dbContext;
        readonly IWebHostEnvironment _env;

        public PersonController(HrDbContext dbContext, IWebHostEnvironment env)
        {
            _dbContext = dbContext;
            _env = env;
        }

        [HttpGet("{id?}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> GetPersonsAsync(int? id)
        {
            ActionResult result;

            try
            {
                IEnumerable<Person> persons = await _dbContext.Person.AsNoTracking().Where(p => !id.HasValue || p.PersonId == id.Value).ToListAsync();
                if (persons != null && persons.Count() > 0)
                {
                    result = Ok(persons);
                }
                else
                {
                    result = NotFound();
                }
            }
            catch (Exception e)
            {
                result = StatusCode(500, (_env.IsDevelopment() ? e.ToString() : "Server error"));
            }

            return result;
        }

        [HttpPost("")]
        public async Task<ActionResult> AddPersonAsync([FromForm] Person person)
        {
            ActionResult result;

            try
            {
                await _dbContext.Person.AddAsync(person);
                await _dbContext.SaveChangesAsync();

                result = Created($"api/person/{person.PersonId}", person);
            }
            catch (Exception e)
            {
                result = StatusCode(500, (_env.IsDevelopment() ? e.ToString() : "Server error"));
            }

            return result;
        }

        [HttpPut("")]
        public async Task<ActionResult> ChangePersonAsync([FromBody] Person person)
        {
            ActionResult result;

            try
            {
                // check is new CV file
                Person existPerson = await _dbContext.Person.AsNoTracking().Where(p => p.PersonId == person.PersonId).FirstOrDefaultAsync();
                if (existPerson != null && existPerson.CV != person.CV)
                {
                    var cvData = await ProcessCvData_Async(person.CV);
                }

                // update person data in db
                _dbContext.Person.Update(person);
                await _dbContext.SaveChangesAsync();

                result = Ok();
            }
            catch (Exception e)
            {
                result = StatusCode(500, (_env.IsDevelopment() ? e.ToString() : "Server error"));
            }

            return result;
        }

        [HttpDelete("")]
        public async Task<ActionResult> DeletePersonAsync(IEnumerable<long> personIds)
        {
            ActionResult result;

            try
            {
                List<Person> toDelete = await _dbContext.Person.Where(p => personIds.Contains(p.PersonId)).ToListAsync();
                _dbContext.Person.RemoveRange(toDelete);
                await _dbContext.SaveChangesAsync();

                result = Ok();
            }
            catch (Exception e)
            {
                result = StatusCode(500, (_env.IsDevelopment() ? e.ToString() : "Server error"));
            }

            return result;
        }

        [HttpPost("cv")]
        public async Task<ActionResult> ParseCvAsync([FromForm] CvFile cv)
        {
            ActionResult result;

            try
            {
                result = Ok(new {Techs = await ProcessCvData_Async(cv.CV) });
            }
            catch (Exception e)
            {
                result = StatusCode(500, (_env.IsDevelopment() ? e.ToString() : "Server error"));
            }

            return result;
        }

        private async Task<Dictionary<string, bool>> ProcessCvData_Async(IFormFile cv)
        {
            List<string> techs = new List<string>
            {
                ".net",
                "angular",
                "c#",
                "core",
                "css",
                "ef",
                "entity framework",
                "html",
                "javascript",
                "js",
                "mvc",
                "node.js",
                "react",
                "ts",
                "typescript",
                "vb",
                "vue",
                "web api"
            };

            Dictionary<string, bool> techData = new Dictionary<string, bool>(techs.Select(t => new KeyValuePair<string, bool>(t, false)));

            if (cv.Length > 0)
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    await cv.CopyToAsync(ms);
                    byte[] data = new byte[ms.Length];
                    await ms.ReadAsync(data, 0, (int)ms.Length);

                    //TextExtractor te = new TextExtractor();
                    //var teResult = te.Extract(data);

                    //techs.ForEach(t => techData[t] = teResult.Text.Contains(t));
                }
            }

            return techData;
        }
    }
}