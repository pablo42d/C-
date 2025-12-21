using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace SystemTelefonicznyGY.Models
{
    public class Pracownik
    {
        // Pola prywatne 
        private int _id;
        private string _imie;
        private string _nazwisko;
        private string _rola;
        private string _login;
        private int _idStanowiska;
        private int _idDzialu;


        // Właściwości publiczne na początek

        //public int Id { get; set; }
        //public string Imie { get; set; }
        //public string Nazwisko { get; set; }
        //public string PelneNazwisko { get; set; }
        //public string Rola { get; set; }
        //public string Login { get; set; }
        //public int IdStanowiska { get; set; }
        //public int IdDzialu { get; set; }

        public int Id { get { return _id; } }
        public string Imie { get { return _imie; } }
        public string Nazwisko { get { return _nazwisko; } }
        public string PelneNazwisko { get { return $"{_imie} {_nazwisko}"; } }
        public string Rola { get { return _rola; } }
        public string Login { get { return _login; } }
        public int IdStanowiska { get { return _idStanowiska; } }
        public int IdDzialu { get { return _idDzialu; } }


        // --- DODATKOWE WŁAŚCIWOŚCI DLA WIDOKU (GET/SET) ---
        // Te pola wypełnimy danymi z JOIN w kontrolerze
        public string NazwaStanowiska { get; set; }
        public string Dzial { get; set; }
        public string NrStacjonarny { get; set; }
        public string NrKomorkowy { get; set; }
        

        // Konstruktor (zmieniony na 7 parametrów zgodnie z bazą)
        public Pracownik(int id, string imie, string nazwisko, string rola, int idDzialu, string login, int idStanowiska)
        {
            _id = id;
            _imie = imie;
            _nazwisko = nazwisko;
            _rola = rola;
            _idDzialu = idDzialu;
            _login = login;
            _idStanowiska = idStanowiska;
        }
    }


    //public class Pracownik
    //{
    //    private int _id;
    //    private string _imie;
    //    private string _nazwisko;
    //    private string _rola;
    //    private int _idDzialu;
    //    private string _login;
    //    private int _idStanowiska;



    //    // Właściwości publiczne do odczytu i zapisu
    //    public int Id { get { return _id; } }
    //    public string Imie { get { return _imie; } }
    //    public string Nazwisko { get { return _nazwisko; } }
    //    public string PelneNazwisko { get { return $"{_imie} {_nazwisko}"; } }
    //    public string Rola { get { return _rola; } }
    //    public int IdDzialu { get { return _idDzialu; } }      
    //    public string Login { get { return _login; } }
    //    public int IdStanowiska { get { return _idStanowiska; } }
    //    // Pole tekstowe do wyświetlania nazwy w tabeli (opcjonalnie)
    //    public string NazwaStanowiska { get; set; }


    //    public Pracownik(int id, string imie, string nazwisko, string rola, int idDzialu, string login, int idStanowiska)
    //    {
    //        _id = id;
    //        _imie = imie;
    //        _nazwisko = nazwisko;
    //        _rola = rola;
    //        _idDzialu = idDzialu;           
    //        _login = login;
    //        _idStanowiska = idStanowiska;            
    //    }

    //public class PodsumowaniePracownikaModel
    //{
    //    public List<Urzadzenie> MojeUrzadzenia { get; set; } = new List<Urzadzenie>();
    //    public List<DataRow> BilingiKomorkowe { get; set; } = new List<DataRow>();
    //    public List<DataRow> BilingiStacjonarne { get; set; } = new List<DataRow>();
    //    public decimal SumaKomorkowe { get; set; } = 0;
    //    public decimal SumaStacjonarne { get; set; } = 0;
    //}

    //}
}