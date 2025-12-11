using System;
using System.Collections.Generic;
using System.Text;

namespace Lab04.Zadanie3
{
    internal class Person : IPerson
    {

        private string Imie;
        private string Nazwisko;

        public Person(string imie, string nazwisko)
        {
            this.Imie = imie;
            this.Nazwisko = nazwisko;
            //Imie = imie;
            //Nazwisko = nazwisko;
        }
        // Implementacja metody ZwrocPelnaNazwe
        public void ZwrocPelnaNazwe()
        {
            Console.WriteLine($"Pełna nazwa: {Imie} {Nazwisko}");
        }
    }
}
