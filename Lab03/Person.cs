using System;
using System.Collections.Generic;
using System.Text;

namespace Lab03
{
    // ========= 1 ===========================
    //klasa bazowa Person
    public class Person
    {
        //// przykład właściwości z metodami get i set
        //private string name; // field
        //public string Name // property
        //{
        //    get { return name; } // get method
        //    set { name = value; } // set method
        //}

        //// krutszy zapis właściwości auto-implemented
        //public string Name1 // property
        //{ get; set; }



        //// ========= 2 Dziedziczenie ===========================
        //// właściwości klasy Person
        //public string FirstName { get; set; }
        //public string LastName { get; set; }

        //// konstruktor klasy Person
        //public Person(string FirstName, string LastName)
        //{
        //    this.FirstName = FirstName;
        //    this.LastName = LastName;
        //}

        //// nadpisanie metody ToString()
        //public override string? ToString()
        //{
        //    return "Student: " + FirstName + " " + LastName;
        //}

        // ========= Zadanie 1 a. ===========================
        // pola klasy Person
        private string firstName;
        private string lastName;
        private int age;
        // konstruktor klasy Person
        public Person(string firstName, string lastName, int age)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.age = age;
        }
        // metoda View
        public void View()
        {
            Console.WriteLine("Person: " + firstName + " " + lastName + ", Age: " + age);
        }
    }
}
