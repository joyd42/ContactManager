using System;
using ContactManager.Data;
using ContactManager.Model;
using ContactManager.Service.Interfaces;

namespace ContactManager.Service.Repositories
{
    public class WijzigContactRepository : ToonContactRepository, IWijzigContactRepository, IToonContactRepository
    {
        protected WijzigContactRepository()
        {
        }

        public WijzigContactRepository(Context context)
        {
            Context = context;
        }


        public void UpdatePersoon(Persoon persoon)
        {
            Context.Update(persoon);
            Context.Update(persoon.Adres);

            try
            {
                Context.UpdateRange(persoon.Telefoons);
            }
            catch (InvalidOperationException exc)
            {
                Context.AddRange(persoon.Telefoons);
            }
        }

        public void UpdatePersoonEnBewaar(Persoon persoon)
        {
            UpdatePersoon(persoon);
            Bewaar();
        }

        public void UpdateOrganisatie(Organisatie organisatie)
        {
            Context.Update(organisatie);
            Context.Update(organisatie.Adres);
            if (organisatie.ContactPersoon != null)
                Context.Update(organisatie.ContactPersoon);
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
    }
}
