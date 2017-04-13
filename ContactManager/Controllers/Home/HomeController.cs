using System.Collections.Generic;
using ContactManager.Data;
using ContactManager.Model;
using ContactManager.Service.Interfaces;
using ContactManager.ViewModels;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ContactManager.Controllers.Home
{
    public partial class HomeController : Controller
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
    }
}
