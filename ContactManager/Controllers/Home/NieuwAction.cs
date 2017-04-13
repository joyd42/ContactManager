using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContactManager.Model;
using ContactManager.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ContactManager.Controllers.Home
{
    public partial class HomeController
    {
        public IActionResult Nieuw(string naam, string straat, string gemeente)
        {
            return null;

        }

        public IActionResult NieuwForm(ContactSoort contactSoort)
        {
            var model = new NieuwViewModel
            {
                VoorbeeldContact = NieuwContactVanJuisteSoort(contactSoort)
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
