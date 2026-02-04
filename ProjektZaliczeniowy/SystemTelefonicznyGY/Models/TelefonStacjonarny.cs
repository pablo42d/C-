using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SystemTelefonicznyGY.Models
{
    public class TelefonStacjonarny : Urzadzenie
    {

        private string _macAdres;
        private string _liniaTyp;
        //public string MacAdres { get { return _macAdres; } }
        //public string LiniaTyp { get { return _liniaTyp; } }
        public TelefonStacjonarny(int id, string model, string sn, string status, int idPracownika, string macAdres, string liniaTyp) : base(id, model, sn, status, idPracownika)
        {
            this._macAdres = macAdres;
            this._liniaTyp = liniaTyp;
        }

    }
}