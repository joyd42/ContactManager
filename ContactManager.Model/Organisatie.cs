using System;
using System.Collections.Generic;
using System.Text;

namespace ContactManager.Model
{
    public class Organisatie : Contact
    {
        public Persoon ContactPersoon { get; set; }

        public override string ToString()
        {
            return $"{base.ToString()}, {nameof(ContactPersoon)}: {ContactPersoon}";
        }
    }
}
