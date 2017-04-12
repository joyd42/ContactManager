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
            return QueryContacten().ToList();
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
