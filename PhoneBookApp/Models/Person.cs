using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBookApp.Models
{
    // Klasa bazowa - ogólna reprezentacja osoby
    public class Person
    {
        // Imię osoby
        public string FirstName { get; set; }

        // Nazwisko osoby
        public string LastName { get; set; }
    }
}
/*
To jest klasa bazowa (rodzic).

Będzie dziedziczona przez Employee.

Spełnia wymaganie 7+ klas + hierarchia.*/