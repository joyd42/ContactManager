using System;
using System.Collections.Generic;
using System.Linq;
using ContactManager.Model;


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
            return Context.Set<Contact>().ToList();
        }






        private IQueryable<Contact> QueryContacten()
        {
            return Query<Contact>();
        }

        private IQueryable<T> Query<T>() where T : class
        {
            return Context.Set<T>();
        }
    }
}
