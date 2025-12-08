// Dziedziczenie i polimorfizm w C#

using Lab03;
using System;
using static Lab03.Reader;
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
Person person = new Person("Jan", "Kowalski", 25);
person.View();

// ========= Zadanie 1 b. ===========================
/*
 * Stwórz klasę Reader, dziedziczącą z klasy Person. Dodatkowo klasa Reader powinna posiadać pole –
listę / tablicę obiektów typu Book - listę książek przeczytanych przez danego czytelnika oraz metodę
ViewBook - wypisujące tytuły książek, które czytelnik przeczytał.
Stwórz 3-5 książek, 2-4 czytelników, przypisz książki do tablic / list przeczytanych książek czytelników,
wykonaj metody ViewBook
*/
// Tworzenie książek
Book b1 = new Book("Hobbit");
Book b2 = new Book("Wiedźmin");
Book b3 = new Book("Dziady");
Book b4 = new Book("Metro 2033");

// Tworzenie czytelników
Reader r1 = new Reader("Adam", "Kowelski", 32);
Reader r2 = new Reader("Ewa","Bączek", 43);
Person p1 = new Person("Jan", "Kowalski", 30);


// Przypisywanie przeczytanych książek
r1.AddBook(b1);
r1.AddBook(b3);
r2.AddBook(b2);
r2.AddBook(b4);
r2.AddBook(b1);

// Wywołanie metody ViewBook
r1.ViewBook();
r2.ViewBook();

// Wyświetlanie (teraz metoda zwraca string)
Console.WriteLine(r1.ViewBook());
Console.WriteLine(r2.ViewBook());


