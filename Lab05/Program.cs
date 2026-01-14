//using System.Collections;
// enum

//enum  DniTygodnia
//{
//    Poniedziałek =1,
//    Wtorek,
//    Sroda,
//    Czwartek,
//    Piątek,
//    Sobota,
//    Niedziela
//}

//class Program
//{
//    static void Main(string[] args)
//    {
//        DniTygodnia ddzien= DniTygodnia.Poniedziałek;
//        int ileGodzin = IleGodzin(dzien);
//        Console.WriteLine($"Godziny pracy: {dzien} = {ileGodzin}");
//    }// End of Main

//    static int IleGodzin(DniTygodnia dzien)
//    {
//        switch (dzien)
//        {
//            case DniTygodnia.Poniedziałek:
//            case DniTygodnia.Wtorek:
//            case DniTygodnia.Sroda:
//            case DniTygodnia.Czwartek:
//            case DniTygodnia.Piątek:
//                return 8;
//            case DniTygodnia.Sobota:
//            case DniTygodnia.Niedziela:
//                return 0;
//            default:
//                return 0;
//        }


//    }

//}

//wyjątki 
//try
//kod który może spowodować wyjątek}
//try
//{
//    Console.WriteLine("podaj liczbę");
//    double a = inputDouble();
//    //Console.WriteLine("podaj drugą liczbę");
//    double b;
//    do // wykona się przynajmniej raz
//    {
//        Console.WriteLine("podaj drugą liczbę");
//        double b = inputDouble();
//        if (b == 0)
//        {
//            Console.WriteLine("Błąd, nie dziel przez 0");
//        }
//        else
//        {
//            double wynik = a / b;
//            Console.WriteLine($"wynik dzielenia {a} przez {b} to {wynik}");
//        }
//    } while (b == 0);

//    double wynik = a / b;
//    Console.WriteLine($"wynik dzielenia {a} przez {b} to {wynik}");
//}
//catch (Exception)
//{

//    double inputDouble()
//    {
//        double liczba;
//        try
//        {
//            string input = Console.ReadLine();
//            double value = double.Parse(input);
//            return value;
//        }
//        catch (FormatException)
//        {
//            Console.WriteLine("Niepoprawny format liczby. Spróbuj ponownie.");
//            //return inputDouble(); // Rekurencyjne wywołanie w celu ponownego wprowadzenia
//        }
//    }
//}
// ... (other code remains unchanged)

//double inputDouble()
//{
//    double liczba;
//    while (true)
//    {
//        try
//        {
//            string input = Console.ReadLine();
//            double value = double.Parse(input);
//            return value;
//        }
//        catch (FormatException)
//        {
//            Console.WriteLine("Niepoprawny format liczby. Spróbuj ponownie.");
//        }
//    }
//}

//try
//{
//    Console.WriteLine("podaj liczbę");
//    double a = inputDouble();
//    double b; // Declare b here
//    do // wykona się przynajmniej raz
//    {
//        Console.WriteLine("podaj drugą liczbę");
//        b = inputDouble(); // Assign to the already declared b
//        if (b == 0)
//        {
//            Console.WriteLine("Błąd, nie dziel przez 0");
//        }
//        else
//        {
//            double wynik = a / b;
//            Console.WriteLine($"wynik dzielenia {a} przez {b} to {wynik}");
//        }
//    } while (b == 0);

//    double wynik = a / b;
//    Console.WriteLine($"wynik dzielenia {a} przez {b} to {wynik}");
//}
//catch (Exception)
//{
//    // Exception handling if needed
//}

////catch może  być dowolna liczba
//catch (DivideByZeroException)
//{
//    Console.WriteLine("Błąd: Próba dzielenia przez zero.");
//}
//catch (FormatException)
//{
//    Console.WriteLine("Błąd: Niepoprawny format liczby.");
//}
//catch (Exception ex)
//{
//    Console.WriteLine($"Wystąpił nieoczekiwany błąd: {ex.Message}");
//    }
//    //finally zwsze się wykona
//    finally
//{
//    Console.WriteLine("Koniec operacji dzielenia");
//}

//kolekcje
//List<double> list = new List<double>();
//Array araay = new Array[10];
//ArrayList asd = new ArrayList();
//LinkedList<double> linkedList = new LinkedList<double>();
// ======================================================================

/* Zadanie 1. Kalkulator operacji matematycznych
Napisz program kalkulator, który wykonuje operacje matematyczne na dwóch liczbach. Użyj typu
wyliczeniowego (enum) do reprezentowania dostępnych operacji: dodawanie, odejmowanie,
mnożenie, dzielenie. Program powinien obsługiwać błędy wprowadzania danych przez użytkownika
(np. wpisanie tekstu zamiast liczby) oraz wyjątek dzielenia przez zero.
Wymagania:
• Użyj typu wyliczeniowego Operacja z wartościami: Dodawanie, Odejmowanie, Mnożenie,
Dzielenie.
• Przechwytuj wyjątki takie jak DivideByZeroException oraz FormatException.
• Skorzystaj z kolekcji List<double>, aby przechowywać wyniki poprzednich obliczeń.
• Po wykonaniu operacji, wyświetl wynik oraz historię wszystkich poprzednich wyników.
*/
// ======================================================================

//using System;
//using System.Collections.Generic;

//class Program
//{
//    static void Main(string[] args)
//    {
//        Kalkulator kalkulator = new Kalkulator();
//        List<double> historiaWynikow = new List<double>();
//        while (true)
//        {
//            Console.WriteLine("Wybierz operację matematyczną:");
//            List<string> dostepneOperacje = kalkulator.PobierzDostepneOperacje();
//            for (int i = 0; i < dostepneOperacje.Count; i++)
//            {
//                Console.WriteLine($"{i + 1}. {dostepneOperacje[i]}");
//            }
//            Console.WriteLine("0. Wyjście");
//            string wybor = Console.ReadLine();
//            if (wybor == "0")
//            {
//                break;
//            }
//            if (int.TryParse(wybor, out int indeksOperacji) && indeksOperacji > 0 && indeksOperacji <= dostepneOperacje.Count)
//            {
//                string operacja = dostepneOperacje[indeksOperacji - 1];
//                kalkulator.ObsluzWyjatki(() =>
//                {
//                    Console.Write("Podaj pierwszą liczbę: ");
//                    double a = double.Parse(Console.ReadLine());
//                    Console.Write("Podaj drugą liczbę: ");
//                    double b = double.Parse(Console.ReadLine());
//                    double wynik = kalkulator.WykonajOperacje(a, b, operacja);
//                    Console.WriteLine($"Wynik: {wynik}");
//                    historiaWynikow.Add(wynik);
//                    kalkulator.WyswietlHistorieWynikow(historiaWynikow);
//                });
//            }
//            else
//            {
//                Console.WriteLine("Niepoprawny wybór operacji.");
//            }
//        }
//    }
//}

/* Zadanie 2.  Zarządzanie zamówieniami w sklepie
Stwórz aplikację konsolową, która zarządza zamówieniami w sklepie. Każde zamówienie powinno mieć
przypisany status, reprezentowany przez typ wyliczeniowy (enum), oraz zawierać listę produktów. Użyj
kolekcji Dictionary<int, List<string>> do przechowywania zamówień, gdzie kluczem będzie numer
zamówienia, a wartością lista produktów.
Wymagania:
• Użyj typu wyliczeniowego StatusZamowienia z wartościami: Oczekujące, Przyjęte,
Zrealizowane, Anulowane.
• Dodaj metodę, która zmienia status zamówienia. Obsłuż wyjątek KeyNotFoundException, jeśli
zamówienie o podanym numerze nie istnieje.
• Dodaj metodę wyświetlającą wszystkie zamówienia i ich status.
• Użyj ArgumentException, aby zgłosić błąd, jeśli użytkownik próbuje zmienić status na ten sam,
co obecny.
*/

// Odkomentuj poniższy kod aby zobaczyć rozwiązanie zadania 2

//using Lab05.zadanie2;
//using System;
//using System.Collections.Generic;

//class Program
//{

//    static void Main()
//    {
//        MenedzerZamowien menedzer = new MenedzerZamowien();

//        menedzer.DodajZamowienie(1,
//            new List<string> { "Laptop", "Mysz" });

//        menedzer.DodajZamowienie(2,
//            new List<string> { "Telefon" });

//        menedzer.WyswietlZamowienia();

//        try
//        {
//            menedzer.ZmienStatus(1, StatusZamowienia.Przyjete);
//            menedzer.ZmienStatus(2, StatusZamowienia.Przyjete); // wyjątek
//        }
//        catch (Exception e)
//        {
//            Console.WriteLine("Błąd: " + e.Message);
//        }

//        Console.WriteLine("\nPo zmianach:\n");
//        menedzer.WyswietlZamowienia();

//        Console.ReadKey();
//    }
//}


// ======================================================================
/*
Zadanie 3: Gra w zgadywanie kolorów
Stwórz grę, w której użytkownik zgaduje losowo wybrany kolor z listy dostępnych kolorów. Wykorzystaj
typ wyliczeniowy (enum) do reprezentowania kolorów oraz kolekcję List<T> do przechowywania
wszystkich dostępnych kolorów. Obsłuż wyjątki, jeśli użytkownik wpisze nieprawidłowy kolor.
Wymagania:
• Użyj typu wyliczeniowego Kolor z wartościami: Czerwony, Niebieski, Zielony, Żółty, Fioletowy.
• Losowo wybierz kolor z kolekcji List<Kolor>.
• Obsłuż wyjątek ArgumentException, gdy użytkownik wpisze kolor, który nie znajduje się na
liście.
• Dodaj możliwość ponownego zgadywania, aż użytkownik odgadnie prawidłowy kolor.
*/

// Odkomentuj poniższy kod aby zobaczyć rozwiązanie zadania 3

//using Lab05.zadanie3;

//class Program
//{
//    static void Main()
//    {
//        GraKolory gra = new GraKolory();
//        gra.Start();
//    }
//}