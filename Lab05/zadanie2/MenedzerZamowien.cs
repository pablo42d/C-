using System;
using System.Collections.Generic;
using System.Text;

namespace Lab05.zadanie2
{
    internal class MenedzerZamowien
    {
        private Dictionary<int, Zamowienie> zamowienia =
        new Dictionary<int, Zamowienie>();

        public void DodajZamowienie(int numer, List<string> produkty)
        {
            zamowienia.Add(numer, new Zamowienie(numer, produkty));
        }

        public void ZmienStatus(int numer, StatusZamowienia nowyStatus)
        {
            if (!zamowienia.ContainsKey(numer))
                throw new KeyNotFoundException("Zamówienie nie istnieje");

            if (zamowienia[numer].Status == nowyStatus)
                throw new ArgumentException("Status jest już ustawiony");

            zamowienia[numer].Status = nowyStatus;
        }

        public void WyswietlZamowienia()
        {
            foreach (var z in zamowienia.Values)
            {
                Console.WriteLine($"Zamówienie {z.Numer}");
                Console.WriteLine($"Status: {z.Status}");

                foreach (var p in z.Produkty)
                    Console.WriteLine("- " + p);

                Console.WriteLine();
            }
        }
    }
}