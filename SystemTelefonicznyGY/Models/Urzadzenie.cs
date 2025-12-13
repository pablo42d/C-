using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SystemTelefonicznyGY.Models
{
    public class Urzadzenie : ElementSystemu
    {
        private string _model;
        private string _sn;
        private string _status;
        private int _idPracownika;

        public string Model { get { return _model; } set { _model = value; } }
        public string SN { get { return _sn; } }
        public string Status { get { return _status; } set { _status = value; } }
        public int IdPracownika { get { return _idPracownika; } }

        /// <summary>
        /// Inicjalizuje nową instancję klasy Urzadzenie z podanymi wartościami. 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="model"></param>
        /// <param name="sn"></param>
        /// <param name="status"></param>
        /// <param name="idPracownika"></param>
        public Urzadzenie(int id, string model, string sn, string status, int idPracownika) : base(id)
        {
            _model = model;
            _sn = sn;
            _status = status;
            _idPracownika = idPracownika;
        }

    }
}