using System;

namespace ContactManager.Model
{
    public class Persoon : Contact
    {
        public Persoon(){
        }

        public DateTime? GeboorteDatum { get; set; }

        public string Mugshot { get; set; }

        public override ContactSoort GeefContactSoort()
        {
            return ContactSoort.Persoon;
        }


        public override string ToString()
        {
            return $"{base.ToString()}, {nameof(GeboorteDatum)}: {GeboorteDatum}";
        }
    }


}