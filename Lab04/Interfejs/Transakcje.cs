using System;
using System.Collections.Generic;
using System.Text;

namespace Lab04.Interfejs
{
    public class Transakcje : ITransakcje
    {
        private string kod;
        private string data;
        private int ilosc;
        public Transakcje()
        {
            kod = "";
            data = "";
            ilosc = 0;
        }
        public Transakcje(string k, string d, int i)
        {
            kod = k;
            data = d;
            ilosc = i;
        }
        public int PoliczIlosc()
        {
            return ilosc;
        }
        public void WyswietlDane()
        {
            Console.WriteLine("Kod: {0}", kod);
            Console.WriteLine("Data: {0}", data);
            Console.WriteLine("Ilość: {0}", ilosc);
        }

    }
}
