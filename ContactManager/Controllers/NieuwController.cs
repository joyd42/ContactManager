using ContactManager.Model;
using ContactManager.Service.Interfaces;
using ContactManager.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ContactManager.Controllers
{
    public class NieuwController : Controller
    {
        private readonly INieuwContactRepository _nieuwContactRepository;

        public NieuwController(INieuwContactRepository nieuwContactRepository)
        {
            _nieuwContactRepository = nieuwContactRepository;
        }


        public IActionResult NieuwePersoon(Persoon persoon)
        {
            _nieuwContactRepository.VoegPersoonToeEnBewaar(persoon);
            return RedirectToAction("Contacten", "Home");
        }

        public IActionResult NieuwePersoonForm()
        {
            var model = new NieuwViewModel
            {
                Persoon = new Persoon()
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
                Organisatie = new Organisatie()
            };
            return View(model);
        }

    }
}