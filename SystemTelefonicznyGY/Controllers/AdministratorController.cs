using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using SystemTelefonicznyGY.Logika;
using SystemTelefonicznyGY.Models;

namespace SystemTelefonicznyGY.Controllers
{
    public class AdministratorController : Controller
    {
        // --- WSTRZYKIWANIE SERWISÓW ---
        // Instancje klas z folderu Logika, które wykonują "brudną robotę" (SQL, obliczenia)
        private readonly PracownikService _pracownikService = new PracownikService();
        private readonly DzialyService _dzialyService = new DzialyService();
        private readonly BilingService _bilingService = new BilingService();
        private readonly ZasobyService _zasobyService = new ZasobyService();

        // Metoda pomocnicza sprawdzająca uprawnienia (korzysta z Sesji, więc zostaje w Kontrolerze)
        private bool CzyAdmin()
        {
            return Session["RolaPracownika"] != null && Session["RolaPracownika"].ToString() == "Admin";
        }

        // ==========================================
        // 1. DASHBOARD (Panel Główny)
        // ==========================================
        public ActionResult Index()
        {
            if (!CzyAdmin()) return RedirectToAction("Login", "Konto");

            // Statystyki pobieramy używając serwisu (np. pobieramy listę i liczymy elementy)
            // 1. Pobieramy liczbę pracowników 
            var listaPracownikow = _pracownikService.PobierzListęPracownikow("");
            ViewBag.LiczbaPracownikow = listaPracownikow.Count;

            // 2. Ustalamy datę dla statystyk (np. poprzedni miesiąc, bo wtedy przychodzą faktury)
            DateTime dataRaportu = DateTime.Now.AddMonths(-1);
            string nazwaMiesiaca = dataRaportu.ToString("MMMM yyyy");

            // 3. Pobieramy sumę kosztów z serwisu 
            decimal suma = _bilingService.PobierzSumeKosztow(dataRaportu.Month, dataRaportu.Year);

            // 4. Przekazujemy dane do Widoku
            ViewBag.OstatniMiesiac = nazwaMiesiaca; // To było wcześniej
            ViewBag.OstatniMiesiacNazwa = nazwaMiesiaca; // Twój widok używa też tej nazwy (zobaczyłem w błędzie)
            ViewBag.SumaBilingow = suma; // <--- To jest kluczowe dla naprawy błędu!

            return View();
        }

        // ==========================================
        // 2. ZARZĄDZANIE PRACOWNIKAMI
        // ==========================================
        public ActionResult Pracownicy()
        {
            if (!CzyAdmin()) return RedirectToAction("Login", "Konto");

            // Pobieramy listę z serwisu. Brak SQL w kontrolerze.
            var lista = _pracownikService.PobierzListęPracownikow("");
            return View(lista);
        }

        [HttpGet]
        public ActionResult Edytuj(int? id)
        {
            if (!CzyAdmin()) return RedirectToAction("Login", "Konto");

            // Pobieramy dane słownikowe z serwisów do dropdownów
            ViewBag.ListaDzialow = _dzialyService.PobierzWszystkieDzialy();
            ViewBag.ListaStanowiska = _dzialyService.PobierzStanowiskaZDzialem();

            if (id.HasValue)
            {
                // Pobieramy konkretnego pracownika przez Serwis
                var p = _pracownikService.PobierzPracownikaPoId(id.Value);
                if (p != null) return View(p);
            }

            // Nowy pracownik - domyślny obiekt
            return View(new Pracownik(0, "", "", "User", 1, "", 1));
        }

        [HttpPost]
        public ActionResult Zapisz(int Id, string Imie, string Nazwisko, string Login, int IdDzialu, string Rola, int IdStanowiska, string Haslo)
        {
            if (!CzyAdmin()) return RedirectToAction("Login", "Konto");

            try
            {
                // Przekazujemy dane do serwisu. Serwis decyduje czy to INSERT czy UPDATE.
                _pracownikService.ZapiszPracownika(Id, Imie, Nazwisko, Login, IdDzialu, Rola, IdStanowiska, Haslo);
                TempData["Sukces"] = "Dane zostały pomyślnie zapisane.";
            }
            catch (Exception ex)
            {
                TempData["Blad"] = "Błąd zapisu: " + ex.Message;
            }

            return RedirectToAction("Pracownicy");
        }

        public ActionResult Usun(int id)
        {
            if (!CzyAdmin()) return RedirectToAction("Index");

            try
            {
                // Delegujemy usuwanie do serwisu
                _pracownikService.UsunPracownika(id);
                TempData["Sukces"] = "Pracownik został usunięty.";
            }
            catch (Exception ex)
            {
                TempData["Blad"] = "Nie można usunąć pracownika: " + ex.Message;
            }

            return RedirectToAction("Pracownicy");
        }

        // ==========================================
        // 3. DZIAŁY I STANOWISKA
        // ==========================================
        public ActionResult Dzialy()
        {
            if (!CzyAdmin()) return RedirectToAction("Login", "Konto");

            // Pobieramy dane z serwisu DzialyService
            DataTable dtDzialy = _dzialyService.PobierzWszystkieDzialy();
            ViewBag.WszystkieStanowiska = _dzialyService.PobierzWszystkieStanowiska();

            return View(dtDzialy);
        }

        public ActionResult UsunDzial(int id)
        {
            if (!CzyAdmin()) return RedirectToAction("Dzialy");
            try
            {
                _dzialyService.UsunDzial(id);
                TempData["Sukces"] = "Dział został usunięty.";
            }
            catch (Exception ex)
            {
                TempData["Blad"] = "Błąd: " + ex.Message;
            }
            return RedirectToAction("Dzialy");
        }

        [HttpGet]
        public ActionResult EdytujDzial(int? id)
        {
            if (!CzyAdmin()) return RedirectToAction("Login", "Konto");

            if (id.HasValue)
            {
                // Pobieramy listę i filtrujemy lokalnie (lub dodaj metodę PobierzDzialPoId w serwisie)
                DataTable dt = _dzialyService.PobierzWszystkieDzialy();
                DataRow row = dt.Select($"ID = {id.Value}").FirstOrDefault();
                if (row != null) return View(row);
            }
            return View((DataRow)null);
        }

        [HttpPost]
        public ActionResult ZapiszDzial(int Id, string NazwaDzialu, string SkroconaNazwa)
        {
            if (!CzyAdmin()) return RedirectToAction("Login", "Konto");
            try
            {
                _dzialyService.ZapiszDzial(Id, NazwaDzialu, SkroconaNazwa);
                TempData["Sukces"] = "Dział zapisany.";
            }
            catch (Exception ex)
            {
                TempData["Blad"] = "Błąd: " + ex.Message;
            }
            return RedirectToAction("Dzialy");
        }

        // --- STANOWISKA ---

        [HttpGet]
        public ActionResult EdytujStanowisko(int? id, int? idDzialu)
        {
            if (!CzyAdmin()) return RedirectToAction("Login", "Konto");

            ViewBag.IdDzialu = idDzialu;
            ViewBag.ListaDzialow = _dzialyService.PobierzWszystkieDzialy();

            if (id.HasValue)
            {
                DataTable dt = _dzialyService.PobierzWszystkieStanowiska();
                DataRow row = dt.Select($"ID = {id.Value}").FirstOrDefault();
                if (row != null) return View(row);
            }
            return View();
        }

        [HttpPost]
        public ActionResult ZapiszStanowisko(int Id, string NazwaStanowiska, int ID_Dzialu)
        {
            if (!CzyAdmin()) return RedirectToAction("Login", "Konto");
            try
            {
                _dzialyService.ZapiszStanowisko(Id, NazwaStanowiska, ID_Dzialu);
                TempData["Sukces"] = "Stanowisko zapisane.";
            }
            catch (Exception ex)
            {
                TempData["Blad"] = "Błąd: " + ex.Message;
            }
            return RedirectToAction("Dzialy");
        }

        public ActionResult UsunStanowisko(int id)
        {
            if (!CzyAdmin()) return RedirectToAction("Dzialy");
            try
            {
                _dzialyService.UsunStanowisko(id);
                TempData["Sukces"] = "Stanowisko usunięte.";
            }
            catch (Exception ex)
            {
                TempData["Blad"] = "Błąd: " + ex.Message;
            }
            return RedirectToAction("Dzialy");
        }

        // ==========================================
        // 4. ZARZĄDZANIE SPRZĘTEM (ZasobyService)
        // ==========================================
        public ActionResult Urzadzenia(string szukanaFraza)
        {
            if (!CzyAdmin()) return RedirectToAction("Login", "Konto");

            // Korzystamy z nowego serwisu ZasobyService
            DataTable dt = _zasobyService.PobierzUrzadzenia(szukanaFraza);

            ViewBag.OstatniaFraza = szukanaFraza;
            return View(dt);
        }

        [HttpGet]
        public ActionResult EdytujUrzadzenie(int? id)
        {
            if (!CzyAdmin()) return RedirectToAction("Login", "Konto");

            // Pobieramy listę pracowników do dropdowna (PracownikService) - reuse!
            // Możemy przekonwertować List<Pracownik> na DataTable lub ViewBag, zależnie jak widok to przyjmuje.
            // Tutaj pobieramy prosty DataTable z imionami
            // Dla uproszczenia w modelu thin controller, możemy użyć metody serwisu zwracającej listę i w widoku użyć @model List
            // lub tutaj mapować. Zakładam, że widok oczekuje DataTable, więc można dodać pomocniczą metodę w PracownikService lub użyć bilingu.
            // *Ad-hoc*: użyjmy listy pracowników i przekażmy jako ViewBag
            // ViewBag.ListaPracownikow = _pracownikService.PobierzListęPracownikow("");
            ViewBag.ListaPracownikow = _pracownikService.PobierzPracownikowDoDropdown();

            if (id.HasValue)
            {
                return View(_zasobyService.PobierzUrzadzeniePoId(id.Value));
            }

            return View();
        }

        [HttpPost]
        public ActionResult ZapiszUrzadzenie(int ID, string Aparat, string Model, string IMEI_MAC, string SN, string NrInwentarzowy, string Status, int? ID_Pracownika)
        {
            if (!CzyAdmin()) return RedirectToAction("Login", "Konto");

            _zasobyService.ZapiszUrzadzenie(ID, Aparat, Model, IMEI_MAC, SN, NrInwentarzowy, Status, ID_Pracownika);

            TempData["Sukces"] = "Dane urządzenia zostały zaktualizowane.";
            return RedirectToAction("Urzadzenia");
        }

        public ActionResult WycofajUrzadzenie(int id)
        {
            if (!CzyAdmin()) return RedirectToAction("Urzadzenia");
            try
            {
                _zasobyService.WycofajUrzadzenie(id);
                TempData["Sukces"] = "Urządzenie wycofane.";
            }
            catch (Exception ex)
            {
                TempData["Blad"] = "Błąd: " + ex.Message;
            }
            return RedirectToAction("Urzadzenia");
        }

        // ==========================================
        // 5. NUMERY KOMÓRKOWE (ZasobyService)
        // ==========================================
        public ActionResult NumeryKomorkowe(string szukanaFraza)
        {
            if (!CzyAdmin()) return RedirectToAction("Login", "Konto");

            DataTable dt = _zasobyService.PobierzNumeryKomorkowe(szukanaFraza);
            ViewBag.OstatniaFraza = szukanaFraza;
            return View(dt);
        }

        public ActionResult DezaktywujNumer(int id)
        {
            if (!CzyAdmin()) return RedirectToAction("NumeryKomorkowe");
            try
            {
                _zasobyService.DezaktywujNumerKomorkowy(id);
                TempData["Sukces"] = "Numer zdezaktywowany.";
            }
            catch (Exception ex)
            {
                TempData["Blad"] = "Błąd: " + ex.Message;
            }
            return RedirectToAction("NumeryKomorkowe");
        }

        [HttpGet]
        public ActionResult EdytujNumer(int? id)
        {
            if (!CzyAdmin()) return RedirectToAction("Login", "Konto");

            ViewBag.ListaPracownikow = _pracownikService.PobierzPracownikowDoDropdown();

            //ViewBag.ListaPracownikow = _pracownikService.PobierzListęPracownikow(""); // Reuse

            if (id.HasValue)
            {
                var row = _zasobyService.PobierzNumerKomorkowyPoId(id.Value);
                if (row != null) return View(row);
            }
            return View();
        }

        [HttpPost]
        public ActionResult ZapiszNumer(int ID, string Numer, string NumerKarty, string PIN, string PUK, string PlanOpis, string Status, int? ID_Pracownika)
        {
            if (!CzyAdmin()) return RedirectToAction("Login", "Konto");

            _zasobyService.ZapiszNumerKomorkowy(ID, Numer, NumerKarty, PIN, PUK, PlanOpis, Status, ID_Pracownika);
            TempData["Sukces"] = "Numer zapisany.";

            return RedirectToAction("NumeryKomorkowe");
        }

        // ==========================================
        // 6. NUMERY STACJONARNE (ZasobyService)
        // ==========================================
        public ActionResult NumeryStacjonarne(string szukanaFraza)
        {
            if (!CzyAdmin()) return RedirectToAction("Login", "Konto");

            DataTable dt = _zasobyService.PobierzNumeryStacjonarne(szukanaFraza);
            ViewBag.OstatniaFraza = szukanaFraza;
            return View(dt);
        }

        [HttpGet]
        public ActionResult EdytujNumerStacjonarny(int? id)
        {
            if (!CzyAdmin()) return RedirectToAction("Login", "Konto");
            ViewBag.ListaPracownikow = _pracownikService.PobierzPracownikowDoDropdown();
            //ViewBag.ListaPracownikow = _pracownikService.PobierzListęPracownikow("");

            if (id.HasValue)
            {
                var row = _zasobyService.PobierzNumerStacjonarnyPoId(id.Value);
                if (row != null) return View(row);
            }
            return View();
        }

        [HttpPost]
        public ActionResult ZapiszNumerStacjonarny(int ID, string Numer, string LiniaTyp, int? ID_Pracownika, string PrefiksKraj, string PrefiksMiasto, string Opis, string StatusCOR)
        {
            if (!CzyAdmin()) return RedirectToAction("Login", "Konto");

            _zasobyService.ZapiszNumerStacjonarny(ID, Numer, LiniaTyp, ID_Pracownika, PrefiksKraj, PrefiksMiasto, Opis, StatusCOR);
            TempData["Sukces"] = "Numer stacjonarny zapisany.";

            return RedirectToAction("NumeryStacjonarne");
        }

        // ==========================================
        // 7. IMPORT BILINGÓW (BilingService)
        // ==========================================
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
                    // Cała skomplikowana logika parsowania jest w serwisie
                    var wynik = _bilingService.ImportujPlik(plikBilingowy.InputStream, typ);

                    TempData["Sukces"] = $"Zaimportowano {wynik.LiczbaRekordow} rekordów. Faktura: {wynik.NumerFaktury}.";
                }
                catch (Exception ex)
                {
                    TempData["Blad"] = "Błąd importu: " + ex.Message;
                }
            }
            return RedirectToAction("Index");
        }

        // ==========================================
        // 8. RAPORTY (BilingService)
        // ==========================================

        public ActionResult Raporty(int? miesiac, int? rok, string fraza, string nrFaktury, int? dzialId, string manager, DateTime? od, DateTime? doDaty, int strona = 1)
        {
            if (!CzyAdmin()) return RedirectToAction("Login", "Konto");

            // 1. Logika Domyślnego Widoku (Miesiąc wstecz)
            //bool czyDomyslnyWidok = false;
            if (!miesiac.HasValue || !rok.HasValue)
            {
                var dataOczekiwana = DateTime.Now.AddMonths(-1);
                miesiac = dataOczekiwana.Month;
                rok = dataOczekiwana.Year;
                //// Jeśli użytkownik nie wybrał daty, ustalamy oczekiwany biling na poprzedni miesiąc
                //var dzis = DateTime.Now;
                //var dataOczekiwana = dzis.AddMonths(-1);

                //miesiac = dataOczekiwana.Month;
                //rok = dataOczekiwana.Year;
                //czyDomyslnyWidok = true;
            }

            ViewBag.Dzialy = _dzialyService.PobierzWszystkieDzialy();
            //ViewBag.Dzialy = _baza.PobierzDane("SELECT ID, NazwaDzialu FROM Dzialy ORDER BY NazwaDzialu");
            ViewBag.WybranyMiesiac = miesiac;
            ViewBag.WybranyRok = rok;

            // 2. Sprawdzenie czy w ogóle są dane dla tego miesiąca
            // (Tylko jeśli nie szukamy po konkretnym zakresie dat z kalendarza)
            if (!od.HasValue && !doDaty.HasValue)
            {
                bool czySaDane = _bilingService.CzyIstniejaBilingi(miesiac.Value, rok.Value);

                if (!czySaDane)
                {
                    string nazwaMiesiaca = new DateTime(rok.Value, miesiac.Value, 1).ToString("MMMM yyyy");
                    ViewBag.KomunikatBledu = $"Administrator nie wprowadził jeszcze bilingów za miesiąc {nazwaMiesiaca}.";

                    // Jeśli to domyślny widok i nie ma danych, możemy spróbować poszukać jeszcze starszych, 
                    // albo po prostu wyświetlić pustą tabelę z komunikatem.
                    // Tutaj wyświetlamy pustą tabelę z komunikatem.
                    return View(new DataTable());
                }
            }

            // 3. Pobieranie danych z Serwisu (Z PAGINACJĄ)
            int rozmiarStrony = 50;

            // Liczymy rekordy do paginacji
            int iloscRekordow = _bilingService.PoliczRekordy(miesiac.Value, rok.Value, fraza, nrFaktury, dzialId, manager, od, doDaty);
            ViewBag.LiczbaStron = (int)Math.Ceiling((double)iloscRekordow / rozmiarStrony);
            ViewBag.AktualnaStrona = strona;
            ViewBag.LiczbaWierszy = iloscRekordow;

            // Pobieramy paczkę danych
            DataTable dt = _bilingService.PobierzRaport(miesiac.Value, rok.Value, fraza, nrFaktury, dzialId, manager, od, doDaty, strona, rozmiarStrony);

            return View(dt);
        }

        public void EksportujRaport(int? miesiac, int? rok, string fraza, string nrFaktury, int? dzialId, string manager, DateTime? od, DateTime? doDaty)
        {
            if (!CzyAdmin()) return;

            // Logika daty (musi być spójna z widokiem)
            if (!miesiac.HasValue || !rok.HasValue)
            {
                var dataOczekiwana = DateTime.Now.AddMonths(-1);
                miesiac = dataOczekiwana.Month;
                rok = dataOczekiwana.Year;
            }

            // POBIERANIE WSZYSTKIEGO (rozmiarStrony = 0 oznacza brak limitu)
            DataTable dt = _bilingService.PobierzRaport(miesiac.Value, rok.Value, fraza, nrFaktury, dzialId, manager, od, doDaty, 1, 0);

            StringBuilder sb = _bilingService.GenerujCsvRaportu(dt);

            Response.Clear();
            Response.AddHeader("content-disposition", "attachment;filename=Raport_Bilingowy_Pelny.csv");
            Response.ContentType = "text/csv";
            Response.ContentEncoding = System.Text.Encoding.UTF8;
            Response.Write('\uFEFF');
            Response.Output.Write(sb.ToString());
            Response.End();
        }

        //public ActionResult Raporty(int? miesiac, int? rok, string fraza, string nrFaktury, int? dzialId, string manager, DateTime? od, DateTime? doDaty, int strona = 1)
        //{
        //    if (!CzyAdmin()) return RedirectToAction("Login", "Konto");

        //    // 1. Logika domyślnego czasu (zostaje w kontrolerze, bo to logika prezentacji)
        //    if (!miesiac.HasValue || !rok.HasValue)
        //    {
        //        rok = DateTime.Now.Year;
        //        miesiac = DateTime.Now.Month;
        //        // Można dodać metodę w BilingService do pobrania daty ostatniego bilingu, aby to ulepszyć
        //    }

        //    ViewBag.Dzialy = _dzialyService.PobierzWszystkieDzialy();
        //    ViewBag.WybranyMiesiac = miesiac;
        //    ViewBag.WybranyRok = rok;

        //    // 2. Budowanie filtrów (parametry dla serwisu)
        //    string warunekCzasu;
        //    if (od.HasValue || doDaty.HasValue)
        //    {
        //        List<string> czesciDaty = new List<string>();
        //        if (od.HasValue) czesciDaty.Add($"b.DataPolaczenia >= '{od.Value:yyyy-MM-dd}'");
        //        if (doDaty.HasValue) czesciDaty.Add($"b.DataPolaczenia <= '{doDaty.Value:yyyy-MM-dd} 23:59:59'");
        //        warunekCzasu = string.Join(" AND ", czesciDaty);
        //    }
        //    else
        //    {
        //        warunekCzasu = $"MONTH(b.DataPolaczenia) = {miesiac} AND YEAR(b.DataPolaczenia) = {rok}";
        //    }

        //    string filtry = "";
        //    if (!string.IsNullOrEmpty(fraza)) filtry += $" AND (NumerTelefonu LIKE '%{fraza}%' OR Pracownik LIKE '%{fraza}%')";
        //    if (dzialId.HasValue) filtry += $" AND DzialID = {dzialId.Value}";
        //    if (!string.IsNullOrEmpty(manager)) filtry += $" AND MenagerName LIKE '%{manager}%'";
        //    if (!string.IsNullOrEmpty(nrFaktury)) filtry += $" AND NrFaktury = '{nrFaktury}'";

        //    // 3. Pobranie danych z serwisu (z paginacją)
        //    int rozmiarStrony = 50;
        //    int pomin = (strona - 1) * rozmiarStrony;

        //    // Uwaga: Można dodać metodę PoliczRekordy w BilingService dla dokładnej paginacji
        //    // Tutaj uproszczone pobieranie danych
        //    DataTable dt = _bilingService.PobierzDaneRaportu(warunekCzasu, filtry, pomin, rozmiarStrony);

        //    ViewBag.AktualnaStrona = strona;
        //    // ViewBag.LiczbaStron = ... (Wymagałoby osobnego zapytania count w serwisie)

        //    return View(dt);
        //}

        //public void EksportujRaport(int? miesiac, int? rok, string fraza, int? dzialId, string manager, DateTime? od, DateTime? doDaty)
        //{
        //    if (!CzyAdmin()) return;

        //    // 1. Budowanie warunku czasu
        //    string warunekCzasu;
        //    if (od.HasValue || doDaty.HasValue)
        //    {
        //        List<string> czesciDaty = new List<string>();
        //        if (od.HasValue) czesciDaty.Add($"b.DataPolaczenia >= '{od.Value:yyyy-MM-dd}'");
        //        if (doDaty.HasValue) czesciDaty.Add($"b.DataPolaczenia <= '{doDaty.Value:yyyy-MM-dd} 23:59:59'");
        //        warunekCzasu = string.Join(" AND ", czesciDaty);
        //    }
        //    else
        //    {
        //        int m = miesiac ?? DateTime.Now.Month;
        //        int r = rok ?? DateTime.Now.Year;
        //        warunekCzasu = $"MONTH(b.DataPolaczenia) = {m} AND YEAR(b.DataPolaczenia) = {r}";
        //    }

        //    // 2. Budowanie filtrów
        //    string filtry = "";
        //    if (!string.IsNullOrEmpty(fraza)) filtry += $" AND (NumerTelefonu LIKE '%{fraza}%' OR Pracownik LIKE '%{fraza}%')";
        //    if (dzialId.HasValue) filtry += $" AND DzialID = {dzialId.Value}";
        //    if (!string.IsNullOrEmpty(manager)) filtry += $" AND MenagerName LIKE '%{manager}%'";

        //    // 3. Pobranie danych z serwisu (bez limitu stron)
        //    var dt = _bilingService.PobierzDaneRaportu(warunekCzasu, filtry);

        //    // 4. Generowanie CSV z serwisu
        //    var sb = _bilingService.GenerujCsvRaportu(dt);

        //    // 5. Wysłanie pliku
        //    Response.Clear();
        //    Response.AddHeader("content-disposition", "attachment;filename=Raport_Bilingowy.csv");
        //    Response.ContentType = "text/csv";
        //    Response.ContentEncoding = System.Text.Encoding.UTF8;
        //    Response.Write('\uFEFF');
        //    Response.Output.Write(sb.ToString());
        //    Response.End();
        //}

        // Metoda do Raportu Księgowego - również korzystająca z danych serwisu
        public void RaportKsiegowy()
        {
            if (!CzyAdmin()) return;

            // Pobieramy wszystkie dane (można zoptymalizować dodając metodę agregującą w BilingService)
            // Tutaj dla prostoty pobieramy "wszystko" i grupujemy w pamięci (Linq to DataTable)
            // W środowisku produkcyjnym lepiej zrobić GROUP BY w SQL wewnątrz BilingService
            var dt = _bilingService.PobierzWszystkieBilingi();
            //var dt = _bilingService.PobierzDaneRaportu("1=1", "");

            var grouped = dt.AsEnumerable()
                .GroupBy(r => new { Dzial = r["Dzial"], Manager = r["MenagerName"] })
                .Select(g => new {
                    g.Key.Dzial,
                    g.Key.Manager,
                    Ilosc = g.Count(),
                    Netto = g.Sum(x => Convert.ToDecimal(x["KwotaNetto"])),
                    Brutto = g.Sum(x => Convert.ToDecimal(x["KwotaBrutto"]))
                });

            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.AppendLine("Dzial;Manager;Ilosc Polaczen;Suma Netto;Suma Brutto");
            foreach (var row in grouped)
            {
                sb.AppendLine($"{row.Dzial};{row.Manager};{row.Ilosc};{row.Netto};{row.Brutto}");
            }

            Response.Clear();
            Response.AddHeader("content-disposition", "attachment;filename=Raport_Ksiegowy.csv");
            Response.ContentType = "text/csv";
            Response.ContentEncoding = System.Text.Encoding.UTF8;
            Response.Output.Write(sb.ToString());
            Response.End();
        }
    }
}