namespace Videoteka.Models.Domain
{
    public class Zaposlenik
    {
        //Osnovni podaci o zaposleniku
        public int ZaposlenikId { get; set; }//za kreiranje primarnog kljuca treba zavrsiti na Id
        public string ImeZaposlenika { get; set; }
        public string PrezimeZaposlenika { get; set; }
        public string BrojTelZaposlenika { get; set; }
        public string? EmailZaposlenika { get; set; }


        //Dodatni podaci o zaposleniku
        public string? PozicijaZaposlenika { get; set; }
        public long? PlacaZaposlenika { get; set; }
        public DateTime DatumZaposlenja { get; set; }
        public DateTime DatumRodenja { get; set; }


    }
}
