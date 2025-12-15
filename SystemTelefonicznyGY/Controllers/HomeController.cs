using System;
using System.Collections.Generic;
using System.Linq;
//using System.Web;
using System.Web.Mvc;
using System.Data;
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
            List<PracownikWidok> listaPracownikow = new List<PracownikWidok>();
            
            string sql = @"
        SELECT 
            p.Imie, 
            p.Nazwisko, 
            p.Stanowisko,
            p.login,
            d.NazwaDzialu, 
            d.SkroconaNazwa,
            ns.Numer AS NrStacjonarny,
            nk.Numer AS NrKomorkowy
        FROM Pracownicy p
        JOIN Dzialy d ON p.ID_Dzialu = d.ID
        LEFT JOIN NumeryStacjonarne ns ON p.ID = ns.ID_Pracownika
        LEFT JOIN NumeryKomorkowe nk ON p.ID = nk.ID_Pracownika";

            if (!string.IsNullOrEmpty(szukanaFraza))
            {
                //sql += " WHERE p.Nazwisko LIKE '%" + szukanaFraza + "%' OR d.NazwaDzialu LIKE '%" + szukanaFraza + "%'";
                // Rozszerzone wyszukiwanie po wszystkich kolumnach (Imie, Nazwisko, Stanowisko, Dzial, Numery)
                sql += @" WHERE p.Imie LIKE '%" + szukanaFraza + @"%' 
                  OR p.Nazwisko LIKE '%" + szukanaFraza + @"%' 
                  OR p.Stanowisko LIKE '%" + szukanaFraza + @"%' 
                  OR d.NazwaDzialu LIKE '%" + szukanaFraza + @"%' 
                  OR d.SkroconaNazwa LIKE '%" + szukanaFraza + @"%'
                  OR p.login LIKE '%" + szukanaFraza + @"%'
                  OR ns.Numer LIKE '%" + szukanaFraza + @"%' 
                  OR nk.Numer LIKE '%" + szukanaFraza + @"%'";
            }
            
            DataTable dt = _baza.PobierzDane(sql);

            // Mapowanie z DataTable na Listę Obiektów
            foreach (DataRow wiersz in dt.Rows)
            {
                listaPracownikow.Add(new PracownikWidok
                {
                    Imie = wiersz["Imie"].ToString(),
                    Nazwisko = wiersz["Nazwisko"].ToString(),
                    Stanowisko = wiersz["Stanowisko"].ToString(),
                    Dzial = wiersz["NazwaDzialu"].ToString() + " (" + wiersz["SkroconaNazwa"].ToString() + ")",
                    Login = wiersz["login"].ToString(),
                    NrStacjonarny = wiersz["NrStacjonarny"] != DBNull.Value ? wiersz["NrStacjonarny"].ToString() : "---",
                    NrKomorkowy = wiersz["NrKomorkowy"] != DBNull.Value ? wiersz["NrKomorkowy"].ToString() : "---"
                });
            }

            // Sortowanie alfabetyczne po nazwisku 
            var posortowanaLista = listaPracownikow.OrderBy(p => p.Nazwisko).ToList();

            return View(posortowanaLista);
            
        }

        
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}