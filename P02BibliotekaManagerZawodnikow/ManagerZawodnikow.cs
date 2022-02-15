using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace P02BibliotekaManagerZawodnikow
{
   public class ManagerZawodnikow
   {
        public Zawodnik[] WczytajZawodnikowZPliku()
        {
            WebClient wc = new WebClient();
            string url = "http://tomaszles.pl/wp-content/uploads/2019/06/zawodnicy.txt";
            string dane = wc.DownloadString(url);

            string[] wiersze = dane.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
            Zawodnik[] zawodnicy = new Zawodnik[wiersze.Length - 1];

            for (int i = 1; i < wiersze.Length; i++)
            {
                string[] komorki = wiersze[i].Split(';');
                Zawodnik zi = new Zawodnik();
                zi.Id = Convert.ToInt32(komorki[0]);

                if (!string.IsNullOrEmpty(komorki[1]))

                    zi.IdTrenera = Convert.ToInt32(komorki[1]);
                zi.Imie = komorki[2];
                zi.Nazwisko = komorki[3];
                zi.Kraj = komorki[4];
                zi.DataUrodzenia = Convert.ToDateTime(komorki[5]);
                zi.Waga = Convert.ToInt32(komorki[6]);
                zi.Wzrost = Convert.ToInt32(komorki[7]);
                zawodnicy[i - 1] = zi;
            }
            return zawodnicy;
        }

        public Zawodnik[] WczytajZawodnikowZBazy()
        {
            PolaczenieZBaza pzb = new PolaczenieZBaza();
            string[][] wynik= pzb.WykonajZapytanieSQL("select * from zawodnicy");

            Zawodnik[] zawodnicy = new Zawodnik[wynik.Length];
            for (int i = 0; i < wynik.Length; i++)
            {
                string[] komorki = wynik[i];
                Zawodnik zi = new Zawodnik();
                zi.Id = Convert.ToInt32(komorki[0]);

                if (!string.IsNullOrEmpty(komorki[1]))

                    zi.IdTrenera = Convert.ToInt32(komorki[1]);
                zi.Imie = komorki[2];
                zi.Nazwisko = komorki[3];
                zi.Kraj = komorki[4];
                zi.DataUrodzenia = Convert.ToDateTime(komorki[5]);
                zi.Waga = Convert.ToInt32(komorki[6]);
                zi.Wzrost = Convert.ToInt32(komorki[7]);
                zawodnicy[i] = zi;
            }
            return zawodnicy;
        }

        public void DodajDoBazy(Zawodnik z)
        {
            PolaczenieZBaza pzb = new PolaczenieZBaza();
            string sql = "insert into zawodnicy values " +
                $"(null, '{z.Imie}', '{z.Nazwisko}', '{z.Kraj}', '{z.DataUrodzenia.ToString("yyyyMMdd")}', {z.Wzrost}, {z.Waga});";
            pzb.WykonajZapytanieSQL(sql);
        }

        public void UsunZBazy(Zawodnik z)
        {
            string sql = $"delete zawodnicy where id_zawodnika={z.Id}";
            PolaczenieZBaza pzb = new PolaczenieZBaza();
            pzb.WykonajZapytanieSQL(sql);
        }

        public void EdytujWBazie(Zawodnik z)
        {
            string sql = "update zawodnicy set " +
                $"imie = '{z.Imie}', nazwisko = '{z.Nazwisko}' where id_zawodnika = {z.Id}";
            PolaczenieZBaza pzb = new PolaczenieZBaza();
            pzb.WykonajZapytanieSQL(sql);

        }
    }


}


// Microsoft SQL Server  <- pgoram do zarządzania bazą
// Oracle
// MySQL
// Postgres

