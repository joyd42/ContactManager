using System;
using System.Collections.Generic;
using System.Text;

namespace ContactManager.Model
{
    public class Telefoon
    {
        protected internal Telefoon(string naam, string nummer)
        {
            Naam = naam;
            Nummer = nummer;
        }

        public int Id { get; set; }
        public string Naam { get; set; }
        public string Nummer { get; set; }

        public override string ToString()
        {
            return $"{Naam}: {Nummer}";
        }
    }
}
