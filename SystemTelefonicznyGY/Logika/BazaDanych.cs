using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration; // Wymaga dodania referencji w projekcie

namespace SystemTelefonicznyGY.Logika
{
    public class BazaDanych
    {
        //private string _stringPolaczenia = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SystemTelefonicznyGYDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        // Prywatne pole z tzw. Connection Stringiem
        private string _stringPolaczenia = @"Data Source=DESKTOP-COV87SH\SQLEXPRESS;Initial Catalog=SystemTelefonicznyGY;Integrated Security=True";

        // Bezpieczna wersja pobierania danych z parametrami
        public DataTable PobierzDane(string zapytanieSql, Dictionary<string, object> parametry)
        {
            DataTable tabela = new DataTable();
            using (SqlConnection polaczenie = new SqlConnection(_stringPolaczenia))
            {
                SqlCommand komenda = new SqlCommand(zapytanieSql, polaczenie);
                foreach (var p in parametry)
                {
                    komenda.Parameters.AddWithValue(p.Key, p.Value ?? DBNull.Value);
                }
                SqlDataAdapter adapter = new SqlDataAdapter(komenda);
                adapter.Fill(tabela);
            }
            return tabela;
        }


        //// Metoda do pobierania danych (zwraca DataTable)
        //public DataTable PobierzDane(string zapytanieSql)
        //{
        //    DataTable tabelaWynikow = new DataTable();

        //    using (SqlConnection polaczenie = new SqlConnection(_stringPolaczenia))
        //    {
        //        try
        //        {
        //            SqlCommand komenda = new SqlCommand(zapytanieSql, polaczenie);
        //            SqlDataAdapter adapter = new SqlDataAdapter(komenda);
        //            polaczenie.Open();
        //            adapter.Fill(tabelaWynikow);
        //        }
        //        catch (Exception ex)
        //        {
        //            // Możemy np. zapisać błąd do logów
        //            throw new Exception("Błąd połączenia z bazą: " + ex.Message);
        //        }
        //        finally
        //        {
        //            polaczenie.Close();
        //        }
        //    }
        //    return tabelaWynikow;
        //}

        // Metoda do operacji typu INSERT, UPDATE, DELETE
        public int WykonajPolecenie(string zapytanieSql)
        {
            using (SqlConnection polaczenie = new SqlConnection(_stringPolaczenia))
            {
                SqlCommand komenda = new SqlCommand(zapytanieSql, polaczenie);
                polaczenie.Open();
                return komenda.ExecuteNonQuery();
            }
        }
    }
}
