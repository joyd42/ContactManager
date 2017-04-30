using System.Collections.Generic;
using System.Linq;
using ContactManager.Model;

namespace ContactManager.Service.Interfaces
{
    public interface IToonContactRepository
    {
        IEnumerable<Contact> AlleContacten();
        IEnumerable<Contact> ContactenMetNaam(string naam);
        IEnumerable<Persoon> PersonenMetNaam(string naam);
        Organisatie OrganisatieMetId(int id);
        Persoon PersoonMetId(int id);
        IQueryable<Persoon> QueryPersonen();
        IQueryable<Organisatie> QueryOrganisaties();
        bool PersoonIsContactPersoonVoorOrganisatie(int persoonId);
    }

}
