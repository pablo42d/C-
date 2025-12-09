using System;
using System.Collections.Generic;
using System.Text;
using Lab03;

namespace Lab03
{
    internal class DocumentaryBook : Book
    {
        protected string Topic { get; set; }

        public DocumentaryBook(string title, Person author, int year, string topic) : base(title, author, year)
        {
            this.Topic = topic;
        }
        public override string View()
        {
            return base.View() + $", Temat: {Topic}";
            //return $"\"{Title}\", {Author.FirstName} {Author.LastName}, rok: {Year}, topic: {topic}";
        }
    }
}
