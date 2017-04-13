using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContactManager.Service.Interfaces;
using ContactManager.Model;
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



        public IActionResult Nieuw(Contact contact)
        {
            var nieuwContact = contact;


            
            return View(null);

        }

        public IActionResult NieuwForm(ContactSoort contactSoort)
        {
            var model = new NieuwViewModel
            {
                Contact = NieuwContactVanJuisteSoort(contactSoort)
            };
            return View(model);
        }

        private static Contact NieuwContactVanJuisteSoort(ContactSoort contactSoort)
        {
            Contact contact;
            if (contactSoort == ContactSoort.Organisatie)
            {
                contact = new Organisatie();
            }
            else
            {
                contact = new Persoon();
            }
            return contact;
        }
    }
}
