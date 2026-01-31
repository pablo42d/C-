using System;
using System.Collections.Generic;
using System.Text;
using Sklep;

namespace Sklep
{
    abstract class Produkty
    {
        public string Nazwa { get; set; }
        public decimal CenaBazowa { get; set; }

        public Produkty(string nazwa, decimal cena)
        {
            Nazwa = nazwa;
            CenaBazowa = cena;
        }
        public abstract decimal ObliczCene();
        public override string ToString()
        {
            return $"{Nazwa} - Cena bazowa: {ObliczCene()} zł";
        }
    }
}
