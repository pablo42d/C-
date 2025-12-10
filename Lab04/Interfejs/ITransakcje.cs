using System;
using System.Collections.Generic;
using System.Text;

//Interfejs
//Interfejs jest definiowany jako swojego rodzaju wzór, który wszystkie klasy implementujące muszą
//przestrzegać. Interfejs określa ’co’ powinno być zrobione a klasa dziedzicząca ’jak’ powinno to być
//zrobione.

namespace Lab04.Interfejs
{
    public interface ITransakcje
    {
        // składowe interfejsu
        void WyswietlDane();
        int PoliczIlosc();
    }
}
