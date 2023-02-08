namespace Videoteka.Models
{
        public class AzurirajClanaViewModel
        {
            public int ClanaId { get; set; }
            public string ImeClana { get; set; }
            public string PrezimeClana { set; get; }

            public string GradClana { set; get; }
            public string PosKod { set; get; }
            public string UlicaClana { set; get; }
            public int KucniBrClana { set; get; }
            public string BrojTelClana { set; get; }
            public string? EmailClana { set; get; }
            public DateTime PrijavljenDatum { set; get; }
            public DateTime DatumClanarine { set; get; }
        }
    }
