using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
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
        // 1. GET: Administrator( dashbord Administratora = Vidok Index)
        public ActionResult Index()
        {
            if (!CzyAdmin()) return RedirectToAction("Login", "Konto");

            // Wypisujemy statystyki na kafelki
            ViewBag.LiczbaPracownikow = _baza.PobierzDane("Select Count(*) FROM Pracownicy").Rows[0][0];
            ViewBag.OstatniMiesiac = DateTime.Now.AddMonths(-1).ToString("MMMM yyyy");

            return View();
        }

        // 2. Lista Pracowników = vidok Pracownicy
        public ActionResult Pracownicy()
        {
            // pobieramy dane z bazy danych i przekazujemy je do vidoku Pracownicy wypełniając tabelę 
            if (!CzyAdmin()) return RedirectToAction("Login", "Konto"); // Wywołanie kontrolera

            string sql = @"Select p.*, d.NazwaDzialu
        FROM Pracownicy p
        JOIN Dzialy d ON p.ID_Dzialu = d.ID
        ORDER BY p.Nazwisko";

            DataTable dt = _baza.PobierzDane(sql);
            List<Pracownik> lista = new List<Pracownik>();

            // Iterowanie po wynikach z bazy
            if (dt != null)
            {
                foreach (DataRow row in dt.Rows)
                {
                    // Używamy konstruktora, który zdefiniowałeś w modelu Pracownik
                    lista.Add(new Pracownik(
                        Convert.ToInt32(row["ID"]),
                        row["Imie"].ToString(),
                        row["Nazwisko"].ToString(),
                        row["Rola"].ToString(),
                        Convert.ToInt32(row["ID_Dzialu"]),
                        row["Login"].ToString(),
                        row["Stanowisko"].ToString()
                    ));
                }                
            }
            return View(lista);
        }

        [HttpGet]
        public ActionResult Edytuj(int? id)
        {
            if (!CzyAdmin()) return RedirectToAction("Login", "Konto");

            // Pobieramy działy do listy rozwijanej
            DataTable dtDzialy = _baza.PobierzDane("SELECT ID, NazwaDzialu FROM Dzialy");
            ViewBag.ListaDzialow = dtDzialy;

            if (id.HasValue)
            {
                // Tryb Edycji: Pobierz dane pracownika
                DataTable dt = _baza.PobierzDane($"SELECT * FROM Pracownicy WHERE ID = {id.Value}");
                if (dt != null && dt.Rows.Count > 0)
                {
                    DataRow row = dt.Rows[0];
                    var p = new Pracownik(
                        Convert.ToInt32(row["ID"]),
                        row["Imie"].ToString(),
                        row["Nazwisko"].ToString(),
                        row["Rola"].ToString(),
                        Convert.ToInt32(row["ID_Dzialu"]),
                        row["Login"].ToString(),
                        row["Stanowisko"].ToString()
                    );
                    return View(p);
                }
            }

            // Tryb Dodawania: Zwracamy pusty obiekt (używając konstruktora z domyślnymi wartościami)
            return View(new Pracownik(0, "", "", "User", 1, "", ""));
        }
        //Implementacja zapisu(Metoda POST) Aby formularz zaczął działać, dodajemy metodę Zapisz. Ponieważ model Pracownik nie ma publicznych setterów(ma tylko get), parametry z formularza odbierzemy bezpośrednio w argumentach metody.
        [HttpPost]
        public ActionResult Zapisz(int Id, string Imie, string Nazwisko, string Login, int IdDzialu, string Rola, string Stanowisko)
        {
            if (!CzyAdmin()) return RedirectToAction("Login", "Konto");

            string sql;
            if (Id == 0)
            {
                // INSERT - Nowy pracownik (Hasło domyślne np. 'Start123')
                sql = $@"INSERT INTO Pracownicy (Imie, Nazwisko, Login, Haslo, Rola, ID_Dzialu, Stanowisko, Kraj) 
                 VALUES ('{Imie}', '{Nazwisko}', '{Login}', 'Start123', '{Rola}', {IdDzialu}, '{Stanowisko}', 'Polska')";
            }
            else
            {
                // UPDATE - Istniejący pracownik
                sql = $@"UPDATE Pracownicy SET 
                 Imie = '{Imie}', 
                 Nazwisko = '{Nazwisko}', 
                 Login = '{Login}', 
                 Rola = '{Rola}', 
                 ID_Dzialu = {IdDzialu}, 
                 Stanowisko = '{Stanowisko}' 
                 WHERE ID = {Id}";
            }

            try
            {
                _baza.WykonajPolecenie(sql);
                TempData["Sukces"] = "Dane pracownika zostały zapisane.";
            }
            catch (Exception ex)
            {
                TempData["Blad"] = "Błąd zapisu: " + ex.Message;
            }

            return RedirectToAction("Pracownicy");
        }

        // Metoda suwanie Pracownika
        public ActionResult Usun(int id)
        {
            if (!CzyAdmin()) return RedirectToAction("Index");

            try
            {
                // Warto najpierw sprawdzić czy pracownik nie ma przypisanych numerów/urządzeń
                // lub polegać na kaskadowym usuwaniu w bazie danych.
                _baza.WykonajPolecenie($"DELETE FROM Pracownicy WHERE ID = {id}");
                TempData["Sukces"] = "Pracownik został usunięty.";
            }
            catch (Exception ex)
            {
                TempData["Blad"] = "Nie można usunąć pracownika (prawdopodobnie ma przypisane numery).";
            }

            return RedirectToAction("Pracownicy");
        }

    }
}