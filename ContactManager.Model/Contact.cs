using System;
using System.Collections.Generic;

namespace ContactManager.Model
{
    public abstract class Contact
    {
        protected Contact() { }

        public int Id { get; set; }

        public string Naam { get; set; }
        public Adres Adres { get; protected set; } = new Adres();

        


        public IList<Telefoon> Telefoons { get;  set; } = new List<Telefoon>();

        public void VoegTelefoonToe(string naam, string nummer)
        {
            Telefoons.Add(new Telefoon(naam, nummer));
        }
        public void VoegTelefoonToe(string naam, string nummer, int id)
        {
            Telefoons.Add(new Telefoon(naam, nummer, id));
        }

        public void VoegTelefoonsToe(string[] telefoonsNamen, string[] telefoonNummers)
        {
            for (var i = 0; i < telefoonsNamen.Length; i++)
            {
                VoegTelefoonToe(telefoonsNamen[i], telefoonNummers[i]);
            }
        }
        public void VoegTelefoonsToe(string[] telefoonsNamen, string[] telefoonNummers, int[] iDs)
        {
            for (var i = 0; i < telefoonsNamen.Length; i++)
            {
                VoegTelefoonToe(telefoonsNamen[i], telefoonNummers[i], iDs[i]);
            }
        }

        public void VerwijderTelefoon(Telefoon telefoon)
        {
            Telefoons.Remove(telefoon);
        }

        public abstract ContactSoort GeefContactSoort();

        public override string ToString()
        {
            return $"{Naam} @ {Adres}";
        }
    }
}
