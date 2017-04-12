using System;
using System.Collections.Generic;
using System.Text;

namespace ContactManager.Model
{
    public class Adres
    {
        internal Adres()
        {
        }
        public int Id { get; set; }

        public string Straat { get; set; }
        public string Locatie { get; set; }
        public string Land { get; set; }
        public Contact Contact { get; set; }

        public override string ToString()
        {
            return $"{Straat}, {Locatie}, {Land}";
        }
    }
}
