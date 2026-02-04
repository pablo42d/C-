using System;
using System.Collections.Generic;
using System.Text;

namespace EgzaminLab
{
    internal interface IRejestrRezerwacji
    {
        void DodajRezerwacje(IRezerwacja rezerwacja);
        void WyswietlWszystkieRezerwacje();
        void UsunRezerwacje(string idRezerwacji);
        void ZnajdzRezerwacje(string idRezerwacji); 
    }
}
