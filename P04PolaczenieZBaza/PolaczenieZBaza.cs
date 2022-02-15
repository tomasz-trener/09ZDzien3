using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P04PolaczenieZBaza
{
    class PolaczenieZBaza
    {

        public string[][] WykonajZapytanieSQL(string sql)
        {
            SqlConnection connection; // służy do komunikacja bazą 
            SqlCommand command; // przechowuje polecenie SQL
            SqlDataReader dataReader; // czytanie wyników z bazy 

            string connString = "Data Source=.;Initial Catalog=A_Zawodnicy;User ID=sa;Password=alx";

            connection = new SqlConnection(connString);

            command = new SqlCommand(sql, connection);

            connection.Open();
            dataReader = command.ExecuteReader(); // polecenie wysyłania SQL do bazy 

            int ileKolumn = dataReader.FieldCount;

            List<string[]> wyniki = new List<string[]>();

            while (dataReader.Read())
            {
                string[] wiersz = new string[ileKolumn];
                //dataReader.GetValues(wiersz);
                for (int i = 0; i < ileKolumn; i++)
                    wiersz[i] = Convert.ToString(dataReader.GetValue(i));
                
                wyniki.Add(wiersz);
            }
            connection.Close();

            return wyniki.ToArray();
        }


    }
}
