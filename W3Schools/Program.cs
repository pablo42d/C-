// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");

using System.Xml;
using W3Schools;

/*
Toturial toturial = new Toturial();
//toturial.VariableTypes();
toturial.RunVariableTypes();
//toturial.Operators();
toturial.RunOperators();
//toturial.DataTypesSizes();
toturial.RunDataTypesSizes();
//toturial.SomeMhedod();
toturial.RunSomeMethod();
//toturial.getUserInput();
toturial.RunGetUserInput();
//toturial.MathMethods();
toturial.RunMathMethods();
//toturial.StringMethods();
toturial.RunStringFormatting();
//toturial.CondditionalsExample();
toturial.RunConditionalsExample();
//toturial.LoopsExample();
toturial.RunLoopsExample();
//toturial.ArraysExample();
toturial.RunArraysExample();
//toturial.RandomNumbers();
toturial.RunRandomNumbers();
*/
//toturial.Run();


/*
//wywołanie metody w głowym programie Main
Main(args);
//deklaracja metody wraz z ciałem metody
//MyMethod() is the name of the method
//string country is the parameter of the method
//"Norway" is the default value of the parameter
//void means that this method does not return a value
//static means that this method belongs to the class and not to an object of the class
//Console application always starts with a static Main method
//
static void MyMethod(string country = "Norway") // metoda z parametrem domyślnym
{
    Console.WriteLine(country);
}

static void Main(string[] args) // główna metoda programu
{
    MyMethod("Sweden");   
    MyMethod("India");
    MyMethod();
    MyMethod("USA");
}

// Sweden
// India
// Norway
// USA

Main2(args);
static void MyMethod2(string fname, int age)
{
    Console.WriteLine(fname + " is " + age);
}

static void Main2(string[] args)
{
    MyMethod2("Liam", 5);
    MyMethod2("Jenny", 8);
    MyMethod2("Anja", 31);
}

// Liam is 5
// Jenny is 8
// Anja is 31

Main3(args);
static void KeyValue(string child1, string child2, string child3)
{
    Console.WriteLine("The youngest child is: " + child3);
}

static void Main3(string[] args)
{
    KeyValue(child3: "John", child1: "Liam", child2: "Liam");
}

// The youngest child is: John


View();

int a = 5, b = 1;

Console.WriteLine(a + " + " + b + " = " + sum(a, b));
Console.WriteLine("suma liczb 3 + 4 = " + sum(3, 4));


static int sum(int a, int b)
{
    return a + b;
}

static void View()
{
    Console.WriteLine("Wprowadź swoje imię:");
    string name = Console.ReadLine();
    Console.WriteLine("Hello " + name);
}

//Przeciążenie metod:
int myNum1 = PlusMethodInt(8, 5);   //wywołanie metod przeciążonych
double myNum2 = PlusMethodDouble(4.3, 6.26);    //wywołanie metod przeciążonych
Console.WriteLine("Int: " + myNum1);
Console.WriteLine("Double: " + myNum2);

//przeciążenie metod
static int PlusMethodInt(int x, int y)
{
return x + y;
}
static double PlusMethodDouble(double x, double y)
{
    return x + y;
}


// wywołanie metody z innej klasy

Methods methods = new Methods();
//Console.WriteLine(a + " + " + b + " = " + methods.sum(a, b));   //wywołanie metody sum z klasy Methods nie można wywołać metody statycznej bezpośrednio z innej klasy
//Console.WriteLine("suma liczb 3 + 4 = " + methods.sum1(3, 4));  //wywołanie metody sum1 z klasy Methods po zmianie na public
//methods.sum1(a,b);     //wywołanie metody sum1 z klasy Methods po zmianie na public ale return nie przekazuje nic na zewnątrz metody
Console.WriteLine("suma liczb zadeklarowanych {0} + {1} = {2}", a, b, methods.sum1(a, b));
Console.WriteLine("Delta dla równania kwadratowego o współczynnikach a=1, b=5, c=6 wynosi: " + methods.ObliczDelta(1, 5, 6));
Console.WriteLine("Wylosowana liczba z przedziału 1.5 do 4.5: " + methods.LosujLiczbe());
*/

/*
///Using Classes and Objects

/// Creating objects from a class 
Car car = new Car(); // creating an object of the Car class
Console.WriteLine("Samochod kolor: " + car.color + " rocznik: " + car.rok);

// displaying the values of the attributes color and rok
car = new Car();    // creating another object of the Car class
car.color = "blue"; // changing the color attribute of the
car.rok = 2022;     // changing the rok attribute of the car object
Console.WriteLine("Samochod kolor: " + car.color + " rocznik: " + car.rok); // displaying the values of the attributes color and rok
car.FullThrottle(); // calling the method FullThrottle on the car object

//Multiple Objects run
Console.WriteLine("Multiple Object");
MultipleObjects multipleObjects = new MultipleObjects();
multipleObjects.Run();



/// Accessing Attributes
static void Main(string[] args)
{
    Car car = new Car();
    Console.WriteLine(car.color);
}

Main(args);

// Output: red
// Explanation: In the Main method, we create an object of the Car class named car. We then access the color attribute of the car object using dot notation (car.color) and print its value to the console. The output will be "red" since that is the default value assigned to the color attribute in the Car class.
// Accessing Methods
static void Main2(string[] args)
{   Car car = new Car();
    car.FullThrottle();
}
Main2(args);
// Output: The car is going as fast as it can!
*/

//Accessing to the object method and field myCar using MyClass
Console.WriteLine("Accessing to the object method using MyClass:");

MyClass myCar = new MyClass(); // Create an object (myCar) of MyClass
myCar.fullThrottle(); // Call the fullThrottle method on the myCar object
// Output: The car is going as fast as it can!
myCar.color = "blue"; // Change the value of the color field
Console.WriteLine(myCar.color); // Output the value of the color field
// Output: blue
myCar.maxSpeed = 250; // Change the value of the maxSpeed field 
Console.WriteLine(myCar.maxSpeed); // Output the value of the maxSpeed field
// Output: 250
myCar.model = "Mitsubishi"; // Assign a value to the model field without making it empty
Console.WriteLine(myCar.model); // Output the value of the model field
                                // Output: Mitsubishi

MyClass Ford = new MyClass();
Ford.model = "Mustang";
Ford.color = "red";
Ford.year = 1969;

MyClass Opel = new MyClass();
Opel.model = "Astra";
Opel.color = "white";
Opel.year = 2005;
Console.WriteLine(Ford.model + " " + Ford.color + " " + Ford.year);
Console.WriteLine(Opel.model + " " + Opel.color + " " + Opel.year);
Console.WriteLine(myCar.model + " " + myCar.color + "year is not assigned, so it will output " + myCar.year); // year is not assigned, so it will output 0 (Mitsubishi blue 0)

// Constructors
MyClass Car = new MyClass();    // Create an object of the Car Class (this will call the constructor)
Console.WriteLine("Constructor example:");
Console.WriteLine(Car.model + " " + Car.maxSpeed + " is Electric: " + Car.isElectric); // Print the value of model, maxSpeed, isElectric, Output: Toyota 100 is Electric: False

//Create another object of the MyClass with different parameter
Console.WriteLine("Constructor with parameter example:");

MyClass Renault = new MyClass("Trafic", "Yellow", 2020,"NO");
Console.WriteLine(Renault.model + " " + Renault.color + " " + Renault.year + " Damage condytion " + Renault.demaged);

MyClass Honda = new MyClass("Civic", "Black", 2018,"YES");
Console.WriteLine(Honda.model + " " + Honda.color + " " + Honda.year + " Damage condytion " + Honda.demaged);

/*
// Access Modifiers

//public	    The code is accessible for all classes
//private	    The code is only accessible within the same class
//protected	The code is accessible within the same class, or in a class that is inherited from that class. You will learn more about inheritance in a later chapter
//internal	The code is only accessible within its own assembly, but not from another assembly. You will learn more about this in a later chapter
//There's also two combinations: protected internal and private protected.

//For now, lets focus on public and private modifiers.
*/


Fruit fruit = new Fruit();
Console.WriteLine("Access Modifiers (private) example:");
fruit.displayType();

/*
 * To control the visibility of class members (the security level of each individual class and class member).
 * To achieve "Encapsulation" - which is the process of making sure that "sensitive" data is hidden from users. This is done by declaring fields as private. You will learn more about this in the next chapter.
 * To protect members from being modified by accident and to avoid unintended consequences.
 * By default, all members of a class are private if you don't specify an access modifier:
 
class Car
{
  string model;  // private
  string year;   // private
}
 
 */

/*
//C# Properties (Get and Set)

Encapsulation, is to make sure that "sensitive" data is hidden from users.To achieve this, you must:

* declare fields/variables as private
* provide public get and set methods, through properties, to access and update the value of a private field
* 
* Why Encapsulation?
Better control of class members (reduce the possibility of yourself (or others) to mess up the code)
Fields can be made read-only (if you only use the get method), or write-only (if you only use the set method)
Flexible: the programmer can change one part of the code without affecting other parts
Increased security of data
*/
Person person = new Person();
person.Name = "John"; // Set the value of the Name property
Console.WriteLine("C# Properties (Get and Set) example:");
Console.WriteLine("Person Name: " + person.Name); // Get the value of the Name property
Console.WriteLine("Wpisz swoje imię: ");
Console.WriteLine(person.Name = Console.ReadLine());
// Automatic Properties (Short Hand)
person.Age = 42; // Set the value of the Age property
Console.WriteLine("Person Age: " + person.Age); // Get the value of the Age property
Console.WriteLine("Twoje imię to: " + person.Name + " i masz " + person.Age + " lata");

// End of W3Schools/Program.cs



