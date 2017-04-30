using System.Collections.Generic;
using ContactManager.Model;

namespace ContactManager.ViewModels
{
    public class ContactenViewModel : BasisViewModel
    {
        public IEnumerable<Contact> Contacten { get; set; }
        public string Filter { get; set; }
        public int ActiefContactId { get; set; }
        public Contact ActiefContact { get; set; }
        public bool PersoonIsContactPersoon { get; set; }
    }
}
