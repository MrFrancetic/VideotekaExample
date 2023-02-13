using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using Videoteka.Data;
using Videoteka.Models;
using Videoteka.Models.Domain;

namespace Videoteka.Controllers
{
    public class ZaposleniciController : Controller
    {
        private readonly VideotekaDbContext vidDbContext;//sad možemo komunicirati s bazom podataka

        public ZaposleniciController(VideotekaDbContext VidDbContext)//constructor koji sadrzava videotekadb context i dodajemo ime vidDbContext
        {
            vidDbContext = VidDbContext;
        }

        [HttpGet]
        public async Task<IActionResult> Index()//lista koja ce pokazati spremljene zaposlenike, ali isto tako koristi Views.Zaposlenici.Indexcstml
        {
          var zaposlenici=await vidDbContext.Zaposlenici.ToListAsync();
           return View(zaposlenici);
        }


        [HttpGet]
        public IActionResult Add()
        {
            return View();//view ce se koristiti kako bi se dodao novi zaposlenik
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddZaposlenikViewModel addZaposlenikRequest)
        {
            var zaposlenik = new Zaposlenik()
            {
                ImeZaposlenika = addZaposlenikRequest.ImeZaposlenika,
                PrezimeZaposlenika = addZaposlenikRequest.PrezimeZaposlenika,
                BrojTelZaposlenika = addZaposlenikRequest.BrojTelZaposlenika,
                EmailZaposlenika = addZaposlenikRequest.EmailZaposlenika,
                PozicijaZaposlenika = addZaposlenikRequest.PozicijaZaposlenika,
                PlacaZaposlenika = addZaposlenikRequest.PlacaZaposlenika,
                DatumZaposlenja=addZaposlenikRequest.DatumZaposlenja,
                DatumRodenja=addZaposlenikRequest.DatumRodenja
            };

            await vidDbContext.Zaposlenici.AddAsync(zaposlenik);
            await vidDbContext.SaveChangesAsync();
            int newZaposlenikId = zaposlenik.ZaposlenikId;//ovo se koristi kako bi se spremio novi id u zaposlenik klasi Zaposlenik.cs
            return RedirectToAction("Index");//Nakon sto spremimo novog zaposlenika, odvest ce nas na Index action koji ce se odmah izvrsiti i pokazati ce nam tablicu zaposlenika

           
        }

        [HttpGet]
        public async Task<IActionResult> View(int id)
        {
            var zaposlenik= await vidDbContext.Zaposlenici.FirstOrDefaultAsync(x => x.ZaposlenikId == id);

            if (zaposlenik != null)
            { 
                var ViewZap = new AzurirajZaposlenikaViewModel()
                {
                    ZaposlenikId = zaposlenik.ZaposlenikId,
                    ImeZaposlenika = zaposlenik.ImeZaposlenika,
                    PrezimeZaposlenika = zaposlenik.PrezimeZaposlenika,
                    BrojTelZaposlenika = zaposlenik.BrojTelZaposlenika,
                    EmailZaposlenika = zaposlenik.EmailZaposlenika,
                    PozicijaZaposlenika = zaposlenik.PozicijaZaposlenika,
                    PlacaZaposlenika = zaposlenik.PlacaZaposlenika,
                    DatumZaposlenja = zaposlenik.DatumZaposlenja,
                    DatumRodenja = zaposlenik.DatumRodenja
                };
                return await Task.Run(()=>View("View", ViewZap));

            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> View(AzurirajZaposlenikaViewModel az)
        {
            var zaposlenik = await vidDbContext.Zaposlenici.FindAsync(az.ZaposlenikId);

            if(zaposlenik != null)
            {
                zaposlenik.ZaposlenikId=az.ZaposlenikId;
                zaposlenik.ImeZaposlenika = az.ImeZaposlenika;
                zaposlenik.PrezimeZaposlenika = az.PrezimeZaposlenika;
                zaposlenik.BrojTelZaposlenika = az.BrojTelZaposlenika;
                zaposlenik.EmailZaposlenika = az.EmailZaposlenika;
                zaposlenik.PozicijaZaposlenika = az.PozicijaZaposlenika;
                zaposlenik.PlacaZaposlenika = az.PlacaZaposlenika;
                zaposlenik.DatumZaposlenja = az.DatumZaposlenja;
                zaposlenik.DatumRodenja = az.DatumRodenja;

                await vidDbContext.SaveChangesAsync();

                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");

        }

        [HttpPost]
        public async Task<IActionResult> Delete(AzurirajZaposlenikaViewModel az)
        {
            var zaposlenik = await vidDbContext.Zaposlenici.FindAsync(az.ZaposlenikId);
           
            if(zaposlenik != null)
            {
                vidDbContext.Zaposlenici.Remove(zaposlenik);
                await vidDbContext.SaveChangesAsync();

                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
    }
}
