// Dziedziczenie i polimorfizm w C#

using Lab03;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Xml.Linq;

/*
// ========= 1 ===========================
//Person myObj = new Person();
//myObj.Name = "Jan";
//Console.WriteLine(myObj.Name);

// ========= 2 Dziedziczenie ===========================
//utworzenie obiektu Person
Person person = new Person("Jan", "Nowak");
Console.WriteLine("Osoba: " + person.ToString());
//utworzenie obiektu Student
Student student = new Student("Jan", "Nowak", 12345);
Console.WriteLine("Student: " + student.ToString());
// ============================
*/

// ========= Zadanie 1 a. ===========================
/*
Zadanie 1 a.
Stwórz klasy:
• Person z polami: FirstName, LastName, wiek, konstruktorem inicjującym wszystkie pola oraz
metodą View.
• Book z polami: title, author (typu Person), data wydania oraz metodą View.
Utwórz różne obiekty stworzonych klas. Wykonaj metody View.
*/
//Person person = new Person("Jan", "Kowalski", 25);
//person.View();

// ========= Zadanie 1 b. ===========================
/*
 * Stwórz klasę Reader, dziedziczącą z klasy Person. Dodatkowo klasa Reader powinna posiadać pole –
listę / tablicę obiektów typu Book - listę książek przeczytanych przez danego czytelnika oraz metodę
ViewBook - wypisujące tytuły książek, które czytelnik przeczytał.
Stwórz 3-5 książek, 2-4 czytelników, przypisz książki do tablic / list przeczytanych książek czytelników,
wykonaj metody ViewBook
*/
//// Autorzy
//Person p1 = new Person("Adam", "Mickiewicz", 55);
//Person p2 = new Person("Andrzej", "Sapkowski", 70);

//// Tworzenie książek
//Book b1 = new Book("Hobbit", p1, 1937);
//Book b2 = new Book("Wiedźmin", p2, 1993);
//Book b3 = new Book("Dziady", p1, 1823);
//Book b4 = new Book("Historia Polski", p1, 1999);
////Reader.Book book = new Reader.Book("Sample Book"); // Przykład tworzenia obiektu Book z klasy zagnieżdżonej

//// Tworzenie czytelników
//Reader r1 = new Reader("Adam", "Kowelski", 32);
//Reader r2 = new Reader("Ewa", "Bączek", 43);
//Person p3 = new Person("Jan", "Kowalski", 30);


//// Przypisywanie przeczytanych książek
//r1.AddBook(b1);
//r1.AddBook(b3);
//r2.AddBook(b2);
//r2.AddBook(b4);
//r2.AddBook(b1);
////p1.AddBook(b3); // To powinno wywołać błąd, ponieważ Person nie ma metody AddBook


//// Wywołanie metody ViewBook
//r1.ViewBook();
//r2.ViewBook();

// Wyświetlanie (teraz metoda zwraca string)
//Console.WriteLine(r1.ViewBook());
//Console.WriteLine(r2.ViewBook());

// ========= Zadanie 1 d. ===========================
/*
 *Metody View() w klasach Person i Reader poprzedź odpowiednimi słowami kluczowymi, aby wykonanie
kodu:
Person o = new Reader (...);
o.VIew();
spowodowało wyoknanie metody View () z klasy Reader 
 */
/*
Person o = new Reader("Paweł", "Dudek", 28);    // Utworzenie obiektu Reader, ale przypisanie go do zmiennej typu Person
Console.WriteLine(o.View1d());  // Wywołanie metody View1d(), która powinna wykonać metodę z klasy Reader dzięki polimorfizmowi
// Utworzenie obiektu Person, ale przypisanie go do zmiennej typu Reader
Person person1 = new Reader("Anna", "Nowak", 35);
Reader o1 = (Reader)person1;  // Rzutowanie na typ Reader
o1.AddBook(b1);
Console.WriteLine(o1.View1d());  // Wywołanie metody View1
Console.WriteLine(o1.ViewBook());  // Wywołanie metody ViewBook z klasy Reader
*/
// ============ Zadanie 1 g============================
/*
 *
partial class Program
{
    static void Main(string[] args)
    {
        // Autorzy
        Person p1 = new Person("Adam", "Mickiewicz", 55);
        Person p2 = new Person("Andrzej", "Sapkowski", 70);

        // Książki
        Book b1 = new Book("Dziady", p1, 1823);
        Book b2 = new AdventureBook("Wiedźmin", p2, 1993, "Kontynent");
        Book b3 = new DocumentaryBook("Historia Polski", p1, 1999, "Polska");
        Book b4 = new AdventureBook("Hobbit", p1, 1937, "Śródziemie");

        // Czytelnicy
        Reader r1 = new Reader("Kasia", "Nowak", 22);
        Reader r2 = new Reader("Marek", "Wiśniewski", 30);

        r1.AddBook(b1);
        r1.AddBook(b2);

        r2.AddBook(b3);

        // Recenzenci
        Reviewer rv1 = new Reviewer("Tomek", "Kowal", 40);
        Reviewer rv2 = new Reviewer("Ewa", "Lis", 28);

        rv1.AddBook(b1);
        rv1.AddBook(b4);

        rv2.AddBook(b2);
        rv2.AddBook(b3);

        // Lista Person
        List<Person> people = new List<Person>()
        {
            r1, r2, rv1, rv2
        };

        foreach (var person in people)
        {
            Console.WriteLine(person.View());
            Console.WriteLine("-----------------------");
        }
    }
}
*/

// ================================================ Zadanie 1 g end ===========================

// ================================================ Zadanie 2 ===========================

/*Napisz program, w którym będą dwie klasy: Samochod i SamochodOsobowy. W klasach tych powinny
znajdować się następujące pola:
• Samochod: Marka, Model, Nadwozie, Kolor, Rok produkcji, Przebieg (nie może być ujemny)
• SamochodOsobowy: Waga (powinna być z przedziału 2 t – 4,5 t), Pojemność silnika (powinna
być z przedziału 0,8-3,0), Ilość osób
Klasa SamochodOsobowy dziedziczy po klasie Samochod. W obydwu klasach utwórz konstruktor, który
pobierze dane od użytkownika. Dodatkowo w klasie Samochod przeciąż konstruktor w taki sposób, by
wartości pól były parametrami metody. W klasie Samochod utwórz także metodę, która wyświetli
informacje o samochodzie. Przesłoń ją w klasie SamochodOsobowy. W metodzie Main() utwórz obiekt
klasy SamochodOsobowy oraz dwa obiekty klasy Samochod (wykorzystując różne konstruktory).
Wyświetl informacje o samochodach.
*/

/*
// utwórz obiekt klasy SamochodOsobow
SamochodOsobowy osobowy = new SamochodOsobowy();
osobowy.Marka = "Toyota";
osobowy.Model = "Corolla";
osobowy.Nadwozie = "Sedan";
osobowy.Kolor = "Czerwony";
osobowy.RokProdukcji = 2020;
osobowy.Przebieg = 15000;
osobowy.Waga = 3.0;
osobowy.PojemnoscSilnika = 1.8;
osobowy.IloscOsob = 5;
Console.WriteLine("Informacje o samochodzie osobowym:");
osobowy.WyswietlInformacje();
Console.WriteLine("-----------------------");

// dwa obiekty klasy Samochod (wykorzystując różne konstruktory)
Samochod samochod1 = new Samochod("Ford", "Focus", "Hatchback", "Niebieski", 2018, 30000);

Console.WriteLine("Informacje o samochodzie 1:");
samochod1.WyswietlInformacje();
Console.WriteLine("-----------------------");
Samochod samochod2 = new Samochod();
Console.WriteLine("Informacje o samochodzie 2:");
samochod2.WyswietlInformacje();
*/

// W metodzie Main() tworzymy obiekt klasy SamochodOsobowy oraz dwa obiekty klasy Samochod (wykorzystując różne konstruktory) i wyświetlamy informacje o samochodach.

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("=== Tworzenie samochodu osobowego ===");
        SamochodOsobowy os1 = new SamochodOsobowy();

        Console.WriteLine("\n=== Tworzenie samochodów (różne konstruktory) ===");

        Samochod s1 = new Samochod();   // konstruktor od użytkownika

        Samochod s2 = new Samochod(
            "Toyota",
            "Corolla",
            "Sedan",
            "Srebrny",
            2018,
            45000
        ); // konstruktor parametrowy

        Console.WriteLine("\n=== Dane samochodów ===");
        os1.WyswietlInformacje();
        s1.WyswietlInformacje();
        s2.WyswietlInformacje();
       
    }
}

// ================================================ Zadanie 2 end ===========================

