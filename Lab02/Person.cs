using Lab02;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab02
{
    internal class Person
    {
        private string firstName, lastName;
        private int age;

        //public Person()
        //{
        //}

        public Person(string firstName, string lastName, int age)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.age = age;
        }

        public void View()
        {
            Console.WriteLine($"First Name: {firstName}, Last Name: {lastName}, Age: {age}");
        }

        public string FirstName
        {
            get
            {
                return firstName;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < 2)
                {
                    throw new ArgumentException("First name must be at least 2 characters long and cannot be empty.");
                }

                firstName = value;
            }
        }
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

        public int Age
        {
            get { return Age; }
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

