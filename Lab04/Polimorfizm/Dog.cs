using System;
using System.Collections.Generic;
using System.Text;

namespace Lab04.Polimorfizm
{
    internal class Dog : Animal
    {
        public override string Speak()
        {
            Console.WriteLine("The dog barks: bow wow");
            return "The dog barks.";
        }
        //public void animalSound()
        //{
        //    Console.WriteLine(Speak());
        //}
    }
}
