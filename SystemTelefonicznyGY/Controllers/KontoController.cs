using System;
using System.Web.Mvc;
using SystemTelefonicznyGY.Logika;
using SystemTelefonicznyGY.Logika.Interfejsy;
using SystemTelefonicznyGY.Models;

namespace SystemTelefonicznyGY.Controllers
{
    public class KontoController : Controller
    {
        // Używamy serwisu - pełna separacja od SQL
        private readonly IPracownikService _pracownikService = new PracownikService();

        [HttpGet]
        public ActionResult Login()
        {
            return View(new LogowanieModel());
        }

        [HttpPost]
        public ActionResult Login(LogowanieModel model)
        {
            if (ModelState.IsValid)
            {
                // Logika logowania w serwisie
                var pracownikRow = _pracownikService.Zaloguj(model.Login, model.Haslo);

                if (pracownikRow != null)
                {
                    Session["IdPracownika"] = pracownikRow["ID"];
                    Session["ImiePracownika"] = pracownikRow["Imie"];
                    Session["NazwiskoPracownika"] = pracownikRow["Nazwisko"];
                    Session["RolaPracownika"] = pracownikRow["Rola"];

                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Błędny login lub hasło pracownika.");
                }
            }
            return View(model);
        }

        public ActionResult Wyloguj()
        {
            Session.Abandon();
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public ActionResult ProcesZmianyHasla(ZmianaHaslaModel model)
        {
            if (Session["IdPracownika"] == null) return RedirectToAction("Login", "Konto");

            // 1. Walidacja modelu (długość hasła, czy się powtarzają)
            string blad = model.SprawdzBledy();
            if (blad != null)
            {
                TempData["Blad"] = blad;
                return Redirect(Request.UrlReferrer.ToString());
            }

            // 2. Weryfikacja starego hasła przez SERWIS
            bool czyStareDobre = _pracownikService.WeryfikujHaslo(model.IdPracownika, model.StareHaslo);

            if (!czyStareDobre)
            {
                TempData["Blad"] = "Podane obecne hasło jest błędne.";
                return Redirect(Request.UrlReferrer.ToString());
            }

            // 3. Zmiana hasła przez SERWIS
            try
            {
                _pracownikService.ZmienHaslo(model.IdPracownika, model.NoweHaslo);
                TempData["Sukces"] = "Hasło zostało pomyślnie zmienione.";
            }
            catch (Exception ex)
            {
                TempData["Blad"] = "Błąd bazy: " + ex.Message;
            }

            return Redirect(Request.UrlReferrer.ToString());
        }
    }
}