using System;
using System.Collections.Generic;
using System.Text;
using Sklep;

namespace Sklep
{
    internal class Elektronika:Produkty
    {
        public Elektronika(string nazwa, decimal cena) : base(nazwa, cena) { }
        
        public override decimal ObliczCene()
        {
            // podatek 23%
            return CenaBazowa * 1.23m;
        }
    }
}
