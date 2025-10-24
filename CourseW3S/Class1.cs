using CourseW3S;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using static System.Net.Mime.MediaTypeNames;


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
        private void operators()
        {
            Console.WriteLine("-------Operators-----");
            int a = 10;
            int b = 5;
            // Arithmetic Operators
            Console.WriteLine("Addition: " + (a + b));          // 15
            Console.WriteLine("Subtraction: " + (a - b));       // 5
            Console.WriteLine("Multiplication: " + (a * b));    // 50
            Console.WriteLine("Division: " + (a / b));          // 2
            Console.WriteLine("Modulus: " + (a % b));           // 0
            Console.WriteLine("Increment: " + (++a));              // 11
            Console.WriteLine("Decrement: " + (--b));              // 4
            Console.WriteLine(" " + (b = b | 3));     // 7
            Console.WriteLine(" " + (b = b & 2));     // 2
            Console.WriteLine(" " + (b = b ^ 5));     // 7 

            // Comparison Operators
            Console.WriteLine("Equal: " + (a == b));           // False
            Console.WriteLine("Not Equal: " + (a != b));       // True
            Console.WriteLine("Greater Than: " + (a > b));      // True
            Console.WriteLine("Less Than: " + (a < b));         // False
            Console.WriteLine("Greater Than or Equal: " + (a >= b)); // True
            Console.WriteLine("Less Than or Equal: " + (a <= b));    // False
            Console.WriteLine(" " + (b <<= 1));   // 4
            Console.WriteLine(" " + (b >>= 2));   // 1

            // Logical Operators
            bool x = true;
            bool y = false;
            Console.WriteLine("Logical AND: " + (x && y));      // False
            Console.WriteLine("Logical OR: " + (x || y));       // True
            Console.WriteLine("Logical NOT: " + (!x));          // False
        }
        public void RunOperators()
        {
            operators();
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

        private void MathMethods()
        {
            Console.WriteLine("-------Math Methods-----");
            int num1 = -10;
            double num2 = 5.75;
            double num3 = 4.3;
            // Absolute value
            Console.WriteLine("Absolute value of " + num1 + " is: " + Math.Abs(num1));  // 10
            // Power
            Console.WriteLine(num2 + " raised to the power of 2 is: " + Math.Pow(num2, 3)); // 190.109375 5,75x5,75x5,75 
            // Square root
            Console.WriteLine("Square root of " + num3 + " is: " + Math.Sqrt(num3));    // 2.0736
            Console.WriteLine("Square root of 64 is: " + Math.Sqrt(64));    // 8
            // Maximum
            Console.WriteLine("Maximum of " + num2 + " and " + num3 + " is: " + Math.Max(num2, num3));  // 6.75
            // Minimum
            Console.WriteLine("Minimum of " + num2 + " and " + num3 + " is: " + Math.Min(num2, num3));  // 4.3
            // Rounding
            Console.WriteLine(num2 + " rounded is: " + Math.Round(num2)); // 6
        }
        public void RunMathMethods()
        {
            MathMethods();
        }

        private void RandomNumbers()
        {
            Console.WriteLine("-------Random Numbers-----");
            //Create an instance of the Random class
            Random random = new Random();
            //Generate a random integer between 0 and 100
            int randomInt = random.Next(0, 101);
            Console.WriteLine("Random Integer: " + randomInt);
            //Generate a random double between 0.0 and 1.0
            double randomDouble = random.NextDouble();
            Console.WriteLine("Random Double: " + randomDouble);
            //Generate a random integer within a specified range (e.g., 50 to 150)
            int randomRangeInt = random.Next(50, 151);
            Console.WriteLine("Random Integer (50-150): " + randomRangeInt);
        }
        public void RunRandomNumbers()
        {
            RandomNumbers();

        }
        //--------String Formatting------
        private void StringFormatting()
        {
            Console.WriteLine("-------String Formatting-----");
            string name = "John";
            int age = 30;
            // Using String.Format
            string formattedString1 = String.Format("My name is {0} and I am {1} years old.", name, age);
            Console.WriteLine(formattedString1);
            // Using Interpolated Strings
            string formattedString2 = $"My name is {name} and I am {age} years old.";
            Console.WriteLine(formattedString2);
            // Using Composite Formatting
            Console.WriteLine("My name is {0} and I am {1} years old.", name, age);
            // To count length of string
            Console.WriteLine(name.Length); //4
            // To uppercase
            Console.WriteLine(name.ToUpper()); //JOHN
            // To lowercase
            Console.WriteLine(name.ToLower()); //john
            // To concat strings
            string lastName = "Doe";
            Console.WriteLine(String.Concat(name, " ", lastName, "I'm", age, "old year")); // John Doe I'm 30 old year

            string x = "10";
            string y = "20";
            string z = x + y;  // z will be 1020 (a string)

            Console.WriteLine(z);

            int v = Convert.ToInt32(x) + Convert.ToInt32(y); // z will be 30 (an integer/number)

            // To find a substring, replace a substring, or get a character at a specific index
            string myString = "Hello, World!";
            // Location of letter W
            Console.WriteLine(myString.IndexOf("W")); //7
            // Get last word from position 7
            int charPos = myString.IndexOf("W");
            string lastWord = myString.Substring(charPos);
            Console.WriteLine(lastWord); //World!
            // Replace World with C#
            Console.WriteLine(myString.Replace("World", "C#")); //Hello, C#!
            // Get character at index 0
            Console.WriteLine(myString[0]); // H

            // Special characters
            // New line \n, Tab \t, Double Quote \", Backslash \\
            string specialString = "Hello,\nWorld!\tThis is a \"special\" string with a backslash \\";  //Hello,//World!   This is a "special" string with a backslash \
            Console.WriteLine(specialString);
            // The sequence \'  inserts a single quote in a string
            string singleQuoteString = "It\'s a beautiful day!";
            Console.WriteLine(singleQuoteString);
            // The sequence \\  inserts a single backslash in a string:
            string backslashString = "This is a backslash: \\";
            Console.WriteLine(backslashString);
            // The sequence \n  inserts a new line in a string:
            string newLineString = "Hello World!\nWelcome to C# programming.";
            Console.WriteLine(newLineString);
            // The sequence \t  inserts a tab in a string:
            string tabString = "Name:\tJohn Doe";
            Console.WriteLine(singleQuoteString);

            Console.WriteLine(newLineString);   //Hello World!
                                                //Welcome to C# programming.
            Console.WriteLine(tabString);   //Name:   John Doe

            // boolean methods for strings

            int myAge = Convert.ToInt32(Console.ReadLine()); // why I have to convert it to int?
            int votingAge = 18;

            if (myAge >= votingAge)
            {
                Console.WriteLine("Old enough to vote!");
            }
            else
            {
                Console.WriteLine("Not old enough to vote.");
            }

        }
        public void RunStringFormatting()
        {
            StringFormatting();
        }
        //--------Conditionals Example------
        /*
        1. If Statement:
        if (condition) 
        {
            // block of code to be executed if the condition is True
        }
        2. If-Else Statement:
        if (condition) 
        {
            // block of code to be executed if the condition is True
        } 
        else 
        {
            // block of code to be executed if the condition is False
        }
        3. Else-If Ladder:
        if (condition1) 
        {
            // block of code to be executed if condition1 is True
        } 
        else if (condition2) 
        {
            // block of code to be executed if condition2 is True
        } 
        else 
        {
            // block of code to be executed if both condition1 and condition2 are False
        }
        4. Switch Statement:
        switch (expression) 
        {
            case value1:
                // block of code to be executed if expression equals value1
                break;
            case value2:
                // block of code to be executed if expression equals value2
                break;
            ...
            default:
                // block of code to be executed if expression doesn't match any case
                break;
        }
        5. Ternary Operator:
        variable = (condition) ? expressionTrue :  expressionFalse;


        6. Nested If Statements:
        if (condition1) 
        {
            if (condition2) 
            {
                // block of code to be executed if both condition1 and condition2 are True
            }
        }
     
        */

        private void ConditionalsExample()
        {
            Console.WriteLine("-------Conditionals Example-----");


            int number = 10;
            // If-Else statement
            if (number > 0)
            {
                Console.WriteLine(number + " is a positive number.");
            }
            else if (number < 0)
            {
                Console.WriteLine(number + " is a negative number.");
            }
            else
            {
                Console.WriteLine("The number is zero.");
            }

            /* Switch statement
            switch (expression)
            {
                case x:
                    // code block
                    break;
                case y:
                    // code block
                    break;
                default:
                    // code block
                    break;
            }*/

            Console.WriteLine("Choose a day (1-7):");
            int day = Console.ReadLine() != null ? Convert.ToInt32(Console.ReadLine()) : 0; // 1-7  
            switch (day)
            {
                case 1:
                    Console.WriteLine("Monday");
                    break;
                case 2:
                    Console.WriteLine("Tuesday");
                    break;
                case 3:
                    Console.WriteLine("Wednesday");
                    break;
                case 4:
                    Console.WriteLine("Thursday");
                    break;
                case 5:
                    Console.WriteLine("Friday");
                    break;
                case 6:
                    Console.WriteLine("Saturday");
                    break;
                case 7:
                    Console.WriteLine("Sunday");
                    break;
                default:
                    Console.WriteLine("Invalid day");
                    break;


            }

            /*5.Ternary Operator:
            //variable = (condition) ? expressionTrue : expressionFalse;
            int time = 20;
            if (time < 18)
            {
                Console.WriteLine("Good day.");
            }
            else
            {
                Console.WriteLine("Good evening.");
            }*/

            int time = 20;
            string result = (time < 18) ? "Good day." : "Good evening.";
            Console.WriteLine(result);  // Good evening.

        }
        public void RunConditionalsExample()
        {
            ConditionalsExample();
        }

        //--------Loops Example------
        /*
         * while (condition) 
        {
            // code block to be executed
        }
         */

        private void LoopsExample()
        {
            Console.WriteLine("-------Loops Example-----");

            //In the example below, the code in the loop will run, over and over again, as long as a variable (z) is less than 5:

            int z = 0;
            while (z < 5)
            {
                Console.WriteLine(z);
                z++;
            }

            //The do/while loop is a variant of the while loop. This loop will execute the code block once, before checking if the condition is true, then it will repeat the loop as long as the condition is true.
            /* 
             do 
            {
                // code block to be executed
             }
                while (condition);
            The example below uses a do/while loop. The loop will always be executed at least once, even if the condition is false, because the code block is executed before the condition is tested:

             */

            int m = 0;
            do
            {
                Console.WriteLine(m);
                m++;
            } while (m < 5);

            // For loop
            Console.WriteLine("For Loop:");
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("Iteration: " + i);
            }
            // While loop
            Console.WriteLine("While Loop:");
            int j = 0;
            while (j < 5)
            {
                Console.WriteLine("Iteration: " + j);
                j++;
            }
            // Do-While loop
            Console.WriteLine("Do-While Loop:");
            int k = 0;
            do
            {
                Console.WriteLine("Iteration: " + k);
                k++;
            } while (k < 5);
        }
        public void RunLoopsExample()
        {
            LoopsExample();
        }


        private void ArraysExample()
        {
            Console.WriteLine("-------Arrays Example-----");
            // Declare and initialize an array of integers
            int[] numbers = { 10, 20, 30, 40, 50 };
            // Access and print elements of the array
            Console.WriteLine("First element: " + numbers[0]); // 10
            Console.WriteLine("Second element: " + numbers[1]); // 20
            // Modify an element in the array
            numbers[2] = 35;
            Console.WriteLine("Modified third element: " + numbers[2]); // 35
            // Get the length of the array
            Console.WriteLine("Array length: " + numbers.Length); // 5
            // Iterate through the array using a for loop
            Console.WriteLine("Array elements:");
            for (int i = 0; i < numbers.Length; i++)
            {
                Console.WriteLine(numbers[i]);
            }
        }
        public void RunArraysExample()
        {
            ArraysExample();
        }
        public void Run()
        {
            //RunVariableTypes();
            //RunDataTypesSizes();
            //RunOperators();
            //RunSomeMethod();
            //RunGetUserInput();
            //RunMathMethods();
            //RunStringFormatting();
            //RunConditionalsExample();
            //RunLoopsExample();
            //RunArraysExample();
            //RunRandomNumbers();
            LoopsExample();



        }
    }
}
