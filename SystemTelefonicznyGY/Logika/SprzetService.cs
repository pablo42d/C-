using System;
using System.Collections.Generic;
using System.Data;
using SystemTelefonicznyGY.Models;

namespace SystemTelefonicznyGY.Logika
{
    public class SprzetService
    {
        private readonly BazaDanych _baza;
        public SprzetService(BazaDanych baza) { _baza = baza; }

        public DataTable PobierzUrzadzenia(string fraza = null)
        {
            var p = new Dictionary<string, object>();
            // Zachowanie Twojego oryginalnego zapytania z przypisaniem pracownika
            string sql = @"SELECT u.*, p.Imie, p.Nazwisko, (p.Imie + ' ' + p.Nazwisko) AS PrzypisanyPracownik 
                           FROM Urzadzenia u LEFT JOIN Pracownicy p ON u.ID_Pracownika = p.ID";

            if (!string.IsNullOrEmpty(fraza))
            {
                // Dodano NrInwentarzowy zgodnie z Twoim kodem
                sql += " WHERE u.IMEI_MAC LIKE @f OR u.Model LIKE @f OR u.NrInwentarzowy LIKE @f OR p.Nazwisko LIKE @f";
                p.Add("@f", "%" + fraza + "%");
            }
            return _baza.PobierzDane(sql, p);
        }

        public DataRow PobierzUrzadzeniePoId(int id)
        {
            DataTable dt = _baza.PobierzDane("SELECT * FROM Urzadzenia WHERE ID = @id",
                new Dictionary<string, object> { { "@id", id } });
            return (dt != null && dt.Rows.Count > 0) ? dt.Rows[0] : null;
        }

        public void ZapiszUrzadzenie(int id, string aparat, string model, string imei, string sn, string status, int? idPracownika)
        {
            var p = new Dictionary<string, object> {
                { "@a", aparat }, { "@m", model }, { "@imei", imei }, { "@sn", sn }, { "@st", status },
                { "@idP", (object)idPracownika ?? DBNull.Value }, { "@id", id }
            };

            string sql = id == 0
                ? "INSERT INTO Urzadzenia (Aparat, Model, IMEI_MAC, SN, Status, ID_Pracownika) VALUES (@a, @m, @imei, @sn, @st, @idP)"
                : "UPDATE Urzadzenia SET Aparat=@a, Model=@m, IMEI_MAC=@imei, SN=@sn, Status=@st, ID_Pracownika=@idP WHERE ID=@id";

            _baza.WykonajPolecenie(sql, p);
        }

        public void WycofajUrzadzenie(int id)
        {
            _baza.WykonajPolecenie("UPDATE Urzadzenia SET Status = 'Wycofane' WHERE ID = @id",
                new Dictionary<string, object> { { "@id", id } });
        }

        public DataTable PobierzListePracownikow()
        {
            return _baza.PobierzDane("SELECT ID, Imie + ' ' + Nazwisko AS Nazwa FROM Pracownicy ORDER BY Nazwisko",
                new Dictionary<string, object>());
        }
    }
}