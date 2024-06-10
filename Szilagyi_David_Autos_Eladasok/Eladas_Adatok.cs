using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Szilagyi_David_Autos_Eladasok
{
    class Eladas_Adatok
    {
        public string Country { get; set; }
        public int Sales2005 { get; set; }
        public int Sales2006 { get; set; }
        public int Sales2007 { get; set; }
        public int Sales2008 { get; set; }
        public int Sales2009 { get; set; }
        public int Sales2010 { get; set; }
        public int Sales2011 { get; set; }
        public int Sales2012 { get; set; }
        public int Sales2013 { get; set; }
        public int Sales2014 { get; set; }
        public int Sales2015 { get; set; }
        public int Sales2016 { get; set; }
        public int Sales2017 { get; set; }
        public int Sales2018 { get; set; }
        public int Sales2019 { get; set; }
        public int Sales2020 { get; set; }
        public int Sales2021 { get; set; }
        public int Sales2022 { get; set; }

        public Eladas_Adatok(string sor, char hatarolo)
        {
            var adatok = sor.Split(hatarolo);

            

            Country = adatok[0];
            Sales2005 = String.IsNullOrEmpty(adatok[1]) ? 0 : int.Parse(adatok[1].Replace(",",""));
            Sales2006 = String.IsNullOrEmpty(adatok[2]) ? 0 : int.Parse(adatok[2].Replace(",", ""));
            Sales2007 = String.IsNullOrEmpty(adatok[3]) ? 0 : int.Parse(adatok[3].Replace(",", ""));
            Sales2008 = String.IsNullOrEmpty(adatok[4]) ? 0 : int.Parse(adatok[4].Replace(",", ""));
            Sales2009 = String.IsNullOrEmpty(adatok[5]) ? 0 : int.Parse(adatok[5].Replace(",", ""));
            Sales2010 = String.IsNullOrEmpty(adatok[6]) ? 0 : int.Parse(adatok[6].Replace(",", ""));
            Sales2011 = String.IsNullOrEmpty(adatok[7]) ? 0 : int.Parse(adatok[7].Replace(",", ""));
            Sales2012 = String.IsNullOrEmpty(adatok[8]) ? 0 : int.Parse(adatok[8].Replace(",", ""));
            Sales2013 = String.IsNullOrEmpty(adatok[9]) ? 0 : int.Parse(adatok[9].Replace(",", ""));
            Sales2014 = String.IsNullOrEmpty(adatok[10]) ? 0 : int.Parse(adatok[10].Replace(",", ""));
            Sales2015 = String.IsNullOrEmpty(adatok[11]) ? 0 : int.Parse(adatok[11].Replace(",", ""));
            Sales2016 = String.IsNullOrEmpty(adatok[12]) ? 0 : int.Parse(adatok[12].Replace(",", ""));
            Sales2017 = String.IsNullOrEmpty(adatok[13]) ? 0 : int.Parse(adatok[13].Replace(",", ""));
            Sales2018 = String.IsNullOrEmpty(adatok[14]) ? 0 : int.Parse(adatok[14].Replace(",", ""));
            Sales2019 = String.IsNullOrEmpty(adatok[15]) ? 0 : int.Parse(adatok[15].Replace(",", ""));
            Sales2020 = String.IsNullOrEmpty(adatok[16]) ? 0 : int.Parse(adatok[16].Replace(",", ""));
            Sales2021 = String.IsNullOrEmpty(adatok[17]) ? 0 : int.Parse(adatok[17].Replace(",", ""));
            Sales2022 = String.IsNullOrEmpty(adatok[18]) ? 0 : int.Parse(adatok[18].Replace(",", ""));

            
        }
    }
}
