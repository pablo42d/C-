using System;
using System.Collections.Generic;
using SystemTelefonicznyGY.Logika.Interfejsy;
using System.Data; // Niezbędne do obsługi DataTable i DataRow
using System.Linq;
using System.Web;
using System.Web.UI.WebControls.WebParts;
using SystemTelefonicznyGY.Models;

namespace SystemTelefonicznyGY.Logika
{
    // Klasa serwisowa grupująca logikę zarządzania "zasobami" firmy: Urządzenia, Numery Komórkowe, Numery Stacjonarne
    public class ZasobyService : IZasobyService
    {
        private readonly BazaDanych _baza = new BazaDanych();


        // ==========================================
        // SEKCJA 1: URZĄDZENIA (TELEFONY, TABLETY ITP.)
        // ==========================================

        
        // Metoda pobiera listę urządzeń, opcjonalnie filtrując po frazie (np. nazwisko, model, IMEI)
        public DataTable PobierzUrzadzenia(string szukanaFraza)
        {
            // Budujemy zapytanie SQL z LEFT JOIN, aby pobrać imię i nazwisko pracownika (jeśli jest przypisany)
            string sql = @"
                SELECT u.*, p.Imie, p.Nazwisko, (p.Imie + ' ' + p.Nazwisko) AS PrzypisanyPracownik
                FROM Urzadzenia u
                LEFT JOIN Pracownicy p ON u.ID_Pracownika = p.ID";

            // Jeśli użytkownik wpisał coś w wyszukiwarkę, dodajemy warunek WHERE
            if (!string.IsNullOrEmpty(szukanaFraza))
            {
                // Używamy LIKE, aby szukać fragmentów tekstu w różnych kolumnach
                sql += $@" WHERE u.IMEI_MAC LIKE '%{szukanaFraza}%' 
                           OR u.Model LIKE '%{szukanaFraza}%' 
                           OR u.NrInwentarzowy LIKE '%{szukanaFraza}%' 
                           OR p.Nazwisko LIKE '%{szukanaFraza}%'";
            }

            // Wykonuje zapytanie i zwraca tabelę danych gotową do wyświetlenia w Widoku
            return _baza.PobierzDane(sql);
        }

        // Metoda pobiera dane jednego urządzenia do edycji na podstawie jego ID
        public DataRow PobierzUrzadzeniePoId(int id)
        {
            // Pobiera wszystkie kolumny dla konkretnego ID
            DataTable dt = _baza.PobierzDane($"SELECT * FROM Urzadzenia WHERE ID = {id}");

            // Jeśli znaleziono rekord, zwracamy pierwszy wiersz. Jeśli nie - null.
            return dt.Rows.Count > 0 ? dt.Rows[0] : null;
        }

        // Metoda obsługuje zarówno dodawanie NOWEGO (INSERT) jak i edycję ISTNIEJĄCEGO (UPDATE) urządzenia
        public void ZapiszUrzadzenie(int id, string aparat, string model, string imeiMac, string sn, string nrInwentarzowy, string status, int? idPracownika)
        {
            // Logika obsługi wartości NULL dla SQL. Jeśli idPracownika to null, wstawia string "NULL", inaczej wstawia liczbę (ID).
            string pracownikVal = idPracownika.HasValue ? idPracownika.Value.ToString() : "NULL";
            string sql;

            if (id == 0)
            {
                // ID = 0 oznacza, że to nowy rekord -> używa INSERT
                sql = $@"INSERT INTO Urzadzenia (Aparat, Model, IMEI_MAC, SN, Status, NrInwentarzowy, ID_Pracownika) 
                         VALUES ('{aparat}', '{model}', '{imeiMac}', '{sn}', '{status}', '{nrInwentarzowy}', {pracownikVal})";
            }
            else
            {
                // ID > 0 oznacza edycję istniejącego rekordu -> używa UPDATE
                sql = $@"UPDATE Urzadzenia SET 
                         Aparat='{aparat}', Model='{model}', IMEI_MAC='{imeiMac}', SN='{sn}', 
                         Status='{status}', NrInwentarzowy='{nrInwentarzowy}', ID_Pracownika={pracownikVal} 
                         WHERE ID={id}";
            }

            // Wysłanie gotowego polecenia do bazy
            _baza.WykonajPolecenie(sql);
        }

        // Metoda "miękkiego usuwania" - zmienia status na 'Wycofane' zamiast kasować rekord z bazy
        public void WycofajUrzadzenie(int id)
        {
            _baza.WykonajPolecenie($"UPDATE Urzadzenia SET Status = 'Wycofane' WHERE ID = {id}");
        }

        // Metoda dedykowana dla Panelu Użytkownika - zwraca listę obiektów Urzadzenie
        public List<Urzadzenie> PobierzUrzadzeniaPracownika(int idPracownika)
        {
            List<Urzadzenie> lista = new List<Urzadzenie>();
            string sql = $"SELECT * FROM Urzadzenia WHERE ID_Pracownika = {idPracownika}";

            DataTable dt = _baza.PobierzDane(sql);

            foreach (DataRow row in dt.Rows)
            {
                var u = new Urzadzenie(
                    Convert.ToInt32(row["ID"]),
                    row["Model"].ToString(),
                    row["SN"].ToString(),
                    row["Status"].ToString(),
                    idPracownika
                )
                {
                    Aparat = row["Aparat"].ToString()
                }                ;
                
                lista.Add(u);
            }

            return lista;
        }



        // ==========================================
        // SEKCJA 2: NUMERY KOMÓRKOWE
        // ==========================================

        // Pobiera listę numerów komórkowych z danymi pracowników (dla widoku NumeryKomorkowe)
        public DataTable PobierzNumeryKomorkowe(string szukanaFraza)
        {
            // LEFT JOIN pozwala pobrać numer nawet jeśli nie ma przypisanego pracownika
            string sql = @"
                SELECT n.*, p.Imie + ' ' + p.Nazwisko AS PrzypisanyPracownik
                FROM NumeryKomorkowe n
                LEFT JOIN Pracownicy p ON n.ID_Pracownika = p.ID";

            // Filtrowanie po wielu kolumnach (Numer, PIN, PUK, Nazwisko pracownika)
            if (!string.IsNullOrEmpty(szukanaFraza))
            {
                sql += $@" WHERE n.Numer LIKE '%{szukanaFraza}%' 
                           OR n.NumerKarty LIKE '%{szukanaFraza}%' 
                           OR n.PIN LIKE '%{szukanaFraza}%' 
                           OR n.PUK LIKE '%{szukanaFraza}%'
                           OR n.PlanOpis LIKE '%{szukanaFraza}%'
                           OR n.Status LIKE '%{szukanaFraza}%'
                           OR p.Nazwisko LIKE '%{szukanaFraza}%'";
            }

            return _baza.PobierzDane(sql);
        }

        // Pobiera jeden numer komórkowy do edycji
        public DataRow PobierzNumerKomorkowyPoId(int id)
        {
            DataTable dt = _baza.PobierzDane($"SELECT * FROM NumeryKomorkowe WHERE ID = {id}");
            return dt.Rows.Count > 0 ? dt.Rows[0] : null;
        }

        // Dodaje lub aktualizuje numer komórkowy
        public void ZapiszNumerKomorkowy(int id, string numer, string numerKarty, string pin, string puk, string planOpis, string status, int? idPracownika)
        {
            // Obsługa przypisania do pracownika (NULL lub ID)
            string pracownikSql = idPracownika.HasValue ? idPracownika.Value.ToString() : "NULL";

            string sql = id == 0
                ? $@"INSERT INTO NumeryKomorkowe (Numer, NumerKarty, PIN, PUK, PlanOpis, Status, ID_Pracownika) 
                     VALUES ('{numer}', '{numerKarty}', '{pin}', '{puk}', '{planOpis}', '{status}', {pracownikSql})"
                : $@"UPDATE NumeryKomorkowe SET 
                     Numer='{numer}', NumerKarty='{numerKarty}', PIN='{pin}', PUK='{puk}', 
                     PlanOpis='{planOpis}', Status='{status}', ID_Pracownika={pracownikSql} WHERE ID={id}";

            _baza.WykonajPolecenie(sql);
        }

        // Dezaktywacja numeru - zmiana statusu i odpięcie pracownika (ustawienie ID_Pracownika na NULL)
        public void DezaktywujNumerKomorkowy(int id)
        {
            string sql = $"UPDATE NumeryKomorkowe SET Status = 'nie aktywny', ID_Pracownika = NULL WHERE ID = {id}";
            _baza.WykonajPolecenie(sql);
        }


        // ==========================================
        // SEKCJA 3: NUMERY STACJONARNE
        // ==========================================

        // Pobiera listę numerów stacjonarnych z wyszukiwarką
        public DataTable PobierzNumeryStacjonarne(string szukanaFraza)
        {
            string sql = @"
                SELECT ns.*, p.Imie + ' ' + p.Nazwisko AS PrzypisanyPracownik
                FROM NumeryStacjonarne ns
                LEFT JOIN Pracownicy p ON ns.ID_Pracownika = p.ID";

            if (!string.IsNullOrEmpty(szukanaFraza))
            {
                sql += $@" WHERE ns.Numer LIKE '%{szukanaFraza}%' 
                           OR ns.LiniaTyp LIKE '%{szukanaFraza}%' 
                           OR ns.Opis LIKE '%{szukanaFraza}%' 
                           OR ns.StatusCOR LIKE '%{szukanaFraza}%'
                           OR p.Nazwisko LIKE '%{szukanaFraza}%'";
            }

            return _baza.PobierzDane(sql);
        }

        // Pobiera dane pojedynczego numeru stacjonarnego
        public DataRow PobierzNumerStacjonarnyPoId(int id)
        {
            DataTable dt = _baza.PobierzDane($"SELECT * FROM NumeryStacjonarne WHERE ID = {id}");
            return dt.Rows.Count > 0 ? dt.Rows[0] : null;
        }

        // Zapisuje (Insert/Update) numer stacjonarny
        public void ZapiszNumerStacjonarny(int id, string numer, string liniaTyp, int? idPracownika, string prefiksKraj, string prefiksMiasto, string opis, string statusCor)
        {
            string pracownikIdSql = idPracownika.HasValue ? idPracownika.Value.ToString() : "NULL";

            string sql = id == 0
                ? $@"INSERT INTO NumeryStacjonarne (Numer, LiniaTyp, ID_Pracownika, PrefiksKraj, PrefiksMiasto, Opis, StatusCOR) 
                     VALUES ('{numer}', '{liniaTyp}', {pracownikIdSql}, '{prefiksKraj}', '{prefiksMiasto}', '{opis}', '{statusCor}')"
                : $@"UPDATE NumeryStacjonarne SET 
                     Numer='{numer}', LiniaTyp='{liniaTyp}', ID_Pracownika={pracownikIdSql}, 
                     PrefiksKraj='{prefiksKraj}', PrefiksMiasto='{prefiksMiasto}', Opis='{opis}', StatusCOR='{statusCor}' 
                     WHERE ID={id}";

            _baza.WykonajPolecenie(sql);
        }
    }
}