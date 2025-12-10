using System;
using System.Collections.Generic;
using System.Text;

namespace Lab04.Polimorfizm
{
    internal class Animal   // Base class (parent class)
    {
        public virtual string Speak()
        {
            Console.WriteLine("The animal makes a sound");
            return "The animal makes a sound.";
        }
    }
}
