using Lab03;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lab03
{
    // klasa AdventureBook dziedzicząca po klasie Book dodajeąca pole region oraz nadpisująca metodę View
    internal class AdventureBook : Book
    {
        // pole region
        protected string Region{get; set; }

        // właściwość Region
        public AdventureBook(string title, Person author, int year, string region) : base(title, author, year)
        {
            this.Region = region;
        }
        // add region to Book view
        //public string Region
        //    {
        //    get { return region; }
        //    set { region = value; }
        //}
        public override string View()
        {
            return base.View() + $", Region: {Region}";
            //return $"\"{Title}\", {Author.FirstName} {Author.LastName}, rok: {Year}, region: {region}";
        }
    }
}
