using ContactManager.Model;
using ContactManager.Service.Interfaces;
using ContactManager.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ContactManager.Controllers

{

    public class NieuwController : Controller
    {
        private readonly INieuwContactRepository _nieuwContactRepository;

        public NieuwController(INieuwContactRepository nieuwContactRepository)
        {
            _nieuwContactRepository = nieuwContactRepository;
        }



        public IActionResult NieuwePersoon(Persoon persoon, string[] telefoonNaam, string[] telefoonNummer)
        {
            for (int i = 0; i < telefoonNaam.Length; i++)
            {
                persoon.VoegTelefoonToe(telefoonNaam[i], telefoonNummer[i]);
            }


            _nieuwContactRepository.VoegPersoonToeEnBewaar(persoon);
            return RedirectToAction("LaatstToegevoegdContactMetNaam", "Home", new { naam = persoon.Naam, actiefContactSoort = "Persoon" });
        }

        public IActionResult NieuwePersoonForm()
        {
            var model = new NieuwViewModel
            {
                Persoon = new Persoon(),
                Titel = "Nieuwe Persoon"

            };
            return View(model);
        }

        public IActionResult NieuweOrganisatie(Organisatie organisatie)
        {
            _nieuwContactRepository.VoegOrganisatieToeEnBewaar(organisatie);
            return RedirectToAction("Contacten", "Home");
        }

        public IActionResult NieuweOrganisatieForm()
        {
            var model = new NieuwViewModel
            {
                Organisatie = new Organisatie(),
                Titel = "Nieuwe Organisatie"
            };
            return View(model);
        }

    }
}