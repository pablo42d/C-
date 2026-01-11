using System;
using SystemTelefonicznyGY.Logika.Interfejsy;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace SystemTelefonicznyGY.Logika
{
    public class BazaDanych : IBazaDanych
    {
        // Connection string (tylko do odczytu)
        private readonly string _stringPolaczenia = @"Data Source=DESKTOP-COV87SH\SQLEXPRESS;Initial Catalog=SystemTelefonicznyGY;Integrated Security=True";

        // =============================================
        // METODY POBIERANIA DANYCH (SELECT)
        // =============================================

        // WERSJA 1: Przyjmuje List<SqlParameter> (Dla AdministratorController i ZasobyService)
        public DataTable PobierzDane(string zapytanieSql, List<SqlParameter> parametry = null)
        {
            DataTable tabelaWynikow = new DataTable();

            using (SqlConnection polaczenie = new SqlConnection(_stringPolaczenia))
            {
                try
                {
                    SqlCommand komenda = new SqlCommand(zapytanieSql, polaczenie);

                    if (parametry != null)
                    {
                        komenda.Parameters.AddRange(parametry.ToArray());
                    }

                    SqlDataAdapter adapter = new SqlDataAdapter(komenda);
                    polaczenie.Open();
                    adapter.Fill(tabelaWynikow);
                }
                catch (Exception ex)
                {
                    throw new Exception("Błąd połączenia z bazą: " + ex.Message);
                }
            }
            return tabelaWynikow;
        }

       
        // =============================================
        // METODY WYKONYWANIA POLECEŃ (INSERT, UPDATE, DELETE)
        // =============================================

        // WERSJA 1: Przyjmuje List<SqlParameter>
        public int WykonajPolecenie(string zapytanieSql, List<SqlParameter> parametry = null)
        {
            using (SqlConnection polaczenie = new SqlConnection(_stringPolaczenia))
            {
                try
                {
                    SqlCommand komenda = new SqlCommand(zapytanieSql, polaczenie);

                    if (parametry != null)
                    {
                        komenda.Parameters.AddRange(parametry.ToArray());
                    }

                    polaczenie.Open();
                    return komenda.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw new Exception("Błąd wykonywania polecenia: " + ex.Message);
                }
            }
        }        
    }
}