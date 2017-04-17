using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContactManager.Model;

namespace ContactManager.ViewModels
{
    public class NieuwViewModel : BasisViewModel
    {
        public Persoon Persoon { get; set; } = new Persoon();
        public Organisatie Organisatie { get; set; } = new Organisatie();

        public ContactSoort ContactSoort { get; set; } 
    }
}
