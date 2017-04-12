using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContactManager.Model;

namespace ContactManager.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Contact> Contacten { get; set; }

        public string Filter { get; set; }

        public IEnumerable<Contact> ContactenMetNaam
        {
            get
            {
                if (string.IsNullOrEmpty(Filter))
                {
                    return Contacten;
                }
                else
                {
                    return Contacten.Where(c => c.Naam.Contains(Filter));
                }
            }
        }

        

    }
}
