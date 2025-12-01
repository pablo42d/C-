using System;
using System.Data.SqlClient;

namespace PhoneBookApp.Data
{
    public class Database
    {
        // Testowa linia do sprawdzenia łańcucha połączenia
        //MessageBox.Show(ConfigurationManager.ConnectionStrings["PhoneBookDb"].ConnectionString);

        // Łańcuch połączenia pobierany z App.config
        private readonly string _connectionString =
            System.Configuration.ConfigurationManager.ConnectionStrings["PhoneBookDb"].ConnectionString;

        // Metoda do stworzenia i zwrócenia nowego połączenia SQL
        // Każde wywołanie tworzy nowe połączenie
        // Dzięki temu nie trzymamy otwartego połączenia cały czas

        public SqlConnection GetConnection()
        {
            SqlConnection connection = new SqlConnection(_connectionString);
            return connection;
        }

        // Prosty test połączenia – sprawdzimy na formularzu logowania
        public bool TestConnection()
        {
            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    conn.Open();
                    return true; // połączenie działa
                }
            }
            catch (Exception)
            {
                return false; // połączenie nie działa
            }
        }
    }
}
/*
 3. Wyjaśnienie linia po linii
🔹 using System.Data.SqlClient;

Dodaje obsługę SQL Server (biblioteka do komunikacji z SQL).

🔹 _connectionString

Pobiera Twój łańcuch połączenia z pliku App.config:

<connectionStrings>
 <add name="PhoneBookDb"
      connectionString="Data Source=DESKTOP-COV87SH\SQLEXPRESS;Initial Catalog=phoneBook;Integrated Security=True"
      providerName="System.Data.SqlClient" />
</connectionStrings>


Dzięki temu:

nie musisz wpisywać połączenia w kodzie,

łatwo go zmienić w przyszłości.

🔹 GetConnection()

Zwraca nowe połączenie SQL za każdym razem, gdy aplikacja potrzebuje wykonać zapytanie.

To dobra praktyka — zamiast trzymać jedno połączenie cały czas otwarte.

🔹 TestConnection()

Otwiera połączenie i zamyka je natychmiast.

Jeżeli się uda → zwraca true
Jeśli nie → zwraca false

Tę metodę wykorzystamy na pierwszym formularzu logowania, aby sprawdzić:

✔ czy baza istnieje
✔ czy połączenie działa
✔ czy login/pass są pobrane poprawnie
 */