using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Web.Mvc;
using SystemTelefonicznyGY.Logika;
using SystemTelefonicznyGY.Logika.Interfejsy;
using SystemTelefonicznyGY.Models;

namespace SystemTelefonicznyGY.Controllers
{
    public class PanelUzytkownikaController : Controller
    {
        // Wstrzykuje serwisy (readonly dla bezpieczeństwa i wydajności)
        private readonly IBilingService _bilingService = new BilingService();
        private readonly IZasobyService _zasobyService = new ZasobyService();

        // 1. GŁÓWNY WIDOK PANELU (Podsumowanie)
        public ActionResult Index(int? miesiac, int? rok)
        {
            if (Session["IdPracownika"] == null) return RedirectToAction("Login", "Konto");

            int idPracownika = Convert.ToInt32(Session["IdPracownika"]);
            var model = new PodsumowaniePracownikaModel
            {
                IdPracownika = idPracownika
            };

            // 1. Pobiera datę (jeśli użytkownik nie wybrał, bierze ostatnią dostępną)
            var (m, r) = (miesiac.HasValue && rok.HasValue)
                ? (miesiac.Value, rok.Value)
                : _bilingService.PobierzDateOstatniegoBilinguPracownika(idPracownika);

            // Przekazuje wybraną datę do widoku (np. do nagłówka)
            ViewBag.WybranyMiesiac = m;
            ViewBag.WybranyRok = r;

            // 2. Pobiera Urządzenia (korzystając z ZasobyService)
            model.MojeUrzadzenia = _zasobyService.PobierzUrzadzeniaPracownika(idPracownika);

            // 3. Pobiera Bilingi Komórkowe i liczy sumę 
            DataTable dtKom = _bilingService.PobierzBilingiPracownika(idPracownika, m, r, "kom");
            foreach (DataRow row in dtKom.Rows)
            {
                model.BilingiKomorkowe.Add(row);
                model.SumaKomorkowe += Convert.ToDecimal(row["KwotaBrutto"]);
            }

            // 4. Pobiera Bilingi Stacjonarne i liczy sumę
            DataTable dtStac = _bilingService.PobierzBilingiPracownika(idPracownika, m, r, "stac");
            foreach (DataRow row in dtStac.Rows)
            {
                model.BilingiStacjonarne.Add(row);
                model.SumaStacjonarne += Convert.ToDecimal(row["KwotaBrutto"]);
            }

            return View(model);
        }

        // 2. SZCZEGÓŁY BILINGU KOMÓRKOWEGO
        public ActionResult BilingiKomorkowe()
        {
            if (Session["IdPracownika"] == null) return RedirectToAction("Login", "Konto");
            int id = Convert.ToInt32(Session["IdPracownika"]);

            // Pobieramy ostatnią dostępną datę
            var (m, r) = _bilingService.PobierzDateOstatniegoBilinguPracownika(id);

            ViewBag.Typ = "Komórkowe";
            ViewBag.MiesiacBilingowy = $"{m:D2}.{r}";

            // Pobieramy dane z serwisu
            return View(_bilingService.PobierzBilingiPracownika(id, m, r, "kom"));
        }

        // 3. SZCZEGÓŁY BILINGU STACJONARNEGO
        public ActionResult BilingiStacjonarne()
        {
            if (Session["IdPracownika"] == null) return RedirectToAction("Login", "Konto");
            int id = Convert.ToInt32(Session["IdPracownika"]);

            var (m, r) = _bilingService.PobierzDateOstatniegoBilinguPracownika(id);

            ViewBag.Typ = "Stacjonarne";
            ViewBag.MiesiacBilingowy = $"{m:D2}.{r}";

            return View(_bilingService.PobierzBilingiPracownika(id, m, r, "stac"));
        }

        // 4. EKSPORT DO CSV (Dla pracownika)
        public void EksportBilingu(string typ)
        {
            if (Session["IdPracownika"] == null) return;
            int id = Convert.ToInt32(Session["IdPracownika"]);

            var (m, r) = _bilingService.PobierzDateOstatniegoBilinguPracownika(id);

            // Pobiera dane (typ "kom" lub inna wartość oznacza stacjonarny)
            DataTable dt = _bilingService.PobierzBilingiPracownika(id, m, r, typ);

            // Generowanie pliku CSV
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Data;Numer Wlasny;Numer Wybierany;Czas (s);Brutto;Faktura");

            foreach (DataRow row in dt.Rows)
            {
                sb.AppendLine(string.Format("{0:yyyy-MM-dd HH:mm};{1};{2};{3};{4:N2};{5}",
                    row["DataPolaczenia"],
                    row["NumerTelefonu"],
                    row["NumerWybierany"],
                    row["CzasTrwania"],
                    row["KwotaBrutto"],
                    row["NrFaktury"]));
            }

            Response.Clear();
            Response.AddHeader("content-disposition", "attachment;filename=Moj_Biling_" + typ + ".csv"); // Nazwa pobieranego pliku
            Response.ContentType = "text/csv";
            Response.ContentEncoding = System.Text.Encoding.UTF8;
            Response.Write('\uFEFF'); // BOM dla Excela
            Response.Output.Write(sb.ToString());
            Response.End();
        }
    }
}