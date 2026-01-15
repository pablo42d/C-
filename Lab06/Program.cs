//string content = File.ReadAllText("dane.txt");
//Console.WriteLine(content);

//string[] lines = File.ReadLines(content);

//StreamReader // duże dane 
//File.WriteAllText // adpisanie danych
////joson i seriolizacja  danych to string string na text i text na string
//string joson = JsonSerializer.Serialize(lines);
//// 5 kroków 

/* 
  Zadanie 1. Zaprojektuj system do zarządzania kontaktami (Id, Name, Email), który będzie posiadać
następującą strukturę:
• Program.cs – menu + obsługa opcji
• Contact.cs – model danych
• TxtContactRepository.cs – zapis/odczyt TXT (CSV)
• JsonContactRepository.cs – zapis/odczyt JSON
Zakładamy, że plik txt oraz json zawiera dane w postaci:
• Txt: 1;Jan Kowalski;jan@x.pl
• JSON:
[
 {
 "Id": 1,
 "Name": "Jan Kowalski",
 "Email": "jan@x.pl"
 }
]

 */

using System;
using Lab06.zadanie1;

class Program
{
    static void Main()
    {
        var repo = new TxtContactRepository("contacts.txt");

        while (true)
        {
            Console.WriteLine("1. Pokaż kontakty");
            Console.WriteLine("2. Dodaj kontakt");
            Console.WriteLine("0. Wyjście");

            var choice = Console.ReadLine();

            if (choice == "1")
                ShowAll(repo);
            else if (choice == "2")
                Add(repo);
            else if (choice == "0")
                break;
        }
    }

    static void ShowAll(TxtContactRepository repo)
    {
        var contacts = repo.GetAll();

        if (contacts.Count == 0)
        {
            Console.WriteLine("Brak kontaktów");
            return;
        }

        foreach (var c in contacts)
            Console.WriteLine($"{c.Id} | {c.Name} | {c.Email}");
    }

    static void Add(TxtContactRepository repo)
    {
        var c = ReadContactFromUser(true);
        repo.Add(c);
        Console.WriteLine("Dodano dane");
    }

    static Contact ReadContactFromUser(bool requireID)
    {
        int id = 0;

        if (requireID)
        {
            Console.Write("Id: ");
            int.TryParse(Console.ReadLine(), out id);
        }

        Console.Write("Imię i nazwisko: ");
        string name = Console.ReadLine() ?? "";

        Console.Write("Email: ");
        string email = Console.ReadLine() ?? "";

        return new Contact
        {
            Id = id,
            Name = name,
            Email = email
        };
    }
}

/*
 *  Zastosowano model Contact, repozytorium TXT oraz JSON.
    Dane w TXT są zapisywane w formacie CSV, a JSON przy użyciu System.Text.Json.
    Program zawiera menu i obsługę wejścia użytkownika.
 */


// ==================================================================
/*
 Zadanie 2. Wykorzystując bazę danych „db.json”, zawierającą informację o populacji USA, Indii i Chin od roku
1960, napisz program:
• Pozwalający sprawdzić ile wynosi różnica populacji pomiędzy rokiem 1970 a 2000 dla Indii
• Pozwalający sprawdzić ile wynosi różnica populacji pomiędzy rokiem 1965 a 2010 dla USA
• Pozwalający sprawdzić ile wynosi różnica populacji pomiędzy rokiem 1980 a 2018 dla Chin
• Pozwalający użytkownikowi na wybranie roku i kraju, z którego populację chciałby wyświetlić.
• Pozwalający użytkownikowi na sprawdzenie różnicy populacji dla wskazanego zakresu lat i
kraju,
• Pozwalający użytkownikowi na sprawdzenie procentowego wzrostu populacji dla każdego kraju
względem roku poprzedniego do wskazanego,
 */
