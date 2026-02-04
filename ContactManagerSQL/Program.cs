
using ContactManagerSQL.Data;
using ContactManagerSQL.Models;
using System;
using System.Collections.Generic;

class Program
{
    // =========================
    // 1) CONNECTION STRING
    // =========================
    //[cite_start]// Ustawienie parametrów połączenia z bazą danych 
    //const string ConnectionString = @"Data Source=DESKTOP-COV87SH\SQLEXPRESS;Initial Catalog=ContactDB;Integrated Security=True";
    const string ConnectionString = @"Data Source=DESKTOP-COV87SH\SQLEXPRESS;Initial Catalog=ContactDB;Integrated Security=True;Encrypt=False;TrustServerCertificate=True";

    static void Main()
    {
        //[cite_start]// Inicjalizacja repozytorium warstwy dostępu do danych (DAL) 
        ContactRepository repo = new ContactRepository(ConnectionString);

        while (true)
        {
            PrintMenu();
            string choice = Console.ReadLine() ?? "";
            try
            {
                switch (choice)
                {
                    case "1":
                        Create(repo); // Dodawanie kontaktu 
                        break;
                    case "2":
                        ReadAll(repo); // Wyświetlanie wszystkich 
                        break;
                    case "3":
                        Search(repo); // Wyszukiwanie po nazwisku 
                        break;
                    case "4":
                        Update(repo); // Edycja kontaktu 
                        break;
                    case "5":
                        Delete(repo); // Usuwanie kontaktu 
                        break;
                    case "6":
                        BulkInsertDemo(repo); // Masowe dodawanie 
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Nieprawidłowy wybór.");
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Wystąpił błąd: " + ex.Message); // Logowanie wyjątków do konsoli 
            }
        }
    }

    static void PrintMenu()
    {
        //[cite_start]// Interfejs użytkownika w warstwie prezentacji 
        Console.WriteLine("\n=== CONTACT MANAGER (ADO.NET + DAL) ===");
        Console.WriteLine("1) Dodaj kontakt");
        Console.WriteLine("2) Pokaż wszystkie");
        Console.WriteLine("3) Wyszukaj po nazwisku");
        Console.WriteLine("4) Edytuj kontakt");
        Console.WriteLine("5) Usuń kontakt");
        Console.WriteLine("6) Bulk insert (transakcja) - demo");
        Console.WriteLine("0) Wyjście");
        Console.Write("Wybór: ");
    }

    // =========================
    // CREATE
    // =========================
    static void Create(ContactRepository repo)
    {
        //[cite_start]// Pobieranie danych od użytkownika przy użyciu helperów
        var c = new Contact
        {
            FirstName = ReadRequired("Imię: "),
            LastName = ReadRequired("Nazwisko: "),
            Phone = ReadOptional("Telefon (opcjonalnie): "),
            Email = ReadOptional("Email (opcjonalnie): ")
        };

        int id = repo.Add(c); // Wywołanie metody z repozytorium
        Console.WriteLine($"Dodano pomyślnie! ID nowego kontaktu: {id}");
    }

    // =========================
    // READ
    // =========================
    static void ReadAll(ContactRepository repo)
    {
        //[cite_start]// Pobranie listy modeli z DAL
        List<Contact> contacts = repo.GetAll();
        Console.WriteLine("\nID | Imię | Nazwisko | Telefon | Email");
        Console.WriteLine("---------------------------------------");
        foreach (var c in contacts)
        {
            Console.WriteLine(c.ToString()); // Wykorzystanie nadpisanej metody ToString() modelu
        }
    }

    // =========================
    // SEARCH BY LAST NAME
    // =========================
    static void Search(ContactRepository repo)
    {
        string fragment = ReadRequired("Podaj fragment nazwiska do wyszukania: ");
        List<Contact> results = repo.SearchByLastName(fragment); // Wyszukiwanie LIKE

        Console.WriteLine($"\nZnaleziono rekordów: {results.Count}");
        foreach (var c in results)
        {
            Console.WriteLine(c.ToString());
        }
    }

    // =========================
    // UPDATE
    // =========================
    static void Update(ContactRepository repo)
    {
        int id = ReadInt("Podaj ID kontaktu do edycji: ");

        var c = new Contact
        {
            Id = id,
            FirstName = ReadRequired("Nowe Imię: "),
            LastName = ReadRequired("Nowe Nazwisko: "),
            Phone = ReadOptional("Nowy Telefon: "),
            Email = ReadOptional("Nowy Email: ")
        };

        bool success = repo.Update(c); // Aktualizacja w bazie
        Console.WriteLine(success ? "Zaktualizowano dane." : "Nie znaleziono kontaktu o podanym ID.");
    }

    // =========================
    // DELETE
    // =========================
    static void Delete(ContactRepository repo)
    {
        int id = ReadInt("Podaj ID kontaktu do usunięcia: ");
        bool success = repo.Delete(id); // Usuwanie po ID
        Console.WriteLine(success ? "Kontakt został usunięty." : "Błąd: Nie znaleziono kontaktu o takim ID.");
    }

    // =========================
    // TRANSACTION (BULK INSERT)
    // ========================= 
    static void BulkInsertDemo(ContactRepository repo)
    {
        //[cite_start]// Demonstracja transakcji bazodanowej
        int count = ReadInt("Ile rekordów wygenerować testowo? ");
        List<Contact> testContacts = new List<Contact>();

        for (int i = 1; i <= count; i++)
        {
            testContacts.Add(new Contact
            {
                FirstName = "Test" + i,
                LastName = "BulkUser" + i,
                Phone = "000-000-" + i,
                Email = $"test{i}@example.com"
            });
        }

        int inserted = repo.BulkInsert(testContacts); // Masowe wstawianie w ramach transakcji
        Console.WriteLine($"Pomyślnie dodano {inserted} rekordów w jednej transakcji.");
    }
    // ========================= Wczytanie z pliku CSV (opcjonalnie) import.csv(dane oddzielone przecinkami) =========================
    //static void BulkInsertDemo(ContactRepository repo)
    //{
    //    string sciezkaPliku = "import.csv"; // Plik w folderze bin/Debug

    //    if (!File.Exists(sciezkaPliku))
    //    {
    //        Console.WriteLine("Błąd: Nie znaleziono pliku import.csv!");
    //        return;
    //    }

    //    List<Contact> kontaktyZPliku = new List<Contact>();
    //    string[] linie = File.ReadAllLines(sciezkaPliku); // Czytamy cały plik

    //    foreach (string linia in linie)
    //    {
    //        string[] dane = linia.Split(','); // Dzielimy linię tam, gdzie jest przecinek
    //        if (dane.Length >= 2) // Minimum to imię i nazwisko
    //        {
    //            kontaktyZPliku.Add(new Contact
    //            {
    //                FirstName = dane[0],
    //                LastName = dane[1],
    //                Phone = dane.Length > 2 ? dane[2] : null,
    //                Email = dane.Length > 3 ? dane[3] : null
    //            });
    //        }
    //    }

    //    int ileDodano = repo.BulkInsert(kontaktyZPliku);
    //    Console.WriteLine($"Pomyślnie załadowano z pliku i dodano do bazy: {ileDodano} rekordów.");
    //}

    // ==========================================================
    // HELPERS - Metody pomocnicze do walidacji wejścia
    // ==========================================================
    static string ReadRequired(string label)
    {
        while (true)
        {
            Console.Write(label);
            string s = Console.ReadLine() ?? "";
            if (!string.IsNullOrWhiteSpace(s)) return s.Trim();
            Console.WriteLine("Pole nie może być puste."); // Zapewnia brak wartości null tam, gdzie są wymagane
        }
    }

    static string? ReadOptional(string label)
    {
        Console.Write(label);
        string s = Console.ReadLine() ?? "";
        s = s.Trim();
        return string.IsNullOrWhiteSpace(s) ? null : s; // Obsługa wartości opcjonalnych (NULL w bazie)
    }

    static int ReadInt(string label)
    {
        while (true)
        {
            Console.Write(label);
            if (int.TryParse(Console.ReadLine(), out int id)) return id; // Zabezpieczenie przed wpisaniem tekstu zamiast liczby
            Console.WriteLine("Podaj poprawną liczbę całkowitą.");
        }
    }
}
