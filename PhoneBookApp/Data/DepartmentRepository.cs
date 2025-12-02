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
    }
}