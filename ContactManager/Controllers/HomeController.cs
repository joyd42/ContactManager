﻿using System.Linq;
using ContactManager.Model;
using ContactManager.Service.Interfaces;
using ContactManager.ViewModels;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ContactManager.Controllers
{
    public class HomeController : Controller
    {
        private readonly IToonContactRepository _toonContactRepository;

        public HomeController(IToonContactRepository toonContactRepository)
        {
            _toonContactRepository = toonContactRepository;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {

            return RedirectToAction(nameof(Contacten));
        }

        public IActionResult Contacten(string filter, int actiefContactId, string actiefContactSoort)
        {
            var model = new ContactenViewModel
            {
                Contacten = string.IsNullOrEmpty(filter)
                    ? _toonContactRepository.AlleContacten()
                    : _toonContactRepository.ContactenMetNaam(filter),
                Filter = filter,
                ActiefContactId = actiefContactId,
                ActiefContact = GeefActiefContact(actiefContactId, actiefContactSoort)
            };


            return View(model);
        }

        public IActionResult LaatstToegevoegdContactMetNaam(string naam, string actiefContactSoort)
        {
            var contactLijst = _toonContactRepository.ContactenMetNaam(naam);
            var id = contactLijst.Select(contact => contact.Id).Max();

            return RedirectToAction(nameof(Contacten), new { actiefContactId = id, actiefContactSoort = actiefContactSoort });
        }

        private Contact GeefActiefContact(int actiefContactId, string actiefContactSoort)
        {
            Contact actiefContact = null;
            if (string.IsNullOrEmpty(actiefContactSoort))
            {
                actiefContact = new Contact
                {
                    Naam = "",
                    Id = 0,
                    Adres = { Id = 0, Land = "", Locatie = "", Straat = "" }
                };
            }

            else if (actiefContactSoort == nameof(Organisatie))
            {
                actiefContact = _toonContactRepository.OrganisatieMetId(actiefContactId);
            }
            else if (actiefContactSoort == nameof(Persoon))
            {
                actiefContact = _toonContactRepository.PersoonMetId(actiefContactId);
            }

            return actiefContact;
        }
    }
}
