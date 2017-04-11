using System;
using System.Collections.Generic;
using System.Text;

namespace ContactManager.Model
{
    public class Persoon : Contact
    {
        public DateTime? GeboorteDatum { get; set; }
    }
}
