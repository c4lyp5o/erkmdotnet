namespace JpModel
{
    public class JpItems
    {
        public List<Jp> jp { get; set; }
    }
    public class Jp
    {
        public int id { get; set; }
        public string? nama { get; set; }
        public string? statusPegawai { get; set; }
        public string? mdtbNumber { get; set; }
    }
}