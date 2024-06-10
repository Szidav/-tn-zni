using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_feladat
{
    public class Dolgozo
    {
        public int Id { get; set; }
        public string Nev { get; set; }
        public string Foglalkozas { get; set; }
        public string Nyelv { get; set; }

        public Dolgozo(string sor) 
        {
            var adatok=sor.Split(';');
            Id = Convert.ToInt32(adatok[0]);
            Nev = adatok[1];
            Foglalkozas = adatok[2];
            Nyelv = adatok[3];
        }
    }
}
