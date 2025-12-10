using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Lab04.Cwiczenie1
{
    internal class Internship : IContract
    {
        public decimal StawkaMiesieczna { get; set; }
        public Internship() : this(1000m) { }
        public Internship(decimal stawkaMiesieczna)
        {
            StawkaMiesieczna = stawkaMiesieczna;
        }

        public decimal Salary()
        {
            return StawkaMiesieczna;
        }

        public override string? ToString()
        {
            return $"Umowa: staż " +
                $"Stawka: {StawkaMiesieczna.ToString("C", new CultureInfo("pl-PL"))}";
        }

    }
}
