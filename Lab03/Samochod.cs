using System;
using System.Collections.Generic;
using System.Text;

namespace Lab03
{
    internal class Samochod
    {
        // pola klasy Samochod Marka, Model, Nadwozie, Kolor, Rok produkcji, Przebieg (nie może być ujemny)
        public string Marka { get; set; }
        public string Model { get; set; }
        public string Nadwozie { get; set; }
        public string Kolor { get; set; }
        public int RokProdukcji { get; set; }
        private int przebieg;

        public int Przebieg
        {
            get { return przebieg; }
            // get => przebieg;
            // set => przebieg = value < 0 ? throw new ArgumentException("Przebieg nie może być ujemny.") : value;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Przebieg nie może być ujemny.");
                }
                przebieg = value;
            }
        }
        // przeciąż konstruktor w taki sposób, by wartości pól były parametrami metody
        public Samochod(string marka, string model, string nadwozie, string kolor, int rokProdukcji, int przebieg)
        {
            Marka = marka;
            Model = model;
            Nadwozie = nadwozie;
            Kolor = kolor;
            RokProdukcji = rokProdukcji;
            Przebieg = przebieg; // // walidacja w setterze
        }
        // konstruktor, który pobierze dane od użytkownika

        public Samochod()
        {
            Console.Write("Podaj markę samochodu: ");
            Marka = Console.ReadLine();
            Console.Write("Podaj model samochodu: ");
            Model = Console.ReadLine();
            Console.Write("Podaj nadwozie samochodu: ");
            Nadwozie = Console.ReadLine();
            Console.Write("Podaj kolor samochodu: ");
            Kolor = Console.ReadLine();
            Console.Write("Podaj rok produkcji samochodu: ");
            RokProdukcji = int.Parse(Console.ReadLine());
            Console.Write("Podaj przebieg samochodu: ");
            Przebieg = int.Parse(Console.ReadLine());
        }
        // metoda, która wyświetli informacje o samochodzie 
        public virtual void WyswietlInformacje()
        {
            Console.WriteLine($"\nSamochód:");
            Console.WriteLine($"Marka: {Marka}");
            Console.WriteLine($"Model: {Model}");
            Console.WriteLine($"Nadwozie: {Nadwozie}");
            Console.WriteLine($"Kolor: {Kolor}");
            Console.WriteLine($"Rok produkcji: {RokProdukcji}");
            Console.WriteLine($"Przebieg: {Przebieg} km");
        }
    }
}
