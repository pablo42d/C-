using PhoneBookApp.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace PhoneBookApp.Data
{
    public class DepartmentRepository
    {
        private readonly Database _db = new Database();

        public List<Department> GetAllDepartments()
        {
            var list = new List<Department>();
            string query = "SELECT * FROM Departments ORDER BY DepartmentName";

            using (SqlConnection conn = _db.GetConnection())
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                conn.Open();
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new Department
                        {
                            DepartmentID = reader["DepartmentID"] != DBNull.Value ? Convert.ToInt32(reader["DepartmentID"]) : 0,
                            DepartmentName = reader["DepartmentName"]?.ToString(),
                            Description = reader["Description"]?.ToString()
                        });
                    }
                }
            }

            return list;
        }

        // Jeżeli chcesz, możesz dodać tu Add/Update/Delete dla działów.
        public int AddDepartment(Department dep)
        {
            string query = "INSERT INTO Departments (DepartmentName, Description) VALUES (@name,@desc); SELECT SCOPE_IDENTITY();";
            using (var conn = _db.GetConnection())
            using (var cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@name", dep.DepartmentName ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@desc", dep.Description ?? (object)DBNull.Value);
                conn.Open();
                object res = cmd.ExecuteScalar();
                return res != null ? Convert.ToInt32(res) : 0;
            }
        }

        public void UpdateDepartment(Department dep)
        {
            string query = "UPDATE Departments SET DepartmentName=@name, Description=@desc WHERE DepartmentID=@id";
            using (var conn = _db.GetConnection())
            using (var cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@name", dep.DepartmentName ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@desc", dep.Description ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@id", dep.DepartmentID);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteDepartment(int departmentId)
        {
            string query = "DELETE FROM Departments WHERE DepartmentID=@id";
            using (var conn = _db.GetConnection())
            using (var cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@id", departmentId);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}