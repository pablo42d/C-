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

        public ActionResult Index()
        {
            // Zapytanie SQL łączące pracowników z działami
            string sql = @"SELECT p.Imie, p.Nazwisko, p.Stanowisko, d.NazwaDzialu 
                           FROM Pracownicy p 
                           JOIN Dzialy d ON p.ID_Dzialu = d.ID";

            if (!string.IsNullOrEmpty(szukanaFraza))
            {
                sql += " WHERE p.Nazwisko LIKE '%" + szukanaFraza + "%' OR d.NazwaDzialu LIKE '%" + szukanaFraza + "%'";
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