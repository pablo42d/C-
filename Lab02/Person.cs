using Lab02;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab02
{
    internal class Person
    {
        //pola prywatne klasy Person
        private string firstName, lastName;
        private int age;

        //konstruktor bezparametrowy domyślny
        //public Person()
        //{
        //}

        //konstruktor parametrowy
        public Person(string firstName, string lastName, int age)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.age = age;
        }
        //metoda View() wyświetlająca dane osoby
        public void View()
        {
            Console.WriteLine($"First Name: {firstName}, Last Name: {lastName}, Age: {age}");
        }
        // właściwości klasy Person
        public string FirstName
        {
            get // akcesor get
            {
                return firstName;   // zwraca wartość pola firstName
            }
            set // akcesor set
            {
                // walidacja wartości przed przypisaniem
                if (string.IsNullOrWhiteSpace(value) || value.Length < 2)   // sprawdza czy wartość jest pusta lub krótsza niż 2 znaki
                {
                    throw new ArgumentException("First name must be at least 2 characters long and cannot be empty.");
                }

                firstName = value;  // przypisuje wartość do pola firstName
            }
        }
        // właściwość LastName z walidacją
        public string LastName
        {
            get
            {
                return lastName;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < 2)
                {
                    throw new ArgumentException("First name must be at least 2 characters long and cannot be empty.");
                }

                lastName = value;
            }
        }
        // właściwość Age z walidacją
        public int Age
        {
            get 
            { 
                return age;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Age cannot be negative.");
                }

                age = value;
            }
        }
    }

}

