using System;
using System.Collections.Generic;
using System.Text;

namespace EgzaminLab
{
    internal class RejestrRezerwacji
    {
        public List<IRezerwacja> rezerwacje;
        // public List<Rezerwacja> rezerwacje;
        public RejestrRezerwacji()
        {
            //rezerwacje = new List<Rezerwacja>();
            rezerwacje = new List<IRezerwacja>();
        }
        public void DodajRezerwacje(IRezerwacja nowaRezerwacja)
        {
            rezerwacje.Add(nowaRezerwacja);
        }
        //public void DodajRezerwacje(Rezerwacja nowaRezerwacja)
        //{
        //    rezerwacje.Add(nowaRezerwacja);
        //}


        public void UsunRezerwacje(string id)
        {
            //Rezerwacja? znaleziona = null;
            IRezerwacja? znaleziona = null;
            foreach (var r in rezerwacje)
            {
                //if (r.PobierzId() == id)
                if (r.IdRezerwacji == id)
                {
                    znaleziona = r;
                    break;
                }
            }

            if (znaleziona != null)
            {
                rezerwacje.Remove(znaleziona);
                Console.WriteLine($"Usunięto rezerwację {id}");
            }
            else Console.WriteLine("Nie znaleziono takiej rezerwacji.");
        }

        public void WyswietlWszystkie()
        {            
            foreach (var r in rezerwacje)
            {
                r.Wyswietl();
                Console.WriteLine("--------------------------");
            }
        }

        public void ZnajdzRezerwacje(string id)
        {
            foreach (var r in rezerwacje)
            {
                //if (r.PobierzId() == id)
                if (r.IdRezerwacji == id)
                {
                    r.Wyswietl();
                    return;
                }
            }
            Console.WriteLine("Brak rezerwacji o tym ID.");
        }
    }
}
