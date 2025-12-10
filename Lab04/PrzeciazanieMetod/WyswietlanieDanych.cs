using System;
using System.Collections.Generic;
using System.Text;

//Przeciążanie metod
//W tej samej definicji klasy może znajdować się wiele funkcji o tej samej nazwie. Definicja metod musi
//się różnić od siebie typem i/lub liczbą parametrów. Nie można przeciążyć metod, które różnią się tylko
//zwracanym typem.


namespace Lab04.PrzeciazanieMetod
{
    internal class WyswietlanieDanych
    {
        public void Wyswietl(int i)
        {
            Console.WriteLine("Wyswietlana liczba: {0}", i);
        }
        public void Wyswietl(double d)
        {
            Console.WriteLine("Wyswietlana liczna: {0}", d);
        }
        public void Wyswietl(string s)
        {
            Console.WriteLine("Wyswietlany tekst: {0}", s);
        }

    }
}
/*
Operatory przeciążalne i nieprzeciążalne

+, -, !, ~, ++, -- operatory jednoargumentowe mogą zostać przeciążone
+, -, *, /, % operatory binarne mogą zostać przeciążone
==, !=, <,>, <=, >= operatory porównania mogą zostać przeciążone
&&, || operatory operacji logicznych nie mogą być przeciążone
bezpośrednio
+=, -=, *=, /=, %= operatory przypisania nie mogą być przeciążone
=, ., ?:, ->, new, is, sizeof, typeof te operatory nie mogą być przeciążone
*/