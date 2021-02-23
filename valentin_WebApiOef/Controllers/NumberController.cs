using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace valentin_WebApiOef.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NumberController : ControllerBase
    {
        public Path path = new Path();
        public NumberController()
        {

        }
        [HttpGet]
        public ActionResult<int> GetNumber()
        {
            try
            {
                string file = System.IO.File.ReadAllText($"{path.GetFilePath()}getal.txt");
                return Ok(Convert.ToInt32(file));
            }
            catch (FileNotFoundException)
            {
                return NotFound();
            }
        }
        [HttpPost("create")]
        public ActionResult CreateNumber(int newNumber)
        {
            using (StreamWriter outputFile = new StreamWriter(System.IO.Path.Combine(path.GetFilePath(), "getal.txt")))
            {
                outputFile.WriteLine(newNumber);
                return base.Ok();
            }
        }
        [HttpPost("rng")]
        public ActionResult CreateRngNumber()
        {
            var rng = new Random();
            using (StreamWriter outputFile = new StreamWriter(System.IO.Path.Combine(path.GetFilePath(), "getal.txt")))
            {
                outputFile.WriteLine(rng.Next(1, 10));
                return base.Ok();
            }
        }
    }
}
