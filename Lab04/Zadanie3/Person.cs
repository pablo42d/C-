using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using Lab04.Zadanie3;

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
        //public List<Person> DaneOsobowe()
        //{
        //    List<Person> daneOsobowe = new List<Person>();
        //    daneOsobowe.Add(new Person("Imie", Imie));
        //    daneOsobowe.Add(new Person("Nazwisko", Nazwisko));
        //    return daneOsobowe;
        //}


        // Implementacja metody ZwrocPelnaNazwe
        public string ZwrocPelnaNazwe()
        {
            //Console.WriteLine($"Pełna nazwa: {Imie} {Nazwisko}");
            return $"{Imie} {Nazwisko}";
            //foreach (var dane in DaneOsobowe())
            //{
            //    Console.WriteLine($"{dane.Nazwa}: {dane.Wartosc}");                

            //}
        }
    }
}
