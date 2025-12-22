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

            // Łączymy pracowników ze stanowiskami, a stanowiska z działami
            string sql = @"
        SELECT p.*, s.NazwaStanowiska, d.NazwaDzialu
        FROM Pracownicy p
        JOIN Stanowiska s ON p.ID_Stanowiska = s.ID
        JOIN Dzialy d ON s.ID_Dzialu = d.ID
        ORDER BY p.Nazwisko";

            //    string sql = @"Select p.*, d.NazwaDzialu
            //FROM Pracownicy p
            //JOIN Dzialy d ON p.ID_Dzialu = d.ID
            //ORDER BY p.Nazwisko";

            DataTable dt = _baza.PobierzDane(sql);
            List<Pracownik> lista = new List<Pracownik>();

            // Iterowanie po wynikach z bazy
            if (dt != null)
            {
                foreach (DataRow row in dt.Rows)
                {
                    // Używam konstruktora, który zdefiniowałem w modelu Pracownik
                    var p = new Pracownik(
                        Convert.ToInt32(row["ID"]),
                        row["Imie"].ToString(),
                        row["Nazwisko"].ToString(),
                        row["Rola"].ToString(),
                        Convert.ToInt32(row["ID_Dzialu"]),
                        row["Login"].ToString(),
                        Convert.ToInt32(row["ID_Stanowiska"])
                    );
                    p.NazwaStanowiska = row["NazwaStanowiska"].ToString();
                    lista.Add(p);
                }
            }
            return View(lista);
        }

       
        [HttpGet]
        public ActionResult Edytuj(int? id)
        {
            if (!CzyAdmin()) return RedirectToAction("Login", "Konto");

            // Pobieramy działy do listy rozwijanej
            DataTable dtDzialy = _baza.PobierzDane("SELECT ID, NazwaDzialu FROM Dzialy ORDER BY NazwaDzialu");
            ViewBag.ListaDzialow = dtDzialy;
            // Pobieramy stanowiska do osobnej listy rozwijanej
            //DataTable dtStanowiska = _baza.PobierzDane("SELECT ID, NazwaStanowiska FROM Stanowiska ORDER BY NazwaStanowiska");
            //ViewBag.ListaStanowiska = dtStanowiska;
            // Poprawione zapytanie - musi zawierać ID_Dzialu dla każdego stanowiska
            DataTable dtStanowiska = _baza.PobierzDane("SELECT ID, NazwaStanowiska, ID_Dzialu FROM Stanowiska ORDER BY NazwaStanowiska");
            ViewBag.ListaStanowiska = dtStanowiska;

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
                        Convert.ToInt32(row["ID_Stanowiska"])
                    );
                    return View(p);
                }
            }

            // Tryb Dodawania: Zwracamy pusty obiekt (używając konstruktora z domyślnymi wartościami)
            return View(new Pracownik(1, "", "", "User", 1, "", 1));
        }
        //Implementacja zapisu(Metoda POST) Aby formularz zaczął działać, dodajemy metodę Zapisz. Ponieważ model Pracownik nie ma publicznych setterów(ma tylko get), parametry z formularza odbierzemy bezpośrednio w argumentach metody.
        // Zmieniamy parametr string NazwaStanowiska na int IdStanowiska, aby pasował do wyboru z listy <select>. Aktualizujemy również zapytania SQL, by zapisywały ID w kolumnie ID_Stanowiska.

        [HttpPost]
        public ActionResult Zapisz(int Id, string Imie, string Nazwisko, string Login, int IdDzialu, string Rola, int IdStanowiska, string Haslo)
        {
            if (Session["RolaPracownika"]?.ToString() != "Admin") return RedirectToAction("Login", "Konto");

            string sql;
            if (Id == 0)
            {
                // Teraz zmienna Haslo jest widoczna i zostanie pobrana z formularza
                sql = $@"INSERT INTO Pracownicy (Imie, Nazwisko, Login, Haslo, Rola, ID_Dzialu, ID_Stanowisko, Kraj) 
                 VALUES ('{Imie}', '{Nazwisko}', '{Login}', '{Haslo}', '{Rola}', {IdDzialu}, {IdStanowiska}, 'Polska')";
            }
            else
            {
                sql = $@"UPDATE Pracownicy SET 
                 Imie = '{Imie}', 
                 Nazwisko = '{Nazwisko}', 
                 Login = '{Login}', 
                 Rola = '{Rola}', 
                 ID_Dzialu = {IdDzialu}, 
                 Stanowiska = '{IdStanowiska}'                 
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




        // --- ZARZĄDZANIE DZIAŁAMI I STANOWISKAMI ---

        // Lista działów
        public ActionResult Dzialy()
        {
            if (!CzyAdmin()) return RedirectToAction("Login", "Konto");

            // Pobieramy listę wszystkich działów
            DataTable dtDzialy = _baza.PobierzDane("SELECT * FROM Dzialy ORDER BY NazwaDzialu");

            // Pobieramy listę WSZYSTKICH stanowisk, aby przypisać je do odpowiednich kafelków w widoku
            DataTable dtStanowiska = _baza.PobierzDane("SELECT * FROM Stanowiska ORDER BY NazwaStanowiska");

            // Przekazujemy stanowiska przez ViewBag, a działy jako główny Model
            ViewBag.WszystkieStanowiska = dtStanowiska;

            //// Pobieramy działy wraz z listą przypisanych stanowisk (używając GROUP_CONCAT lub dodatkowego zapytania)
            //string sql = @"SELECT d.*, 
            //      (SELECT COUNT(*) FROM Stanowiska WHERE ID_Dzialu = d.ID) as LiczbaStanowisk 
            //      FROM Dzialy d ORDER BY d.NazwaDzialu";

            //DataTable dt = _baza.PobierzDane(sql);
            return View(dtDzialy);
        }

        // Akcja usuwania działu
        public ActionResult UsunDzial(int id)
        {
            if (!CzyAdmin()) return RedirectToAction("Dzialy");
            try
            {
                _baza.WykonajPolecenie($"DELETE FROM Dzialy WHERE ID = {id}");
                TempData["Sukces"] = "Dział został usunięty.";
            }
            catch (Exception ex)
            {
                TempData["Blad"] = "Nie można usunąć działu, który ma przypisane stanowiska lub pracowników." + ex.Message;
            }
            return RedirectToAction("Dzialy");
        }

        // --- Dodawanie Działu ---
        [HttpGet]
        public ActionResult EdytujDzial(int? id)
        {
            if (!CzyAdmin()) return RedirectToAction("Login", "Konto");

            if (id.HasValue)
            {
                DataTable dt = _baza.PobierzDane($"SELECT * FROM Dzialy WHERE ID = {id.Value}");
                if (dt != null && dt.Rows.Count > 0)
                {
                    // Przekazujemy DataRow do widoku
                    return View(dt.Rows[0]);
                }
            }
            // Dla nowego działu przekazujemy null (widok musi to obsłużyć). Jawne przekazanie null wymagane ze względu na przeciążenie widoku. wywołanie bez parametrów może powodować błąd kompilacji.return View()
            return View((System.Data.DataRow)null);
        }

        [HttpPost]
        public ActionResult ZapiszDzial(int Id, string NazwaDzialu, string SkroconaNazwa)
        {
            if (!CzyAdmin()) return RedirectToAction("Login", "Konto");

            string sql;
            if (Id == 0)
            {
                // Przy dodawaniu (INSERT) NIE podajemy ID - baza nada je automatycznie
                sql = $@"INSERT INTO Dzialy (NazwaDzialu, SkroconaNazwa) 
                 VALUES ('{NazwaDzialu}', '{SkroconaNazwa}')";
            }
            else
            {
                // Przy edycji aktualizujemy obie nazwy
                sql = $@"UPDATE Dzialy SET 
                 NazwaDzialu = '{NazwaDzialu}', 
                 SkroconaNazwa = '{SkroconaNazwa}' 
                 WHERE ID = {Id}";
            }

            try
            {
                _baza.WykonajPolecenie(sql);
                TempData["Sukces"] = "Lista działów została zaktualizowana.";
            }
            catch (Exception ex)
            {
                TempData["Blad"] = "Błąd zapisu: " + ex.Message;
            }

            return RedirectToAction("Dzialy");
        }

        // --- ZARZĄDZANIE STANOWISKAMI ---

        [HttpGet]
        public ActionResult EdytujStanowisko(int? id, int? idDzialu)
        {
            if (!CzyAdmin()) return RedirectToAction("Login", "Konto");

            // 1. Przekazujemy ID działu dla nowych stanowisk
            ViewBag.IdDzialu = idDzialu;
            // 2. Pobieramy działy do listy rozwijanej
            DataTable dtDzialy = _baza.PobierzDane("SELECT ID, NazwaDzialu, SkroconaNazwa FROM Dzialy ORDER BY NazwaDzialu");
            ViewBag.ListaDzialow = dtDzialy;

            if (id.HasValue)
            {
                DataTable dt = _baza.PobierzDane($"SELECT * FROM Stanowiska WHERE ID = {id.Value}");
                return View(dt.Rows[0]);
            }
            return View();
        }
        
        [HttpPost]
        public ActionResult ZapiszStanowisko(int Id, string NazwaStanowiska, int ID_Dzialu)
        {
            if (!CzyAdmin()) return RedirectToAction("Login", "Konto");

            string sql = Id == 0
                ? $"INSERT INTO Stanowiska (NazwaStanowiska, ID_Dzialu) VALUES ('{NazwaStanowiska}', {ID_Dzialu})"
                : $"UPDATE Stanowiska SET NazwaStanowiska = '{NazwaStanowiska}', ID_Dzialu = {ID_Dzialu} WHERE ID = {Id}";

            try
            {
                _baza.WykonajPolecenie(sql);
                TempData["Sukces"] = "Lista działów został zaktualizowany. Zapisano stanowisko: " + NazwaStanowiska;
            }
            catch (Exception ex)
            {
                TempData["Blad"] = "Błąd zapisu stanowiska: " + ex.Message;
            }

            return RedirectToAction("Dzialy");
        }

        public ActionResult UsunStanowisko(int id)
        {
            if (!CzyAdmin()) return RedirectToAction("Dzialy");

            try
            {
                // Sprawdzamy, czy jakieś bilingi lub pracownicy nie korzystają z tego stanowiska
                _baza.WykonajPolecenie($"DELETE FROM Stanowiska WHERE ID = {id}");
                TempData["Sukces"] = "Stanowisko zostało usunięte z listy.";
            }
            catch (Exception ex)
            {
                TempData["Blad"] = "Nie można usunąć stanowiska. Upewnij się, że żaden pracownik nie ma go przypisanego. " + ex.Message;
            }

            return RedirectToAction("Dzialy");
        }

        // --- ZARZĄDZANIE SPRZETEM ---

        public ActionResult Urzadzenia(string szukanaFraza)
        {
            if (!CzyAdmin()) return RedirectToAction("Login", "Konto");

            // Budujemy zapytanie z JOIN, aby móc szukać po Nazwisku pracownika
            string sql = @"
        SELECT u.*, p.Imie, p.Nazwisko, (p.Imie + ' ' + p.Nazwisko) AS PrzypisanyPracownik
        FROM Urzadzenia u
        LEFT JOIN Pracownicy p ON u.ID_Pracownika = p.ID";

            if (!string.IsNullOrEmpty(szukanaFraza))
            {
                // Użycie LIKE '%...%' pozwala znaleźć frazę w dowolnym miejscu ciągu (np. fragment IMEI)
                sql += $@" WHERE u.IMEI_MAC LIKE '%{szukanaFraza}%' 
                   OR u.Model LIKE '%{szukanaFraza}%' 
                   OR u.NrInwentarzowy LIKE '%{szukanaFraza}%' 
                   OR p.Nazwisko LIKE '%{szukanaFraza}%'";
            }

            DataTable dt = _baza.PobierzDane(sql);

            // Przekazujemy frazę z powrotem, aby input w wyszukiwarce nie stał się pusty po kliknięciu "Filtruj"
            ViewBag.OstatniaFraza = szukanaFraza;

            return View(dt);
        }

        [HttpGet]
        public ActionResult EdytujUrzadzenie(int? id)
        {
            if (!CzyAdmin()) return RedirectToAction("Login", "Konto");

            // Pobieramy listę pracowników do dropdowna, aby móc przypisać im sprzęt
            DataTable dtPracownicy = _baza.PobierzDane("SELECT ID, Imie + ' ' + Nazwisko AS Nazwa FROM Pracownicy ORDER BY Nazwisko");
            ViewBag.ListaPracownikow = dtPracownicy;

            if (id.HasValue)
            {
                // Tryb EDYCJI
                DataTable dt = _baza.PobierzDane($"SELECT * FROM Urzadzenia WHERE ID = {id.Value}");
                if (dt != null && dt.Rows.Count > 0)
                {
                    return View(dt.Rows[0]);
                }
            }

            // Tryb DODAWANIA (zwraca pusty widok)
            return View();
        }

        [HttpPost]
        public ActionResult ZapiszUrzadzenie(int ID, string Aparat, string Model, string IMEI_MAC, string SN, string NrInwentarzowy, string Status, int? ID_Pracownika)
        {
            if (!CzyAdmin()) return RedirectToAction("Login", "Konto");

            // Obsługa NULL dla pracownika (jeśli urządzenie jest w magazynie)
            string pracownikVal = ID_Pracownika.HasValue ? ID_Pracownika.Value.ToString() : "NULL";
            string sql;

            if (ID == 0)
            {
                sql = $@"INSERT INTO Urzadzenia (Aparat, Model, IMEI_MAC, SN, Status, NrInwentarzowy, ID_Pracownika) 
                 VALUES ('{Aparat}', '{Model}', '{IMEI_MAC}', '{SN}', '{Status}', '{NrInwentarzowy}', {pracownikVal})";
            }
            else
            {
                sql = $@"UPDATE Urzadzenia SET 
                 Aparat='{Aparat}', Model='{Model}', IMEI_MAC='{IMEI_MAC}', SN='{SN}', 
                 Status='{Status}', NrInwentarzowy='{NrInwentarzowy}', ID_Pracownika={pracownikVal} 
                 WHERE ID={ID}";
            }

            _baza.WykonajPolecenie(sql);
            TempData["Sukces"] = "Dane urządzenia zostały zaktualizowane.";
            return RedirectToAction("Urzadzenia");
        }

        // Metoda usuwanie Urządzenia przez wycofanie zamiast fizycznego usunięcia

        public ActionResult WycofajUrzadzenie(int id)
        {
            if (!CzyAdmin()) return RedirectToAction("Urzadzenia");
            try
            {
                _baza.WykonajPolecenie($"UPDATE Urzadzenia SET Status = 'Wycofane' WHERE ID = {id}");
                TempData["Sukces"] = "Urządzenie zostało wycofane z użytku.";
            }
            catch (Exception ex)
            {
                TempData["Blad"] = "Nie można wycofać urządzenia. " + ex.Message;
            }
            return RedirectToAction("Urzadzenia");
        }



        // --- SEKCJA IMPORTU BILINGÓW Z PLIKU CSV ---

        // Metoda wyświetlająca stronę wyboru pliku CSV
        [HttpGet]
        public ActionResult Import()
        {
            if (!CzyAdmin()) return RedirectToAction("Login", "Konto");
            return View();
        }

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