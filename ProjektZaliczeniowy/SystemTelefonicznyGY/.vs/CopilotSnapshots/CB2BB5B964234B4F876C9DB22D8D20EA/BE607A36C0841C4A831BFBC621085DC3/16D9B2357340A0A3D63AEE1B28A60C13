using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemTelefonicznyGY.Models;

namespace SystemTelefonicznyGY.Logika.Interfejsy
{
    internal interface IZasobyService
    {
        DataTable PobierzUrzadzenia(string szukanaFraza);
        DataRow PobierzUrzadzeniePoId(int id);
        void ZapiszUrzadzenie(int id, string aparat, string model, string imeiMac, string sn, string nrInwentarzowy, string status, int? idPracownika);
        void WycofajUrzadzenie(int id);
        DataTable PobierzNumeryKomorkowe(string szukanaFraza);
        DataRow PobierzNumerKomorkowyPoId(int id);
        void ZapiszNumerKomorkowy(int id, string numer, string numerKarty, string pin, string puk, string planOpis, string status, int? idPracownika);
        void DezaktywujNumerKomorkowy(int id);
        DataTable PobierzNumeryStacjonarne(string szukanaFraza);
        DataRow PobierzNumerStacjonarnyPoId(int id);
        void ZapiszNumerStacjonarny(int id, string numer, string liniaTyp, int? idPracownika, string prefiksKraj, string prefiksMiasto, string opis, string statusCor);
        List<Urzadzenie> PobierzUrzadzeniaPracownika(int idPracownika);
    }
}
