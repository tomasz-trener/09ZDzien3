using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P02BibliotekaManagerZawodnikow
{
  public class Zawodnik
    {
        public int Id;
        public int IdTrenera;
        public string Imie;
        public string Nazwisko;
        public string Kraj;
        public int Waga;
        public int Wzrost;
        public DateTime DataUrodzenia;

        public string ImieNazwisko
        {
            get
            {
                return Imie + " " + Nazwisko;
            }
        }


    }
}
