using System;
using System.Collections.Generic;
using System.Text;
using ContactManager.Model;

namespace ContactManager.Service.Interfaces
{
    public interface IVerwijderContractRepository
    {
        void VerwijderOrganisatie(int organisatieId);
        void VerwijderPersoon(int persoonId);
        void VerwijderOrganisatieEnBewaar(int organisatieId);
        void VerwijderPersoonEnBewaar(int persoonId);
        void Bewaar();
        bool PersoonIsContactPersoonVoorOrganisatie(int persoonId);

    }
}
