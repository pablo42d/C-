using W3Schools;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

namespace W3Schools
{
    //internal class Classes
    //{

    //}
    /*OOP stands for Object-Oriented Programming
    Class is a template for objects, and an object is an instance of a class.
    When the individual objects are created, they inherit all the variables and methods from the class.
    Everything in C# is associated with classes and objects, along with its attributes and methods. For example: in real life, a car is an object. The car has attributes, such as weight and color, and methods, such as drive and brake.
    A Class is like an object constructor, or a "blueprint" for creating objects.
    To create a class, use the class keyword:
    */
    class Car   //It is not required, but it is a good practice to start with an uppercase first letter when naming classes
    {
        //field (or attribute)
        public string color = "red";
        public int rok = 2023;

        //object method
        public void FullThrottle()
        {
            Console.WriteLine("The car is going as fast as it can!");
        }

    }

    // Multiple Objects
    class MultipleObjects   // Create a class called MultipleObjects where we will create multiple objects from the Car class
    {
        public void Run()
        {
            Car myObj1 = new Car(); // Create the first myCar object
            Car myObj2 = new Car(); // Create another myCar object
            // Call the FullThrottle method on the first car object
            myObj1.FullThrottle();
            // Display the value of the color field (attribute) and rok field of the first car object
            Console.WriteLine(myObj1.color + " " + myObj1.rok);
            // Display the value of the color field (attribute) and rok field of the second car object
            Console.WriteLine(myObj2.color + " " + myObj2.rok);
        }
    }

    // The class

    class MyClass
    {
        // Class members
        public string color = "red";        // field
        public int maxSpeed = 200;          // field
        public string model;                // You can also leave the fields blank, and modify them when creating the object
        public bool isElectric = false;     // Declare at class level

        // Create a class constructor for the MyClass class
        public MyClass()
        {
            model = "Toyota"; // Set the initial value for model
            maxSpeed = 100;   // Set the initial value for maxSpeed
            isElectric = false; // Set the initial value for isElectric
        }

        // Create a class constructor with a parameter
        public string demaged;
        public MyClass( string modelName, string modelColor, int modelYear, string condition)
        {
            model = modelName;
            color = modelColor;
            year = modelYear;
            demaged = condition;
        }

        public int year;                    // You can also leave the fields blank, and modify them when creating the object
        public void fullThrottle()          // method
        {
            Console.WriteLine("The car is going as fast as it can!");
        }
    }
}
