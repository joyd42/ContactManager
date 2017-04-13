using System;
using System.Collections.Generic;
using System.Text;
using ContactManager.Model;

namespace ContactManager.Service.Interfaces
{
    public interface INieuwContactRepository
    {
        void Bewaar();
        void VoegOrganisatieToe(Organisatie organisatie);
        void VoegOrganisatieToeEnBewaar(Organisatie organisatie);
        void VoegPersoonToe(Persoon persoon);
        void VoegPersoonToeEnBewaar(Persoon persoon);

    }
}
