using System;
using System.Collections.Generic;
using System.Text;
using Lab05.zadanie3;


namespace Lab05.zadanie3
{
    class GraKolory
    {
        private List<Kolor> kolory = new List<Kolor>
        {
            Kolor.Czerwony,
            Kolor.Niebieski,
            Kolor.Zielony,
            Kolor.Zolty,
            Kolor.Fioletowy
        };

        private Kolor wylosowanyKolor;

        public GraKolory()
        {
            Random random = new Random();
            wylosowanyKolor = kolory[random.Next(kolory.Count)];
        }

        public void Start()
        {
            bool odgadniety = false;

            while (!odgadniety)
            {
                try
                {
                    Console.Write("Podaj kolor: ");
                    string input = Console.ReadLine()!; // tu null nie wystąpi

                    Kolor podanyKolor;

                    if (!Enum.TryParse(input, true, out podanyKolor)
                        || !kolory.Contains(podanyKolor))
                    {
                        throw new ArgumentException("Nieprawidłowy kolor!");
                    }

                    if (podanyKolor == wylosowanyKolor)
                    {
                        Console.WriteLine("Brawo! Odgadłeś kolor 🎉");
                        odgadniety = true;
                    }
                    else
                    {
                        Console.WriteLine("Nie zgadłeś, spróbuj ponownie.");
                    }
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine("Błąd: " + e.Message);
                }
            }
        }
    }

}

