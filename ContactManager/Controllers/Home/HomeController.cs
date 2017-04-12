using ContactManager.Data;
using ContactManager.ViewModels;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ContactManager.Controllers.Home
{
    public class HomeController : Controller
    {
        private readonly IContactRepository _contactRepository;

        public HomeController(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {

            return RedirectToAction(nameof(Contacten));
        }

        public IActionResult Contacten(string filter, int actiefContactId)
        {
            var model = new HomeViewModel()
            {
                Contacten = _contactRepository.AlleContacten(),
                Filter = filter,
                ActiefContactId = actiefContactId
            };
            return View(model);
        }
    }
}
