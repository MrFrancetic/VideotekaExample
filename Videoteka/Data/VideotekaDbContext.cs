using Microsoft.EntityFrameworkCore;
using Videoteka.Models.Domain;

namespace Videoteka.Data
{
    public class VideotekaDbContext : DbContext
    {
        public VideotekaDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Zaposlenik> Zaposlenici { get; set; }
        public DbSet<Clan> Clanovi { get; set; }
        public DbSet<Proizvod> Proizvodi { get; set; }
        public DbSet<Kategorija> Kategorija { get; set;}

    }
}
