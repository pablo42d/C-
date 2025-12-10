using System;
using System.Collections.Generic;
using System.Text;

namespace Lab04.Zadanie1
{
    internal class Rectangle1 : Shape
    {
        public Rectangle1(int x, int y, int Hight, int Width) : base(x, y, Hight, Width)
        {

        }
        public override void Draw()
        {
            Console.WriteLine("Rysuję prostokąt (Rectangle).");
        }

    }
}
