namespace Videoteka.Models
{
    public class AzurirajZaposlenikaViewModel
    {
        public int ZaposlenikId { get; set; }
        public string ImeZaposlenika { get; set; }
        public string PrezimeZaposlenika { get; set; }
        public string BrojTelZaposlenika { get; set; }
        public string? EmailZaposlenika { get; set; }
        public string? PozicijaZaposlenika { get; set; }
        public long? PlacaZaposlenika { get; set; }
        public DateTime DatumZaposlenja { get; set; }
        public DateTime DatumRodenja { get; set; }
    }
}
