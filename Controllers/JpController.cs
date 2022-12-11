using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
// using System.Text.Json.Serialization;
using System.Text.RegularExpressions;
using JpModel;

namespace MainController
{
    [Route("[controller]")]
    [ApiController]
    public class jpController : ControllerBase
    {
        [HttpGet]
        public string Get()
        {
            List<Jp> jp = new List<Jp>();
            using (StreamReader r = new StreamReader("./Database/jp.json"))
            {
                string json = r.ReadToEnd();
                jp = JsonSerializer.Deserialize<List<Jp>>(json);
            }

            string jsonString = JsonSerializer.Serialize(jp, new JsonSerializerOptions() { WriteIndented = true });

            return jsonString;
        }

        [HttpGet("query")]
        public string Get(string nama)
        {
            var item = Request.Query["nama"];

            List<Jp> jp = new List<Jp>();
            using (StreamReader r = new StreamReader("./Database/jp.json"))
            {
                string json = r.ReadToEnd();
                jp = JsonSerializer.Deserialize<List<Jp>>(json);
            }

            List<Jp> filteredData = jp.Where(x => Regex.IsMatch(x.nama, item, RegexOptions.IgnoreCase)).ToList();

            string jsonString = JsonSerializer.Serialize(filteredData, new JsonSerializerOptions() { WriteIndented = true });

            return jsonString;
        }
    }
}