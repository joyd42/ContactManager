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
        private readonly IWijzigContactRepository _wijzigContactRepository;

        public NieuwController(INieuwContactRepository nieuwContactRepository, IWijzigContactRepository wijzigContactRepository)
        {
            _nieuwContactRepository = nieuwContactRepository;
            _wijzigContactRepository = wijzigContactRepository;
        }



        public IActionResult NieuwePersoon(Persoon persoon, string[] telefoonsNamen, string[] telefoonNummers)
        {
            persoon.VoegTelefoonsToe(telefoonsNamen, telefoonNummers);

            _nieuwContactRepository.VoegPersoonToeEnBewaar(persoon);
            return RedirectToAction(nameof(HomeController.LaatstToegevoegdContactMetNaam), "Home", new { naam = persoon.Naam, actiefContactSoort = ContactSoort.Persoon.ToString() });
        }

        public IActionResult UpdatePersoon(Persoon persoon, string[] telefoonsNamen, string[] telefoonNummers)
        {
            var test = persoon;
            throw new NotImplementedException();
        }

        public IActionResult NieuweOrganisatie(Organisatie organisatie, string[] telefoonsNamen, string[] telefoonNummers, int? contactPersoonId)
        {
            organisatie.VoegTelefoonsToe(telefoonsNamen, telefoonNummers);

            if (contactPersoonId != null)
            {
                organisatie.ContactPersoon = _nieuwContactRepository.PersoonMetId((int)contactPersoonId);
            }
            _nieuwContactRepository.VoegOrganisatieToeEnBewaar(organisatie);
            return RedirectToAction(nameof(HomeController.LaatstToegevoegdContactMetNaam), "Home", new { naam = organisatie.Naam, actiefContactSoort = ContactSoort.Organisatie.ToString() });
        }

        public IActionResult ContactForm(ContactSoort contactSoort, int contactId, bool bestaalAl)
        {
            var model = new NieuwViewModel
            {
                ContactSoort = contactSoort,
                Titel = bestaalAl ? "Update " + contactSoort.ToString() : "Nieuwe " + contactSoort.ToString()
            };

            if (contactSoort == ContactSoort.Persoon)
            {
                model.Persoon = _nieuwContactRepository.PersoonMetId(contactId);
            }
            else
            {
                model.Organisatie = _nieuwContactRepository.OrganisatieMetId(contactId);
            }

            return View(model);
        }


        public JsonResult Personen(string naam)
        {
            var personen = _nieuwContactRepository.PersonenMetNaam(naam);
            return Json(personen);
        }
    }
}