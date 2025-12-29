using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
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
                // Jeśli admin nie podał hasła, używamy domyślnego Welcome123
                string finalneHaslo = string.IsNullOrEmpty(Haslo) ? "Welcome123" : Haslo;
                //string.IsNullOrEmpty(Haslo) ? "Welcome123" : Haslo;
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
                 ID_Stanowiska = '{IdStanowiska}'                 
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

        // --- Zarządzanie Numerami Telefonicznymi ---
        // --- Telefony Komórkowe ---

        // 1. Lista numerów z wyszukiwarką po wszystkich kolumnach
        public ActionResult NumeryKomorkowe(string szukanaFraza)
        {
            if (!CzyAdmin()) return RedirectToAction("Login", "Konto");

            string sql = @"
        SELECT n.*, p.Imie + ' ' + p.Nazwisko AS PrzypisanyPracownik
        FROM NumeryKomorkowe n
        LEFT JOIN Pracownicy p ON n.ID_Pracownika = p.ID";

            if (!string.IsNullOrEmpty(szukanaFraza))
            {
                sql += $@" WHERE n.Numer LIKE '%{szukanaFraza}%' 
                   OR n.NumerKarty LIKE '%{szukanaFraza}%' 
                   OR n.PIN LIKE '%{szukanaFraza}%' 
                   OR n.PUK LIKE '%{szukanaFraza}%'
                   OR n.PlanOpis LIKE '%{szukanaFraza}%'
                   OR n.Status LIKE '%{szukanaFraza}%'
                   OR p.Nazwisko LIKE '%{szukanaFraza}%'";
            }

            DataTable dt = _baza.PobierzDane(sql);
            ViewBag.OstatniaFraza = szukanaFraza;
            return View(dt);
        }
        // Usuwanie numeru za pomocą dezaktywacji i ustawianie parametru nie aktywny
        public ActionResult DezaktywujNumer(int id)
        {
            if (!CzyAdmin()) return RedirectToAction("NumeryKomorkowe");

            // Zmiana statusu na 'nie aktywny' i odpięcie pracownika
            string sql = $"UPDATE NumeryKomorkowe SET Status = 'nie aktywny', ID_Pracownika = NULL WHERE ID = {id}";

            try
            {
                _baza.WykonajPolecenie(sql);
                TempData["Sukces"] = "Numer został zdezaktywowany i przeniesiony do rezerwy.";
            }
            catch (Exception ex)
            {
                TempData["Blad"] = "Błąd: " + ex.Message;
            }

            return RedirectToAction("NumeryKomorkowe");
        }

        // 2. Widok dodawania/edycji
        [HttpGet]
        public ActionResult EdytujNumer(int? id)
        {
            if (!CzyAdmin()) return RedirectToAction("Login", "Konto");

            ViewBag.ListaPracownikow = _baza.PobierzDane("SELECT ID, Imie + ' ' + Nazwisko AS Nazwa FROM Pracownicy ORDER BY Nazwisko");

            if (id.HasValue)
            {
                DataTable dt = _baza.PobierzDane($"SELECT * FROM NumeryKomorkowe WHERE ID = {id.Value}");
                if (dt != null && dt.Rows.Count > 0) return View(dt.Rows[0]);
            }
            return View();
        }

        // 3. Zapis zmian (INSERT/UPDATE)
        [HttpPost]
        public ActionResult ZapiszNumer(int ID, string Numer, string NumerKarty, string PIN, string PUK, string PlanOpis, string Status, int? ID_Pracownika)
        {
            if (!CzyAdmin()) return RedirectToAction("Login", "Konto");

            string pracownikSql = ID_Pracownika.HasValue ? ID_Pracownika.Value.ToString() : "NULL";
            string sql = ID == 0
                ? $@"INSERT INTO NumeryKomorkowe (Numer, NumerKarty, PIN, PUK, PlanOpis, Status, ID_Pracownika) 
             VALUES ('{Numer}', '{NumerKarty}', '{PIN}', '{PUK}', '{PlanOpis}', '{Status}', {pracownikSql})"
                : $@"UPDATE NumeryKomorkowe SET 
             Numer='{Numer}', NumerKarty='{NumerKarty}', PIN='{PIN}', PUK='{PUK}', 
             PlanOpis='{PlanOpis}', Status='{Status}', ID_Pracownika={pracownikSql} WHERE ID={ID}";

            _baza.WykonajPolecenie(sql);
            TempData["Sukces"] = "Dane numeru zostały pomyślnie zaktualizowane.";
            return RedirectToAction("NumeryKomorkowe");
        }

        // --- SEKCJA ZARZĄZANIA NUMERAMI STACJONARNYMI ---

        // Wyświetlanie listy z wyszukiwarką
        public ActionResult NumeryStacjonarne(string szukanaFraza)
        {
            if (!CzyAdmin()) return RedirectToAction("Login", "Konto");

            string sql = @"
        SELECT ns.*, p.Imie + ' ' + p.Nazwisko AS PrzypisanyPracownik
        FROM NumeryStacjonarne ns
        LEFT JOIN Pracownicy p ON ns.ID_Pracownika = p.ID";

            if (!string.IsNullOrEmpty(szukanaFraza))
            {
                sql += $@" WHERE ns.Numer LIKE '%{szukanaFraza}%' 
                   OR ns.LiniaTyp LIKE '%{szukanaFraza}%' 
                   OR ns.Opis LIKE '%{szukanaFraza}%' 
                   OR ns.StatusCOR LIKE '%{szukanaFraza}%'
                   OR p.Nazwisko LIKE '%{szukanaFraza}%'";
            }

            DataTable dt = _baza.PobierzDane(sql);
            ViewBag.OstatniaFraza = szukanaFraza;
            return View(dt);
        }

        // Widok edycji
        [HttpGet]
        public ActionResult EdytujNumerStacjonarny(int? id)
        {
            if (!CzyAdmin()) return RedirectToAction("Login", "Konto");

            ViewBag.ListaPracownikow = _baza.PobierzDane("SELECT ID, Imie + ' ' + Nazwisko AS Nazwa FROM Pracownicy ORDER BY Nazwisko");

            if (id.HasValue)
            {
                DataTable dt = _baza.PobierzDane($"SELECT * FROM NumeryStacjonarne WHERE ID = {id.Value}");
                if (dt != null && dt.Rows.Count > 0) return View(dt.Rows[0]);
            }
            return View();
        }

        // Zapis (INSERT / UPDATE) Dodajemy nowy lub edydtujemy już istniejący
        [HttpPost]
        public ActionResult ZapiszNumerStacjonarny(int ID, string Numer, string LiniaTyp, int? ID_Pracownika, string PrefiksKraj, string PrefiksMiasto, string Opis, string StatusCOR)
        {
            if (!CzyAdmin()) return RedirectToAction("Login", "Konto");

            string pracownikIdSql = ID_Pracownika.HasValue ? ID_Pracownika.Value.ToString() : "NULL";
            string sql = ID == 0
                ? $@"INSERT INTO NumeryStacjonarne (Numer, LiniaTyp, ID_Pracownika, PrefiksKraj, PrefiksMiasto, Opis, StatusCOR) 
             VALUES ('{Numer}', '{LiniaTyp}', {pracownikIdSql}, '{PrefiksKraj}', '{PrefiksMiasto}', '{Opis}', '{StatusCOR}')"
                : $@"UPDATE NumeryStacjonarne SET 
             Numer='{Numer}', LiniaTyp='{LiniaTyp}', ID_Pracownika={pracownikIdSql}, 
             PrefiksKraj='{PrefiksKraj}', PrefiksMiasto='{PrefiksMiasto}', Opis='{Opis}', StatusCOR='{StatusCOR}' 
             WHERE ID={ID}";

            _baza.WykonajPolecenie(sql);
            TempData["Sukces"] = "Dane numeru stacjonarnego zostały zaktualizowane.";
            return RedirectToAction("NumeryStacjonarne");
        }


        // --- SEKCJA IMPORTU BILINGÓW Z PLIKU CSV ---

        // Metoda wyświetlająca stronę wyboru pliku CSV

        // V1.3

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
                    string tabelaSQL = (typ == "kom") ? "BilingiKomorkowe" : "BilingiStacjonarne";
                    int licznik = 0;
                    bool czyUsunietoStaraFakture = false;
                    string numerFakturyInfo = "nieznany";

                    using (var reader = new System.IO.StreamReader(plikBilingowy.InputStream))
                    {
                        reader.ReadLine(); // Pomijam nagłówek w pliku bilingowym

                        while (!reader.EndOfStream)
                        {
                            var linia = reader.ReadLine();
                            if (string.IsNullOrWhiteSpace(linia)) continue;

                            var wartosci = linia.Split(';');
                            if (wartosci.Length < 9) continue;

                            // --- POBRANIE NR FAKTURY I SPRAWDZENIE CZY ISTNIEJE W TD JEŚLI TAK TO USUWAMY I WGRYWAMY NOWĄ ---
                            string nrFaktury = wartosci[8].Trim().Replace("'", "''");

                            // Używamy zmiennej czyUsunietoStaraFakture, aby DELETE wykonał się tylko RAZ
                            if (!czyUsunietoStaraFakture && !string.IsNullOrEmpty(nrFaktury))
                            {
                                _baza.WykonajPolecenie($"DELETE FROM {tabelaSQL} WHERE NrFaktury = '{nrFaktury}'");
                                czyUsunietoStaraFakture = true; // Zmieniamy wartość, flaga jest teraz "użyta"
                                numerFakturyInfo = nrFaktury;
                            }

                            // --- 2: KONWERSJA DATY ---
                            string dataDlaSQL;
                            if (DateTime.TryParseExact(wartosci[0], "dd.MM.yyyy HH:mm",
                                System.Globalization.CultureInfo.InvariantCulture,
                                System.Globalization.DateTimeStyles.None, out DateTime dt))
                            {
                                dataDlaSQL = dt.ToString("yyyy-MM-dd HH:mm:ss");
                            }
                            else
                            {
                                DateTime.TryParse(wartosci[0], out dt);
                                dataDlaSQL = dt.ToString("yyyy-MM-dd HH:mm:ss");
                            }

                            // --- 3: PRZYGOTOWANIE DANYCH ---
                            string numerA = KonwertujNumer(wartosci[1]);
                            string numerB = KonwertujNumer(wartosci[2]);
                            string typPol = wartosci[3].Replace("'", "''");
                            string czas = wartosci[5];
                            string netto = wartosci[6].Replace(',', '.');
                            string brutto = wartosci[7].Replace(',', '.');

                            // --- 4: DEFINICJA I UŻYCIE SQL ---
                            // Deklarujemy 'string sql' bezpośrednio przed wykonaniem
                            string sql = $@"INSERT INTO {tabelaSQL} 
                        (DataPolaczenia, NumerTelefonu, NumerWybierany, TypPolaczenia, CzasTrwania, KwotaNetto, KwotaBrutto, NrFaktury)
                        VALUES ('{dataDlaSQL}', '{numerA}', '{numerB}', '{typPol}', '{czas}', {netto}, {brutto}, '{nrFaktury}')";

                            _baza.WykonajPolecenie(sql);
                            licznik++;
                        }

                        TempData["Sukces"] = $"Pomyślnie zaimportowano {licznik} rekordów. Faktura: {numerFakturyInfo}.";
                    }
                }
                catch (Exception ex)
                {
                    TempData["Blad"] = "Błąd: " + ex.Message;
                }
            }
            return RedirectToAction("Index");
        }


        // Funkcja pomocnicza do naprawy formatu naukowego (np. 4,815E+10 -> 48150000000)
        private string KonwertujNumer(string raw)
        {
            if (string.IsNullOrWhiteSpace(raw)) return "";
            raw = raw.Trim().Replace(" ", "");

            if (raw.Contains("E+"))
            {
                if (double.TryParse(raw.Replace(",", "."), System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out double parsed))
                {
                    return parsed.ToString("F0");
                }
            }
            return raw;
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

        // --- SEKCJA POBIERANIA BILINGÓW DO PLIKU CSV ---


        //private List<Biling> PobierzDaneZTablei(string tabela, int m, int r, DateTime? od, DateTime? doDaty, string fraza, int? dzialId, string manager)
        //{
        //    // Budujemy zapytanie bazowe
        //    string sql = $@"SELECT b.DataPolaczenia, b.NumerTelefonu, b.KwotaNetto, b.KwotaBrutto, b.NrFaktury, 
        //                   p.Imie + ' ' + p.Nazwisko AS Pracownik, p.MenagerName AS Manager, d.NazwaDzialu AS Dzial
        //            FROM {tabela} b
        //            LEFT JOIN Pracownicy p ON ... -- Twoje JOINy
        //            LEFT JOIN Dzialy d ON p.ID_Dzialu = d.ID
        //            WHERE 1=1";

        //    // Priorytet kalendarza
        //    if (od.HasValue && doDaty.HasValue)
        //    {
        //        sql += $" AND b.DataPolaczenia >= '{od:yyyy-MM-dd}' AND b.DataPolaczenia <= '{doDaty:yyyy-MM-dd} 23:59:59'";
        //    }
        //    else
        //    {
        //        sql += $" AND MONTH(b.DataPolaczenia) = {m} AND YEAR(b.DataPolaczenia) = {r}";
        //    }

        //    // Pozostałe filtry
        //    if (!string.IsNullOrEmpty(fraza)) sql += $" AND ..."; // Twoja logika frazy

        //    DataTable dt = _baza.PobierzDane(sql);

        //    // Mapowanie DataTable na List<Biling>
        //    return dt.AsEnumerable().Select(row => new Biling
        //    {
        //        DataPolaczenia = row.Field<DateTime>("DataPolaczenia"),
        //        NumerTelefonu = row.Field<string>("NumerTelefonu"),
        //        // ... reszta pól
        //    }).ToList();
        //}







        // //--- 1. METODA WYŚWIETLAJĄCA STRONĘ RAPORTÓW  ---

        //public ActionResult Raporty(int? miesiac, int? rok, string fraza)
        //{
        //    int m, r;
        //    // Logika domyślnego bilingu (sqlOstatnia), jeśli parametry są puste
        //    if (!miesiac.HasValue || !rok.HasValue)
        //    {
        //        // ... Twoje zapytanie TOP 1 YEAR/MONTH ...
        //        m = 12; r = 2025; // Przykład po znalezieniu
        //    }
        //    else
        //    {
        //        m = miesiac.Value; r = rok.Value;
        //    }

        //    var model = new RaportViewModel
        //    {
        //        WybranyMiesiac = m,
        //        WybranyRok = r,
        //        Fraza = fraza,
        //        Komorkowe = PobierzDane("BilingiKomorkowe", m, r, fraza),
        //        Stacjonarne = PobierzDane("BilingiStacjonarne", m, r, fraza)
        //    };

        //    return View(model);
        //}

        //// Uniwersalna metoda mapująca dane na klasę Biling
        //private List<Biling> PobierzDane(string tabela, int m, int r, string fraza)
        //{
        //    string sql = $@"SELECT * FROM {tabela} WHERE MONTH(DataPolaczenia) = {m} AND YEAR(DataPolaczenia) = {r}";
        //    if (!string.IsNullOrEmpty(fraza)) sql += $" AND (NumerTelefonu LIKE '%{fraza}%')";

        //    DataTable dt = _baza.PobierzDane(sql);
        //    var lista = new List<Biling>();
        //    foreach (DataRow row in dt.Rows)
        //    {
        //        lista.Add(new Biling
        //        {
        //            DataPolaczenia = Convert.ToDateTime(row["DataPolaczenia"]),
        //            NumerTelefonu = row["NumerTelefonu"].ToString(),
        //            Brutto = Convert.ToDecimal(row["KwotaBrutto"]),
        //            Typ = tabela.Contains("Komorkowe") ? "Komórkowy" : "Stacjonarny"
        //        });
        //    }
        //    return lista;
        //}



        public ActionResult Raporty(int? miesiac, int? rok, string fraza, string nrFaktury, int? dzialId, string manager, DateTime? od, DateTime? doDaty, int strona = 1)//(string fraza, string nrFaktury, int? dzialId, string manager, DateTime? od, DateTime? doDaty, int strona = 1)
        {
            if (!CzyAdmin()) return RedirectToAction("Login", "Konto");

            // 1. Ustalenie domyślnego miesiąca i roku, jeśli nie wybrano filtrów
            if (!miesiac.HasValue || !rok.HasValue)
            {
                string sqlOstatnia = @"SELECT TOP 1 YEAR(DataPolaczenia) as R, MONTH(DataPolaczenia) as M 
                               FROM (SELECT DataPolaczenia FROM BilingiKomorkowe UNION ALL SELECT DataPolaczenia FROM BilingiStacjonarne) AS T 
                               ORDER BY DataPolaczenia DESC";
                DataTable dtOstatnia = _baza.PobierzDane(sqlOstatnia);
                if (dtOstatnia.Rows.Count > 0)
                {
                    rok = Convert.ToInt32(dtOstatnia.Rows[0]["R"]);
                    miesiac = Convert.ToInt32(dtOstatnia.Rows[0]["M"]);
                }
                else
                {
                    rok = DateTime.Now.Year;
                    miesiac = DateTime.Now.Month;
                }
            }

            ViewBag.Dzialy = _baza.PobierzDane("SELECT ID, NazwaDzialu FROM Dzialy ORDER BY NazwaDzialu");
            ViewBag.WybranyMiesiac = miesiac;
            ViewBag.WybranyRok = rok;

            int rozmiarStrony = 50;
            int pomin = (strona - 1) * rozmiarStrony;


            try
            {
                // 1. Logika określenia zakresu czasu (Priorytet dla kalendarza)
                string warunekCzasu;
                if (od.HasValue || doDaty.HasValue)
                {
                    List<string> czesciDaty = new List<string>();
                    if (od.HasValue) czesciDaty.Add($"b.DataPolaczenia >= '{od.Value:yyyy-MM-dd}'");
                    if (doDaty.HasValue) czesciDaty.Add($"b.DataPolaczenia <= '{doDaty.Value:yyyy-MM-dd} 23:59:59'");
                    warunekCzasu = string.Join(" AND ", czesciDaty);
                }
                else
                {
                    warunekCzasu = $"MONTH(b.DataPolaczenia) = {miesiac} AND YEAR(b.DataPolaczenia) = {rok}";
                }

                // 2. Pozostałe filtry tekstowe
                string filtryDodatkowe = "";
                if (!string.IsNullOrEmpty(fraza)) filtryDodatkowe += $" AND (NumerTelefonu LIKE '%{fraza}%' OR Pracownik LIKE '%{fraza}%')";
                if (dzialId.HasValue) filtryDodatkowe += $" AND DzialID = {dzialId.Value}";
                if (!string.IsNullOrEmpty(manager)) filtryDodatkowe += $" AND MenagerName LIKE '%{manager}%'";
                if (!string.IsNullOrEmpty(nrFaktury)) filtryDodatkowe += $" AND NrFaktury = '{nrFaktury}'";

                // 3. Główny SQL (jako baza pod liczenie i dane)
                string sqlBazowy = BilingService.GenerujSqlBazowy(warunekCzasu); // pracownikId zostaje null

        //        string sqlBazowy = $@"
        //SELECT b.DataPolaczenia, b.NumerTelefonu, b.KwotaNetto, b.KwotaBrutto, b.NrFaktury, 
        //       p.Imie + ' ' + p.Nazwisko AS Pracownik, p.MenagerName, d.ID AS DzialID, 
        //       d.NazwaDzialu AS Dzial, 'Komórkowy' AS Typ
        //FROM BilingiKomorkowe b
        //LEFT JOIN NumeryKomorkowe n ON (CASE WHEN LEN(b.NumerTelefonu) > 9 THEN RIGHT(b.NumerTelefonu, 9) ELSE b.NumerTelefonu END) = n.Numer
        //LEFT JOIN Pracownicy p ON n.ID_Pracownika = p.ID
        //LEFT JOIN Dzialy d ON p.ID_Dzialu = d.ID
        //WHERE {warunekCzasu}
        //UNION ALL
        //SELECT b.DataPolaczenia, b.NumerTelefonu, b.KwotaNetto, b.KwotaBrutto, b.NrFaktury, 
        //       p.Imie + ' ' + p.Nazwisko AS Pracownik, p.MenagerName, d.ID AS DzialID,
        //       d.NazwaDzialu AS Dzial, 'Stacjonarny' AS Typ
        //FROM BilingiStacjonarne b
        //LEFT JOIN NumeryStacjonarne n ON (CASE WHEN b.NumerTelefonu LIKE '4814%' OR b.NumerTelefonu LIKE '4822%' THEN RIGHT(b.NumerTelefonu, 7) ELSE b.NumerTelefonu END) = n.Numer
        //LEFT JOIN Pracownicy p ON n.ID_Pracownika = p.ID
        //LEFT JOIN Dzialy d ON p.ID_Dzialu = d.ID
        //WHERE {warunekCzasu}";

                // 4. Zapytanie LICZĄCE całkowitą ilość rekordów
                string sqlLiczenie = $@"SELECT COUNT(*) FROM ({sqlBazowy}) AS T WHERE 1=1 {filtryDodatkowe}";
                DataTable dtLiczenie = _baza.PobierzDane(sqlLiczenie);
                int lacznieRekordow = Convert.ToInt32(dtLiczenie.Rows[0][0]);
                ViewBag.LiczbaStron = (int)Math.Ceiling((double)lacznieRekordow / rozmiarStrony);

                // 5. Zapytanie o konkretne DANE dla aktualnej strony
                string sqlDane = $@"SELECT * FROM ({sqlBazowy}) AS Zbiorcze 
                        WHERE 1=1 {filtryDodatkowe} 
                        ORDER BY DataPolaczenia DESC 
                        OFFSET {pomin} ROWS FETCH NEXT {rozmiarStrony} ROWS ONLY";

                DataTable dt = _baza.PobierzDane(sqlDane);

                // Ustawienie statusów dla widoku
                ViewBag.AktualnaStrona = strona;
                ViewBag.BrakKomorkowych = dt.AsEnumerable().All(r => r["Typ"].ToString() != "Komórkowy");
                ViewBag.BrakStacjonarnych = dt.AsEnumerable().All(r => r["Typ"].ToString() != "Stacjonarny");

                return View(dt);

            }
            catch (Exception ex)
            {
                ViewBag.Blad = "Błąd bazy danych: " + ex.Message;
                return View(new DataTable());
            }
        }


        //public ActionResult Raporty(string fraza, string nrFaktury, int? dzialId, string manager, DateTime? od, DateTime? doDaty, int strona = 1)
        //{
        //    if (!CzyAdmin()) return RedirectToAction("Login", "Konto");

        //    // Ustalenie domyślnego miesiąca i roku, jeśli nie wybrano filtrów
        //    if (!miesiac.HasValue || !rok.HasValue)
        //    {
        //        string sqlOstatnia = @"SELECT TOP 1 YEAR(DataPolaczenia) as R, MONTH(DataPolaczenia) as M 
        //                               FROM (SELECT DataPolaczenia FROM BilingiKomorkowe UNION ALL SELECT DataPolaczenia FROM BilingiStacjonarne) AS T 
        //                               ORDER BY DataPolaczenia DESC";
        //        DataTable dtOstatnia = _baza.PobierzDane(sqlOstatnia);
        //        if (dtOstatnia.Rows.Count > 0)
        //        {
        //            rok = Convert.ToInt32(dtOstatnia.Rows[0]["R"]);
        //            miesiac = Convert.ToInt32(dtOstatnia.Rows[0]["M"]);
        //        }
        //        else
        //        {
        //            rok = DateTime.Now.Year;
        //            miesiac = DateTime.Now.Month;
        //        }
        //    }

        //    //// Jeśli nrFaktury jest pusty, znajdźmy najnowszą fakturę w bazie
        //    //if (string.IsNullOrEmpty(nrFaktury) && !od.HasValue)
        //    //{
        //    //    string sqlOstatnia = "SELECT TOP 1 NrFaktury FROM (SELECT NrFaktury, DataPolaczenia FROM BilingiKomorkowe UNION ALL SELECT NrFaktury, DataPolaczenia FROM BilingiStacjonarne) AS T ORDER BY DataPolaczenia DESC";
        //    //    DataTable dtOstatnia = _baza.PobierzDane(sqlOstatnia);
        //    //    if (dtOstatnia.Rows.Count > 0)
        //    //    {
        //    //        nrFaktury = dtOstatnia.Rows[0]["NrFaktury"].ToString();
        //    //    }
        //    //}

        //    // 1: Widok Raportów (Tabela na stronie)
        //    ViewBag.Dzialy = _baza.PobierzDane("SELECT ID, NazwaDzialu FROM Dzialy ORDER BY NazwaDzialu");
        //    ViewBag.WybranyMiesiac = miesiac;
        //    ViewBag.WybranyRok = rok;

        //    string sql = @"
        //SELECT * FROM (
        //    -- CZĘŚĆ KOMÓRKOWA
        //    SELECT b.DataPolaczenia, b.NumerTelefonu, b.KwotaNetto, b.KwotaBrutto, b.NrFaktury, 
        //           p.Imie + ' ' + p.Nazwisko AS Pracownik, p.MenagerName, 
        //           d.NazwaDzialu AS Dzial, d.ID AS DzialID, 'Komórkowy' AS Typ
        //    FROM BilingiKomorkowe b
        //    LEFT JOIN NumeryKomorkowe n ON 
        //        (CASE WHEN LEN(b.NumerTelefonu) > 9 THEN RIGHT(b.NumerTelefonu, 9) ELSE b.NumerTelefonu END) = n.Numer
        //    LEFT JOIN Pracownicy p ON n.ID_Pracownika = p.ID
        //    LEFT JOIN Dzialy d ON p.ID_Dzialu = d.ID

        //    UNION ALL

        //    -- CZĘŚĆ STACJONARNA (z wycinaniem 7 cyfr dla Warszawy 22 i Tarnowa 14)
        //    SELECT b.DataPolaczenia, b.NumerTelefonu, b.KwotaNetto, b.KwotaBrutto, b.NrFaktury, 
        //           p.Imie + ' ' + p.Nazwisko AS Pracownik, p.MenagerName, 
        //           d.NazwaDzialu AS Dzial, d.ID AS DzialID, 'Stacjonarny' AS Typ
        //    FROM BilingiStacjonarne b
        //    LEFT JOIN NumeryStacjonarne n ON 
        //        (CASE 
        //            WHEN b.NumerTelefonu LIKE '4814%' OR b.NumerTelefonu LIKE '4822%' THEN RIGHT(b.NumerTelefonu, 7)
        //            WHEN LEN(b.NumerTelefonu) > 7 THEN RIGHT(b.NumerTelefonu, 7)
        //            ELSE b.NumerTelefonu 
        //         END) = n.Numer
        //    LEFT JOIN Pracownicy p ON n.ID_Pracownika = p.ID
        //    LEFT JOIN Dzialy d ON p.ID_Dzialu = d.ID
        //) AS Zbiorcze WHERE 1=1";


        //    //        string sql = @"
        //    //SELECT * FROM (
        //    //    SELECT b.DataPolaczenia, b.NumerTelefonu, b.KwotaNetto, b.KwotaBrutto, b.NrFaktury, 
        //    //           p.Imie + ' ' + p.Nazwisko AS Pracownik, p.MenagerName, 
        //    //           d.NazwaDzialu AS Dzial, d.ID AS DzialID, 'Komórkowy' AS Typ -- POPRAWKA 2
        //    //    FROM BilingiKomorkowe b
        //    //    JOIN NumeryKomorkowe n ON b.NumerTelefonu = n.Numer
        //    //    JOIN Pracownicy p ON n.ID_Pracownika = p.ID
        //    //    JOIN Dzialy d ON p.ID_Dzialu = d.ID
        //    //    UNION ALL
        //    //    SELECT b.DataPolaczenia, b.NumerTelefonu, b.KwotaNetto, b.KwotaBrutto, b.NrFaktury, 
        //    //           p.Imie + ' ' + p.Nazwisko AS Pracownik, p.MenagerName, 
        //    //           d.NazwaDzialu AS Dzial, d.ID AS DzialID, 'Stacjonarny' AS Typ -- POPRAWKA 2
        //    //    FROM BilingiStacjonarne b
        //    //    JOIN NumeryStacjonarne n ON b.NumerTelefonu = n.Numer
        //    //    JOIN Pracownicy p ON n.ID_Pracownika = p.ID
        //    //    JOIN Dzialy d ON p.ID_Dzialu = d.ID
        //    //) AS Zbiorcze WHERE 1=1";


        //    if (!string.IsNullOrEmpty(fraza)) sql += $" AND (NumerTelefonu LIKE '%{fraza}%' OR Pracownik LIKE '%{fraza}%')";
        //    if (!string.IsNullOrEmpty(nrFaktury)) sql += $" AND NrFaktury = '{nrFaktury}'";
        //    if (dzialId.HasValue) sql += $" AND DzialID = {dzialId.Value}";
        //    if (!string.IsNullOrEmpty(manager)) sql += $" AND MenagerName LIKE '%{manager}%'";
        //    if (od.HasValue) sql += $" AND DataPolaczenia >= '{od.Value:yyyy-MM-dd}'";
        //    if (doDaty.HasValue) sql += $" AND DataPolaczenia <= '{doDaty.Value:yyyy-MM-dd} 23:59:59'";

        //    int rozmiarStrony = 50;
        //    int pomin = (strona - 1) * rozmiarStrony;

        //    //sql += $@" ORDER BY DataPolaczenia DESC 
        //    //   OFFSET {pomin} ROWS 
        //    //   FETCH NEXT {rozmiarStrony} ROWS ONLY";

        //    DataTable dt = _baza.PobierzDane(sql);
        //    // Przekazujemy aktualną stronę do widoku
        //    ViewBag.AktualnaStrona = strona;
        //    ViewBag.NrFaktury = nrFaktury; // Aby formularz wiedział, co jest wybrane

        //    return View(dt);
        //}

        // --- 2. METODA GENERUJĄCA ZBIORCZY RAPORT KSIĘGOWY (Suma na działy) ---
        public void RaportKsiegowy()
        {
            if (!CzyAdmin()) return;

            string sql = @"
    SELECT Dzial, MenagerName, 
           COUNT(*) AS IloscPolaczen, 
           SUM(KwotaNetto) AS SumaNetto, 
           SUM(KwotaBrutto) AS SumaBrutto
    FROM (
        SELECT d.NazwaDzialu AS Dzial, p.MenagerName, b.KwotaNetto, b.KwotaBrutto 
        FROM BilingiKomorkowe b 
        LEFT JOIN NumeryKomorkowe n ON (CASE WHEN LEN(b.NumerTelefonu) > 9 THEN RIGHT(b.NumerTelefonu, 9) ELSE b.NumerTelefonu END) = n.Numer
        LEFT JOIN Pracownicy p ON n.ID_Pracownika = p.ID 
        LEFT JOIN Dzialy d ON p.ID_Dzialu = d.ID
        UNION ALL
        SELECT d.NazwaDzialu AS Dzial, p.MenagerName, b.KwotaNetto, b.KwotaBrutto 
        FROM BilingiStacjonarne b 
        LEFT JOIN NumeryStacjonarne n ON (CASE WHEN b.NumerTelefonu LIKE '4814%' OR b.NumerTelefonu LIKE '4822%' THEN RIGHT(b.NumerTelefonu, 7) ELSE b.NumerTelefonu END) = n.Numer
        LEFT JOIN Pracownicy p ON n.ID_Pracownika = p.ID 
        LEFT JOIN Dzialy d ON p.ID_Dzialu = d.ID
    ) AS Dane
    GROUP BY Dzial, MenagerName";

            //        string sql = @"
            //SELECT Dzial, MenagerName, SUM(KwotaNetto) as SumaNetto, SUM(KwotaBrutto) as SumaBrutto, COUNT(*) as IloscPolaczen
            //FROM (
            //    SELECT d.NazwaDzialu AS Dzial, p.MenagerName, b.KwotaNetto, b.KwotaBrutto FROM BilingiKomorkowe b 
            //    JOIN NumeryKomorkowe n ON b.NumerTelefonu = n.Numer JOIN Pracownicy p ON n.ID_Pracownika = p.ID JOIN Dzialy d ON p.ID_Dzialu = d.ID
            //    UNION ALL
            //    SELECT d.NazwaDzialu AS Dzial, p.MenagerName, b.KwotaNetto, b.KwotaBrutto FROM BilingiStacjonarne b 
            //    JOIN NumeryStacjonarne n ON b.NumerTelefonu = n.Numer JOIN Pracownicy p ON n.ID_Pracownika = p.ID JOIN Dzialy d ON p.ID_Dzialu = d.ID
            //) as Dane
            //GROUP BY Dzial, MenagerName";

            DataTable dt = _baza.PobierzDane(sql);
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Dzial;Manager;Ilosc Polaczen;Suma Netto;Suma Brutto");

            foreach (DataRow row in dt.Rows)
            {
                sb.AppendLine($"{row["Dzial"]};{row["MenagerName"]};{row["IloscPolaczen"]};{row["SumaNetto"]};{row["SumaBrutto"]}");
            }

            Response.Clear();
            Response.AddHeader("content-disposition", "attachment;filename=Raport_Ksiegowy_Goodyear.csv");
            Response.ContentType = "text/csv";
            Response.ContentEncoding = System.Text.Encoding.UTF8;
            Response.Output.Write(sb.ToString());
            Response.Flush();
            Response.End();
        }

        public void EksportujRaport(int? miesiac, int? rok, string fraza, int? dzialId, string manager, DateTime? od, DateTime? doDaty)
        {
            if (!CzyAdmin()) return;

            // 1. Logika określenia zakresu czasu (Identyczna jak w Raporty)
            string warunekCzasu;
            if (od.HasValue || doDaty.HasValue)
            {
                List<string> czesciDaty = new List<string>();
                if (od.HasValue) czesciDaty.Add($"b.DataPolaczenia >= '{od.Value:yyyy-MM-dd}'");
                if (doDaty.HasValue) czesciDaty.Add($"b.DataPolaczenia <= '{doDaty.Value:yyyy-MM-dd} 23:59:59'");
                warunekCzasu = string.Join(" AND ", czesciDaty);
            }
            else
            {
                // Używamy przekazanych parametrów lub domyślnych
                int m = miesiac ?? DateTime.Now.Month;
                int r = rok ?? DateTime.Now.Year;
                warunekCzasu = $"MONTH(b.DataPolaczenia) = {m} AND YEAR(b.DataPolaczenia) = {r}";
            }

            // 2. Filtry dodatkowe
            string filtryDodatkowe = "";
            if (!string.IsNullOrEmpty(fraza)) filtryDodatkowe += $" AND (NumerTelefonu LIKE '%{fraza}%' OR Pracownik LIKE '%{fraza}%')";
            if (dzialId.HasValue) filtryDodatkowe += $" AND DzialID = {dzialId.Value}";
            if (!string.IsNullOrEmpty(manager)) filtryDodatkowe += $" AND MenagerName LIKE '%{manager}%'";

            // 3. Budowa zapytania SQL (UNION ALL dla obu tabel)
            string sql = $@"
    SELECT * FROM (
        SELECT b.DataPolaczenia, b.NumerTelefonu, b.KwotaNetto, b.KwotaBrutto, b.NrFaktury, 
               p.Imie + ' ' + p.Nazwisko AS Pracownik, p.MenagerName, d.NazwaDzialu AS Dzial, d.ID AS DzialID
        FROM BilingiKomorkowe b
        LEFT JOIN NumeryKomorkowe n ON (CASE WHEN LEN(b.NumerTelefonu) > 9 THEN RIGHT(b.NumerTelefonu, 9) ELSE b.NumerTelefonu END) = n.Numer
        LEFT JOIN Pracownicy p ON n.ID_Pracownika = p.ID
        LEFT JOIN Dzialy d ON p.ID_Dzialu = d.ID
        WHERE {warunekCzasu}
        UNION ALL
        SELECT b.DataPolaczenia, b.NumerTelefonu, b.KwotaNetto, b.KwotaBrutto, b.NrFaktury, 
               p.Imie + ' ' + p.Nazwisko AS Pracownik, p.MenagerName, d.NazwaDzialu AS Dzial, d.ID AS DzialID
        FROM BilingiStacjonarne b
        LEFT JOIN NumeryStacjonarne n ON (CASE WHEN b.NumerTelefonu LIKE '4814%' OR b.NumerTelefonu LIKE '4822%' THEN RIGHT(b.NumerTelefonu, 7) ELSE b.NumerTelefonu END) = n.Numer
        LEFT JOIN Pracownicy p ON n.ID_Pracownika = p.ID
        LEFT JOIN Dzialy d ON p.ID_Dzialu = d.ID
        WHERE {warunekCzasu}
    ) AS Zbiorcze WHERE 1=1 {filtryDodatkowe} ORDER BY DataPolaczenia DESC";

            DataTable dt = _baza.PobierzDane(sql);

            // 4. Budowanie pliku CSV
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Data;Numer;Pracownik;Manager;Dzial;Netto;Brutto;Faktura");

            foreach (DataRow row in dt.Rows)
            {
                sb.AppendLine(string.Format("{0:dd.MM.yyyy HH:mm};{1};{2};{3};{4};{5:N2};{6:N2};{7}",
                    row["DataPolaczenia"],
                    row["NumerTelefonu"],
                    row["Pracownik"],
                    row["MenagerName"],
                    row["Dzial"],
                    row["KwotaNetto"],
                    row["KwotaBrutto"],
                    row["NrFaktury"]));
            }

            // 5. Wysyłka pliku do przeglądarki
            Response.Clear();
            Response.AddHeader("content-disposition", "attachment;filename=Raport_Bilingowy.csv");
            Response.ContentType = "text/csv";
            Response.ContentEncoding = System.Text.Encoding.UTF8;
            Response.Write('\uFEFF'); // BOM dla Excela
            Response.Output.Write(sb.ToString());
            Response.End();
        }

        // old
        //        public void EksportujRaport(int? miesiac, int? rok, string fraza, int? dzialId, string manager) // string fraza, string nrFaktury, int? dzialId, string manager, DateTime? od, DateTime? doDaty)
        //        {
        //            if (!CzyAdmin()) return;
        //            // 1. Zabezpieczenie przed brakiem dat - jeśli null, bierzemy obecny miesiąc/rok
        //            int m = miesiac ?? DateTime.Now.Month;
        //            int r = rok ?? DateTime.Now.Year;

        //            // 1. Budujemy zapytanie bazowe (identyczne jak w widoku, aby wyniki były spójne)
        //            string sql = $@"
        //    SELECT * FROM (
        //        SELECT b.DataPolaczenia, b.NumerTelefonu, b.KwotaNetto, b.KwotaBrutto, b.NrFaktury, 
        //               p.Imie + ' ' + p.Nazwisko AS Pracownik, p.MenagerName, 
        //               d.NazwaDzialu AS Dzial, d.ID AS DzialID
        //        FROM BilingiKomorkowe b
        //        LEFT JOIN NumeryKomorkowe n ON (CASE WHEN LEN(b.NumerTelefonu) > 9 THEN RIGHT(b.NumerTelefonu, 9) ELSE b.NumerTelefonu END) = n.Numer
        //        LEFT JOIN Pracownicy p ON n.ID_Pracownika = p.ID
        //        LEFT JOIN Dzialy d ON p.ID_Dzialu = d.ID
        //        WHERE MONTH(b.DataPolaczenia) = {m} AND YEAR(b.DataPolaczenia) = {r}

        //        UNION ALL

        //        SELECT b.DataPolaczenia, b.NumerTelefonu, b.KwotaNetto, b.KwotaBrutto, b.NrFaktury, 
        //               p.Imie + ' ' + p.Nazwisko AS Pracownik, p.MenagerName, 
        //               d.NazwaDzialu AS Dzial, d.ID AS DzialID
        //        FROM BilingiStacjonarne b
        //        LEFT JOIN NumeryStacjonarne n ON (CASE WHEN b.NumerTelefonu LIKE '4814%' OR b.NumerTelefonu LIKE '4822%' THEN RIGHT(b.NumerTelefonu, 7) ELSE b.NumerTelefonu END) = n.Numer
        //        LEFT JOIN Pracownicy p ON n.ID_Pracownika = p.ID
        //        LEFT JOIN Dzialy d ON p.ID_Dzialu = d.ID
        //        WHERE MONTH(b.DataPolaczenia) = {m} AND YEAR(b.DataPolaczenia) = {r}
        //    ) AS Zbiorcze WHERE 1=1";
        ////            string sql = @"
        ////SELECT * FROM (
        ////    -- CZĘŚĆ KOMÓRKOWA
        ////    SELECT b.DataPolaczenia, b.NumerTelefonu, b.KwotaNetto, b.KwotaBrutto, b.NrFaktury, 
        ////           p.Imie + ' ' + p.Nazwisko AS Pracownik, p.MenagerName, 
        ////           d.NazwaDzialu AS Dzial, d.ID AS DzialID, 'Komórkowy' AS Typ
        ////    FROM BilingiKomorkowe b
        ////    LEFT JOIN NumeryKomorkowe n ON 
        ////        (CASE WHEN LEN(b.NumerTelefonu) > 9 THEN RIGHT(b.NumerTelefonu, 9) ELSE b.NumerTelefonu END) = n.Numer
        ////    LEFT JOIN Pracownicy p ON n.ID_Pracownika = p.ID
        ////    LEFT JOIN Dzialy d ON p.ID_Dzialu = d.ID

        //            //    UNION ALL

        //            //    -- CZĘŚĆ STACJONARNA (z wycinaniem 7 cyfr dla Warszawy 22 i Tarnowa 14)
        //            //    SELECT b.DataPolaczenia, b.NumerTelefonu, b.KwotaNetto, b.KwotaBrutto, b.NrFaktury, 
        //            //           p.Imie + ' ' + p.Nazwisko AS Pracownik, p.MenagerName, 
        //            //           d.NazwaDzialu AS Dzial, d.ID AS DzialID, 'Stacjonarny' AS Typ
        //            //    FROM BilingiStacjonarne b
        //            //    LEFT JOIN NumeryStacjonarne n ON 
        //            //        (CASE 
        //            //            WHEN b.NumerTelefonu LIKE '4814%' OR b.NumerTelefonu LIKE '4822%' THEN RIGHT(b.NumerTelefonu, 7)
        //            //            WHEN LEN(b.NumerTelefonu) > 7 THEN RIGHT(b.NumerTelefonu, 7)
        //            //            ELSE b.NumerTelefonu 
        //            //         END) = n.Numer
        //            //    LEFT JOIN Pracownicy p ON n.ID_Pracownika = p.ID
        //            //    LEFT JOIN Dzialy d ON p.ID_Dzialu = d.ID
        //            //) AS Zbiorcze WHERE 1=1";
        //            //        string sql = @"
        //            //SELECT * FROM (
        //            //    SELECT b.DataPolaczenia, b.NumerTelefonu, b.KwotaNetto, b.KwotaBrutto, b.NrFaktury, 
        //            //           p.Imie + ' ' + p.Nazwisko AS Pracownik, p.MenagerName, 
        //            //           d.NazwaDzialu AS Dzial, d.ID AS DzialID
        //            //    FROM BilingiKomorkowe b
        //            //    JOIN NumeryKomorkowe n ON b.NumerTelefonu = n.Numer
        //            //    JOIN Pracownicy p ON n.ID_Pracownika = p.ID
        //            //    JOIN Dzialy d ON p.ID_Dzialu = d.ID
        //            //    UNION ALL
        //            //    SELECT b.DataPolaczenia, b.NumerTelefonu, b.KwotaNetto, b.KwotaBrutto, b.NrFaktury, 
        //            //           p.Imie + ' ' + p.Nazwisko AS Pracownik, p.MenagerName, 
        //            //           d.NazwaDzialu AS Dzial, d.ID AS DzialID
        //            //    FROM BilingiStacjonarne b
        //            //    JOIN NumeryStacjonarne n ON b.NumerTelefonu = n.Numer
        //            //    JOIN Pracownicy p n.ID_Pracownika = p.ID
        //            //    JOIN Dzialy d ON p.ID_Dzialu = d.ID
        //            //) AS Zbiorcze WHERE 1=1";

        //            // 2. Dodajemy filtry, aby użytkownik pobrał to, co widzi przefiltrowane na ekranie
        //            if (!string.IsNullOrEmpty(fraza)) sql += $" AND (NumerTelefonu LIKE '%{fraza}%' OR Pracownik LIKE '%{fraza}%')";
        //            //if (!string.IsNullOrEmpty(nrFaktury)) sql += $" AND NrFaktury = '{nrFaktury}'";
        //            if (dzialId.HasValue) sql += $" AND DzialID = {dzialId.Value}";
        //            if (!string.IsNullOrEmpty(manager)) sql += $" AND MenagerName LIKE '%{manager}%'";
        //            //if (od.HasValue) sql += $" AND DataPolaczenia >= '{od.Value:yyyy-MM-dd}'";
        //            //if (doDaty.HasValue) sql += $" AND DataPolaczenia <= '{doDaty.Value:yyyy-MM-dd} 23:59:59'";
        //            sql += " ORDER BY DataPolaczenia DESC"; // Sortowanie dla czytelności pliku

        //            DataTable dt = _baza.PobierzDane(sql);

        //            // 3. Budowanie pliku CSV (z polskimi znakami)
        //            StringBuilder sb = new StringBuilder();
        //            // Używamy średnika jako separatora (standard dla polskiego Excela)
        //            sb.AppendLine("Data;Numer;Pracownik;Manager;Dzial;Netto;Brutto;Faktura");

        //            foreach (DataRow row in dt.Rows)
        //            {
        //                string linia = string.Format("{0};{1};{2};{3};{4};{5};{6};{7}",
        //                    row["DataPolaczenia"],
        //                    row["NumerTelefonu"],
        //                    row["Pracownik"],
        //                    row["MenagerName"],
        //                    row["Dzial"],
        //                    row["KwotaNetto"],
        //                    row["KwotaBrutto"],
        //                    row["NrFaktury"]);
        //                sb.AppendLine(linia);
        //            }

        //            // 4. Wysłanie pliku
        //            Response.Clear();
        //            //Response.Buffer = true;
        //            Response.AddHeader("content-disposition", "attachment;filename=Raport_Bilingowy_Goodyear.csv");
        //            Response.ContentType = "text/csv";
        //            Response.ContentEncoding = System.Text.Encoding.UTF8; // Ważne dla polskich znaków
        //            Response.Write('\uFEFF'); // BOM dla Excela, żeby poprawnie czytał polskie znaki w UTF-8
        //            Response.Output.Write(sb.ToString());
        //            //Response.Flush();
        //            Response.End();
        //        }

    }
}