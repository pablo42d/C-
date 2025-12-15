using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web.Mvc;
using SystemTelefonicznyGY.Logika;
using SystemTelefonicznyGY.Models;

namespace SystemTelefonicznyGY.Controllers
{
    public class PanelUzytkownikaController : Controller
    {
        private readonly int idZalogowanego;
        private BazaDanych _baza = new BazaDanych();

        // GET: PanelUzytkownika
        // Sprawdzamy, czy użytkownik jest zalogowany przed wyświetleniem panelu użytkownika
        public ActionResult Index()
        {
            //if (Session["IdPracownika"] == null)
            //{
            //    return RedirectToAction("Login", "Konto");
            //}

            //int idZalogowanegoPracownika = Convert.ToInt32(Session["IdPracownika"]);

            //// Przygotowanie kontenera na dane (ViewModel)
            //var model = new PodsumowaniePracownikaModel();

            // inna wersja
            if (Session["IdPracownika"] == null) return RedirectToAction("Login", "Konto");
            int id = Convert.ToInt32(Session["IdPracownika"]);

            var model = new PodsumowaniePracownikaModel();

            // 2. Pobieranie Urządzeń dla zalogowanego pracownika
            // 
            string sqlUrzadzenia = $"SELECT * FROM Urzadzenia WHERE ID_Pracownika = {idZalogowanego}";
            DataTable dtUrzadzenia = _baza.PobierzDane(sqlUrzadzenia);
            foreach (DataRow row in dtUrzadzenia.Rows)
            {
                model.MojeUrzadzenia.Add(new Urzadzenie(
                    Convert.ToInt32(row["ID"]),
                    row["Model"].ToString(),
                    row["SN"].ToString(),
                    row["Status"].ToString(),
                    idZalogowanego
                )
                { Aparat = row["Aparat"].ToString() });
            }
            // 3. Pobieranie Połączeń komórkowych i sumowanie kosztów
            string sqlKom = $@"SELECT b.* FROM BilingiKomorkowe b 
                               JOIN NumeryKomorkowe n ON b.ID_NumeruKomorkowego = n.ID 
                               WHERE n.ID_Pracownika = {idZalogowanego}";
            DataTable dtKom = _baza.PobierzDane(sqlKom);
            foreach (DataRow row in dtKom.Rows)
            {
                decimal koszt = Convert.ToDecimal(row["KwotaBrutto"]);
                model.BilingiKomorkowe.Add(row); // Używamy DataRow dla uproszczenia bilingu szczegółowego
                model.SumaKomorkowe += koszt;
            }
            // 4. Pobieranie Połączeń stacjonarnych i sumowanie kosztów
            string sqlStacjonarne = $@"SELECT b.* FROM BilingiStacjonarne b 
                                      JOIN NumeryStacjonarne n ON b.ID_NumeruStacjonarnego = n.ID 
                                      WHERE n.ID_Pracownika = {idZalogowanego}";
            DataTable dtStacjonarne = _baza.PobierzDane(sqlStacjonarne);
            foreach (DataRow row in dtStacjonarne.Rows)
            {
                decimal koszt = Convert.ToDecimal(row["KwotaBrutto"]);
                model.BilingiStacjonarne.Add(row); // Używamy DataRow dla uproszczenia bilingu szczegółowego
                model.SumaStacjonarne += koszt;
            }
            return View(model);

        }

        // 2. Strona bilingów komórkowych
        public ActionResult BilingiKomorkowe()
        {
            if (Session["IdPracownika"] == null) return RedirectToAction("Login", "Konto");
            int id = Convert.ToInt32(Session["IdPracownika"]);

            string sql = $@"SELECT b.* FROM BilingiKomorkowe b 
                   JOIN NumeryKomorkowe n ON b.ID_NumeruKomorkowego = n.ID 
                   WHERE n.ID_Pracownika = {id}";
            DataTable dt = _baza.PobierzDane(sql);

            return View(dt); // Przekazujemy surowe dane do dedykowanego widoku
        }

        // 3. Strona bilingów stacjonarnych
        public ActionResult BilingiStacjonarne()
        {
            if (Session["IdPracownika"] == null) return RedirectToAction("Login", "Konto");
            int id = Convert.ToInt32(Session["IdPracownika"]);

            string sql = $@"SELECT b.* FROM BilingiStacjonarne b 
                   JOIN NumeryStacjonarne n ON b.ID_NumeruStacjonarnego = n.ID 
                   WHERE n.ID_Pracownika = {id}";
            DataTable dt = _baza.PobierzDane(sql);

            return View(dt);
        }
    }


    public class PodsumowaniePracownikaModel
    {
        public List<Urzadzenie> MojeUrzadzenia { get; set; } = new List<Urzadzenie>();
        public List<DataRow> BilingiKomorkowe { get; set; } = new List<DataRow>();
        public List<DataRow> BilingiStacjonarne { get; set; } = new List<DataRow>();
        public decimal SumaKomorkowe { get; set; } = 0;
        public decimal SumaStacjonarne { get; set; } = 0;
    }

}