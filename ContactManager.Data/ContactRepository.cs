using System;
using System.Collections.Generic;
using System.Linq;
using ContactManager.Model;
using Microsoft.EntityFrameworkCore;


namespace ContactManager.Data
{
    public class ContactRepository : IContactRepository
    {
        protected ContactRepository() { }
        protected Context Context { get; set; }

        public ContactRepository(Context context)
        {
            Context = context;
        }

        public IEnumerable<Contact> AlleContacten()
        {
            return QueryContacten()
                    .Take(100)
                    .ToList();
        }

        public IEnumerable<Contact> ContactenMetKlantNaam(string naam)
        {
            return QueryContacten()
                    .Where(c => c.Naam.Contains(naam))
                    .Take(100)
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
    }
}
