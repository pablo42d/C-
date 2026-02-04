using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using SystemTelefonicznyGY.Logika;
using SystemTelefonicznyGY.Logika.Interfejsy;
using SystemTelefonicznyGY.Models;

namespace SystemTelefonicznyGY.Controllers
{
    public class AdministratorController : Controller
    {
        // --- WSTRZYKIWANIE SERWISÓW ---
        // Instancje klas z folderu Logika, które wykonują (SQL, obliczenia)
        private readonly IPracownikService _pracownikService = new PracownikService();
        private readonly IDzialyService _dzialyService = new DzialyService();
        private readonly IBilingService _bilingService = new BilingService();
        private readonly IZasobyService _zasobyService = new ZasobyService();

        public AdministratorController()
            : this(new PracownikService(), new DzialyService(), new BilingService(), new ZasobyService())
        {
        }

        // Ten konstruktor jest używany przez UNIT TESTY do wstrzykiwania Mocków.
        public AdministratorController(IPracownikService pracownikService, IDzialyService dzialyService, IBilingService bilingService, IZasobyService zasobyService)
        {
            // Zabezpieczenie (opcjonalne, dobre praktyki)
            _pracownikService = pracownikService ?? throw new ArgumentNullException(nameof(pracownikService));
            _dzialyService = dzialyService ?? throw new ArgumentNullException(nameof(dzialyService));
            _bilingService = bilingService ?? throw new ArgumentNullException(nameof(bilingService));
            _zasobyService = zasobyService ?? throw new ArgumentNullException(nameof(zasobyService));
        }

        // Metoda pomocnicza sprawdzająca uprawnienia (korzysta z Sesji)
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

            // Statystyki pobieramy używając serwisu (np. pobiera listę i liczymy elementy)
            // 1. Pobiera liczbę pracowników 
            var listaPracownikow = _pracownikService.PobierzListęPracownikow("");
            ViewBag.LiczbaPracownikow = listaPracownikow.Count;

            // 2. Ustala datę dla statystyk (np. poprzedni miesiąc, bo wtedy przychodzą faktury)
            DateTime dataRaportu = DateTime.Now.AddMonths(-1);
            string nazwaMiesiaca = dataRaportu.ToString("MMMM yyyy");

            // 3. Pobiera sumę kosztów z serwisu 
            decimal suma = _bilingService.PobierzSumeKosztow(dataRaportu.Month, dataRaportu.Year);

            // 4. Przekazuje dane do Widoku
            ViewBag.OstatniMiesiac = nazwaMiesiaca; 
            ViewBag.OstatniMiesiacNazwa = nazwaMiesiaca; 
            ViewBag.SumaBilingow = suma; 

            return View();
        }

        // ==========================================
        // 2. ZARZĄDZANIE PRACOWNIKAMI
        // ==========================================
        public ActionResult Pracownicy()
        {
            if (!CzyAdmin()) return RedirectToAction("Login", "Konto");

            // Pobieram listę z serwisu. Brak SQL w kontrolerze.
            var lista = _pracownikService.PobierzListęPracownikow("");
            return View(lista);
        }

        [HttpGet]
        public ActionResult Edytuj(int? id)
        {
            if (!CzyAdmin()) return RedirectToAction("Login", "Konto");

            // Pobiera dane słownikowe z serwisów do dropdownów
            ViewBag.ListaDzialow = _dzialyService.PobierzWszystkieDzialy();
            ViewBag.ListaStanowiska = _dzialyService.PobierzStanowiskaZDzialem();

            if (id.HasValue)
            {
                // Pobiera konkretnego pracownika przez Serwis
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
                // Przekazuje dane do serwisu. Serwis decyduje czy to INSERT czy UPDATE.
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
                // Delegujey usuwanie do serwisu
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

            // Pobiera dane z serwisu DzialyService
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
                // Pobiera listę i filtrujemy lokalnie (lub dodaj metodę PobierzDzialPoId w serwisie)
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

            // Korzysta z serwisu ZasobyService
            DataTable dt = _zasobyService.PobierzUrzadzenia(szukanaFraza);

            ViewBag.OstatniaFraza = szukanaFraza;
            return View(dt);
        }

        [HttpGet]
        public ActionResult EdytujUrzadzenie(int? id)
        {
            if (!CzyAdmin()) return RedirectToAction("Login", "Konto");

            // Pobiera listę pracowników do dropdowna (PracownikService)            
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
                // Sprawdza, czy nazwa pliku kończy się na ".csv" (wielkość liter nie ma znaczenia)
                if (!plikBilingowy.FileName.EndsWith(".csv", StringComparison.OrdinalIgnoreCase))
                {
                    TempData["Blad"] = "Niedozwolony format pliku! Proszę wgrać plik z rozszerzeniem .csv";
                    return RedirectToAction("Index");
                }
                // ---------------------------------------------

                try
                {
                    var wynik = _bilingService.ImportujPlik(plikBilingowy.InputStream, typ);

                    // Tutaj można zmienić klucz na "Sukces" lub inny "Komunikat"
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
            if (!miesiac.HasValue || !rok.HasValue)
            {
                var dataOczekiwana = DateTime.Now.AddMonths(-1);
                miesiac = dataOczekiwana.Month;
                rok = dataOczekiwana.Year;                
            }

            ViewBag.Dzialy = _dzialyService.PobierzWszystkieDzialy();            
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
                    
                    return View(new DataTable());
                }
            }

            // 3. Pobieranie danych z Serwisu (Z PAGINACJĄ)
            int rozmiarStrony = 50;

            // Liczy rekordy do paginacji
            int iloscRekordow = _bilingService.PoliczRekordy(miesiac.Value, rok.Value, fraza, nrFaktury, dzialId, manager, od, doDaty);
            ViewBag.LiczbaStron = (int)Math.Ceiling((double)iloscRekordow / rozmiarStrony);
            ViewBag.AktualnaStrona = strona;
            ViewBag.LiczbaWierszy = iloscRekordow;

            // Pobiera paczkę danych
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
        

        // Metoda do Raportu Księgowego - również korzystająca z danych serwisu
        public void RaportKsiegowy()
        {
            if (!CzyAdmin()) return;

            // Pobiera wszystkie dane 
            // Tutaj dla prostoty pobieramy "wszystko" i grupujemy w pamięci (Linq to DataTable)
            // W środowisku produkcyjnym lepiej zrobić GROUP BY w SQL wewnątrz BilingService
            var dt = _bilingService.PobierzWszystkieBilingi();
            
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