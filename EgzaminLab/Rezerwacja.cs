using System;
using System.Collections.Generic;
using System.Text;

namespace EgzaminLab
{
    internal class Rezerwacja
    {
        // prywatne pola
        private string idRezerwacji;
        private string zasob;
        private string rezerwujacy;
        private DateTime data;
        private string status; // np. "Aktywna", "Anulowana", Zrealizowana"

        // Konstruktor domyślny
        public Rezerwacja()
        {
            idRezerwacji = "";
            zasob = "";
            rezerwujacy = "";
            data = DateTime.Now;
            status = "Nowa";
        }

        // Konstruktor z parametrami
        public Rezerwacja(string id, string co, string kto, DateTime kiedy, string stan)
        {
            idRezerwacji = id;
            zasob = co;
            rezerwujacy = kto;
            data = kiedy;
            status = stan;
        }

        // Metody operacyjne
        public string PobierzId() => idRezerwacji;

        public void ZmienStatus(string nowyStatus)
        {
            status = nowyStatus;
        }

        public void Wyswietl()
        {
            Console.WriteLine($"ID obiektu: {idRezerwacji}");
            Console.WriteLine($"Rezerwujesz: {zasob}");
            Console.WriteLine($"Osoba: {rezerwujacy}");
            Console.WriteLine($"Data: {data.ToShortDateString()}");
            Console.WriteLine($"Status rezerwowanych zasobów: {status}");
            Console.WriteLine("------------------------------------------");
            //Console.WriteLine($"ID obiektu: {idRezerwacji} | Rezerwujwsz: {zasob} | Osoba: {rezerwujacy}");
            //Console.WriteLine($"Data: {data.ToShortDateString()} | Status rezerwowanych zasobów: {status}");
        }
    }
}
