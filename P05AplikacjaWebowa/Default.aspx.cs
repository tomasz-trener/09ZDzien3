using P02BibliotekaManagerZawodnikow;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace P05AplikacjaWebowa
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnWczytaj_Click(object sender, EventArgs e)
        {
            ManagerZawodnikow mz = new ManagerZawodnikow();
            Zawodnik[] zawodnicy=  mz.WczytajZawodnikowZBazy();

            foreach (var z in zawodnicy)
                lbDane.Items.Add(z.ImieNazwisko);
        }
    }
}