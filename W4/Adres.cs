using System;
using System.Collections.Generic;
using System.Text;

namespace W4
{
    internal class Adres
    {
        public string Miejscowosc { get; set; }
        public string NumerDomu { get; set; }
        public int KodPocztowy { get; set; }

        public Adres()
        {
            Miejscowosc = "Rzeszów";
            NumerDomu = "163";
            KodPocztowy = 39-200;
        }
    }
}
