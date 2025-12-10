using System;
using System.Collections.Generic;
using System.Text;

namespace Lab04.Klasy_Abstrakcyjne
{
    abstract class Figure
    {
        // Abstract method (does not have a body)
        public abstract double area();
        public abstract double circumference();
        // Regular method
        public void view()
        {
            Console.WriteLine("Figura: ");
        }

    }
}
