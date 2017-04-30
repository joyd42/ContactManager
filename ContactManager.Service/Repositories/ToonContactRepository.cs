using System.Collections.Generic;
using System.Linq;
using ContactManager.Data;
using ContactManager.Model;
using ContactManager.Service.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ContactManager.Service.Repositories
{
    public class ToonContactRepository : IToonContactRepository
    {
        protected ToonContactRepository()
        {
        }

        protected Context Context { get; set; }

        public ToonContactRepository(Context context)
        {
            Context = context;
        }

        public IEnumerable<Contact> AlleContacten()
        {
            return QueryContacten()
                .Take(100)
                .ToList();
        }

        public IEnumerable<Contact> ContactenMetNaam(string naam)
        {
            return QueryContacten()
                .Where(c => c.Naam.Contains(naam))
                .Take(10)
                .ToList();
        }

        public IEnumerable<Persoon> PersonenMetNaam(string naam)
        {
            return QueryPersonen()
                .Where(p => p.Naam.Contains(naam))
                .Take(10)
                .ToList();
        }


        public Organisatie OrganisatieMetId(int id)
        {
            return QueryContacten()
                .OfType<Organisatie>()
                .Include(o => o.ContactPersoon)
                .FirstOrDefault(o => o.Id.Equals(id));
        }

        public Persoon PersoonMetId(int id)
        {
            return QueryContacten()
                .OfType<Persoon>()
                .FirstOrDefault(p => p.Id.Equals(id));
        }

        public IQueryable<Persoon> QueryPersonen()
        {
            return Query<Persoon>();
        }

        public IQueryable<Organisatie> QueryOrganisaties()
        {
            return Query<Organisatie>();
        }

        private IQueryable<Contact> QueryContacten()
        {
            return Query<Contact>()
                .Include(c => c.Adres)
                .Include(c => c.Telefoons);
        }


        private IQueryable<T> Query<T>() where T : class
        {
            return Context.Set<T>();
        }

        public bool PersoonIsContactPersoonVoorOrganisatie(int persoonId)
        {
            var organisatiesVoorPersoon = QueryOrganisaties().Where(o => o.ContactPersoon.Id.Equals(persoonId));

            return organisatiesVoorPersoon.Any();
        }
    }
}
