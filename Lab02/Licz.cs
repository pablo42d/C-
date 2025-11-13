using System;

namespace Lab02
{
    public class Licz
    {
        private int value;

        public Licz(int value)
        {
            this.value = value;
        }
        public void Dodaj(int dodaj)
        {
            value += dodaj;
        }
        public void Odejmij(int odejmij)
        {
            value -= odejmij;
        }
        public int Wynik
        {
            get { return value; }
        }


        /*
        private int wynik = 6;

        public int Wynik
        {
            get { return wynik; }   // umożliwia odczyt wartości wyniku z zewnątrz
            set { wynik = value; }  // umożliwia ustawienie wartości wyniku z zewnątrz
        }

        public void Dodaj(int value)
        {
            wynik += value;
        }

        public void Odejmij(int value)
        {
            wynik -= value;
        }

        public static void PokazWyrazenie(int wynik)
        {
            Console.WriteLine($"Wynik wyrażenia: {wynik}");
        }

        // Konstruktor bezparametrowy
        //public Licz()
        //{
        //    this.wynik = 0;
        //}
        // Konstruktor parametrowy
        public Licz(int value)
        {
            this.wynik = value;
        }
        // Do klasy Licz dodaj konstruktor z jednym parametrem - który inicjuje pole wartość na liczbę przekazaną w parametrze
        //public Licz(int wartoscPoczatkowa)
        //{
        //    this.wynik = wartoscPoczatkowa;
        //}
        */


    }
}
