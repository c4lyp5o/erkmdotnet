namespace FasilitiModel
{
    public class FasilitiItems
    {
        public List<Fasiliti> fasiliti { get; set; }
    }
    public class Fasiliti
    {
        public int id { get; set; }
        public string? nama { get; set; }
        public string? negeri { get; set; }
        public string? daerah { get; set; }
        public string? kodFasiliti { get; set; }
        public string? kodFasilitiGiret { get; set; }
    }
}