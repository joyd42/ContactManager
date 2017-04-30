using ContactManager.Model;

namespace ContactManager.Service.Interfaces
{
    public interface IWijzigContactRepository : IToonContactRepository
    {
        void UpdatePersoon(Persoon persoon);
        void UpdateOrganisatieEnBewaar(Organisatie organisatie);
        void UpdatePersoonEnBewaar(Persoon persoon);
        void UpdateOrganisatie(Organisatie organisatie);
        void Bewaar();
    }
}
