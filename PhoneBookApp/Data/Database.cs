using System;
using System.Data.SqlClient;
using System.Configuration; // Wymaga pakietu NuGet: System.Configuration.ConfigurationManager

namespace PhoneBookApp.Data
{
    public class Database
    {
        // Łańcuch połączenia pobierany z App.config
        private readonly string _connectionString;

        public Database()
        {
            try
            {
                _connectionString = ConfigurationManager.ConnectionStrings["PhoneBookDb"].ConnectionString;
            }
            catch (Exception ex)
            {
                // Lepiej zgłosić wyjątek w przypadku problemów z konfiguracją
                throw new InvalidOperationException("Connection string 'PhoneBookDb' is missing in App.config.", ex);
            }
        }

        // Zwraca nowe połączenie SQL
        public SqlConnection GetConnection()
        {
            return new SqlConnection(_connectionString);
        }

        // Testuje połączenie z bazą danych
        public bool TestConnection()
        {
            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    conn.Open();
                    return true;
                }
            }
            catch (Exception)
            {
                // Można tutaj logować wyjątek, jeśli potrzebne
                return false;
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