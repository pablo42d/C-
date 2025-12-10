using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Globalization;
using System.Text;

namespace Lab04.Cwiczenie1
{
    internal class Employee
    {
        public string FirstName { get; }
        public string LastName { get; }
        public IContract Contract { get; private set; }

        public Employee(string FirstName, string LastName) : this(FirstName, LastName, new Internship()) { }

        public Employee(string firstName, string lastName, IContract contract)
        {
            FirstName = string.IsNullOrWhiteSpace(firstName)
                ? throw new ArgumentNullException(nameof(firstName))
                : firstName;

            LastName = string.IsNullOrWhiteSpace(lastName)
                ? throw new ArgumentNullException(nameof(lastName))
                : lastName;

            Contract = contract ?? throw new ArgumentNullException(nameof(contract));
        }


        public void ZmienKontrakt(IContract nowyKontrakt)
        {
            Contract = nowyKontrakt ?? throw new ArgumentNullException(nameof(nowyKontrakt));
        }

        public decimal Pensja() => Contract.Salary();

        public override string ToString()
        {
            var pl = new CultureInfo("pl-PL");
            return $"{FirstName} {LastName} – pensja: {Pensja().ToString("C", pl)} ({Contract})";
        }
    }
}

//Klasa powinna:
//• posiadać właściwości(z enkapsulacją):
//o FirstName : string – imię,
//o LastName : string – nazwisko,
//o Contract : IContract – aktualna umowa pracownika (tylko odczyt z zewnątrz),
//• mieć dwa konstruktory:
//o przyjmujący imię i nazwisko – domyślnie tworzy umowę typu Internship z ustaloną stawką (np. 1000),
//o przyjmujący imię, nazwisko oraz dowolny obiekt implementujący IContract,
//• posiadać metodę:
//o void ZmienKontrakt(IContract nowyKontrakt) – zmieniającą umowę pracownika (zabezpiecz się przed null),
//o decimal Pensja() – zwracającą wynik metody Salary() aktualnego kontraktu,
// nadpisać ToString(), tak aby wypisywać dane pracownika oraz jego aktualne wynagrodzenie.
//Uwaga: Właściwość Contract powinna mieć prywatny 
//    setter, żeby z zewnątrz nie można było podmienić kontraktu 
//    bez użycia metody ZmienKontrakt (przykład enkapsulacji logiki zmiany umowy).
