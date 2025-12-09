using System;
using System.Collections.Generic;
using System.Text;

namespace Lab03
{
    internal class SamochodOsobowy : Samochod
    {
        // pola klasy SamochodOsobowy Waga (powinna być z przedziału 2 t – 4,5 t), Pojemność silnika (powinna być z przedziału 0,8-3,0), Ilość osób
        private double waga;

        public double Waga
        {
            get { return waga; }
            // get => waga;
            // set => waga = value < 2.0 || value > 4.5 ? throw new ArgumentException("Waga powinna być z przedziału 2 t – 4,5 t.") : value;
            set
            {
                if (value < 2.0 || value > 4.5)
                {
                    throw new ArgumentException("Waga powinna być z przedziału 2 t – 4,5 t.");
                }
                waga = value;
            }
        }
        private double pojemnoscSilnika;       

        public double PojemnoscSilnika
        {
            get { return pojemnoscSilnika; }
            set
            {
                if (value < 0.8 || value > 3.0)
                {
                    throw new ArgumentException("Pojemność silnika powinna być z przedziału 0,8-3,0.");
                }
                pojemnoscSilnika = value;
            }
        }
        public int IloscOsob { get; set; }

        // konstruktor, który pobierze dane od użytkownika
        public SamochodOsobowy() : base()
        {
            Console.Write("Podaj wagę (2.0–4.5 t): ");
            Waga = double.Parse(Console.ReadLine());

            Console.Write("Podaj pojemność silnika (0.8–3.0 l): ");
            PojemnoscSilnika = double.Parse(Console.ReadLine());

            Console.Write("Podaj ilość osób: ");
            IloscOsob = int.Parse(Console.ReadLine());
        }

        // Przesłanianie klasy Samochod w klasie SamochodOsobowy
        public override void WyswietlInformacje()
        {
            base.WyswietlInformacje();
            Console.WriteLine($"Waga: {Waga} t");
            Console.WriteLine($"Pojemność silnika: {PojemnoscSilnika} L");
            Console.WriteLine($"Ilość osób: {IloscOsob}");
        }



    }
}
