using System;
using System.Collections.Generic;
using System.Text;
using Lab03;

namespace Lab03
{
    // ========= Zadanie 1 f. ===========================
    public class Reviewer : Reader
    {
        private Random rnd = new Random();

        public Reviewer(string firstName, string lastName, int age)
            : base(firstName, lastName, age)
        {
        }

        public override string View()
        {
            string result = base.View();
            result += "\nOceny książek:\n";

            // potrzebne: pełna lista książek – używamy ViewBook()
            string[] books = ViewBook().Split('\n');

            foreach (string line in books)
            {
                if (line.StartsWith("- "))
                {
                    int rating = rnd.Next(1, 11); // 1–10
                    result += $"{line} | Ocena: {rating}/10\n";
                }
            }

            return result;
        }
    
    }
}
