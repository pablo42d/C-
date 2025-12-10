using System;
using System.Collections.Generic;
using System.Text;

namespace Lab04.PrzeciazanieMetod
{
    internal class Pudelko
    {
        private double dlugosc;
        private double szerokosc;
        private double wysokosc;
        public void PobierzDlugosc(double d)
        {
            dlugosc = d;
        }
        public void PobierzSzerokosc(double s)
        {
            szerokosc = s;
        }
        public void PobierzWysokosc(double w)
        {
            wysokosc = w;
        }
        public double ObliczObjetosc()
        {
            return (dlugosc * szerokosc * wysokosc);
        }
        // Przeciążenie operatora +
        // Dodanie do siebie dwóch typów
        public static Pudelko operator +(Pudelko a, Pudelko b)
        {
            Pudelko pud = new Pudelko();
            pud.wysokosc = a.wysokosc + b.wysokosc;
            pud.szerokosc = a.szerokosc + b.szerokosc;
            pud.dlugosc = a.dlugosc + b.dlugosc;
            return pud;
        }
        // Przeciążenie operatora ==
        public static bool operator ==(Pudelko a, Pudelko b)
        {
            bool status = false;
            if (a.dlugosc == b.dlugosc && a.szerokosc == b.szerokosc && a.wysokosc ==
           b.wysokosc)
                status = true;
            return status;
        }
        // Przeciążenie operatora !=
        public static bool operator !=(Pudelko a, Pudelko b)
        {
            bool status = false;
            if (a.dlugosc != b.dlugosc || a.szerokosc != b.szerokosc || a.wysokosc !=
           b.wysokosc)
                status = true;
            return status;
        }
        public override string ToString()
        {
            return String.Format("({0}, {1}, {2})", dlugosc, szerokosc, wysokosc);
        }
    }
}
