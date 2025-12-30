using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace SystemTelefonicznyGY.Logika
{
    public class BilingService
    {
        public static string GenerujSqlBazowy(string warunekCzasu, int? pracownikId = null)
        {
            // Jeśli podano pracownikId, ograniczamy bilingi tylko do tego pracownika
            string filtrPracownika = pracownikId.HasValue ? " AND n.ID_Pracownika = @id" : ""; //$" AND n.ID_Pracownika = {pracownikId.Value}" : "";

            return $@"
        SELECT b.DataPolaczenia, b.NumerTelefonu, b.KwotaNetto, b.KwotaBrutto, b.NrFaktury, 
               p.Imie + ' ' + p.Nazwisko AS Pracownik, p.MenagerName, d.ID AS DzialID, 
               d.NazwaDzialu AS Dzial, 'Komórkowy' AS Typ
        FROM BilingiKomorkowe b
        LEFT JOIN NumeryKomorkowe n ON (CASE WHEN LEN(b.NumerTelefonu) > 9 THEN RIGHT(b.NumerTelefonu, 9) ELSE b.NumerTelefonu END) = n.Numer
        LEFT JOIN Pracownicy p ON n.ID_Pracownika = p.ID
        LEFT JOIN Dzialy d ON p.ID_Dzialu = d.ID
        WHERE ({warunekCzasu}) {filtrPracownika}

        UNION ALL

        SELECT b.DataPolaczenia, b.NumerTelefonu, b.KwotaNetto, b.KwotaBrutto, b.NrFaktury, 
               p.Imie + ' ' + p.Nazwisko AS Pracownik, p.MenagerName, d.ID AS DzialID,
               d.NazwaDzialu AS Dzial, 'Stacjonarny' AS Typ
        FROM BilingiStacjonarne b
        LEFT JOIN NumeryStacjonarne n ON (CASE WHEN b.NumerTelefonu LIKE '4814%' OR b.NumerTelefonu LIKE '4822%' THEN RIGHT(b.NumerTelefonu, 7) ELSE b.NumerTelefonu END) = n.Numer
        LEFT JOIN Pracownicy p ON n.ID_Pracownika = p.ID
        LEFT JOIN Dzialy d ON p.ID_Dzialu = d.ID
        WHERE ({warunekCzasu}) {filtrPracownika}";
        }

        public static (int m, int r) PobierzDateOstatniegoBilingu(BazaDanych baza, int? idPracownika = null)
        {
            var paramy = new Dictionary<string, object>();
            string filtr = "";

            if (idPracownika.HasValue)
            {
                filtr = " WHERE n.ID_Pracownika = @id";
                paramy.Add("@id", idPracownika.Value);
            }

            string sql = $@"
        SELECT TOP 1 YEAR(DataPolaczenia) as R, MONTH(DataPolaczenia) as M 
        FROM (
            SELECT b.DataPolaczenia, n.ID_Pracownika FROM BilingiKomorkowe b
            JOIN NumeryKomorkowe n ON (CASE WHEN LEN(b.NumerTelefonu) > 9 THEN RIGHT(b.NumerTelefonu, 9) ELSE b.NumerTelefonu END) = n.Numer
            UNION ALL
            SELECT b.DataPolaczenia, n.ID_Pracownika FROM BilingiStacjonarne b
            JOIN NumeryStacjonarne n ON (CASE WHEN b.NumerTelefonu LIKE '4814%' OR b.NumerTelefonu LIKE '4822%' THEN RIGHT(b.NumerTelefonu, 7) ELSE b.NumerTelefonu END) = n.Numer
        ) AS T {filtr}
        ORDER BY DataPolaczenia DESC";

            // POPRAWKA CS7036: Przekazujemy słownik parametrów
            DataTable dt = baza.PobierzDane(sql, paramy);
            if (dt != null && dt.Rows.Count > 0)
            {
                return (Convert.ToInt32(dt.Rows[0]["M"]), Convert.ToInt32(dt.Rows[0]["R"]));
            }
            return (DateTime.Now.Month, DateTime.Now.Year);
        }

        public static DataTable PobierzWszystkieBilingi(BazaDanych baza, string warunekCzasu, int? pracownikId = null)
        {
            var paramy = new Dictionary<string, object>();

            if (pracownikId.HasValue)
            {
                paramy.Add("@id", pracownikId.Value);
            }

            // POPRAWKA CS1503: Przekazujemy pracownikId zamiast stringa 'filtr'
            string sql = GenerujSqlBazowy(warunekCzasu, pracownikId);
            return baza.PobierzDane(sql, paramy);
        }
    
    }    
}