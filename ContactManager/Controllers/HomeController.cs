using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Threading.Tasks;
using ContactManager.Data;
using ContactManager.ViewModels;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ContactManager.Controllers
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
            var model = new HomeViewModel()
            {
                Contacten = _contactRepository.AlleContacten()
            };
            
            return View(model);
        }
    }
}
