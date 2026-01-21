using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace SystemTelefonicznyGY.Models
{
    public class Pracownik
    {
        // Właściwości z prywatnym setterem - bezpieczne i zwięzłe
        public int Id { get; private set; }
        public string Imie { get; private set; }
        public string Nazwisko { get; private set; }
        public string Rola { get; private set; }
        public string Login { get; private set; }
        public int IdStanowiska { get; private set; }
        public int IdDzialu { get; private set; }

        // Właściwość obliczana (Expression-bodied member)
        public string PelneNazwisko => $"{Imie} {Nazwisko}";

        // Pozostałe pola dla widoku pozostają bez zmian
        public string NazwaStanowiska { get; set; }
        public string Dzial { get; set; }
        public string NrStacjonarny { get; set; }
        public string NrKomorkowy { get; set; }

        public Pracownik(int id, string imie, string nazwisko, string rola, int idDzialu, string login, int idStanowiska)
        {
            Id = id;
            Imie = imie;
            Nazwisko = nazwisko;
            Rola = rola;
            IdDzialu = idDzialu;
            Login = login;
            IdStanowiska = idStanowiska;
        }

        public static Pracownik ZWiersza(DataRow row)
        {
            var p = new Pracownik(
                Convert.ToInt32(row["ID"]),
                row["Imie"].ToString(),
                row["Nazwisko"].ToString(),
                row["Rola"].ToString(),
                Convert.ToInt32(row["ID_Dzialu"]),
                row["Login"].ToString(),
                Convert.ToInt32(row["ID_Stanowiska"])
            );

            // pola z JOINów
            if (row.Table.Columns.Contains("NazwaStanowiska"))
                p.NazwaStanowiska = row["NazwaStanowiska"].ToString();
            if (row.Table.Columns.Contains("NazwaDzialu"))
                p.Dzial = row["NazwaDzialu"].ToString();

            return p;
        }
    }
}