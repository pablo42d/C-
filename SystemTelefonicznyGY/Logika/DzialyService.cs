using System.Data;
using SystemTelefonicznyGY.Models;

namespace SystemTelefonicznyGY.Logika
{
    public class DzialyService
    {
        private readonly BazaDanych _baza = new BazaDanych();

        public DataTable PobierzWszystkieDzialy()
        {
            return _baza.PobierzDane("SELECT * FROM Dzialy ORDER BY NazwaDzialu");
        }

        public DataTable PobierzWszystkieStanowiska()
        {
            return _baza.PobierzDane("SELECT * FROM Stanowiska ORDER BY NazwaStanowiska");
        }

        // Pobiera stanowiska z ID Działu (potrzebne do edycji)
        public DataTable PobierzStanowiskaZDzialem()
        {
            return _baza.PobierzDane("SELECT ID, NazwaStanowiska, ID_Dzialu FROM Stanowiska ORDER BY NazwaStanowiska");
        }

        public void ZapiszDzial(int id, string nazwa, string skrot)
        {
            string sql = id == 0
                ? $"INSERT INTO Dzialy (NazwaDzialu, SkroconaNazwa) VALUES ('{nazwa}', '{skrot}')"
                : $"UPDATE Dzialy SET NazwaDzialu = '{nazwa}', SkroconaNazwa = '{skrot}' WHERE ID = {id}";
            _baza.WykonajPolecenie(sql);
        }

        public void UsunDzial(int id)
        {
            _baza.WykonajPolecenie($"DELETE FROM Dzialy WHERE ID = {id}");
        }

        public void ZapiszStanowisko(int id, string nazwa, int idDzialu)
        {
            string sql = id == 0
               ? $"INSERT INTO Stanowiska (NazwaStanowiska, ID_Dzialu) VALUES ('{nazwa}', {idDzialu})"
               : $"UPDATE Stanowiska SET NazwaStanowiska = '{nazwa}', ID_Dzialu = {idDzialu} WHERE ID = {id}";
            _baza.WykonajPolecenie(sql);
        }

        public void UsunStanowisko(int id)
        {
            _baza.WykonajPolecenie($"DELETE FROM Stanowiska WHERE ID = {id}");
        }
    }
}