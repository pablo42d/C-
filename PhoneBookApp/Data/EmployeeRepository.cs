using System;
using System.Data.SqlClient;
using PhoneBookApp.Models;

namespace PhoneBookApp.Data
{
    public class EmployeeRepository
    {
        private readonly Database _db = new Database();

        // Pobiera pracownika z bazy na podstawie loginu
        public Employee GetEmployeeByUsername(string username)
        {
            // Inicjalizujemy zmienną na przechowanie wyniku
            Employee employee = null;

            string query = "SELECT * FROM Employees WHERE Username = @username";

            using (SqlConnection conn = _db.GetConnection())
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                // Dodajemy parametr do zapytania
                cmd.Parameters.AddWithValue("@username", username);

                // Otwieramy połączenie i wykonujemy zapytanie
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                // Jeśli znaleziono pracownika, wypełniamy obiekt Employee
                if (reader.Read())
                {
                    employee = new Employee
                    {
                        EmployeeID = Convert.ToInt32(reader["EmployeeID"]),
                        FirstName = reader["FirstName"].ToString(),
                        LastName = reader["LastName"].ToString(),
                        Email = reader["Email"].ToString(),
                        PhoneNumber = reader["PhoneNumber"].ToString(),
                        MobileNumber = reader["MobileNumber"].ToString(),
                        DepartmentID = Convert.ToInt32(reader["DepartmentID"]),
                        Username = reader["Username"].ToString(),
                        PasswordHash = reader["PasswordHash"].ToString(),
                        Role = reader["Role"].ToString(),
                        // Obsluga wartości null dla zdjęcia
                        Photo = reader["Photo"] == DBNull.Value ? null : (byte[])reader["Photo"]
                    };
                }

                // Zamykamy reader
                reader.Close();
            }

            return employee;
        }
    }
}
