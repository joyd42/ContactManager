using System;
using ContactManager.Data;
using ContactManager.Service.Interfaces;

namespace ContactManager.Service.Repositories
{
    public class VerwijderContactRepository : ToonContactRepository, IVerwijderContactRepository, IToonContactRepository
    {
        protected VerwijderContactRepository()
        {
        }

        public VerwijderContactRepository(Context context)
        {
            Context = context;
        }

        public void VerwijderOrganisatie(int organisatieId)
        {
            var organisatie = OrganisatieMetId(organisatieId);
            Context.Contacten.Remove(organisatie);
        }

        public void VerwijderPersoon(int persoonId)
        {
            var persoon = PersoonMetId(persoonId);
            if (PersoonIsContactPersoonVoorOrganisatie(persoonId))
                throw new InvalidOperationException("Persoon is contactpersoon");
            Context.Contacten.Remove(persoon);
        }


        public void VerwijderOrganisatieEnBewaar(int organisatieId)
        {
            VerwijderOrganisatie(organisatieId);
            Bewaar();
        }

        public void VerwijderPersoonEnBewaar(int persoonId)
        {
            VerwijderPersoon(persoonId);
            Bewaar();
        }

        public void Bewaar()
        {
            Context.SaveChanges();
        }
    }
}
