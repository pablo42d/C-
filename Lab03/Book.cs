using System;
using System.Collections.Generic;
using System.Text;
using Lab03;

namespace Lab03
{
    // ========= Zadanie 1 a. ===========================
    // Book z polami: title, author (typu Person), data wydania oraz metodą View

    public class Book
    {
        protected string title;
        protected Person author;
        protected int year;

        public string Title { get => title; }
        public Person Author { get => author; }
        public int Year { get => year; }

        public Book(string title, Person author, int year)
        {
            this.title = title;
            this.author = author;
            this.year = year;
        }

        public virtual string View()
        {
            return $"\"{Title}\", {Author.FirstName} {Author.LastName}, rok: {Year}";
        }
    }
}
