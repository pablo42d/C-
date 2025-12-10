using System;
using System.Collections.Generic;
using System.Text;

namespace Lab04
{
    internal class Pig : Animal
    {
        public override string Speak()
        {
            Console.WriteLine("The pig oinks: oink oink");
            return "The pig oinks: oink oink";            
        }
    }
}
