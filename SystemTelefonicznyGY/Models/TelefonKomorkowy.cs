using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SystemTelefonicznyGY.Models
{
    public class TelefonKomorkowy : Urzadzenie
    {
        // Pola prywatne
        private string _imei;
        private string _numerKartySim;
        private string _pin;
        private string _puk;
        // Właściwości publiczne
        public string Imei { get { return _imei; } set { _imei = value; } }
        public string NumerKartySim { get { return _numerKartySim; } set { _numerKartySim = value; } }
        public string Pin { get { return _pin; } set { _pin = value; } }
        public string Puk { get { return _puk; } set { _puk = value; } }

        public TelefonKomorkowy(int id, string model, string sn, string status, int idPracownika) : base(id, model, sn, status, idPracownika)
        {
            this._imei = Imei;
            this._numerKartySim = NumerKartySim;
            this._pin = Pin;
            this._puk = Puk;

        }
    }
}