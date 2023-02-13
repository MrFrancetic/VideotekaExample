using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using Videoteka.Data;
using Videoteka.Models;
using Videoteka.Models.Domain;

namespace Videoteka.Controllers
{
    public class ProizvodiController : Controller
    {
        private readonly VideotekaDbContext proDbContext;

        public ProizvodiController(VideotekaDbContext ProDbContext)
        {
            proDbContext = ProDbContext;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var proizvod = await proDbContext.Proizvodi.ToListAsync();
            return View(proizvod);
        }

        [HttpGet]
        public IActionResult Add()
        {
           
                if (proDbContext == null)
                {
                    return NotFound();
                }

                var addProizvodViewModel = new AddProizvodViewModel();
                addProizvodViewModel.Kategorije = proDbContext.Kategorija.ToList();
                return View(addProizvodViewModel);

        }
 
        [HttpPost]
        public async Task<IActionResult> Add(AddProizvodViewModel addProizvodRequest)
        {

            var kategorija = await proDbContext.Kategorija.FirstOrDefaultAsync(k => k.KategorijaId == addProizvodRequest.KategorijaId);
                var proizvod = new Proizvod()
                {
                    ImeProizvoda = addProizvodRequest.ImeProizvoda,
                    KategorijaId = kategorija.KategorijaId,
                    OpisProizvoda = addProizvodRequest.OpisProizvoda,
                    Direktor = addProizvodRequest.Direktor,
                    Glumci = addProizvodRequest.Glumci,
                    KodProizvoda = addProizvodRequest.KodProizvoda,
                    DatumIzlaska = addProizvodRequest.DatumIzlaska,
                    DatumDolaskaWeb = addProizvodRequest.DatumDolaskaWeb
                };
                await proDbContext.Proizvodi.AddAsync(proizvod);
                await proDbContext.SaveChangesAsync();
                int newProizvodId = proizvod.ProizvodId;
                return RedirectToAction("Index");

        }

        [HttpGet]
        public async Task<IActionResult> View(int id)
        {
            var proizvod = await proDbContext.Proizvodi.FindAsync(id);
            if(proizvod != null)
            {
                var ViewPro = new AzurirajProizvodViewModel()
                {
                    ProizvodId = proizvod.ProizvodId,
                    ImeProizvoda = proizvod.ImeProizvoda,
                    KategorijaId = proizvod.KategorijaId,
                    Kategorije = await proDbContext.Kategorija.ToListAsync(),
                    OpisProizvoda = proizvod.OpisProizvoda,
                    Direktor = proizvod.Direktor,
                    Glumci = proizvod.Glumci,
                    KodProizvoda = proizvod.KodProizvoda,
                    DatumIzlaska = proizvod.DatumIzlaska,
                    DatumDolaskaWeb = proizvod.DatumDolaskaWeb
                };
                return await Task.Run(() => View("View", ViewPro));
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<IActionResult>View(AzurirajProizvodViewModel azPro)
        {
            var proizvod = await proDbContext.Proizvodi.FindAsync(azPro.ProizvodId);
            if (proizvod !=null)
            {
                proizvod.ProizvodId=azPro.ProizvodId;
                proizvod.ImeProizvoda=azPro.ImeProizvoda;
                proizvod.KategorijaId = azPro.KategorijaId;
                proizvod.OpisProizvoda = azPro.OpisProizvoda;
                proizvod.Direktor=azPro.Direktor;
                proizvod.Glumci=azPro.Glumci;
                proizvod.KodProizvoda= azPro.KodProizvoda;
                proizvod.DatumIzlaska=azPro.DatumIzlaska;
                proizvod.DatumDolaskaWeb = azPro.DatumDolaskaWeb;

                await proDbContext.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
            
        }
        [HttpPost]
        public async Task<IActionResult> Delete(AzurirajProizvodViewModel azPro)
        {
            var proizvod = await proDbContext.Proizvodi.FindAsync(azPro.ProizvodId);
                {
                if(proizvod != null)
                {
                    proDbContext.Proizvodi.Remove(proizvod);
                    await proDbContext.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
                return RedirectToAction("Index");
            }
        }
    }
}
