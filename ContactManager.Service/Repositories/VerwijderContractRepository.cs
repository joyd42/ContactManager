using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ContactManager.Data;
using ContactManager.Model;
using ContactManager.Service.Interfaces;

namespace ContactManager.Service.Repositories
{
    public class VerwijderContractRepository : ToonContactRepository, IVerwijderContractRepository, IToonContactRepository
    {
        protected VerwijderContractRepository(){}

        public VerwijderContractRepository(Context context)
        {
            Context = context;
        }

        public void VerwijderOrganisatie(int organisatieId)
        {
            Organisatie organisatie = OrganisatieMetId(organisatieId);
            Context.Contacten.Remove(organisatie);
        }

        public void VerwijderPersoon(int persoonId)
        {
            Persoon persoon = PersoonMetId(persoonId);
            if (persoon.IsContactPersoonVoorOrganisatie())
            {
                throw new InvalidOperationException("Persoon is contactpersoon voor " + persoon.Organisatie.Naam);
            }
            else
            {
                Context.Contacten.Remove(persoon);
            }
            
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

        public bool PersoonIsContactPersoonVoorOrganisatie(int persoonId)
        {
            Persoon persoon = PersoonMetId(persoonId);
            return persoon.IsContactPersoonVoorOrganisatie();
        }


    }
}
