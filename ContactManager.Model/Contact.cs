using System;
using System.Collections.Generic;

namespace ContactManager.Model
{
    public class Contact
    {

        public int Id { get; set; }

        public string Naam { get; set; }
        public Adres Adres { get; protected set; } = new Adres();

        public string Mugshot { get; set; }


        public ICollection<Telefoon> Telefoons { get; protected set; } = new List<Telefoon>();

        //public void AddTelefoon(string naam, string nummer)
        //{
        //    Telefoons.Add(new Telefoon(naam, nummer));
        //}

        //public void RemoveTelefoon(Telefoon telefoon)
        //{
        //    Telefoons.Remove(telefoon);
        //}

        //public override string ToString()
        //{
        //    return $"{Naam} @ {Adres}";
        //}
    }
}
