using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using SystemTelefonicznyGY.Logika.Interfejsy;
using SystemTelefonicznyGY.Models;

namespace SystemTelefonicznyGY.Logika
{
    public class BilingService : IBilingService
    {
        private readonly BazaDanych _baza = new BazaDanych();

        // Struktura pomocnicza dla importu
        public struct WynikImportu
        {
            public int LiczbaRekordow;
            public string NumerFaktury;
            public string KomunikatBledu;
        }

        // --- 1. METODY IMPORTU  ---

        public WynikImportu ImportujPlik(Stream strumienPliku, string typ)
        {
            var wynik = new WynikImportu();
            string tabelaSQL = (typ == "kom") ? "BilingiKomorkowe" : "BilingiStacjonarne";
            int licznik = 0;
            bool czyUsunietoStaraFakture = false;

            using (var reader = new StreamReader(strumienPliku))
            {
                reader.ReadLine(); // Pomijamy nagłówek

                while (!reader.EndOfStream)
                {
                    var linia = reader.ReadLine();
                    if (string.IsNullOrWhiteSpace(linia)) continue;

                    var wartosci = linia.Split(';');
                    if (wartosci.Length < 9) continue;

                    string nrFaktury = wartosci[8].Trim().Replace("'", "''");

                    if (!czyUsunietoStaraFakture && !string.IsNullOrEmpty(nrFaktury))
                    {
                        _baza.WykonajPolecenie($"DELETE FROM {tabelaSQL} WHERE NrFaktury = '{nrFaktury}'");
                        czyUsunietoStaraFakture = true;
                        wynik.NumerFaktury = nrFaktury;
                    }

                    string dataDlaSQL;
                    if (DateTime.TryParseExact(wartosci[0], "dd.MM.yyyy HH:mm",
                        System.Globalization.CultureInfo.InvariantCulture,
                        System.Globalization.DateTimeStyles.None, out DateTime dt))
                    {
                        dataDlaSQL = dt.ToString("yyyy-MM-dd HH:mm:ss");
                    }
                    else
                    {
                        DateTime.TryParse(wartosci[0], out dt);
                        dataDlaSQL = dt.ToString("yyyy-MM-dd HH:mm:ss");
                    }

                    string numerA = KonwertujNumer(wartosci[1]);
                    string numerB = KonwertujNumer(wartosci[2]);
                    string typPol = wartosci[3].Replace("'", "''");
                    string czas = wartosci[5];
                    string netto = wartosci[6].Replace(',', '.');
                    string brutto = wartosci[7].Replace(',', '.');

                    string sql = $@"INSERT INTO {tabelaSQL} 
                        (DataPolaczenia, NumerTelefonu, NumerWybierany, TypPolaczenia, CzasTrwania, KwotaNetto, KwotaBrutto, NrFaktury)
                        VALUES ('{dataDlaSQL}', '{numerA}', '{numerB}', '{typPol}', '{czas}', {netto}, {brutto}, '{nrFaktury}')";

                    _baza.WykonajPolecenie(sql);
                    licznik++;
                }
            }
            wynik.LiczbaRekordow = licznik;
            return wynik;
        }

        private string KonwertujNumer(string raw)
        {
            if (string.IsNullOrWhiteSpace(raw)) return "";
            raw = raw.Trim().Replace(" ", "");
            if (raw.Contains("E+"))
            {
                if (double.TryParse(raw.Replace(",", "."), System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out double parsed))
                {
                    return parsed.ToString("F0");
                }
            }
            return raw;
        }

        // --- 2. METODY RAPORTOWANIA ---

        // Metoda pomocnicza: Generuje bazowy SQL z JOINami i warunkiem czasu
        // Używana wewnątrz, aby nie powtarzać kodu w PobierzRaport i PoliczRekordy
        public static string GenerujSqlBazowy(string warunekCzasu)
        {
            return $@"
                SELECT b.DataPolaczenia, b.NumerTelefonu, b.KwotaNetto, b.KwotaBrutto, b.NrFaktury, 
                       ISNULL(p.Imie + ' ' + p.Nazwisko, 'Nieprzypisany') AS Pracownik, 
                       ISNULL(p.MenagerName, '-') AS MenagerName, 
                       ISNULL(d.NazwaDzialu, '-') AS Dzial, 
                       d.ID AS DzialID,
                       'Komórkowy' AS Typ
                FROM BilingiKomorkowe b
                LEFT JOIN NumeryKomorkowe n ON (CASE WHEN LEN(b.NumerTelefonu) > 9 THEN RIGHT(b.NumerTelefonu, 9) ELSE b.NumerTelefonu END) = n.Numer
                LEFT JOIN Pracownicy p ON n.ID_Pracownika = p.ID
                LEFT JOIN Dzialy d ON p.ID_Dzialu = d.ID
                WHERE {warunekCzasu}

                UNION ALL

                SELECT b.DataPolaczenia, b.NumerTelefonu, b.KwotaNetto, b.KwotaBrutto, b.NrFaktury, 
                       ISNULL(p.Imie + ' ' + p.Nazwisko, 'Nieprzypisany') AS Pracownik, 
                       ISNULL(p.MenagerName, '-') AS MenagerName, 
                       ISNULL(d.NazwaDzialu, '-') AS Dzial, 
                       d.ID AS DzialID,
                       'Stacjonarny' AS Typ
                FROM BilingiStacjonarne b
                LEFT JOIN NumeryStacjonarne n ON (CASE WHEN b.NumerTelefonu LIKE '4814%' OR b.NumerTelefonu LIKE '4822%' THEN RIGHT(b.NumerTelefonu, 7) ELSE b.NumerTelefonu END) = n.Numer
                LEFT JOIN Pracownicy p ON n.ID_Pracownika = p.ID
                LEFT JOIN Dzialy d ON p.ID_Dzialu = d.ID
                WHERE {warunekCzasu}";
        }

        // Sprawdza czy są jakiekolwiek dane w miesiącu (do alertu "Brak danych")
        public bool CzyIstniejaBilingi(int miesiac, int rok)
        {
            string sql = $@"
                SELECT TOP 1 1 FROM (
                    SELECT DataPolaczenia FROM BilingiKomorkowe WHERE MONTH(DataPolaczenia) = {miesiac} AND YEAR(DataPolaczenia) = {rok}
                    UNION ALL 
                    SELECT DataPolaczenia FROM BilingiStacjonarne WHERE MONTH(DataPolaczenia) = {miesiac} AND YEAR(DataPolaczenia) = {rok}
                ) AS T";
            return _baza.PobierzDane(sql).Rows.Count > 0;
        }

        // Pobiera dane (z paginacją lub bez)
        public DataTable PobierzRaport(int miesiac, int rok, string fraza, string nrFaktury, int? dzialId, string manager, DateTime? od, DateTime? doDaty, int nrStrony = 1, int rozmiarStrony = 0)
        {
            // 1. Warunek Czasu
            string warunekCzasu;
            if (od.HasValue || doDaty.HasValue)
            {
                List<string> czesci = new List<string>();
                if (od.HasValue) czesci.Add($"b.DataPolaczenia >= '{od.Value:yyyy-MM-dd}'");
                if (doDaty.HasValue) czesci.Add($"b.DataPolaczenia <= '{doDaty.Value:yyyy-MM-dd} 23:59:59'");
                warunekCzasu = string.Join(" AND ", czesci);
            }
            else
            {
                warunekCzasu = $"MONTH(b.DataPolaczenia) = {miesiac} AND YEAR(b.DataPolaczenia) = {rok}";
            }

            // 2. Filtry Tekstowe (Szukaj Wszędzie)
            string filtry = "";
            if (!string.IsNullOrEmpty(fraza))
            {
                filtry += $@" AND (
                    NumerTelefonu LIKE '%{fraza}%' OR 
                    Pracownik LIKE '%{fraza}%' OR 
                    MenagerName LIKE '%{fraza}%' OR 
                    Dzial LIKE '%{fraza}%'
                )";
            }
            if (dzialId.HasValue) filtry += $" AND DzialID = {dzialId.Value}";
            if (!string.IsNullOrEmpty(manager)) filtry += $" AND MenagerName LIKE '%{manager}%'";
            if (!string.IsNullOrEmpty(nrFaktury)) filtry += $" AND NrFaktury LIKE '%{nrFaktury}%'";

            // 3. Generowanie zapytania
            string sqlBazowy = GenerujSqlBazowy(warunekCzasu);
            string sqlFinalny;

            if (rozmiarStrony > 0)
            {
                int pomin = (nrStrony - 1) * rozmiarStrony;
                sqlFinalny = $@"SELECT * FROM ({sqlBazowy}) AS Zbiorcze 
                                WHERE 1=1 {filtry} 
                                ORDER BY DataPolaczenia DESC 
                                OFFSET {pomin} ROWS FETCH NEXT {rozmiarStrony} ROWS ONLY";
            }
            else
            {
                // Bez limitu (Export)
                sqlFinalny = $@"SELECT * FROM ({sqlBazowy}) AS Zbiorcze 
                                WHERE 1=1 {filtry} 
                                ORDER BY DataPolaczenia DESC";
            }

            return _baza.PobierzDane(sqlFinalny);
        }

        // Liczy rekordy (do paginacji)
        public int PoliczRekordy(int miesiac, int rok, string fraza, string nrFaktury, int? dzialId, string manager, DateTime? od, DateTime? doDaty)
        {
            // Logika identyczna jak w PobierzRaport, ale zwraca COUNT(*)
            string warunekCzasu;
            if (od.HasValue || doDaty.HasValue)
            {
                List<string> czesci = new List<string>();
                if (od.HasValue) czesci.Add($"b.DataPolaczenia >= '{od.Value:yyyy-MM-dd}'");
                if (doDaty.HasValue) czesci.Add($"b.DataPolaczenia <= '{doDaty.Value:yyyy-MM-dd} 23:59:59'");
                warunekCzasu = string.Join(" AND ", czesci);
            }
            else
            {
                warunekCzasu = $"MONTH(b.DataPolaczenia) = {miesiac} AND YEAR(b.DataPolaczenia) = {rok}";
            }

            string filtry = "";
            if (!string.IsNullOrEmpty(fraza))
            {
                // Uwaga: W podzapytaniu COUNT nazwy kolumn muszą pasować do aliasów z GenerujSqlBazowy
                filtry += $@" AND (NumerTelefonu LIKE '%{fraza}%' OR Pracownik LIKE '%{fraza}%' OR MenagerName LIKE '%{fraza}%' OR Dzial LIKE '%{fraza}%')";
            }
            if (dzialId.HasValue) filtry += $" AND DzialID = {dzialId.Value}";
            if (!string.IsNullOrEmpty(manager)) filtry += $" AND MenagerName LIKE '%{manager}%'";
            if (!string.IsNullOrEmpty(nrFaktury)) filtry += $" AND NrFaktury LIKE '%{nrFaktury}%'";

            string sqlBazowy = GenerujSqlBazowy(warunekCzasu);
            string sqlCount = $@"SELECT COUNT(*) FROM ({sqlBazowy}) AS Zbiorcze WHERE 1=1 {filtry}";

            DataTable dt = _baza.PobierzDane(sqlCount);
            return Convert.ToInt32(dt.Rows[0][0]);
        }

        public StringBuilder GenerujCsvRaportu(DataTable dt)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Data;Numer;Pracownik;Manager;Dzial;Typ;Netto;Brutto;Faktura");

            foreach (DataRow row in dt.Rows)
            {
                sb.AppendLine(string.Format("{0:dd.MM.yyyy HH:mm};{1};{2};{3};{4};{5};{6:N2};{7:N2};{8}",
                    row["DataPolaczenia"],
                    row["NumerTelefonu"],
                    row["Pracownik"],
                    row["MenagerName"],
                    row["Dzial"],
                    row["Typ"],
                    row["KwotaNetto"],
                    row["KwotaBrutto"],
                    row["NrFaktury"]));
            }
            return sb;
        }

        // --- METODY DLA POZOSTAŁYCH KONTROLERÓW (HOME/PANEL) ---

        public decimal PobierzSumeKosztow(int miesiac, int rok)
        {
            string sql = $@"
        SELECT SUM(Kwota) FROM (
            SELECT KwotaBrutto AS Kwota FROM BilingiKomorkowe WHERE MONTH(DataPolaczenia) = {miesiac} AND YEAR(DataPolaczenia) = {rok}
            UNION ALL
            SELECT KwotaBrutto AS Kwota FROM BilingiStacjonarne WHERE MONTH(DataPolaczenia) = {miesiac} AND YEAR(DataPolaczenia) = {rok}
        ) AS T";

            DataTable dt = _baza.PobierzDane(sql);
            if (dt.Rows.Count > 0 && dt.Rows[0][0] != DBNull.Value)
            {
                return Convert.ToDecimal(dt.Rows[0][0]);
            }
            return 0.0m;
        }

        public (int m, int r) PobierzDateOstatniegoBilinguPracownika(int idPracownika)
        {
            string sql = $@"
        SELECT TOP 1 YEAR(DataPolaczenia) as R, MONTH(DataPolaczenia) as M 
        FROM (
            SELECT b.DataPolaczenia FROM BilingiKomorkowe b
            JOIN NumeryKomorkowe n ON (CASE WHEN LEN(b.NumerTelefonu) > 9 THEN RIGHT(b.NumerTelefonu, 9) ELSE b.NumerTelefonu END) = n.Numer
            WHERE n.ID_Pracownika = {idPracownika}
            UNION ALL
            SELECT b.DataPolaczenia FROM BilingiStacjonarne b
            JOIN NumeryStacjonarne n ON (CASE WHEN b.NumerTelefonu LIKE '4814%' OR b.NumerTelefonu LIKE '4822%' THEN RIGHT(b.NumerTelefonu, 7) ELSE b.NumerTelefonu END) = n.Numer
            WHERE n.ID_Pracownika = {idPracownika}
        ) AS T 
        ORDER BY DataPolaczenia DESC";

            DataTable dt = _baza.PobierzDane(sql);
            if (dt.Rows.Count > 0)
            {
                return (Convert.ToInt32(dt.Rows[0]["M"]), Convert.ToInt32(dt.Rows[0]["R"]));
            }
            return (DateTime.Now.Month, DateTime.Now.Year);
        }

        public DataTable PobierzBilingiPracownika(int idPracownika, int m, int r, string typ)
        {
            string sql;
            if (typ == "kom")
            {
                sql = $@"SELECT b.* FROM BilingiKomorkowe b 
               JOIN NumeryKomorkowe n ON (CASE WHEN LEN(b.NumerTelefonu) > 9 THEN RIGHT(b.NumerTelefonu, 9) ELSE b.NumerTelefonu END) = n.Numer
               WHERE n.ID_Pracownika = {idPracownika} 
               AND MONTH(b.DataPolaczenia) = {m} AND YEAR(b.DataPolaczenia) = {r}
               ORDER BY b.DataPolaczenia DESC";
            }
            else
            {
                sql = $@"SELECT b.* FROM BilingiStacjonarne b 
               JOIN NumeryStacjonarne n ON (CASE WHEN b.NumerTelefonu LIKE '4814%' OR b.NumerTelefonu LIKE '4822%' THEN RIGHT(b.NumerTelefonu, 7) ELSE b.NumerTelefonu END) = n.Numer
               WHERE n.ID_Pracownika = {idPracownika}
               AND MONTH(b.DataPolaczenia) = {m} AND YEAR(b.DataPolaczenia) = {r}
               ORDER BY b.DataPolaczenia DESC";
            }
            return _baza.PobierzDane(sql);
        }

        // Metoda dla Raportu Księgowego - pobiera wszystko jak leci (1=1)
        public DataTable PobierzWszystkieBilingi()
        {
            // Używamy istniejącego generatora SQL z warunkiem zawsze prawdziwym
            string sqlBazowy = GenerujSqlBazowy("1=1");

            // Zwracamy wszystko
            string sql = $@"SELECT * FROM ({sqlBazowy}) AS Zbiorcze ORDER BY DataPolaczenia DESC";

            return _baza.PobierzDane(sql);
        }
    }
}