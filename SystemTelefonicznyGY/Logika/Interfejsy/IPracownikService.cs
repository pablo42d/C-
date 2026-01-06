using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using SystemTelefonicznyGY.Models;

namespace SystemTelefonicznyGY.Logika.Interfejsy
{
    public interface IPracownikService
    {
        DataRow Zaloguj(string login, string haslo);
        bool WeryfikujHaslo(int idPracownika, string stareHaslo);
        void ZmienHaslo(int idPracownika, string noweHaslo);
        List<Pracownik> PobierzListęPracownikow(string szukanaFraza = "");
        DataTable PobierzPracownikowDoDropdown();
        void ZapiszPracownika(int id, string imie, string nazwisko, string login, int idDzialu, string rola, int idStanowiska, string haslo);
        void UsunPracownika(int id);
        Pracownik PobierzPracownikaPoId(int id);
    }
}
