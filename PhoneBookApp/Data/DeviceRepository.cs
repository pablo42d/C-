using PhoneBookApp.Forms;
using PhoneBookApp.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace PhoneBookApp.Data
{
    // Zakładamy istnienie klasy Database z metodą GetConnection()
    public class DeviceRepository
    {
        private readonly Database _db = new Database();

        public List<Device> GetAllDevices()
        {
            var list = new List<Device>();
            // Zmieniono na SELECT * FROM Devices, aby pobierać wszystkie pola wymagane przez klasę Device
            string query = "SELECT * FROM Devices";

            using (SqlConnection conn = _db.GetConnection())
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                conn.Open();
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var d = new Device // Używamy klasy Device (zakładamy, że dziedziczy z DeviceBase)
                        {
                            DeviceID = reader["DeviceID"] != DBNull.Value ? Convert.ToInt32(reader["DeviceID"]) : 0,
                            SerialNumber = reader["SerialNumber"]?.ToString(),
                            InventoryNumber = reader["InventoryNumber"]?.ToString(),
                            EmployeeID = reader["EmployeeID"] != DBNull.Value ? (int?)Convert.ToInt32(reader["EmployeeID"]) : null,

                            // Pola dodane do klasy Device, które musimy odczytać
                            DeviceType = reader["DeviceType"]?.ToString(),
                            Model = reader["Model"]?.ToString(),
                            IMEI = reader["IMEI"]?.ToString(),
                            MACAddress = reader["MACAddress"]?.ToString(),
                            HasMDM = reader["HasMDM"] != DBNull.Value ? Convert.ToBoolean(reader["HasMDM"]) : false,
                            DeviceStatus = reader["DeviceStatus"]?.ToString(),
                            Notes = reader["Notes"]?.ToString(),

                            // Pola z DeviceBase (DateTime? są już w kodzie, ale dla pewności je sprawdzamy)
                            IssueDate = reader["IssueDate"] != DBNull.Value ? (DateTime?)Convert.ToDateTime(reader["IssueDate"]) : null,
                            ReplacementDate = reader["ReplacementDate"] != DBNull.Value ? (DateTime?)Convert.ToDateTime(reader["ReplacementDate"]) : null,
                        };
                        list.Add(d);
                    }
                }
            }
            return list;
        }

        public int AddDevice(Device dev)
        {
            string query = @"
INSERT INTO Devices
(SerialNumber, InventoryNumber, EmployeeID, DeviceType, Model, IMEI, MACAddress, IssueDate, ReplacementDate, HasMDM, DeviceStatus, Notes)
VALUES
(@SerialNumber,@InventoryNumber,@EmployeeID,@DeviceType,@Model,@IMEI,@MACAddress,@IssueDate,@ReplacementDate,@HasMDM,@DeviceStatus,@Notes);
SELECT SCOPE_IDENTITY();";

            using (var conn = _db.GetConnection())
            using (var cmd = new SqlCommand(query, conn))
            {
                // Użycie .HasValue dla DateTime? i int? jest poprawne.
                cmd.Parameters.AddWithValue("@SerialNumber", dev.SerialNumber ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@InventoryNumber", dev.InventoryNumber ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@EmployeeID", dev.EmployeeID.HasValue ? (object)dev.EmployeeID.Value : DBNull.Value);

                cmd.Parameters.AddWithValue("@DeviceType", dev.DeviceType ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@Model", dev.Model ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@IMEI", dev.IMEI ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@MACAddress", dev.MACAddress ?? (object)DBNull.Value);

                cmd.Parameters.AddWithValue("@IssueDate", dev.IssueDate.HasValue ? (object)dev.IssueDate.Value : DBNull.Value);
                cmd.Parameters.AddWithValue("@ReplacementDate", dev.ReplacementDate.HasValue ? (object)dev.ReplacementDate.Value : DBNull.Value);

                cmd.Parameters.AddWithValue("@HasMDM", dev.HasMDM);
                cmd.Parameters.AddWithValue("@DeviceStatus", dev.DeviceStatus ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@Notes", dev.Notes ?? (object)DBNull.Value);

                conn.Open();
                object res = cmd.ExecuteScalar();
                return res != null ? Convert.ToInt32(res) : 0;
            }
        }

        public void UpdateDevice(Device dev)
        {
            string query = @"
UPDATE Devices SET
 SerialNumber = @SerialNumber,
 InventoryNumber = @InventoryNumber,
 EmployeeID = @EmployeeID,
 DeviceType = @DeviceType,
 Model = @Model,
 IMEI = @IMEI,
 MACAddress = @MACAddress,
 IssueDate = @IssueDate,
 ReplacementDate = @ReplacementDate,
 HasMDM = @HasMDM,
 DeviceStatus = @DeviceStatus,
 Notes = @Notes
WHERE DeviceID = @DeviceID";

            using (var conn = _db.GetConnection())
            using (var cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@SerialNumber", dev.SerialNumber ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@InventoryNumber", dev.InventoryNumber ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@EmployeeID", dev.EmployeeID.HasValue ? (object)dev.EmployeeID.Value : DBNull.Value);

                cmd.Parameters.AddWithValue("@DeviceType", dev.DeviceType ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@Model", dev.Model ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@IMEI", dev.IMEI ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@MACAddress", dev.MACAddress ?? (object)DBNull.Value);

                cmd.Parameters.AddWithValue("@IssueDate", dev.IssueDate.HasValue ? (object)dev.IssueDate.Value : DBNull.Value);
                cmd.Parameters.AddWithValue("@ReplacementDate", dev.ReplacementDate.HasValue ? (object)dev.ReplacementDate.Value : DBNull.Value);

                cmd.Parameters.AddWithValue("@HasMDM", dev.HasMDM);
                cmd.Parameters.AddWithValue("@DeviceStatus", dev.DeviceStatus ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@Notes", dev.Notes ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@DeviceID", dev.DeviceID);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteDevice(int deviceId)
        {
            string query = "DELETE FROM Devices WHERE DeviceID = @id";
            using (var conn = _db.GetConnection())
            using (var cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@id", deviceId);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}