﻿using System.Collections.Generic;
using ContactManager.Model;

namespace ContactManager.Service.Interfaces
{
    public interface IToonContactRepository
    {
        IEnumerable<Contact> AlleContacten();
        IEnumerable<Contact> ContactenMetKlantNaam(string naam);
        Organisatie OrganisatieMetId(int id);
        Persoon PersoonMetId(int id);
    }

}