using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Jackie
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Statisztika> lista = new List<Statisztika>();
            
            //2. feladat megoldása
            using (StreamReader fajl = new StreamReader("jackie.txt", Encoding.UTF8))
            {
                fajl.ReadLine();
                while (!fajl.EndOfStream)
                {
                    lista.Add(new Statisztika(fajl.ReadLine()));
                }

            }

            //3. feladat
            Console.WriteLine($"3. feladat: {lista.Count}");

            //4. feladat
            Console.WriteLine($"4. feladat: {lista.First(x=>x.Races == lista.Max(y=>y.Races)).Year}");

            //5. feladat
            Console.WriteLine($"5. feladat:\n\r\t60-as évek {lista.Where(x => x.Year >= 1960 && x.Year < 1970).Sum(y => y.Wins)} megnyert verseny\n\r\t70-as évek {lista.Where(x => x.Year >= 1970 && x.Year < 1980).Sum(y => y.Wins)} megnyert verseny");

            //6. feladat
            using (StreamWriter html = new StreamWriter("jackie.html", false, Encoding.UTF8))
            {
                html.WriteLine("<!DOCTYPE html>");
                html.WriteLine("<html lang=\"hu-HU\">");
                html.WriteLine("\t<head><style>td{border: solid 1px #000;}</style></head>");
                html.WriteLine("\t<body>");
                html.WriteLine("\t\t<h1>Jackie Stewart</h1>");
                html.WriteLine("\t\t<table border=\"1px\">");
                html.WriteLine("\t\t\t<thead><tr><th>Év</th><th>Versenyek száma</th><th>Győzelmek száma</th></tr></thead>");
                html.WriteLine("\t\t\t<tbody>");
                foreach (Statisztika item in lista.OrderBy(x => x.Year))
                {
                    html.WriteLine($"\t\t\t\t<tr><td>{item.Year}</td><td>{item.Races}</td><td>{item.Wins}</td></tr>");
                }
                html.WriteLine("\t\t\t</tbody>");
                html.WriteLine("\t\t</table>");
                html.WriteLine("\t</body>");
                html.WriteLine("</html>");
            }
            Console.WriteLine("6. feladat: jackie.html");
            Console.ReadKey();
        }
        class Statisztika
        {
            int year, races, wins, podiums, fastests;

            public int Year { get => year; set => year = value; }
            public int Races { get => races; set => races = value; }
            public int Wins { get => wins; set => wins = value; }
            public int Podiums { get => podiums; set => podiums = value; }
            public int Fastests { get => fastests; set => fastests = value; }

            public Statisztika(int year, int races, int wins, int podiums, int fastests)
            {
                Year = year;
                Races = races;
                Wins = wins;
                Podiums = podiums;
                Fastests = fastests;
            }

            public Statisztika(string adatsor)
            {
                string[] adatok = adatsor.Split('\t');
                Year = int.Parse(adatok[0]);
                Races = int.Parse(adatok[1]);
                Wins = int.Parse(adatok[2]);
                Podiums = int.Parse(adatok[3]);
                Fastests = int.Parse(adatok[4]);
            }
        }
    }
}
