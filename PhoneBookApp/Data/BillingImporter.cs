using System;
using System.IO;
using System.Data.SqlClient;
using PhoneBookApp.Models;

namespace PhoneBookApp.Data
{
    public class BillingImporter
    {
        private readonly Database _db = new Database();

        // Prosty importer CSV. Zakładamy nagłówek:
        // EmployeeID,BillingMonth,PhoneNumber,CallDate,CallDuration,CallCost,Destination
        public void Import(string filePath)
        {
            string ext = Path.GetExtension(filePath).ToLowerInvariant();

            if (ext == ".csv")
            {
                ImportCsv(filePath);
            }
            else
            {
                // .01X/.01Y — tu zostawiamy prosty komunikat
                throw new NotImplementedException("Importer for this format is not implemented yet: " + ext);
            }
        }

        private void ImportCsv(string filePath)
        {
            using (var conn = _db.GetConnection())
            using (var cmd = new SqlCommand("", conn))
            {
                conn.Open();
                using (var sr = new StreamReader(filePath))
                {
                    string header = sr.ReadLine();
                    while (!sr.EndOfStream)
                    {
                        string line = sr.ReadLine();
                        if (string.IsNullOrWhiteSpace(line)) continue;
                        // prosty CSV split (nie obsługuje przecinków w polach)
                        var parts = line.Split(',');

                        if (parts.Length < 7) continue;

                        int employeeId = int.TryParse(parts[0], out var tmpEmp) ? tmpEmp : 0;
                        DateTime billingMonth = DateTime.TryParse(parts[1], out var tmpDt) ? tmpDt : DateTime.MinValue;
                        string phoneNumber = parts[2];
                        DateTime callDate = DateTime.TryParse(parts[3], out var tmpCall) ? tmpCall : DateTime.MinValue;
                        int callDuration = int.TryParse(parts[4], out var tmpDur) ? tmpDur : 0;
                        decimal callCost = decimal.TryParse(parts[5], out var tmpCost) ? tmpCost : 0;
                        string destination = parts[6];

                        cmd.CommandText = @"
INSERT INTO Billings (EmployeeID, BillingMonth, PhoneNumber, CallDate, CallDuration, CallCost, Destination)
VALUES (@EmployeeID,@BillingMonth,@PhoneNumber,@CallDate,@CallDuration,@CallCost,@Destination)";

                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@EmployeeID", employeeId);
                        cmd.Parameters.AddWithValue("@BillingMonth", billingMonth == DateTime.MinValue ? (object)DBNull.Value : billingMonth);
                        cmd.Parameters.AddWithValue("@PhoneNumber", phoneNumber);
                        cmd.Parameters.AddWithValue("@CallDate", callDate == DateTime.MinValue ? (object)DBNull.Value : callDate);
                        cmd.Parameters.AddWithValue("@CallDuration", callDuration);
                        cmd.Parameters.AddWithValue("@CallCost", callCost);
                        cmd.Parameters.AddWithValue("@Destination", destination);

                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }
    }
}
