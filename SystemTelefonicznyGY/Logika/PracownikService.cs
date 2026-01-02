using System;
using System.Collections.Generic;
using System.Data;
using System.Linq; // Umożliwia operacje na kolekcjach danych (LINQ)
using SystemTelefonicznyGY.Models; // Dostęp do modeli (Pracownik, etc.)

namespace SystemTelefonicznyGY.Logika
{
    // Klasa serwisowa obsługująca logikę związaną z Pracownikami
    public class PracownikService
    {
        private readonly BazaDanych _baza = new BazaDanych(); // Instancja naszej klasy do łączenia z SQL

        // Metoda do logowania - sprawdza czy login i hasło pasują
        public DataRow Zaloguj(string login, string haslo)
        {
            // Zabezpieczenie: jeśli hasło lub login puste, nie pytamy bazy
            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(haslo)) return null;

            var dt = _baza.PobierzDane($"SELECT ID, Imie, Nazwisko, Rola, Haslo FROM Pracownicy WHERE Login = '{login}' AND Haslo = '{haslo}'");

            // Jeśli znaleziono rekord, zwracamy pierwszy wiersz, w przeciwnym razie null
            return dt.Rows.Count > 0 ? dt.Rows[0] : null;
        }

        // Metoda pomocnicza do sprawdzania, czy podane hasło jest poprawne dla danego ID
        public bool WeryfikujHaslo(int idPracownika, string stareHaslo)
        {
            // Pobieramy hasło z bazy dla danego ID
            DataTable dt = _baza.PobierzDane($"SELECT Haslo FROM Pracownicy WHERE ID = {idPracownika}");
            return dt.Rows.Count > 0 && dt.Rows[0]["Haslo"].ToString() == stareHaslo;
        }

        // Metoda do zmiany hasła
        public void ZmienHaslo(int idPracownika, string noweHaslo)
        {
            // Wykonujemy UPDATE w bazie
            _baza.WykonajPolecenie($"UPDATE Pracownicy SET Haslo = '{noweHaslo}' WHERE ID = {idPracownika}");
        }

        // Metoda pobierająca listę pracowników (używana w Home/Index i Admin/Pracownicy)
        public List<Pracownik> PobierzListęPracownikow(string szukanaFraza = "")
        {
            List<Pracownik> lista = new List<Pracownik>();

            // Zapytanie SQL łączące tabele (JOIN) aby pobrać nazwy działów i numery
            string sql = @"
            SELECT p.*, s.NazwaStanowiska, d.NazwaDzialu, d.SkroconaNazwa,
                   ns.Numer AS NrStacjonarny, nk.Numer AS NrKomorkowy
            FROM Pracownicy p
            JOIN Dzialy d ON p.ID_Dzialu = d.ID
            JOIN Stanowiska s ON p.ID_Stanowiska = s.ID
            LEFT JOIN NumeryStacjonarne ns ON p.ID = ns.ID_Pracownika
            LEFT JOIN NumeryKomorkowe nk ON p.ID = nk.ID_Pracownika";

            // Jeśli użytkownik coś wpisał, doklejamy warunek WHERE
            if (!string.IsNullOrEmpty(szukanaFraza))
            {
                sql += $@" WHERE p.Imie LIKE '%{szukanaFraza}%' 
                       OR p.Nazwisko LIKE '%{szukanaFraza}%' 
                       OR s.NazwaStanowiska LIKE '%{szukanaFraza}%' 
                       OR d.NazwaDzialu LIKE '%{szukanaFraza}%' 
                       OR ns.Numer LIKE '%{szukanaFraza}%' 
                       OR nk.Numer LIKE '%{szukanaFraza}%'";
            }

            sql += " ORDER BY p.Nazwisko"; // Sortowanie wyników

            DataTable dt = _baza.PobierzDane(sql);

            // Konwersja (Mapowanie) z tabeli SQL na listę obiektów C#
            foreach (DataRow row in dt.Rows)
            {
                var p = new Pracownik(
                    Convert.ToInt32(row["ID"]),
                    row["Imie"].ToString(),
                    row["Nazwisko"].ToString(),
                    row["Rola"].ToString(),
                    Convert.ToInt32(row["ID_Dzialu"]),
                    row["Login"].ToString(),
                    Convert.ToInt32(row["ID_Stanowiska"])
                )
                {
                    // Właściwości ustawiane w klamrach {}
                    NazwaStanowiska = row["NazwaStanowiska"].ToString(),
                    Dzial = dt.Columns.Contains("SkroconaNazwa")
                        ? row["NazwaDzialu"].ToString() + " (" + row["SkroconaNazwa"].ToString() + ")"
                        : row["NazwaDzialu"].ToString(),
                    NrStacjonarny = row.Table.Columns.Contains("NrStacjonarny") && row["NrStacjonarny"] != DBNull.Value
                        ? row["NrStacjonarny"].ToString()
                        : "---",
                    NrKomorkowy = row.Table.Columns.Contains("NrKomorkowy") && row["NrKomorkowy"] != DBNull.Value
                        ? row["NrKomorkowy"].ToString()
                        : "---"
                };

                lista.Add(p);
            }

            return lista;
        }

        // Metoda do pobierania listy pracowników do dropdowna (DataTable z kolumną 'Nazwa')
        public DataTable PobierzPracownikowDoDropdown()
        {
            return _baza.PobierzDane("SELECT ID, Imie + ' ' + Nazwisko AS Nazwa FROM Pracownicy ORDER BY Nazwisko");
        }

        // Metoda zapisu pracownika (Insert lub Update)
        public void ZapiszPracownika(int id, string imie, string nazwisko, string login, int idDzialu, string rola, int idStanowiska, string haslo)
        {
            string sql;

            // ID = 0 oznacza nowego pracownika (INSERT)
            if (id == 0)
            {
                string finalneHaslo = string.IsNullOrEmpty(haslo) ? "Welcome123" : haslo;
                sql = $@"INSERT INTO Pracownicy (Imie, Nazwisko, Login, Haslo, Rola, ID_Dzialu, ID_Stanowiska, Kraj) 
                         VALUES ('{imie}', '{nazwisko}', '{login}', '{finalneHaslo}', '{rola}', {idDzialu}, {idStanowiska}, 'Polska')";
            }
            // ID > 0 oznacza edycję istniejącego (UPDATE)
            else
            {
                // Aktualizujemy dane podstawowe
                sql = $@"UPDATE Pracownicy SET 
                         Imie = '{imie}', 
                         Nazwisko = '{nazwisko}', 
                         Login = '{login}',                 
                         Rola = '{rola}', 
                         ID_Dzialu = {idDzialu}, 
                         ID_Stanowiska = {idStanowiska}";

                // Aktualizujemy hasło TYLKO, jeśli zostało wpisane (nie jest puste)
                if (!string.IsNullOrEmpty(haslo))
                {
                    sql += $", Haslo = '{haslo}'";
                }

                sql += $" WHERE ID = {id}";
            }

            _baza.WykonajPolecenie(sql);
        }

        public void UsunPracownika(int id)
        {
            _baza.WykonajPolecenie($"DELETE FROM Pracownicy WHERE ID = {id}");
        }

        public Pracownik PobierzPracownikaPoId(int id)
        {
            DataTable dt = _baza.PobierzDane($"SELECT * FROM Pracownicy WHERE ID = {id}");
            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                return new Pracownik(
                   Convert.ToInt32(row["ID"]),
                   row["Imie"].ToString(),
                   row["Nazwisko"].ToString(),
                   row["Rola"].ToString(),
                   Convert.ToInt32(row["ID_Dzialu"]),
                   row["Login"].ToString(),
                   Convert.ToInt32(row["ID_Stanowiska"])
               );
            }
            return null;
        }
    }
}