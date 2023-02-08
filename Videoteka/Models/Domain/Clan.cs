namespace Videoteka.Models.Domain
{
    public class Clan
    {
        public int ClanId { get; set; }
        public string ImeClana { get; set; }
        public string PrezimeClana { get; set; }
        public string GradClana { get; set; }

        public string PosKod { get; set; }
        public string UlicaClana { get; set; }
        public int KucniBrClana { get; set; }
        
        public string? BrojTelClana { get; set; }
        public string? EmailClana { get; set; }
        public DateTime PrijavljenDatum { get; set; }
        public DateTime DatumClanarine { get; set; }
    }
}
