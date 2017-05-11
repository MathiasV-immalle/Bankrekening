using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Menu
{
    class Rekening
    {
        public string Voornaam { get; set; }
        public string Achternaam { get; set; }
        public string Leeftijd { get; set; }
        public long Saldo { get; set; }

        public Rekening()
        {
            string[] gegevens = { Voornaam, Achternaam, Leeftijd };
        }
    }
}
