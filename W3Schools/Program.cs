// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");

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






