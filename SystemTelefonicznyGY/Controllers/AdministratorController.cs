using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SystemTelefonicznyGY.Logika;
using SystemTelefonicznyGY.Models;

namespace SystemTelefonicznyGY.Controllers
{
    public class AdministratorController : Controller
    {
        private BazaDanych _baza = new BazaDanych();

        //Sprawdzamy uprawnienia czy Admin
        private bool CzyAdmin()
        {
            return Session["RolaPracownika"] != null && Session["RolaPracownika"].ToString() == "Admin";
        }
        // GET: Administrator( dashbord Administratora
        public ActionResult Index()
        {
            if (!CzyAdmin()) return RedirectToAction("Login", "Konto");

            // Wypisujemy statystyki na kafelki
            ViewBag.LiczbaPracownikow = _baza.PobierzDane("Select Count(*) FROM Pracownicy").Rows[0][0];
            ViewBag.OstatniMiesiac = DateTime.Now.AddMonths(-1).ToString("MMMM yyyy");

            return View();
        }

    }
}