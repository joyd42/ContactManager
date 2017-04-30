using ContactManager.Model;

namespace ContactManager.ViewModels
{
    public class NieuwViewModel : BasisViewModel
    {
        public Persoon Persoon { get; set; }
        public Organisatie Organisatie { get; set; }
        public bool BestaatAl { get; set; }
        public ContactSoort ContactSoort { get; set; }
    }
}
