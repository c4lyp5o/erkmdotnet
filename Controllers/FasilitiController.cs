using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
// using System.Text.Json.Serialization;
using System.Text.RegularExpressions;
using FasilitiModel;

namespace FasilitiController
{
    [Route("[controller]")]
    [ApiController]
    public class fasilitiController : ControllerBase
    {
        [HttpGet]
        public string Get()
        {
            List<Fasiliti> fasiliti = new List<Fasiliti>();
            using (StreamReader r = new StreamReader("./Database/fasiliti.json"))
            {
                string json = r.ReadToEnd();
                fasiliti = JsonSerializer.Deserialize<List<Fasiliti>>(json);
            }

            string jsonString = JsonSerializer.Serialize(fasiliti, new JsonSerializerOptions() { WriteIndented = true });

            return jsonString;
        }

        [HttpGet("query")]
        public string Get(string? nama, string? daerah, string? negeri)
        {
            // make query object
            var queryObject = new { nama, daerah, negeri };

            var item = Request.Query["nama"];

            List<Fasiliti> fasiliti = new List<Fasiliti>();
            using (StreamReader r = new StreamReader("./Database/fasiliti.json"))
            {
                string json = r.ReadToEnd();
                fasiliti = JsonSerializer.Deserialize<List<Fasiliti>>(json) ?? new List<Fasiliti>();
            }

            //filter data according to query
            List<Fasiliti> filteredData = fasiliti.Where(x => Regex.IsMatch(x.nama ?? "", item, RegexOptions.IgnoreCase)).ToList();

            string jsonString = JsonSerializer.Serialize(filteredData, new JsonSerializerOptions() { WriteIndented = true });

            return jsonString;
        }
    }
}