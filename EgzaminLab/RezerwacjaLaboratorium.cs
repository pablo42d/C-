using System;
using System.Collections.Generic;
using System.Text;

namespace EgzaminLab
{
    internal class RezerwacjaLaboratorium : RezerwacjaBase
    {
        public string? NazwaLaboratorium { get; set; }
        public override void Wyswietl()
        {
            Console.WriteLine($"[LABORATORIUM: {NazwaLaboratorium}] ID: {IdRezerwacji}, Zasób: {Zasob}");
        }
    }
}
