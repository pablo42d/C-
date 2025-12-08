// Dziedziczenie i polimorfizm w C#

using Lab03;
using System;
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
