using System;
using System.Collections.Generic;
using System.Text;

namespace Lab05
{
    internal class Kalkulator
    {
        // Metoda do wykonywania podstawowych operacji matematycznych
        public double WykonajOperacje(double a, double b, string operacja)
        {
            return operacja switch
            {
                "+" => a + b,
                "-" => a - b,
                "*" => a * b,
                "/" => b != 0 ? a / b : throw new DivideByZeroException("Nie można dzielić przez zero."),
                _ => throw new InvalidOperationException("Nieznana operacja matematyczna.")
            };
        }

        // wyliczeniowego(enum) do reprezentowania dostępnych operacji: dodawanie, odejmowanie,mnożenie, dzielenie.
        public enum Operacje
        {
            Dodawanie,
            Odejmowanie,
            Mnożenie,
            Dzielenie
        }
        // Metoda do mapowania typu wyliczeniowego na symbol operacji
        public string MapujOperacje(Operacje operacja)
        {
            return operacja switch
            {
                Operacje.Dodawanie => "+",
                Operacje.Odejmowanie => "-",
                Operacje.Mnożenie => "*",
                Operacje.Dzielenie => "/",
                _ => throw new InvalidOperationException("Nieznana operacja matematyczna.")
            };
        }
        // Metoda do pobierania dostępnych operacji jako listy stringów
        public List<string> PobierzDostepneOperacje()
        {
            List<string> operacje = new List<string>();
            foreach (Operacje op in Enum.GetValues(typeof(Operacje)))
            {
                operacje.Add(MapujOperacje(op));
            }
            return operacje;
        }
        // Metoda do wyświetlania historii wyników
        public void WyswietlHistorieWynikow(List<double> historiaWynikow)
        {
            Console.WriteLine("Historia wyników:");
            foreach (var wynik in historiaWynikow)
            {
                Console.WriteLine(wynik);
            }
        }
        // Metoda do obsługi wyjątków
        public void ObsluzWyjatki(Action akcja)
        {
            try
            {
                akcja();
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine($"Błąd: {ex.Message}");
            }
            catch (FormatException)
            {
                Console.WriteLine("Błąd: Niepoprawny format liczby.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Wystąpił nieoczekiwany błąd: {ex.Message}");
            }
            finally
            {
                Console.WriteLine("Koniec operacji kalkulatora.");
            }
        }
        // Metoda do pobierania liczby od użytkownika z obsługą wyjątków
        public double PobierzLiczbeOdUzytkownika(string komunikat)
        {
            while (true)
            {
                Console.WriteLine(komunikat);
                string input = Console.ReadLine();
                try
                {
                    return double.Parse(input);
                }
                catch (FormatException)
                {
                    Console.WriteLine("Błąd: Niepoprawny format liczby. Spróbuj ponownie.");
                }
            }

        }
        
    }
}
