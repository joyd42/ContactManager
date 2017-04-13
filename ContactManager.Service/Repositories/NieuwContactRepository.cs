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

        public void VoegOrganisatieToe(Organisatie organisatie)
        {
            VoegToe<Organisatie>(organisatie);
        }

        public void VoegOrganisatieToeEnBewaar(Organisatie organisatie)
        {
            VoegOrganisatieToe(organisatie);
            Bewaar();
        }

        public void VoegPersoonToe(Persoon persoon)
        {
            VoegToe<Persoon>(persoon);
        }

        public void VoegPersoonToeEnBewaar(Persoon persoon)
        {
            VoegPersoonToe(persoon);
            Bewaar();
        }

        private void VoegToe<T>(T entity) where T : class
        {
            Context.Set<T>().Add(entity);
        }

    }
}
