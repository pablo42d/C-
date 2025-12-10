using System;
using System.Collections.Generic;
using System.Text;

namespace Lab04.Zadanie1
{
    internal class Circle : Shape
    {

        public Circle(int x, int y, int Hight, int Width) : base(x, y, Hight, Width)
        {
        }
        public override void Draw()
        {
            Console.WriteLine("Rysuję koło (Circle).");
        }        
    }
}
