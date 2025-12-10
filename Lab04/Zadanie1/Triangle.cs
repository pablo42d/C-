using System;
using System.Collections.Generic;
using System.Text;

namespace Lab04.Zadanie1
{
    internal class Triangle : Shape
    {
        public Triangle(int x, int y, int Hight, int Width) : base(x, y, Hight, Width)
        {
        }
        public override void Draw()
        {
            Console.WriteLine("Rysuję trójkąt (Triangle).");
        }
    }    
}
