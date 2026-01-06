using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SystemTelefonicznyGY.Models
{
    public class Modem : Urzadzenie
    {
        // Specyficzne pole dla Modemu (np. adres IP lub technologia LTE/5G)
        private string _adresIp;
        private string _technologia; // np. "5G", "LTE"

        public string AdresIp { get { return _adresIp; } set { _adresIp = value; } }
        public string Technologia { get { return _technologia; } set { _technologia = value; } }

        public Modem(int id, string model, string sn, string status, int idPracownika, string adresIp, string technologia)
            : base(id, model, sn, status, idPracownika)
        {
            _adresIp = adresIp;
            _technologia = technologia;
        }
    }
}