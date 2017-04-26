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
        private readonly IVerwijderContractRepository _verwijderContractRepository;

        public NieuwController(INieuwContactRepository nieuwContactRepository, IWijzigContactRepository wijzigContactRepository, IVerwijderContractRepository verwijderContractRepository)
        {
            _nieuwContactRepository = nieuwContactRepository;
            _wijzigContactRepository = wijzigContactRepository;
            _verwijderContractRepository = verwijderContractRepository;
        }



        public IActionResult NieuwePersoon(Persoon persoon, string[] telefoonsNamen, string[] telefoonNummers)
        {
            persoon.VoegTelefoonsToe(telefoonsNamen, telefoonNummers);

            _nieuwContactRepository.VoegPersoonToeEnBewaar(persoon);
            return RedirectToAction(nameof(HomeController.LaatstToegevoegdContactMetNaam), "Home", new { naam = persoon.Naam, actiefContactSoort = ContactSoort.Persoon.ToString() });
        }

        public IActionResult UpdatePersoon(Persoon persoon, string[] telefoonsNamen, string[] telefoonNummers, int[] iDs)
        {
            persoon.Telefoons.Clear();
            persoon.VoegTelefoonsToe(telefoonsNamen, telefoonNummers);

            _wijzigContactRepository.UpdatePersoonEnBewaar(persoon);
            return RedirectToAction(nameof(HomeController.LaatstToegevoegdContactMetNaam), "Home", new { naam = persoon.Naam, actiefContactSoort = ContactSoort.Persoon.ToString() });
        }

        public IActionResult UpdateOrganisatie(Organisatie organisatie, string[] telefoonsNamen, string[] telefoonNummers, int[] iDs, int contactPersoonId)
        {
            organisatie.Telefoons.Clear();
            organisatie.VoegTelefoonsToe(telefoonsNamen, telefoonNummers);
            if (contactPersoonId != 0)
            {
                organisatie.ContactPersoon = _wijzigContactRepository.PersoonMetId(contactPersoonId);
            }
            

            _wijzigContactRepository.UpdateOrganisatieEnBewaar(organisatie);
            return RedirectToAction(nameof(HomeController.LaatstToegevoegdContactMetNaam), "Home", new { naam = organisatie.Naam, actiefContactSoort = ContactSoort.Organisatie.ToString() });
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
                Titel = bestaalAl ? "Update " + contactSoort.ToString() : "Nieuwe " + contactSoort.ToString(),
                BestaatAl = bestaalAl
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

        public IActionResult VerwijderContact(ContactSoort contactSoort, int contactId)
        {
            if (contactSoort == ContactSoort.Organisatie)
            {
                _verwijderContractRepository.VerwijderOrganisatieEnBewaar(contactId);
            }
            else
            {
                if (_verwijderContractRepository.PersoonIsContactPersoonVoorOrganisatie(contactId))
                {
                    return Content("Persoon kan niet verwijderd worden omdat hij een contactpersoon is voor een organisatie");
                }
                else
                {
                    _verwijderContractRepository.VerwijderPersoonEnBewaar(contactId);
                   
                }
            }
            return RedirectToAction(nameof(HomeController.Contacten), "Home");
        }

        public JsonResult Personen(string naam)
        {
            var personen = _nieuwContactRepository.PersonenMetNaam(naam);
            return Json(personen);
        }
    }
}