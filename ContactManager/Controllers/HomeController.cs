using ContactManager.Model;
using ContactManager.Service.Interfaces;
using ContactManager.ViewModels;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ContactManager.Controllers
{
    public class HomeController : Controller
    {
        private readonly IToonContactRepository _contactRepository;

        public HomeController(IToonContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
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
                    ? _contactRepository.AlleContacten()
                    : _contactRepository.ContactenMetKlantNaam(filter),
                Filter = filter,
                ActiefContactId = actiefContactId,
                ActiefContact = GeefActiefContact(actiefContactId, actiefContactSoort)
            };


            return View(model);
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
                actiefContact = _contactRepository.OrganisatieMetId(actiefContactId);
            }
            else if (actiefContactSoort == nameof(Persoon))
            {
                actiefContact = _contactRepository.PersoonMetId(actiefContactId);
            }

            return actiefContact;
        }
    }
}
