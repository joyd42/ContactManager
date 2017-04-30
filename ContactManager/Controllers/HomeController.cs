using System.Linq;
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

        public IActionResult Contacten(string filter, int actiefContactId, ContactSoort actiefContactSoort)
        {
            var model = new ContactenViewModel
            {
                Contacten = string.IsNullOrEmpty(filter)
                    ? _toonContactRepository.AlleContacten()
                    : _toonContactRepository.ContactenMetNaam(filter),
                Filter = filter,
                ActiefContactId = actiefContactId,
                ActiefContact = GeefActiefContact(actiefContactId, actiefContactSoort),
                Titel = "Vind contact",
                PersoonIsContactPersoon = _toonContactRepository.PersoonIsContactPersoonVoorOrganisatie(actiefContactId)
            };


            return View(model);
        }

        public IActionResult LaatstToegevoegdContactMetNaam(string naam, ContactSoort actiefContactSoort)
        {
            var contactLijst = _toonContactRepository.ContactenMetNaam(naam);
            var id = contactLijst.Select(contact => contact.Id).Max();
            var laatstToegevoegdContact = GeefActiefContact(id, actiefContactSoort);

            return RedirectToAction(nameof(Contacten),
                new {actiefContactId = id, actiefContact = laatstToegevoegdContact, actiefContactSoort});
        }

        private Contact GeefActiefContact(int actiefContactId, ContactSoort? actiefContactSoort)
        {
            Contact actiefContact = null;
            if (actiefContactSoort == null)
                actiefContact = new Persoon
                {
                    Naam = "",
                    Id = 0,
                    Adres = {Id = 0, Land = "", Locatie = "", Straat = ""}
                };

            else if (actiefContactSoort == ContactSoort.Organisatie)
                actiefContact = _toonContactRepository.OrganisatieMetId(actiefContactId);
            else if (actiefContactSoort == ContactSoort.Persoon)
                actiefContact = _toonContactRepository.PersoonMetId(actiefContactId);

            return actiefContact;
        }
    }
}
