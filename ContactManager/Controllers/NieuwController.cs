using System;
using ContactManager.Model;
using ContactManager.Service.Interfaces;
using ContactManager.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Newtonsoft.Json;

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
            for (var i = 0; i < telefoonNaam.Length; i++)
            {
                persoon.VoegTelefoonToe(telefoonNaam[i], telefoonNummer[i]);
            }



            _nieuwContactRepository.VoegPersoonToeEnBewaar(persoon);
            return RedirectToAction("LaatstToegevoegdContactMetNaam", "Home", new { naam = persoon.Naam, actiefContactSoort = ContactSoort.Persoon.ToString()});
        }

        public IActionResult NieuweOrganisatie(Organisatie organisatie, string[] telefoonNaam, string[] telefoonNummer, int? contactPersoonId)
        {
            for (var i = 0; i < telefoonNaam.Length; i++)
            {
                organisatie.VoegTelefoonToe(telefoonNaam[i], telefoonNummer[i]);
            }
            if (contactPersoonId != null)
            {
                organisatie.ContactPersoon = _nieuwContactRepository.PersoonMetId((int)contactPersoonId);
            }
            _nieuwContactRepository.VoegOrganisatieToeEnBewaar(organisatie);
            return RedirectToAction("LaatstToegevoegdContactMetNaam", "Home", new { naam = organisatie.Naam, actiefContactSoort = ContactSoort.Organisatie.ToString() });
        }

        public IActionResult NieuweContactForm(ContactSoort contactSoort)
        {
            var model = new NieuwViewModel
            {
                Titel = "Nieuwe " + contactSoort.ToString(),
                ContactSoort = contactSoort

            };
            return View(model);
        }

        public JsonResult Personen(string naam)
        {
            var personen = _nieuwContactRepository.PersonenMetNaam(naam);
            return Json(personen);
        }
    }
}