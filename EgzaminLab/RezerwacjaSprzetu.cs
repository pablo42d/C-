using System;
using System.Collections.Generic;
using System.Text;

namespace EgzaminLab
{
    internal class RezerwacjaSprzetu : RezerwacjaBase
    {
        public string? TypSprzetu { get; set; }
        public override void Wyswietl()
        {
            Console.WriteLine($"[SPRZĘT: {TypSprzetu}] ID: {IdRezerwacji}, Zasób: {Zasob}");
        }
    }
}
