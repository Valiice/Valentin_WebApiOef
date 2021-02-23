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
    public class GetallenController : ControllerBase
    {
        public Path path = new Path();
        public GetallenController()
        {

        }
        [HttpGet]
        public ActionResult<int> GetNumber()
        {
            try
            {
                string[] file = System.IO.File.ReadAllLines($"{path.GetFilePath()}getal.txt");
                return Ok(file);
            }
            catch (FileNotFoundException)
            {
                return NotFound();
            }
        }
        [HttpPost("create")]
        public ActionResult CreateNumber(int newNumber)
        {
            try
            {
                using (StreamWriter sw = System.IO.File.AppendText($"{path.GetFilePath()}getal.txt"))
                {
                    sw.WriteLine(Convert.ToInt32(newNumber));
                    return base.Ok();
                }
            }
            catch (FileNotFoundException)
            {
                return NotFound();
            }
        }
        [HttpDelete("first")]
        public ActionResult DeleteNumber()
        {
            try
            {
                string[] file = System.IO.File.ReadAllLines($"{path.GetFilePath()}getal.txt");
                List<string> listNumber = new List<string>(file);
                listNumber.RemoveAt(0);
                using (StreamWriter outputFile = new StreamWriter(System.IO.Path.Combine(path.GetFilePath(), "getal.txt")))
                {
                    foreach (string number in listNumber)
                    {
                        outputFile.WriteLine(Convert.ToInt32(number));
                    }
                }
                return base.Ok();
            }
            catch (IndexOutOfRangeException)
            {
                return BadRequest();
            }
        }
        [HttpDelete("atIndex")]
        public ActionResult DeleteNumberAtIndex(int indexNum)
        {
            try
            {
                string[] file = System.IO.File.ReadAllLines($"{path.GetFilePath()}getal.txt");
                List<string> listNumber = new List<string>(file);
                listNumber.RemoveAt(indexNum);
                using (StreamWriter outputFile = new StreamWriter(System.IO.Path.Combine(path.GetFilePath(), "getal.txt")))
                {
                    foreach (string number in listNumber)
                    {
                        outputFile.WriteLine(Convert.ToInt32(number));
                    }
                }
                return base.Ok();
            }
            catch (IndexOutOfRangeException)
            {
                return BadRequest();
            }
        }
        [HttpPut]
        public ActionResult ChangeNumber(int indexNumChange, int NumChangeTo)
        {
            try
            {
                string[] file = System.IO.File.ReadAllLines($"{path.GetFilePath()}getal.txt");
                List<string> listNumber = new List<string>(file);
                listNumber[indexNumChange] = $"{NumChangeTo}";
                using (StreamWriter outputFile = new StreamWriter(System.IO.Path.Combine(path.GetFilePath(), "getal.txt")))
                {
                    foreach (string number in listNumber)
                    {
                        outputFile.WriteLine(Convert.ToInt32(number));
                    }
                }
                return base.Ok();
            }
            catch (IndexOutOfRangeException)
            {
                return BadRequest();
            }
        }
    }
}
