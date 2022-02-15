using P02BibliotekaManagerZawodnikow;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace P01AplikacjaZawodnicy
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnWczytaj_Click(object sender, EventArgs e)
        {
            Odswiez();
        }

        private void Odswiez()
        {
            ManagerZawodnikow mz = new ManagerZawodnikow();
            Zawodnik[] zawodnicy = mz.WczytajZawodnikowZBazy();

            //  lbDane.Items.Clear();

            //foreach (var z in zawodnicy)
            //    lbDane.Items.Add(z.ImieNazwisko);
            // zamiast dodawać napisy do kontrolki
            // zastosujemy data binding 

            lbDane.DataSource = zawodnicy;
            lbDane.DisplayMember = "ImieNazwisko";
        }

        private void btnDodaj_Click(object sender, EventArgs e)
        {
            Zawodnik z = new Zawodnik();
            z.Imie = txtImie.Text;
            z.Nazwisko = txtNazwisko.Text;
            z.DataUrodzenia = DateTime.Now;

            ManagerZawodnikow mz = new ManagerZawodnikow();
            mz.DodajDoBazy(z);
            Odswiez();
        }

        private void btnUsun_Click(object sender, EventArgs e)
        {
            Zawodnik zaznaczony = (Zawodnik)lbDane.SelectedItem;

            ManagerZawodnikow mz = new ManagerZawodnikow();
            mz.UsunZBazy(zaznaczony);
            Odswiez();
        }

        private void lbDane_SelectedIndexChanged(object sender, EventArgs e)
        {
            Zawodnik zaznaczony = (Zawodnik)lbDane.SelectedItem;
            txtImie.Text = zaznaczony.Imie;
            txtNazwisko.Text = zaznaczony.Nazwisko;
        }

        private void btnEdytuj_Click(object sender, EventArgs e)
        {
            Zawodnik zaznaczony = (Zawodnik)lbDane.SelectedItem;
            zaznaczony.Imie = txtImie.Text;
            zaznaczony.Nazwisko = txtNazwisko.Text;

            ManagerZawodnikow mz = new ManagerZawodnikow();
            mz.EdytujWBazie(zaznaczony);
            Odswiez();
        }
    }
}
