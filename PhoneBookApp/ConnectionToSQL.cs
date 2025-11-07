using PhoneBookApp;

public class DbConnection
{
    // podaj nazwę swojego serwera SQL
    private string connectionString =
        "Data Source= DESKTOP-COV87SH\\SQLEXPRESS;Initial Catalog=phoneBook;Integrated Security=True"; // connection string/łańcuch połączenia

    public SqlConnection GetConnection() // method to get a new SQL connection/metoda do uzyskania nowego połączenia SQL
    {
        return new SqlConnection(connectionString); // return new SqlConnection object/zwrócenie nowego obiektu SqlConnection
    }
    // Exception handling and resource management should be done where this method is called/Obsługa wyjątków i zarządzanie zasobami powinny być wykonywane tam, gdzie wywoływana jest ta metoda
    //public string ConnectionString { 
    //    get { return connectionString; }
    //}

}

/* Example usage:
 string connstring = "Data Source= DESKTOP-COV87SH\\SQLEXPRESS;Initial Catalog=w72448;Integrated Security=True"; // connection string/łańcuch połączenia
        string query = "SELECT * FROM Druzyna"; // SQL query/ zapytanie SQL

        // Using 'using' statements to ensure proper disposal of resources/Użycie instrukcji 'using' w celu zapewnienia prawidłowego zwolnienia zasobów
        try
        {
            using (var conn = new SqlConnection(connstring))    // create and open connection/utworzenie i otwarcie połączenia
            {
                conn.Open();    // open connection/otwarcie połączenia
                MessageBox.Show("Connection Opened Successfully");  // confirm successful connection/potwierdzenie pomyślnego połączenia

                using (var cmd = new SqlCommand(query, conn))   // create command/utworzenie polecenia
                using (var reader = cmd.ExecuteReader())    // execute command and get reader/wykonanie polecenia i uzyskanie czytnika
                {
                    while (reader.Read())   // read each row/czytanie każdego wiersza
                    {
                        var output = $"Output: {reader.GetValue(0)}_{reader.GetValue(1)}";  // prepare output/przygotowanie wyniku
                        MessageBox.Show(output);    // display output/wyświetlanie wyniku
                    }
                } // reader and cmd disposed here/tutaj usuwane są reader i cmd
            } // connection closed and disposed here/tutaj zamykane jest połączenie i usuwane
        }
        catch (Exception ex)    // handle exceptions here/tutaj obsługa wyjątków
        {
            MessageBox.Show("Error: " + ex.Message);    // display error message/wyświetlanie komunikatu o błędzie
        } 


