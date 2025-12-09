// Dziedziczenie i polimorfizm w C#

using Lab03;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Xml.Linq;

namespace Lab03
{
    public class Reader : Person
    {

        //========= Zadanie 1 b. ===========================
        // klasa Book
        //public class Book
        //{
        //    // pole tytułu książki
        //    public string Title { get; set; }
        //    // konstruktor klasy Book
        //    public Book(string title)
        //    {
        //        Title = title;
        //    }
        //}

        // lista przeczytanych książek
        //private List<Book> ReadBooks {get; set; }
        private List<Book> ReadBooks = new List<Book>();

        // konstruktor klasy Reader
        public Reader(string firstName, string lastName, int age) : base(firstName, lastName, age)
        {
            
            // inicjalizacja listy przeczytanych książek           
            //ReadBooks = new List<Book>();
        }

        // metoda do dodawania książek do listy przeczytanych książek
        public void AddBook(Book book)
        {
            ReadBooks.Add(book);
        }

        // metoda ViewBook - wypisująca tytuły książek, które czytelnik przeczytał
        //public string ViewBook()
        //{

        //    if (ReadBooks.Count == 0)
        //        return $"{this.FirstName} {this.LastName} nie przeczytał żadnych książek.";

        //    string result = $"Książki przeczytane przez {this.FirstName} {this.LastName}:\n";

        //    foreach (var book in ReadBooks)
        //    {
        //        result += $"- {book.Title}\n";
        //    }

        //    return result;

            //Console.WriteLine("Books read by " + {this.FirstName} {this.LastName} + ":");
            //foreach (var book in ReadBooks)
            //{
            //    Console.WriteLine("- " + book.Title);
            //}
        //}

        // lub inna metoda wyświetlająca
        public string ViewBook()
        {
            if (ReadBooks.Count == 0) return "Brak przeczytanych książek.";

            string result = "";
            foreach (var book in ReadBooks)
            {
                result += "- " + book.View() + "\n";
            }
            return result;
        }

        public override string View()
        {
            return base.View() + "\nPrzeczytane książki:\n" + ViewBook();
        }

        // ========== zadanie 1 d. ===========================


        //public override string View1d()
        //{
        //    return $"Czytelnik: {this.FirstName} {this.LastName}:\n";
        //}

    }
}
