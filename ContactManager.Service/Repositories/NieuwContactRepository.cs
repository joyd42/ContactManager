using System;
using System.Collections.Generic;
using System.Text;
using ContactManager.Data;
using ContactManager.Model;
using ContactManager.Service.Interfaces;

namespace ContactManager.Service.Repositories
{
    public class NieuwContactRepository : INieuwContactRepository
    {
        protected NieuwContactRepository() { }
        protected Context Context { get; set; }

        public NieuwContactRepository(Context context)
        {
            Context = context;
        }
        public void Bewaar()
        {
            Context.SaveChanges();
        }

        public void VoegContactToe(Contact contact)
        {
            VoegToe<Contact>(contact);
        }

        public void VoegContactToeEnBewaar(Contact contact)
        {
            VoegContactToe(contact);
            Bewaar();
        }

        private void VoegToe<T>(T entity) where T : class
        {
            Context.Set<T>().Add(entity);
        }

    }
}
