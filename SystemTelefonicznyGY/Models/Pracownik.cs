using System;
using System.Collections.Generic;
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

        // Właściwości publiczne do odczytu i zapisu
        public int Id { get { return _id; } }
        public string Imie { get { return _imie; } }
        public string Nazwisko { get { return _nazwisko; } }
        public string PelneNazwisko { get { return $"{_imie} {_nazwisko}"; } }
        public string Rola { get { return _rola; } }
        public int IdDzialu { get { return _idDzialu; } }

        public Pracownik(int id, string imie, string nazwisko, string rola, int idDzialu)
        {
            _id = id;
            _imie = imie;
            _nazwisko = nazwisko;
            _rola = rola;
            _idDzialu = idDzialu;
        }
    }
}