using System;
using System.Collections.Generic;
using System.Text;

namespace W4
{
    internal class Student : Osoba
    {
        public Student(string imie, string nazwisko, int wiek, string zawod) : base(imie, nazwisko, wiek, zawod)
        {
        }
    }
}
