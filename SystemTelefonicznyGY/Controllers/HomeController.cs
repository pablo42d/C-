using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Web.Mvc;
using System.Collections.Generic;
using System.Linq;
using SystemTelefonicznyGY.Logika; // folder z klasą BazaDanych
using SystemTelefonicznyGY.Models;

namespace SystemTelefonicznyGY.Controllers
{
    public class HomeController : Controller
    {
        private BazaDanych _baza = new BazaDanych();

        public ActionResult Index(string szukanaFraza)       
        {
            // Zapytanie SQL łączące pracowników z działami
            string sql = @" 
            SELECT
            p.Imie, 
            p.Nazwisko, 
            p.Stanowisko, 
            d.NazwaDzialu, 
            d.SkroconaNazwa,
            ns.Numer AS NrStacjonarny,
            nk.Numer AS NrKomorkowy
        FROM Pracownicy p
        JOIN Dzialy d ON p.ID_Dzialu = d.ID
        LEFT JOIN NumeryStacjonarne ns ON p.ID = ns.ID_Pracownika
        LEFT JOIN NumeryKomorkowe nk ON p.ID = nk.ID_Pracownika";

    // Rozszerzenie wyszukiwania o numery telefonów
    if (!string.IsNullOrEmpty(szukanaFraza))
            {
                sql += @" WHERE p.Nazwisko LIKE '%" + szukanaFraza + @"%' 
                  OR d.NazwaDzialu LIKE '%" + szukanaFraza + @"%' 
                  OR ns.Numer LIKE '%" + szukanaFraza + @"%' 
                  OR nk.Numer LIKE '%" + szukanaFraza + @"%'";
            }

            DataTable dt = _baza.PobierzDane(sql);

            // Przekazujemy DataTable bezpośrednio do widoku (proste i skuteczne)
            return View(dt);
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