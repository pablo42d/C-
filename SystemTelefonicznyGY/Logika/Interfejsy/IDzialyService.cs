using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemTelefonicznyGY.Logika.Interfejsy
{
    public interface IDzialyService
    {
        DataTable PobierzWszystkieDzialy();
        DataTable PobierzWszystkieStanowiska();
        DataTable PobierzStanowiskaZDzialem();
        void ZapiszDzial(int id, string nazwa, string skrot);
        void UsunDzial(int id);
        void ZapiszStanowisko(int id, string nazwa, int idDzialu);
        void UsunStanowisko(int id);
    }
}
