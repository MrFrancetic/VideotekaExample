using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using Videoteka.Data;
using Videoteka.Models;
using Videoteka.Models.Domain;

namespace Videoteka.Controllers
{
    public class Kat : Controller
    {
        private readonly VideotekaDbContext katDbContext;
        public Kat(VideotekaDbContext KatDbContext)
        {
            katDbContext = KatDbContext;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var kat = await katDbContext.Kategorija.ToListAsync();
            return View(kat);
        }


        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(AddKategorijuViewModel addKatRequest)
        {
            var kat = new Kategorija()
            {
                NazivKategorije = addKatRequest.NazivKategorije,

            };

            await katDbContext.Kategorija.AddAsync(kat);
            await katDbContext.SaveChangesAsync();
            int newKatId = kat.KategorijaId;
            return RedirectToAction("Index");


        }

        [HttpGet]
        public async Task<IActionResult> View(int id)
        {
            var kat = await katDbContext.Kategorija.FirstOrDefaultAsync(x => x.KategorijaId == id);

            if (kat != null)
            {
                var ViewKat = new AzurirajKategorijuViewModel()
                {
                    KategorijaId = kat.KategorijaId,
                    NazivKategorije=kat.NazivKategorije
                };
                return await Task.Run(() => View("View", ViewKat));

            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> View(AzurirajKategorijuViewModel ak)
        {
            var kat = await katDbContext.Kategorija.FindAsync(ak.KategorijaId);

            if (kat != null)
            {
                kat.KategorijaId = ak.KategorijaId;
                kat.NazivKategorije = ak.NazivKategorije;

                await katDbContext.SaveChangesAsync();

                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");

        }

        [HttpPost]
        public async Task<IActionResult> Delete(AzurirajKategorijuViewModel ak)
        {
            var kat = await katDbContext.Kategorija.FindAsync(ak.KategorijaId);

            if (kat != null)
            {
                katDbContext.Kategorija.Remove(kat);
                await katDbContext.SaveChangesAsync();

                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
    }
}
