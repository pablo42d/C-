//using System;
//using System.Collections.Generic;
//using System.Data;
//using System.Linq;
//using System.Web;

//namespace SystemTelefonicznyGY.Models
//{
//    // Wspólna klasa dla bilingu komórkowego i stacjonarnego
//    public class Biling
//    {
//        public DateTime DataPolaczenia { get; set; }
//        public string NumerTelefonu { get; set; }
//        public string Pracownik { get; set; }
//        public string Manager { get; set; }
//        public string Dzial { get; set; }
//        public string Typ { get; set; }
//        public decimal Netto { get; set; }
//        public decimal Brutto { get; set; }
//        public string NrFaktury { get; set; }
//    }

//    // ViewModel dla widoku raportów
//    public class RaportViewModel
//    {
//        public List<Biling> Komorkowe { get; set; } = new List<Biling>();
//        public List<Biling> Stacjonarne { get; set; } = new List<Biling>();

//        // Filtry do zachowania w formularzu
//        public int WybranyMiesiac { get; set; }
//        public int WybranyRok { get; set; }
//        public string Fraza { get; set; }

//        //public DateTime? Od { get; set; }
//        //public DateTime? DoDaty { get; set; }
//    }

   

//}




   

    //public class Biling
    //{
    //    public int ID { get; set; }
    //    public DateTime DataPolaczenia { get; set; }
    //    public string NumerTelefonu { get; set; }
    //    public string NumerWybierany { get; set; }
    //    public string TypPolaczenia { get; set; }
    //    public string CzasTrwania { get; set; } // Można użyć string lub TimeSpan zależnie od formatu
    //    public decimal KwotaNetto { get; set; }
    //    public decimal KwotaBrutto { get; set; }
    //    public string NrFaktury { get; set; }

    //    // Pola dodatkowe uzyskane z JOINów w SQL
    //    public string Pracownik { get; set; }
    //    public string MenagerName { get; set; }
    //    public string Dzial { get; set; }
    //    public string TypBilingu { get; set; } // Aby odróżnić "Komórkowy" od "Stacjonarny"
    //    private List<Biling> PobierzBilingiZTablei(string nazwaTabeli, int? miesiac, int? rok, DateTime? od, DateTime? doDaty, string fraza, int? dzialId, string manager)
    //    {
    //        // Tutaj zbudujemy bezpieczne zapytanie SQL
    //        // ..

    //.
    //    }
    //    }
    

//        public class RaportViewModel
//    {
//        // Aktywne filtry (potrzebne do formularza i przycisku eksportu)
//        public int WybranyMiesiac { get; set; }
//        public int WybranyRok { get; set; }
//        public DateTime? DataOd { get; set; }
//        public DateTime? DataDo { get; set; }
//        public string Fraza { get; set; }
//        public int? DzialId { get; set; }
//        public string Manager { get; set; }

//        public List<Biling> Komorkowe { get; set; }
//        public List<Biling> Stacjonarne { get; set; }
//    }

//}