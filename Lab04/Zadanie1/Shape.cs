using System;
using System.Collections.Generic;
using System.Text;

namespace Lab04.Zadanie1
{
    internal class Shape
    {
        // właściwości X, Y, Height, Width
        public int X { get; set; }
        public int Y { get; set; }
        public int Height { get; set; }
        public int Width { get; set; }


        public Shape(int x, int y, int Hight, int Width)
        {
            X = x;
            Y = y;
            Height = Hight;
            Width = Width;
        }
        
        // virutalną metodę Draw
        public virtual void Draw()
        {
            Console.WriteLine("Rysuję kształt ogólny (Shape).");
        }
        
    }
}
