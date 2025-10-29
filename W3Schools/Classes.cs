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
        private int speed = 0;              // private field is available only within the class

        // Create a class constructor for the MyClass class
        public MyClass()
        {
            model = "Toyota"; // Set the initial value for model
            maxSpeed = 100;   // Set the initial value for maxSpeed
            isElectric = false; // Set the initial value for isElectric
        }

        // Create a class constructor with a parameter
        public string demaged;
        public MyClass(string modelName, string modelColor, int modelYear, string condition)
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


     /*
        // Access Modifiers

        //public	    The code is accessible for all classes
        //private	    The code is only accessible within the same class
        //protected	The code is accessible within the same class, or in a class that is inherited from that class. You will learn more about inheritance in a later chapter
        //internal	The code is only accessible within its own assembly, but not from another assembly. You will learn more about this in a later chapter
        //There's also two combinations: protected internal and private protected.

        //For now, lets focus on public and private modifiers.
     */


    class Fruit
    {
        private string type = "Apple"; // private field
        
        public void displayType()       // public method to display the private field
        {
            Console.WriteLine("Fruit type: " + type);
            //string result = "Fruit type: " + type;
            //Console.WriteLine(result);
            //return result;
        }


    }
    /*
    //C# Properties (Get and Set)

    Encapsulation, is to make sure that "sensitive" data is hidden from users.To achieve this, you must:

    declare fields/variables as private
    provide public get and set methods, through properties, to access and update the value of a private field

    */


    class Person
    {
        // private field
        private string name;    // private field
        // property
        public string Name  // property
        {
            get { return name; }          // get method
            set { name = value; }         // set method
        }
        /*
         * The Name property is associated with the name field. It is a good practice to use the same name for both the property and the private field, but with an uppercase first letter.
         * The get method returns the value of the variable name.
         * The set method assigns a value to the name variable. The value keyword represents the value we assign to the property.
         */

        // Automatic Properties (Short Hand)
        public int Age { get; set; } // Automatic property, Age is the property 

}
