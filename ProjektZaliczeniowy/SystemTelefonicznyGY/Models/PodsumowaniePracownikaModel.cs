using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SystemTelefonicznyGY.Models
{
    public class PodsumowaniePracownikaModel
    {
        public int IdPracownika { get; set; }
        public List<Urzadzenie> MojeUrzadzenia { get; set; } = new List<Urzadzenie>();
        public List<System.Data.DataRow> BilingiKomorkowe { get; set; } = new List<System.Data.DataRow>();
        public List<System.Data.DataRow> BilingiStacjonarne { get; set; } = new List<System.Data.DataRow>();
        public decimal SumaKomorkowe { get; set; }
        public decimal SumaStacjonarne { get; set; }
    }
}