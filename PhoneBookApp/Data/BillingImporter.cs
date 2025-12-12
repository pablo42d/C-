using System;
using System.IO;
using System.Data.SqlClient;
using System.Globalization;
using System.Text; // Dodajemy do obsługi kodowania
using PhoneBookApp.Models;
using PhoneBookApp.Data;

namespace PhoneBookApp.Data
{
    public class BillingImporter
    {
        private readonly Database _db = new Database();

        public void Import(string filePath)
        {
            string ext = Path.GetExtension(filePath).ToLowerInvariant();

            if (ext == ".csv")
            {
                ImportCsv(filePath);
            }
            else
            {
                throw new NotImplementedException("Format nieobsługiwany: " + ext);
            }
        }

        private void ImportCsv(string filePath)
        {
            const char Separator = ';';
            var CostCulture = CultureInfo.InvariantCulture;

            using (var conn = _db.GetConnection())
            {
                conn.Open();

                using (var cmd = new SqlCommand(@"
                    INSERT INTO Billings (EmployeeID, BillingMonth, PhoneNumber, CallDate, CallDuration, CallCost, Destination)
                    VALUES (@EmployeeID, @BillingMonth, @PhoneNumber, @CallDate, @CallDuration, @CallCost, @Destination)", conn))
                {
                    // Definicja parametrów SQL (pełna)
                    cmd.Parameters.Add("@EmployeeID", System.Data.SqlDbType.Int);
                    cmd.Parameters.Add("@BillingMonth", System.Data.SqlDbType.DateTime);
                    cmd.Parameters.Add("@PhoneNumber", System.Data.SqlDbType.NVarChar);
                    cmd.Parameters.Add("@CallDate", System.Data.SqlDbType.DateTime);
                    cmd.Parameters.Add("@CallDuration", System.Data.SqlDbType.Int);
                    cmd.Parameters.Add("@CallCost", System.Data.SqlDbType.Decimal);
                    cmd.Parameters.Add("@Destination", System.Data.SqlDbType.NVarChar);

                    // KLUCZOWA ZMIANA KODOWANIA: Użycie UTF8 (bez wykrywania BOM)
                    using (var sr = new StreamReader(filePath, Encoding.UTF8, false))
                    {
                        sr.ReadLine(); // Pomiń nagłówek

                        int lineCount = 1;
                        int empId = 0; // Deklaracja empId na zewnątrz try/catch

                        while (!sr.EndOfStream)
                        {
                            lineCount++;
                            string line = sr.ReadLine();
                            if (string.IsNullOrWhiteSpace(line)) continue;

                            string[] parts = line.Split(Separator);

                            if (parts.Length < 7)
                            {
                                throw new Exception($"Błąd w linii {lineCount}: Zbyt mało kolumn. Oczekiwano 7, znaleziono {parts.Length}. Linia: {line}");
                            }

                            try
                            {
                                // === KLUCZOWA POPRAWKA PARSOWANIA ID ===
                                // Użycie liberalnego NumberStyles do akceptacji białych znaków 
                                // oraz InvariantCulture, aby uniknąć problemów z regionalizacją.

                                string empIdRaw = parts[0];

                                if (!int.TryParse(
                                    empIdRaw,
                                    NumberStyles.AllowLeadingWhite | NumberStyles.AllowTrailingWhite | NumberStyles.Integer,
                                    CultureInfo.InvariantCulture,
                                    out empId))
                                {
                                    // Jeśli parsowanie zawiodło, wymuszamy 0, co wywoła znany już błąd FK
                                    empId = 0;
                                }

                                cmd.Parameters["@EmployeeID"].Value = empId;

                                // 2. BillingMonth
                                cmd.Parameters["@BillingMonth"].Value = DateTime.TryParse(parts[1].Trim(), out var bMonth) ? bMonth : (object)DBNull.Value;

                                // 3. PhoneNumber
                                cmd.Parameters["@PhoneNumber"].Value = parts[2].Trim();

                                // 4. CallDate
                                cmd.Parameters["@CallDate"].Value = DateTime.TryParse(parts[3].Trim(), out var cDate) ? cDate : (object)DBNull.Value;

                                // 5. CallDuration
                                cmd.Parameters["@CallDuration"].Value = int.TryParse(parts[4].Trim(), out var duration) ? duration : 0;

                                // 6. CallCost 
                                decimal.TryParse(parts[5].Trim(), NumberStyles.Any, CostCulture, out var cost);
                                cmd.Parameters["@CallCost"].Value = cost;

                                // 7. Destination
                                cmd.Parameters["@Destination"].Value = parts[6].Trim();

                                cmd.ExecuteNonQuery();
                            }
                            catch (SqlException sqlex) when (sqlex.Number == 547)
                            {
                                // W tym momencie błąd 547 może oznaczać: 
                                // 1. Błąd formatowania (empId=0)
                                // 2. Brak pracownika (empId=7, ale rekord 7 został usunięty)
                                throw new Exception($"Błąd w linii {lineCount}: Pracownik o ID '{empId}' nie istnieje (naruszenie klucza obcego). Linia: {line}");
                            }
                            catch (Exception ex)
                            {
                                // Inny błąd bazy danych (np. data w niepoprawnym formacie, naruszenie NOT NULL)
                                throw new Exception($"Błąd w linii {lineCount} podczas wstawiania danych do DB: {ex.Message}\nLinia: {line}");
                            }
                        }
                    }
                }
            }
        }
    }
}



/*
private readonly Database _db = new Database();

// Importer obsługujący .csv oraz placeholder dla 01X/01Y
public void Import(string filePath)
{
    string ext = Path.GetExtension(filePath).ToLowerInvariant();

    switch (ext)
    {
        case ".csv":
            ImportCsv(filePath);
            break;

        case ".01x":
        case ".01y":
            throw new NotImplementedException("Importer for .01X/.01Y not implemented yet.");

        default:
            throw new NotSupportedException("Unsupported billing format: " + ext);
    }
}

private void ImportCsv(string filePath)
{
    using (SqlConnection conn = _db.GetConnection())
    using (SqlCommand cmd = new SqlCommand("", conn))
    {
        conn.Open();

        using (StreamReader sr = new StreamReader(filePath))
        {
            string header = sr.ReadLine(); // pomijamy nagłówek

            while (!sr.EndOfStream)
            {
                string line = sr.ReadLine();
                if (string.IsNullOrWhiteSpace(line)) continue;

                // Rozdzielamy po średniku (standard CSV europ.)
                var parts = line.Split(';');

                if (parts.Length < 7)
                    continue;

                // TryParse – zabezpieczenia
                int.TryParse(parts[0].Trim(), out int employeeId);
                DateTime.TryParse(parts[1].Trim(), out DateTime billingMonth);
                string phoneNumber = parts[2].Trim();
                DateTime.TryParse(parts[3].Trim(), out DateTime callDate);
                int.TryParse(parts[4].Trim(), out int callDuration);
                decimal.TryParse(parts[5].Trim().Replace(",", "."), out decimal callCost);
                string destination = parts[6].Trim();

                cmd.CommandText = @"
INSERT INTO Billings 
(EmployeeID, BillingMonth, PhoneNumber, CallDate, CallDuration, CallCost, Destination)
VALUES
(@EmployeeID, @BillingMonth, @PhoneNumber, @CallDate, @CallDuration, @CallCost, @Destination)";

                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@EmployeeID", employeeId);
                cmd.Parameters.AddWithValue("@BillingMonth", billingMonth == DateTime.MinValue ? (object)DBNull.Value : billingMonth);
                cmd.Parameters.AddWithValue("@PhoneNumber", phoneNumber);
                cmd.Parameters.AddWithValue("@CallDate", callDate == DateTime.MinValue ? (object)DBNull.Value : callDate);
                cmd.Parameters.AddWithValue("@CallDuration", callDuration);
                cmd.Parameters.AddWithValue("@CallCost", callCost);
                cmd.Parameters.AddWithValue("@Destination", destination);

                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw new Exception("BILLING INSERT ERROR for line: " + line + "\n" + ex.Message);
                }
            }
        }
    }
}
*/

/*
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
*/