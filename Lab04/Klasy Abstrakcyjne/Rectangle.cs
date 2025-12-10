using System;
using System.Collections.Generic;
using System.Text;

namespace Lab04.Klasy_Abstrakcyjne
{
    internal class Rectangle
    {
        private double a = 5, b = 2;

        public double Area()
        {
            return a * b;
        }

        public double Circumference()
        {
            return (2 * a) + (2 * b);
        }

        public void view()
        {
            Console.WriteLine("Prostokat, pole: " + Area() + ", obwod: " +
           Circumference());
        }
    }
}
