using System;
using System.Collections.Generic;
using System.Text;

namespace W4
{
    internal class Osoba
    {
        public Adres adres { get; set; }    //kompozycja
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public int Wiek { get; set; }
        public string Zawod { get; set; }
        public Osoba(string imie, string nazwisko, int wiek, string zawod)
        {
            Imie = imie;
            Nazwisko = nazwisko;
            Wiek = wiek;
            Zawod = zawod;
            adres = new Adres();
        }
        public override string ToString()
        {
            return $"{Imie} {Nazwisko}, Wiek: {Wiek}, Zawód: {Zawod}";
        }
    }
}
