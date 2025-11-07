using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient; // Add this for SqlConnection and SqlCommand

namespace PhoneBookApp
{
    internal static class Program
    {

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new LogForm());
        }

        // If you need a database connection, use the static method as shown below:

        // Example usage:
        // using (SqlConnection conn = DbConnection.GetConnection())
        // {
        //     // Use the connection here
        // }

        //public static class DbConnection
        //{
        //    // ścieżka do serwera SQL
        //    private static readonly string connectionString =
        //        "Data Source= DESKTOP-COV87SH\\SQLEXPRESS;Initial Catalog=phoneBook;Integrated Security=True"; // connection string/łańcuch połączenia

        //    public static SqlConnection GetConnection()
        //    {
        //        return new SqlConnection(connectionString);
        //    }
        //}
    }
}





