//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

namespace PhoneBookApp.Models
{
    // Employee dziedziczy po Person
    public class Employee : Person
    {
        public int EmployeeID { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string MobileNumber { get; set; }
        public int DepartmentID { get; set; }

        // Zdjęcie pracownika w bazie jest przechowywane jako varbinary(max)
        public byte[] Photo { get; set; }

        public string Username { get; set; }
        public string PasswordHash { get; set; }

        // Rola: "Employee", "Admin"
        public string Role { get; set; }
    }

}

