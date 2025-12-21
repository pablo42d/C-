using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Security.Policy;
using System.Text;
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

        public object Haslo { get; private set; }

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

        // Metoda wyświetlająca stronę wyboru pliku CSV
        [HttpGet]
        public ActionResult Import()
        {
            if (!CzyAdmin()) return RedirectToAction("Login", "Konto");
            return View();
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
        public ActionResult Zapisz(int Id, string Imie, string Nazwisko, string Login, int IdDzialu, string Rola, string Stanowisko, string Haslo) // <--- Dodano Haslo
        {
            if (Session["RolaPracownika"]?.ToString() != "Admin") return RedirectToAction("Login", "Konto");

            string sql;
            if (Id == 0)
            {
                // Teraz zmienna Haslo jest widoczna i zostanie pobrana z formularza
                sql = $@"INSERT INTO Pracownicy (Imie, Nazwisko, Login, Haslo, Rola, ID_Dzialu, Stanowisko, Kraj) 
                 VALUES ('{Imie}', '{Nazwisko}', '{Login}', '{Haslo}', '{Rola}', {IdDzialu}, '{Stanowisko}', 'Polska')";
            }
            else
            {
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
                TempData["Sukces"] = "Dane zostały pomyślnie zapisane.";
            }
            catch (Exception ex)
            {
                TempData["Blad"] = "Błąd bazy danych: " + ex.Message;
            }

            return RedirectToAction("Pracownicy");
        }


        //if (!CzyAdmin()) return RedirectToAction("Login", "Konto");

        //string sql;
        //if (Id == 0)
        //{
        //    // INSERT - Nowy pracownik (Hasło domyślne np. 'user123')
        //    sql = $@"INSERT INTO Pracownicy (Imie, Nazwisko, Login, Haslo, Rola, ID_Dzialu, Stanowisko, Kraj) 
        //     VALUES ('{Imie}', '{Nazwisko}', '{Login}', 'user123', '{Rola}', {IdDzialu}, '{Stanowisko}', 'Polska')";
        //}
        //else
        //{
        //    // UPDATE - Istniejący pracownik
        //    sql = $@"UPDATE Pracownicy SET 
        //     Imie = '{Imie}', 
        //     Nazwisko = '{Nazwisko}', 
        //     Login = '{Login}', 
        //     Rola = '{Rola}', 
        //     ID_Dzialu = {IdDzialu}, 
        //     Stanowisko = '{Stanowisko}' 
        //     WHERE ID = {Id}";
        //}

        //try
        //{
        //    _baza.WykonajPolecenie(sql);
        //    TempData["Sukces"] = "Dane pracownika zostały zapisane.";
        //}
        //catch (Exception ex)
        //{
        //    TempData["Blad"] = "Błąd podczas zapisu: " + ex.Message;                
        //}

        //return RedirectToAction("Pracownicy");




        // --- SEKCJA ZARZĄDZANIA DZIAŁAMI ---

        // Lista działów
        public ActionResult Dzialy()
        {
            if (!CzyAdmin()) return RedirectToAction("Login", "Konto");

            DataTable dt = _baza.PobierzDane("SELECT * FROM Dzialy ORDER BY NazwaDzialu");
            return View(dt);
        }

        // Widok dodawania/edycji działu
        [HttpGet]
        public ActionResult EdytujDzial(int? id)
        {
            if (!CzyAdmin()) return RedirectToAction("Login", "Konto");

            if (id.HasValue)
            {
                DataTable dt = _baza.PobierzDane($"SELECT * FROM Dzialy WHERE ID = {id.Value}");
                if (dt != null && dt.Rows.Count > 0)
                {
                    return View(dt.Rows[0]);
                }
            }
            return View(); // Zwraca pusty widok dla nowego działu
        }

        // Zapis działu
        [HttpPost]
        public ActionResult ZapiszDzial(int Id, string NazwaDzialu)
        {
            if (!CzyAdmin()) return RedirectToAction("Login", "Konto");

            string sql = Id == 0
                ? $"INSERT INTO Dzialy (NazwaDzialu) VALUES ('{NazwaDzialu}')"
                : $"UPDATE Dzialy SET NazwaDzialu = '{NazwaDzialu}' WHERE ID = {Id}";

            try
            {
                _baza.WykonajPolecenie(sql);
                TempData["Sukces"] = "Lista działów został zaktualizowany.";
            }
            catch (Exception ex)
            {
                TempData["Blad"] = "Błąd zapisu działu: " + ex.Message;
            }

            return RedirectToAction("Dzialy");
        }

        // --- SEKCJA IMPORTU BILINGÓW Z PLIKU CSV ---

        [HttpPost]
        public ActionResult ImportujCSV(HttpPostedFileBase plikBilingowy, string typ)
        {
            if (!CzyAdmin()) return RedirectToAction("Login", "Konto");

            if (plikBilingowy != null && plikBilingowy.ContentLength > 0)
            {
                try
                {
                    using (var reader = new System.IO.StreamReader(plikBilingowy.InputStream))
                    {
                        // Pomijamy nagłówek pliku
                        reader.ReadLine();
                        int licznik = 0;

                        while (!reader.EndOfStream)
                        {
                            var linia = reader.ReadLine();
                            var wartosci = linia.Split(';'); // Zakładamy średnik jako separator

                            // Przykładowy mapowanie: Data;Numer;NumerWybierany;Sekundy;Koszt;Faktura;ID_Numeru
                            string tabela = (typ == "kom") ? "BilingiKomorkowe" : "BilingiStacjonarne";
                            string idKolumna = (typ == "kom") ? "ID_NumeruKomorkowego" : "ID_NumeruStacjonarnego";

                            string sql = $@"INSERT INTO {tabela} (DataPolaczenia, NumerTelefonu, NumerWybierany, CzasTrwania, KwotaBrutto, NrFaktury, {idKolumna})
                                    VALUES ('{wartosci[0]}', '{wartosci[1]}', '{wartosci[2]}', {wartosci[3]}, {wartosci[4].Replace(',', '.')}, '{wartosci[5]}', {wartosci[6]})";

                            _baza.WykonajPolecenie(sql);
                            licznik++;
                        }
                        TempData["Sukces"] = $"Pomyślnie zaimportowano {licznik} rekordów bilingowych.";
                    }
                }
                catch (Exception ex)
                {
                    TempData["Blad"] = "Błąd podczas przetwarzania pliku: " + ex.Message;
                }
            }
            return RedirectToAction("Index");
        }


        // Metoda usuwanie Pracownika
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
                TempData["Blad"] = "Nie można usunąć pracownika (prawdopodobnie ma przypisane numery)." + ex.Message;
            }

            return RedirectToAction("Pracownicy");
        }


        public void EksportujRaport()
        {
            if (!CzyAdmin()) return;

            // Zapytanie łączące pracowników, działy i ich bilingi
            string sql = @"
        SELECT p.Imie, p.Nazwisko, d.NazwaDzialu, 
               ISNULL(SUM(bk.KwotaBrutto), 0) + ISNULL(SUM(bs.KwotaBrutto), 0) as SumaKosztow
        FROM Pracownicy p
        JOIN Dzialy d ON p.ID_Dzialu = d.ID
        LEFT JOIN BilingiKomorkowe bk ON bk.ID_NumeruKomorkowego IN (SELECT ID FROM NumeryKomorkowe WHERE ID_Pracownika = p.ID)
        LEFT JOIN BilingiStacjonarne bs ON bs.ID_NumeruStacjonarnego IN (SELECT ID FROM NumeryStacjonarne WHERE ID_Pracownika = p.ID)
        GROUP BY p.Imie, p.Nazwisko, d.NazwaDzialu";

            DataTable dt = _baza.PobierzDane(sql);

            // Przygotowanie pliku CSV
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Imie;Nazwisko;Dzial;Suma Kosztow");

            foreach (DataRow row in dt.Rows)
            {
                sb.AppendLine($"{row["Imie"]};{row["Nazwisko"]};{row["NazwaDzialu"]};{row["SumaKosztow"]}");
            }

            // Wysłanie pliku do przeglądarki użytkownika
            Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment;filename=Raport_Koszty_Goodyear.csv");
            Response.Charset = "";
            Response.ContentType = "text/csv";
            Response.Output.Write(sb.ToString());
            Response.Flush();
            Response.End();
        }

    }
}