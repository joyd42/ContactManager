using System;
using System.Collections.Generic;

namespace ContactManager.Model
{
    public class Contact
    {

        public int Id { get; set; }

        public string Naam { get; set; }
        public Adres Adres { get; protected set; } = new Adres();

        


        public ICollection<Telefoon> Telefoons { get;  set; } = new List<Telefoon>();

        public void VoegTelefoonToe(string naam, string nummer)
        {
            Telefoons.Add(new Telefoon(naam, nummer));
        }

        public void VerwijderTelefoon(Telefoon telefoon)
        {
            Telefoons.Remove(telefoon);
        }

        public override string ToString()
        {
            return $"{Naam} @ {Adres}";
        }
    }
}
