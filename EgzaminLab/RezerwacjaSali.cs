using System;
using System.Collections.Generic;
using System.Text;

namespace EgzaminLab
{
    internal class RezerwacjaSali : RezerwacjaBase
    {
        public int NumerSali { get; set; }

        public override void Wyswietl()
        {
            Console.WriteLine($"[SALA {NumerSali}] ID: {IdRezerwacji}, Zasób: {Zasob}");
        }
    }
}
