
namespace Videoteka.Models.Domain
{
    public class Proizvod
    {
        public int ProizvodId { get; set; }
        public string ImeProizvoda { get; set; }
        public int KategorijaId { get; set; }
        public Kategorija Kategorija { get; set; } 
        public string OpisProizvoda { get; set; }
        public string Direktor { get; set; }
        public string Glumci { get; set; }
        public double KodProizvoda { get; set; }
        public DateTime DatumIzlaska { get; set; }
        public DateTime DatumDolaskaWeb { get; set; }
    }
    
}
