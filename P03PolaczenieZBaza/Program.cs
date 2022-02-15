using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P03PolaczenieZBaza
{
    class Program
    {
        static void Main(string[] args)
        {
            SqlConnection connection; // służy do komunikacja bazą 
            SqlCommand command; // przechowuje polecenie SQL
            SqlDataReader dataReader; // czytanie wyników z bazy 

            string connString = "Data Source=.;Initial Catalog=A_Zawodnicy;User ID=sa;Password=alx";

            connection = new SqlConnection(connString);

            command = new SqlCommand("SELECT * FROM Zawodnicy",connection);

            connection.Open();
            dataReader= command.ExecuteReader(); // polecenie wysyłania SQL do bazy 

            int ileKomun= dataReader.FieldCount;

            Console.WriteLine("Liczba kolumn wynosi: " + ileKomun);

            //dataReader.Read();
            //string wynik = Convert.ToString(dataReader.GetValue(2));
            //Console.WriteLine(wynik);

            //dataReader.Read();
            //wynik = Convert.ToString(dataReader.GetValue(2));
            //Console.WriteLine(wynik);
            while (dataReader.Read())
            {
                string wynik = Convert.ToString(dataReader.GetValue(2)) +
                    " " + Convert.ToString(dataReader.GetValue(3));
                Console.WriteLine(wynik);
            }

            connection.Close();

           
            Console.ReadKey();
        }
    }
}
