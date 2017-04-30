namespace ContactManager.Service.Interfaces
{
    public interface IVerwijderContactRepository : IToonContactRepository
    {
        void VerwijderOrganisatie(int organisatieId);
        void VerwijderPersoon(int persoonId);
        void VerwijderOrganisatieEnBewaar(int organisatieId);
        void VerwijderPersoonEnBewaar(int persoonId);
        void Bewaar();
    }
}
