using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Szilagyi_David_Autos_Eladasok
{
    class Eladasok_Lista
    {
        private List<Eladas_Adatok> eladasAdatok;

        public List<Eladas_Adatok> EladasAdat { get { return eladasAdatok; } }


        public Eladasok_Lista(string fajl, char hatarolo, int start = 1)
        {
            eladasAdatok = new List<Eladas_Adatok>();

            var sorok = File.ReadAllLines(fajl, Encoding.Default);

            for (int i = start; i < sorok.Length; i++)
            {
                eladasAdatok.Add(new Eladas_Adatok(sorok[i], hatarolo));
            }


        }
    }
}
