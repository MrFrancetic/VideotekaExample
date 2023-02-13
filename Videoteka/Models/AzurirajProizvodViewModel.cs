namespace Videoteka.Models
{
    public class AzurirajProizvodViewModel
    {
        public int ProizvodId { get; set; }
        public string ImeProizvoda { get; set; }
        public int KategorijaId { get; set; }
        public List<Videoteka.Models.Domain.Kategorija> Kategorije { get; set; }
        public string NazivKategorije { get; set; }
        public string OpisProizvoda { get; set; }
        public string Direktor { get; set; }
        public string Glumci { get; set; }
        public double KodProizvoda { get; set; }
        public DateTime DatumIzlaska { get; set; }
        public DateTime DatumDolaskaWeb { get; set; }
    }
}
