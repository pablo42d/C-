using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WSIZRzeszow.Models
{
    public class Student
    {
        // To jest domyślnie klucz główny (PK) dla EF
        public int ID { get; set; }
        public string LastName { get; set; }
        public string FirstMidName { get; set; }
        public DateTime EnrollmentDate { get; set; }
        public virtual ICollection<Enrollment> Enrollments { get; set; }
    }

}