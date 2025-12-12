/* BillingRepository.cs
   Repository class for fetching billing records (Billings).
*/
using PhoneBookApp.Models;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace PhoneBookApp.Data
{
    public class BillingRepository
    {
        private readonly Database _db = new Database();

        // Pobiera wszystkie rekordy bilingowe dla danego pracownika
        public DataTable GetBillingByEmployeeId(int employeeId)
        {
            DataTable dt = new DataTable();

            // Kolumny: BillingID, BillingMonth, PhoneNumber, CallDate, CallDuration, CallCost, Destination
            string query = @"
                SELECT 
                    BillingMonth, 
                    PhoneNumber, 
                    CallDate, 
                    CallDuration, 
                    CallCost, 
                    Destination 
                FROM dbo.Billings 
                WHERE EmployeeID = @EmployeeID 
                ORDER BY CallDate DESC";

            using (SqlConnection conn = _db.GetConnection())
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@EmployeeID", employeeId);
                conn.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    dt.Load(reader);
                }
            }

            return dt;
        }

        // Można tu dodać metodę do pobierania bilingów dla konkretnego miesiąca/roku, jeśli jest to potrzebne.
    }
}
/*
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBookApp.Data
{
    internal class BillingRepository
    {
    }
}
*/
