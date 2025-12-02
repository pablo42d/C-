/*    EmployeeRepository.cs
    Repository class for managing Employee data in the database.
*/

using PhoneBookApp.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace PhoneBookApp.Data
{
    public class EmployeeRepository
    {
        private readonly Database _db = new Database();

        // Pobranie po username (istniejąca metoda - lekko ulepszona)
        public Employee GetEmployeeByUsername(string username)
        {
            Employee employee = null;
            string query = "SELECT * FROM Employees WHERE Username = @username";

            using (SqlConnection conn = _db.GetConnection())
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@username", username ?? string.Empty);
                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        employee = MapReaderToEmployee(reader);
                    }
                }
            }

            return employee;
        }

        // Pobierz wszystkich pracowników
        public List<Employee> GetAllEmployees()
        {
            var list = new List<Employee>();
            string query = "SELECT * FROM Employees";

            using (SqlConnection conn = _db.GetConnection())
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(MapReaderToEmployee(reader));
                    }
                }
            }

            return list;
        }

        // Dodaj pracownika
        public int AddEmployee(Employee emp)
        {
            string query = @"
INSERT INTO Employees
(FirstName, LastName, Email, PhoneNumber, MobileNumber, DepartmentID, Photo, Username, PasswordHash, Role)
VALUES (@FirstName,@LastName,@Email,@PhoneNumber,@MobileNumber,@DepartmentID,@Photo,@Username,@PasswordHash,@Role);
SELECT SCOPE_IDENTITY();";

            using (SqlConnection conn = _db.GetConnection())
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@FirstName", emp.FirstName ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@LastName", emp.LastName ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@Email", emp.Email ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@PhoneNumber", emp.PhoneNumber ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@MobileNumber", emp.MobileNumber ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@DepartmentID", emp.DepartmentID);
                cmd.Parameters.Add("@Photo", SqlDbType.VarBinary).Value = (object)emp.Photo ?? DBNull.Value;
                cmd.Parameters.AddWithValue("@Username", emp.Username ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@PasswordHash", emp.PasswordHash ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@Role", emp.Role ?? (object)DBNull.Value);

                conn.Open();
                object res = cmd.ExecuteScalar();
                int newId = res != null ? Convert.ToInt32(res) : 0;
                return newId;
            }
        }

        // Update
        public void UpdateEmployee(Employee emp)
        {
            string query = @"
UPDATE Employees SET
 FirstName = @FirstName,
 LastName = @LastName,
 Email = @Email,
 PhoneNumber = @PhoneNumber,
 MobileNumber = @MobileNumber,
 DepartmentID = @DepartmentID,
 Photo = @Photo
WHERE EmployeeID = @EmployeeID";

            using (SqlConnection conn = _db.GetConnection())
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@FirstName", emp.FirstName ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@LastName", emp.LastName ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@Email", emp.Email ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@PhoneNumber", emp.PhoneNumber ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@MobileNumber", emp.MobileNumber ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@DepartmentID", emp.DepartmentID);
                cmd.Parameters.Add("@Photo", SqlDbType.VarBinary).Value = (object)emp.Photo ?? DBNull.Value;
                cmd.Parameters.AddWithValue("@EmployeeID", emp.EmployeeID);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        // Delete
        public void DeleteEmployee(int employeeId)
        {
            string query = "DELETE FROM Employees WHERE EmployeeID = @EmployeeID";
            using (SqlConnection conn = _db.GetConnection())
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@EmployeeID", employeeId);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        // Helper: mapowanie SqlDataReader -> Employee
        private Employee MapReaderToEmployee(SqlDataReader reader)
        {
            var emp = new Employee
            {
                EmployeeID = reader["EmployeeID"] != DBNull.Value ? Convert.ToInt32(reader["EmployeeID"]) : 0,
                FirstName = reader["FirstName"]?.ToString(),
                LastName = reader["LastName"]?.ToString(),
                Email = reader["Email"]?.ToString(),
                PhoneNumber = reader["PhoneNumber"]?.ToString(),
                MobileNumber = reader["MobileNumber"]?.ToString(),
                DepartmentID = reader["DepartmentID"] != DBNull.Value ? Convert.ToInt32(reader["DepartmentID"]) : 0,
                Username = reader["Username"]?.ToString(),
                PasswordHash = reader["PasswordHash"]?.ToString(),
                Role = reader["Role"]?.ToString(),
                Photo = reader["Photo"] == DBNull.Value ? null : (byte[])reader["Photo"]
            };

            return emp;
        }
    }
}







/*
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
*/