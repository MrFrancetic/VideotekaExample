using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using Videoteka.Data;
using Videoteka.Models;
using Videoteka.Models.Domain;

namespace Videoteka.Controllers
{
    public class ClanoviController : Controller
    {
        private readonly VideotekaDbContext clanDbContext;

        public ClanoviController(VideotekaDbContext clanDbContext)
        {
            this.clanDbContext = clanDbContext;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var clanovi=await clanDbContext.Clanovi.ToListAsync();
            return View(clanovi);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult>Add(AddClanViewModel addClanViewModelRequest)
        {
            var clan = new Clan()
            {
                ImeClana = addClanViewModelRequest.ImeClana,
                PrezimeClana = addClanViewModelRequest.PrezimeClana,
                BrojTelClana = addClanViewModelRequest.BrojTelClana,
                EmailClana = addClanViewModelRequest.EmailClana,
                PosKod = addClanViewModelRequest.PosKod,
                GradClana = addClanViewModelRequest.GradClana,
                UlicaClana = addClanViewModelRequest.UlicaClana,
                KucniBrClana = addClanViewModelRequest.KucniBrClana,
                PrijavljenDatum = addClanViewModelRequest.PrijavljenDatum,
                DatumClanarine = addClanViewModelRequest.DatumClanarine
            };

            await clanDbContext.Clanovi.AddAsync(clan);
            await clanDbContext.SaveChangesAsync();
            int newClanId = clan.ClanId;
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> View(int id)
        {
            var clan=await clanDbContext.Clanovi.FirstOrDefaultAsync(x=>x.ClanId==id);
            if(clan != null)
            {
                var ViewCla = new AzurirajClanaViewModel()
                {
                    ClanaId = clan.ClanId,
                    ImeClana = clan.ImeClana,
                    PrezimeClana = clan.PrezimeClana,
                    BrojTelClana = clan.BrojTelClana,
                    EmailClana = clan.EmailClana,
                    PosKod = clan.PosKod,
                    GradClana = clan.GradClana,
                    UlicaClana = clan.UlicaClana,
                    KucniBrClana = clan.KucniBrClana,
                    PrijavljenDatum = clan.PrijavljenDatum,
                    DatumClanarine = clan.DatumClanarine
                };
                return await Task.Run(() => View("View", ViewCla));
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<IActionResult> View(AzurirajClanaViewModel aclan)
        {
            var clan = await clanDbContext.Clanovi.FindAsync(aclan.ClanaId);

            if (clan != null)
            {
                clan.ClanId=aclan.ClanaId;
                clan.ImeClana = aclan.ImeClana;
                clan.PrezimeClana = aclan.PrezimeClana;
                clan.BrojTelClana = aclan.BrojTelClana;
                clan.EmailClana = aclan.EmailClana;
                clan.PosKod = aclan.PosKod;
                clan.GradClana = aclan.GradClana;
                clan.UlicaClana = aclan.UlicaClana;
                clan.KucniBrClana = aclan.KucniBrClana;
                clan.PrijavljenDatum = aclan.PrijavljenDatum;
                clan.DatumClanarine = aclan.DatumClanarine;

                await clanDbContext.SaveChangesAsync();

                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(AzurirajClanaViewModel acad)
        {
            var clan = await clanDbContext.Zaposlenici.FindAsync(acad.ClanaId);

            if ( clan != null)
            {
                clanDbContext.Zaposlenici.Remove(clan);
                await clanDbContext.SaveChangesAsync();

                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
    }
}
