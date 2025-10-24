using CourseW3S;


namespace CourseW3S
{
    internal class Class1
    {
        private readonly Random _rng = new Random();

        /*In C#, there are different types of variables (defined with different keywords), for example:

        int - stores integers (whole numbers), without decimals, such as 123 or -123
        double - stores floating point numbers, with decimals, such as 19.99 or -19.99
        char - stores single characters, such as 'a' or 'B'. Char values are surrounded by single quotes
        string - stores text, such as "Hello World". String values are surrounded by double quotes
        bool - stores values with two states: true or false*/
        private void VariableTypes()
        {
            Console.WriteLine("-------Variable Types-----");
            int myNum = 5;               // integer (whole number)
            double myDoubleNum = 5.99D;  // floating point number
            char myLetter = 'D';         // character
            bool myBool = true;          // boolean
            string myText = "Hello";     // string
            Console.WriteLine(myNum);
            Console.WriteLine(myDoubleNum);
            Console.WriteLine(myLetter);
            Console.WriteLine(myBool);
            Console.WriteLine(myText);
        }
        public void RunVariableTypes()
        {
            VariableTypes();
        }

        /*Data Type	Size	Description

        int	4 bytes	Stores whole numbers from -2,147,483,648 to 2,147,483,647
        long	8 bytes	Stores whole numbers from -9,223,372,036,854,775,808 to 9,223,372,036,854,775,807
        float	4 bytes	Stores fractional numbers. Sufficient for storing 6 to 7 decimal digits
        double	8 bytes	Stores fractional numbers. Sufficient for storing 15 decimal digits
        bool	1 byte	Stores true or false values
        char	2 bytes	Stores a single character/letter, surrounded by single quotes
        string	2 bytes per character	Stores a sequence of characters, surrounded by double quotes*/

        private void DataTypesSizes()
        {
            Console.WriteLine("-------Data Type Size-----");
            int myInt = 100000;
            long myLong = 15000000000L;
            float myFloat = 5.75F;
            float f1 = 35e3F;//35000
            double myDouble = 19.99D;
            double d1 = 12E4D; //120000
            bool myBool = true;
            char myChar = 'A';
            string myString = "Hello World";
            Console.WriteLine("Integer: " + myInt);
            Console.WriteLine("Long: " + myLong);
            Console.WriteLine("Float: " + myFloat);
            Console.WriteLine(f1);
            Console.WriteLine(d1);
            Console.WriteLine("Double: " + myDouble);
            Console.WriteLine("Boolean: " + myBool);
            Console.WriteLine("Character: " + myChar);
            Console.WriteLine("String: " + myString);

        }
        public void RunDataTypesSizes()
        {
            DataTypesSizes();
        }


        /*
        string name="John";
        Console.WriteLine(name);

        //Create a variable called myNum of type int and assign it the value 15:

        int myNum = 15;
        Console.WriteLine(myNum);

        //You can also declare a variable without assigning the value, and assign the value later:
        //Example

        int myNum;
        myNum = 15;
        Console.WriteLine(myNum);


        //Change the value of myNum to 20:

        int myNum = 15;
        myNum = 20; // myNum is now 20
        Console.WriteLine(myNum);

        int myNum = 5;
        double myDoubleNum = 5.99D;
        char myLetter = 'D';
        bool myBool = true;
        string myText = "Hello";


        const int myNum = 15;
        myNum = 20; // error*/

        private void SomeMethod()
        {
            Console.WriteLine("-------Some Method----");
            const int myNum = 15;
            Console.WriteLine(myNum);
            //myNum = 20; // error
            Console.WriteLine(myNum);

            string firstName = "John ";
            string lastName = "Doe";
            string fullName = firstName + lastName;
            Console.WriteLine(fullName);


            int x = 5, y = 6, z = 50;
            Console.WriteLine(x + y + z);
            int a, b, c;
            a = b = c = 50;
            Console.WriteLine(a + b + c);// =150

            int myInt = 10;
            double myDouble = 5.25;
            bool myBool = true;

            Console.WriteLine(Convert.ToString(myInt));    // Convert int to string
            Console.WriteLine(Convert.ToDouble(myInt));    // Convert int to double
            Console.WriteLine(Convert.ToInt32(myDouble));  // Convert double to int
            Console.WriteLine(Convert.ToString(myBool));   // Convert bool to string

            int myNewInt = 9;
            double myNewDouble = myNewInt;       // Automatic casting: int to double

            Console.WriteLine(myNewInt);      // Outputs 9
            Console.WriteLine(myNewDouble);   // Outputs 9


            double myDoubleTest = 9.78;
            int myIntTest = (int)myDoubleTest;    // Manual casting: double to int

            Console.WriteLine(myDoubleTest);   // Outputs 9.78
            Console.WriteLine(myIntTest);      // Outputs 9

        }
        public void RunSomeMethod()
        {
            SomeMethod();
        }
        /*

        //konwersja typów

        int myInt = 10;
        double myDouble = 5.25;
        bool myBool = true;

        Console.WriteLine(Convert.ToString(myInt));    // Convert int to string
        Console.WriteLine(Convert.ToDouble(myInt));    // Convert int to double
        Console.WriteLine(Convert.ToInt32(myDouble));  // Convert double to int
        Console.WriteLine(Convert.ToString(myBool));   // Convert bool to string
        int myInt = 9;
        double myDouble = myInt;       // Automatic casting: int to double

        Console.WriteLine(myInt);      // Outputs 9
        Console.WriteLine(myDouble);   // Outputs 9


        double myDouble = 9.78;
        int myInt = (int)myDouble;    // Manual casting: double to int

        Console.WriteLine(myDouble);   // Outputs 9.78
        Console.WriteLine(myInt);      // Outputs 9
        */

        //--------Get User Input------
        public void getUserInput()
        {
            Console.WriteLine("-------Get User Input-----");
            // Type your username and press enter
            Console.WriteLine("Enter username:");

            // Create a string variable and get user input from the keyboard and store it in the variable
            string userName = Console.ReadLine();

            // Print the value of the variable (userName), which will display the input value
            Console.WriteLine("Username is: " + userName);
            Console.WriteLine("Enter your age:");
            int age = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Your age is: " + age);
        } 
        public void RunGetUserInput()
        {
            getUserInput();
        }


       



    }
}
