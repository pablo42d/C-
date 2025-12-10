using System;
using System.Collections.Generic;
using System.Text;

namespace Lab04.Klasy_Abstrakcyjne
{
    internal class Square : Figure
    {
        public double a = 4;
        public override double area()
        {
            return a * a;
        }
        public override double circumference()
        {
            return 4 * a;
        }
        public void view()
        {
            Console.WriteLine("Kwadrat, pole: " + area() + ", obwod: " +
           circumference());
        }

    }
}
