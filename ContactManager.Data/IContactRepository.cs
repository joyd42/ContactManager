using System;
using System.Collections.Generic;
using System.Text;
using ContactManager.Model;

namespace ContactManager.Data
{
    public interface IContactRepository
    {
        IEnumerable<Contact> AlleContacten();
    }
}
