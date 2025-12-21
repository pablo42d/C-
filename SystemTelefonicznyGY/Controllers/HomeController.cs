using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
//using System.Web;
using System.Web.Mvc;
//using System.Web.Mvc;
//using System.Collections.Generic;
//using System.Linq;
using SystemTelefonicznyGY.Logika; // folder z klasą BazaDanych
using SystemTelefonicznyGY.Models;

namespace SystemTelefonicznyGY.Controllers
{
    public class HomeController : Controller
    {
        private BazaDanych _baza = new BazaDanych();

        // Zmiany w metodzie Index dla wyszukiwania i sortowania oraz wyświetlania na stronie głównej
        public ActionResult Index(string szukanaFraza)       
        {
            List<Pracownik> listaPracownikow = new List<Pracownik>();
            //List<PracownikWidok> listaPracownikow = new List<PracownikWidok>();

            
            string sql = @"
            SELECT 
                p.ID,
                p.Imie, 
                p.Nazwisko,
                p.Rola,
                p.ID_Dzialu,
                p.ID_Stanowiska,
                p.login,
                s.NazwaStanowiska,                
                d.NazwaDzialu, 
                d.SkroconaNazwa,
                ns.Numer AS NrStacjonarny,
                nk.Numer AS NrKomorkowy
            FROM Pracownicy p
            JOIN Dzialy d ON p.ID_Dzialu = d.ID
            JOIN Stanowiska s ON p.ID_Stanowiska = s.ID
            LEFT JOIN NumeryStacjonarne ns ON p.ID = ns.ID_Pracownika
            LEFT JOIN NumeryKomorkowe nk ON p.ID = nk.ID_Pracownika";

            if (!string.IsNullOrEmpty(szukanaFraza))
            {
                //sql += " WHERE p.Nazwisko LIKE '%" + szukanaFraza + "%' OR d.NazwaDzialu LIKE '%" + szukanaFraza + "%'";
                // Rozszerzone wyszukiwanie po wszystkich kolumnach (Imie, Nazwisko, Stanowisko, Dzial, Numery)
                sql += @" WHERE p.Imie LIKE '%" + szukanaFraza + @"%' 
                    OR p.Nazwisko LIKE '%" + szukanaFraza + @"%' 
                    OR s.NazwaStanowiska LIKE '%" + szukanaFraza + @"%' 
                    OR d.NazwaDzialu LIKE '%" + szukanaFraza + @"%' 
                    OR d.SkroconaNazwa LIKE '%" + szukanaFraza + @"%'
                    OR p.login LIKE '%" + szukanaFraza + @"%'
                    OR ns.Numer LIKE '%" + szukanaFraza + @"%' 
                    OR nk.Numer LIKE '%" + szukanaFraza + @"%'";
            }

            DataTable dt = _baza.PobierzDane(sql);

            //Mapowanie z DataTable na Listę Obiektów
            foreach (DataRow wiersz in dt.Rows)
            {
                // Wewnątrz pętli foreach w HomeController.Index:
                var p = new Pracownik(
                    Convert.ToInt32(wiersz["ID"]),
                    wiersz["Imie"].ToString(),
                    wiersz["Nazwisko"].ToString(),
                    wiersz["Rola"].ToString(),
                    Convert.ToInt32(wiersz["ID_Dzialu"]),
                    wiersz["Login"].ToString(),
                    Convert.ToInt32(wiersz["ID_Stanowiska"])
                );

                // Te pola są kluczowe dla widoku Index!
                p.NazwaStanowiska = wiersz["NazwaStanowiska"].ToString();
                p.Dzial = wiersz["NazwaDzialu"].ToString() + " (" + wiersz["SkroconaNazwa"].ToString() + ")";
                p.NrStacjonarny = wiersz["NrStacjonarny"] != DBNull.Value ? wiersz["NrStacjonarny"].ToString() : "---";
                p.NrKomorkowy = wiersz["NrKomorkowy"] != DBNull.Value ? wiersz["NrKomorkowy"].ToString() : "---";
                //p.NazwaStanowiska = wiersz["NazwaStanowiska"].ToString();
                //p.Dzial = wiersz["NazwaDzialu"].ToString();
                //p.NrStacjonarny = wiersz["NrStacjonarny"].ToString();
                //p.NrKomorkowy = wiersz["NrKomorkowy"].ToString();

                listaPracownikow.Add(p);
            }


                //foreach (DataRow wiersz in dt.Rows)
                //{
                //    listaPracownikow.Add(new Pracownik
                //    {
                //        Imie = wiersz["Imie"].ToString(),
                //        Nazwisko = wiersz["Nazwisko"].ToString(),
                //        NazwaStanowiska = wiersz["NazwaStanowiska"].ToString(),
                //        //Stanowisko = wiersz["Stanowisko"].ToString(),
                //        Dzial = wiersz["NazwaDzialu"].ToString() + " (" + wiersz["SkroconaNazwa"].ToString() + ")",
                //        Login = wiersz["login"].ToString(),
                //        IdStanowiska = 0, // Nie używane w widoku
                //        NrStacjonarny = wiersz["NrStacjonarny"] != DBNull.Value ? wiersz["NrStacjonarny"].ToString() : "---",
                //        NrKomorkowy = wiersz["NrKomorkowy"] != DBNull.Value ? wiersz["NrKomorkowy"].ToString() : "---"
                //    });
                //}


                // Sortowanie alfabetyczne po nazwisku 
                var posortowanaLista = listaPracownikow.OrderBy(p => p.Nazwisko).ToList();

            return View(posortowanaLista);
            
        }

        
        public ActionResult About()
        {
            ViewBag.Message = "Prefiksy zewnętrzne i wewnętrzne dla Systemu telekomunikacynego Firmy.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Dane kontaktowe do Firmy.";

            return View();
        }
    }
}