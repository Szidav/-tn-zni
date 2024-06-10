using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Szilagyi_David_Autos_Eladasok
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Eladasok_Lista eladasokLista = null;
            try
            {
                eladasokLista = new Eladasok_Lista("car_sales_data_v2.csv", ';');

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.StackTrace);
            }

            //2
            Console.WriteLine($"2.feladat: Országok száma: {eladasokLista.EladasAdat.Count()}");
            Console.WriteLine("");

            //3
            Console.WriteLine($"3.feladat: Oszágok ABC rendbe: ");
            foreach (var orszagnev in eladasokLista.EladasAdat.Select(x => x.Country).OrderBy(e => e).Distinct())
            {
                Console.WriteLine(orszagnev);
            }
            Console.WriteLine("");

            //4 
            var eladasok2010 = eladasokLista.EladasAdat.Max(x=>x.Sales2010);

            var legtobbEladas2010 = eladasokLista.EladasAdat.Find(x => x.Sales2010==eladasok2010);

            Console.WriteLine($"4.feladat: A legtöbb autót eladó ország 2010-ben: {legtobbEladas2010.Country}");
            Console.WriteLine("");

            //5 
            var legtobbEladas = eladasokLista.EladasAdat.Select(x => new { country = x.Country, osszesAuto = x.Sales2005 + x.Sales2006 + x.Sales2007 + x.Sales2008 + x.Sales2009 + x.Sales2010 + x.Sales2011 + x.Sales2012 + x.Sales2013 + x.Sales2014 + x.Sales2015 + x.Sales2016 + x.Sales2017 + x.Sales2018 + x.Sales2019 + x.Sales2020 + x.Sales2021 + x.Sales2022 }).OrderBy(e => e.osszesAuto).ToList();
            var legtobbetElado = legtobbEladas.Last();
            Console.WriteLine($"5.feladat: A legtöbb autót eladó ország: {legtobbetElado.country}");
            Console.WriteLine("");

            //6 
            var legkevesebbEladas = legtobbEladas.First();
            Console.WriteLine($"6.feladat: A legkevesebb autót eladó ország:  {legkevesebbEladas.country}");
            Console.WriteLine("");

            //7
            var legtobbEladottAuto = eladasokLista.EladasAdat.SelectMany(x => new List<(int year, int eladottAutok)>
            {
                (2005, x.Sales2005), (2006, x.Sales2006), (2007, x.Sales2007), (2008, x.Sales2008), (2009, x.Sales2009), (2010, x.Sales2010), (2011, x.Sales2011), (2012, x.Sales2012), (2013, x.Sales2013), (2014, x.Sales2014), (2015, x.Sales2015), (2016, x.Sales2016), (2017, x.Sales2017),
                (2018, x.Sales2018), (2019, x.Sales2019), (2020, x.Sales2020), (2021, x.Sales2021), (2022, x.Sales2022)
            }).GroupBy(x=>x.year)
            .Select(e=> new { year = e.Key, eladottAutok = e.Sum(t=>t.eladottAutok) })
            .OrderByDescending(g=>g.eladottAutok).First().year;
            Console.WriteLine($"7.feladat: A legtöbb eladás éve: {legtobbEladottAuto}");
            Console.WriteLine("");

            //8 
            var legkevesebbEladottAuto = eladasokLista.EladasAdat.SelectMany(x => new List<(int year, int eladottAutok)>
            {
                (2005, x.Sales2005), (2006, x.Sales2006), (2007, x.Sales2007), (2008, x.Sales2008), (2009, x.Sales2009), (2010, x.Sales2010), (2011, x.Sales2011), (2012, x.Sales2012), (2013, x.Sales2013), (2014, x.Sales2014), (2015, x.Sales2015), (2016, x.Sales2016), (2017, x.Sales2017),
                (2018, x.Sales2018), (2019, x.Sales2019), (2020, x.Sales2020), (2021, x.Sales2021), (2022, x.Sales2022)
            }).Where(x=>x.eladottAutok > 0).GroupBy(x=>x.year)
            .Select(e=> new { year = e.Key, eladottAutok = e.Sum(t=>t.eladottAutok) })
            .OrderBy(g=>g.eladottAutok).First().year;
            Console.WriteLine($"8.feladat: A legkevesebb eladás éve: {legkevesebbEladottAuto}");
            Console.WriteLine("");


            //9
            Console.WriteLine("9.feladat: Az output fájl létrehozása");
            using (StreamWriter writer = new StreamWriter("output.csv"))
            {
                writer.WriteLine("country;year;sale");
                foreach (var adatokLista in eladasokLista.EladasAdat)
                {
                    for (int year=2005; year<=2022; year++)
                    {
                        double eladottAutok = Convert.ToDouble(adatokLista.GetType().GetProperty($"Sales{year}").GetValue(adatokLista));
                        writer.WriteLine($"{adatokLista.Country};{year};{eladottAutok}");
                    }
                }
            }
            Console.WriteLine("Az output.csv fájl létrehozva.");


            Console.ReadKey();
        }
    }
}
