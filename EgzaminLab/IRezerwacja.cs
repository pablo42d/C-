using System;
using System.Collections.Generic;
using System.Text;

namespace EgzaminLab
{
    internal interface IRezerwacja
    {
        string IdRezerwacji { get; set; }
        void Wyswietl();
    }
    abstract class RezerwacjaBase : IRezerwacja
    {
        public string IdRezerwacji { get; set; }
        public string Zasob { get; set; }

        public abstract void Wyswietl();
    }
}
