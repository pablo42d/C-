using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace SystemTelefonicznyGY.Models
{
    public class Pracownik
    {
        private int _id;
        private string _imie;
        private string _nazwisko;
        private string _rola;
        private int _idDzialu;
        private string _login;
        private string _stanowisko;

        // Właściwości publiczne do odczytu i zapisu
        public int Id { get { return _id; } }
        public string Imie { get { return _imie; } }
        public string Nazwisko { get { return _nazwisko; } }
        public string PelneNazwisko { get { return $"{_imie} {_nazwisko}"; } }
        public string Rola { get { return _rola; } }
        public int IdDzialu { get { return _idDzialu; } }      
        public string Login { get { return _login; } }
        public string Stanowisko { get { return _stanowisko; } }


        public Pracownik(int id, string imie, string nazwisko, string rola, int idDzialu, string login, string stanowisko)
        {
            _id = id;
            _imie = imie;
            _nazwisko = nazwisko;
            _rola = rola;
            _idDzialu = idDzialu;           
            _login = login;
            _stanowisko = stanowisko;
        }

        //public class PodsumowaniePracownikaModel
        //{
        //    public List<Urzadzenie> MojeUrzadzenia { get; set; } = new List<Urzadzenie>();
        //    public List<DataRow> BilingiKomorkowe { get; set; } = new List<DataRow>();
        //    public List<DataRow> BilingiStacjonarne { get; set; } = new List<DataRow>();
        //    public decimal SumaKomorkowe { get; set; } = 0;
        //    public decimal SumaStacjonarne { get; set; } = 0;
        //}

    }
}