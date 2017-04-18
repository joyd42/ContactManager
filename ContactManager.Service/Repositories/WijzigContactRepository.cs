using System;
using System.Collections.Generic;
using System.Text;
using ContactManager.Model;
using ContactManager.Service.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ContactManager.Service.Repositories
{
    public class WijzigContactRepository : ToonContactRepository, IWijzigContactRepository, IToonContactRepository
    {
        public void UpdatePersoon(Persoon persoon)
        {
            Update<Persoon>(persoon);
        }
        public void UpdatePersoonEnBewaar(Persoon persoon)
        {
            UpdatePersoon(persoon);
            Bewaar();
        }

        public void UpdateOrganisatie(Organisatie organisatie)
        {
            Update<Organisatie>(organisatie);
        }
        public void UpdateOrganisatieEnBewaar(Organisatie organisatie)
        {
            UpdateOrganisatie(organisatie);
            Bewaar();
        }

        public void Bewaar()
        {
            Context.SaveChanges();
        }

        private void Update<T>(T entity) where T : class
        {
            Context.Entry(entity).State = EntityState.Modified;
        }
    }
}
