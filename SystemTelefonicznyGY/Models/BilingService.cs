using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SystemTelefonicznyGY.Models
{
    public class BilingService
    {
        public static string GenerujSqlBazowy(string warunekCzasu, int? pracownikId = null)
        {
            // Jeśli podano pracownikId, ograniczamy bilingi tylko do tego pracownika
            string filtrPracownika = pracownikId.HasValue ? $" AND n.ID_Pracownika = {pracownikId.Value}" : "";

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
    }
}