using System;
using System.Collections.Generic;
using System.Text;
using Sklep;

namespace Sklep
{
    internal class Spozywczy : Produkty
    {
        public Spozywczy(string nazwa, decimal cena) : base(nazwa, cena) { }
        public override decimal ObliczCene()
        {
            // podatek 8%
            return CenaBazowa * 1.08m;
        }
    }
    
}
