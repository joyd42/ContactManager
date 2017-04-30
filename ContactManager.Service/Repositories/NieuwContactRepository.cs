using System.Linq;
using ContactManager.Data;
using ContactManager.Model;
using ContactManager.Service.Interfaces;

namespace ContactManager.Service.Repositories
{
    public class NieuwContactRepository : ToonContactRepository, INieuwContactRepository, IToonContactRepository
    {
        protected NieuwContactRepository()
        {
        }

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
            VoegToe(organisatie);
        }

        public void VoegOrganisatieToeEnBewaar(Organisatie organisatie)
        {
            VoegOrganisatieToe(organisatie);
            Bewaar();
        }

        public void VoegPersoonToe(Persoon persoon)
        {
            VoegToe(persoon);
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

        private IQueryable<T> Query<T>() where T : class
        {
            return Context.Set<T>();
        }
    }
}
