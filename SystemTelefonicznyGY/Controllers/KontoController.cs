using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;  // Dodane dla dostępu do DataTable
using System.Web.Mvc;
using SystemTelefonicznyGY.Logika; // Dodane dla dostępu do klasy BazaDanych
using SystemTelefonicznyGY.Models;  // Dodane dla dostępu do modeli

namespace SystemTelefonicznyGY.Controllers
{
    public class KontoController : Controller
    {
        private BazaDanych _bazaObiekt;

        // Konstruktor - inicjalizuje obiekt BazaDanych tworzymy nową instancję klasy BazaDanych
        public KontoController()
        {
            _bazaObiekt = new BazaDanych();
        }

        // Metoda wyświetlająca stronę logowania
        [HttpGet]
        public ActionResult Login()
        {
            // Przesyłamy pusty obiekt modelu, aby uniknąć NullReferenceException
            var model = new LogowanieModel();
            return View(model);
        }

        // Get:Wyświetlanie formularza logowania
        // Obsluga danych z formularza logowania
        //zmiana sposobu wyświetlania osoby zalogowanej przez dodanie Nazwiska
        [HttpPost]

        public ActionResult Login(LogowanieModel model)
        {
            if (ModelState.IsValid)
            {
                // Szukamy pracownika w bazie (studencki sposób) dodanie Nazwiska do zapytania
                string zapytanie = $"SELECT ID, Imie, Nazwisko, Rola FROM Pracownicy WHERE Login = '{model.Login}' AND Haslo = '{model.Haslo}'";
                DataTable wynik = _bazaObiekt.PobierzDane(zapytanie);

                if (wynik.Rows.Count > 0)
                {
                    // Ustawiamy sesję (pamięć serwera o zalogowanym)
                    Session["IdPracownika"] = wynik.Rows[0]["ID"];
                    Session["ImiePracownika"] = wynik.Rows[0]["Imie"];
                    // Dodanie Nazwiska do sesji
                    Session["NazwiskoPracownika"] = wynik.Rows[0]["Nazwisko"];
                    Session["RolaPracownika"] = wynik.Rows[0]["Rola"];

                    return RedirectToAction("Index", "Home"); // Przekierowanie do strony głównej po zalogowaniu
                }
                else
                {
                    ModelState.AddModelError("", "Błędny login lub hasło pracownika."); // wyświetlenie błędu logowania
                }
            }
            return View(model);
        }

        public ActionResult Wyloguj()
        {
            Session.Abandon(); // Czyścimy wszystko
            return RedirectToAction("Index", "Home");
        }
    }
}