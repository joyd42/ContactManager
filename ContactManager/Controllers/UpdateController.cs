//using System.Linq;
//using ContactManager.Model;
//using ContactManager.Service.Interfaces;
//using ContactManager.ViewModels;
//using Microsoft.AspNetCore.Mvc;

//// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

//namespace ContactManager.Controllers
//{
//    public class UpdateController : Controller
//    {
//        private readonly IWijzigContactRepository _wijzigContactRepository;

//        public UpdateController(IWijzigContactRepository wijzigContactRepository)
//        {
//            _wijzigContactRepository = wijzigContactRepository;
//        }

//        // GET: /<controller>/
//        public IActionResult UpdatePersoon(Persoon persoon, string[] telefoonNaam, string[] telefoonNummer)
//        {
//            for (var i = 0; i < telefoonNaam.Length; i++)
//            {
//                persoon.VoegTelefoonToe(telefoonNaam[i], telefoonNummer[i]);
//            }

//            _wijzigContactRepository.UpdatePersoonEnBewaar(persoon);

//            return RedirectToAction("LaatstToegevoegdContactMetNaam", "Home", new { naam = persoon.Naam, actiefContactSoort = ContactSoort.Persoon.ToString() });
//        }
//        public IActionResult UpdateOrganisatie(Organisatie organisatie, string[] telefoonsNamen, string[] telefoonNummers, int? contactPersoonId)
//        {
//            organisatie.VoegTelefoonsToe(telefoonsNamen, telefoonNummers);

//            if (contactPersoonId != null)
//            {
//                organisatie.ContactPersoon = _wijzigContactRepository.PersoonMetId((int)contactPersoonId);
//            }
//            _wijzigContactRepository.UpdateOrganisatieEnBewaar(organisatie);
//            return RedirectToAction("LaatstToegevoegdContactMetNaam", "Home", new { naam = organisatie.Naam, actiefContactSoort = ContactSoort.Organisatie.ToString() });
//        }

//        public IActionResult UpdateContactForm(ContactSoort contactSoort)
//        {
//            var model = new UpdateViewModel
//            {
//                Titel = "Nieuwe " + contactSoort.ToString(),
//                ContactSoort = contactSoort

//            };
//            return View(model);
//        }

//    }
//}
