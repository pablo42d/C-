using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using SystemTelefonicznyGY.Logika;
using SystemTelefonicznyGY.Models;

namespace SystemTelefonicznyGY.Controllers
{
    public class PanelUzytkownikaController : Controller
    {
        //private readonly int idZalogowanego;
        private BazaDanych _baza = new BazaDanych();

        // Wspólna metoda pomocnicza, aby nie powtarzać kodu
        private (int m, int r) PobierzDateOstatniegoBilingu(int idPracownika)
        {
            string sqlOstatnia = $@"
        SELECT TOP 1 YEAR(DataPolaczenia) as R, MONTH(DataPolaczenia) as M 
        FROM (
            SELECT b.DataPolaczenia FROM BilingiKomorkowe b
            JOIN NumeryKomorkowe n ON (CASE WHEN LEN(b.NumerTelefonu) > 9 THEN RIGHT(b.NumerTelefonu, 9) ELSE b.NumerTelefonu END) = n.Numer
            WHERE n.ID_Pracownika = {idPracownika}
            UNION ALL
            SELECT b.DataPolaczenia FROM BilingiStacjonarne b
            JOIN NumeryStacjonarne n ON (CASE WHEN b.NumerTelefonu LIKE '4814%' OR b.NumerTelefonu LIKE '4822%' THEN RIGHT(b.NumerTelefonu, 7) ELSE b.NumerTelefonu END) = n.Numer
            WHERE n.ID_Pracownika = {idPracownika}
        ) AS T 
        ORDER BY DataPolaczenia DESC";

            DataTable dt = _baza.PobierzDane(sqlOstatnia);
            if (dt.Rows.Count > 0)
            {
                return (Convert.ToInt32(dt.Rows[0]["M"]), Convert.ToInt32(dt.Rows[0]["R"]));
            }
            return (DateTime.Now.Month, DateTime.Now.Year);
        }

        // GET: PanelUzytkownika
        // Sprawdzamy, czy użytkownik jest zalogowany przed wyświetleniem panelu użytkownika

        public ActionResult Index(int? miesiac, int? rok)
        {
            if (Session["IdPracownika"] == null) return RedirectToAction("Login", "Konto");
            
            //if (Session["IdPracownika"] == null)
            //{
            //    return RedirectToAction("Login", "Konto");
            //}

            int idPracownika = Convert.ToInt32(Session["IdPracownika"]);
            var model = new PodsumowaniePracownikaModel();
            model.IdPracownika = idPracownika;
            var ostatniaData = PobierzDateOstatniegoBilingu(idPracownika);

            // 1. Pobieranie Urządzeń
            string sqlUrzadzenia = $"SELECT * FROM Urzadzenia WHERE ID_Pracownika = {idPracownika}";
            DataTable dtUrzadzenia = _baza.PobierzDane(sqlUrzadzenia);
            if (dtUrzadzenia != null)
            {
                foreach (DataRow row in dtUrzadzenia.Rows)
                {
                    model.MojeUrzadzenia.Add(new Urzadzenie(
                        Convert.ToInt32(row["ID"]),
                        row["Model"].ToString(),
                        row["SN"].ToString(),
                        row["Status"].ToString(),
                        idPracownika
                    )
                    { Aparat = row["Aparat"].ToString() });
                }
            }

            // 2. Pobieranie Połączeń KOMÓRKOWYCH
            // Łączymy po numerze telefonu (9 ostatnich cyfr)
        //    string sqlKom = $@"
        //SELECT b.* FROM BilingiKomorkowe b 
        //JOIN NumeryKomorkowe n ON (CASE WHEN LEN(b.NumerTelefonu) > 9 THEN RIGHT(b.NumerTelefonu, 9) ELSE b.NumerTelefonu END) = n.Numer
        //WHERE n.ID_Pracownika = {idPracownika}";

            // 2. Bilingi Komórkowe - TYLKO OSTATNI MIESIĄC
            string sqlKom = $@"
                SELECT b.* FROM BilingiKomorkowe b 
                JOIN NumeryKomorkowe n ON (CASE WHEN LEN(b.NumerTelefonu) > 9 THEN RIGHT(b.NumerTelefonu, 9) ELSE b.NumerTelefonu END) = n.Numer
                WHERE n.ID_Pracownika = {idPracownika} 
                AND MONTH(b.DataPolaczenia) = {ostatniaData.m} AND YEAR(b.DataPolaczenia) = {ostatniaData.r}";

            DataTable dtKom = _baza.PobierzDane(sqlKom);
            if (dtKom != null)
            {
                foreach (DataRow row in dtKom.Rows)
                {
                    model.BilingiKomorkowe.Add(row);
                    model.SumaKomorkowe += Convert.ToDecimal(row["KwotaBrutto"]);
                }
            }

            // 3. Pobieranie Połączeń STACJONARNYCH
            // Łączymy po numerze stacjonarnym (7 cyfr)
            //    string sqlStac = $@"
            //SELECT b.* FROM BilingiStacjonarne b 
            //JOIN NumeryStacjonarne n ON (CASE WHEN b.NumerTelefonu LIKE '4814%' OR b.NumerTelefonu LIKE '4822%' THEN RIGHT(b.NumerTelefonu, 7) ELSE b.NumerTelefonu END) = n.Numer
            //WHERE n.ID_Pracownika = {idPracownika}";

            // 3. Bilingi Stacjonarne - TYLKO OSTATNI MIESIĄC
            string sqlStac = $@"
                SELECT b.* FROM BilingiStacjonarne b 
                JOIN NumeryStacjonarne n ON (CASE WHEN b.NumerTelefonu LIKE '4814%' OR b.NumerTelefonu LIKE '4822%' THEN RIGHT(b.NumerTelefonu, 7) ELSE b.NumerTelefonu END) = n.Numer
                WHERE n.ID_Pracownika = {idPracownika}
                AND MONTH(b.DataPolaczenia) = {ostatniaData.m} AND YEAR(b.DataPolaczenia) = {ostatniaData.r}";

            DataTable dtStac = _baza.PobierzDane(sqlStac);
            if (dtStac != null)
            {
                foreach (DataRow row in dtStac.Rows)
                {
                    model.BilingiStacjonarne.Add(row);
                    model.SumaStacjonarne += Convert.ToDecimal(row["KwotaBrutto"]);
                }
            }

            return View(model);
        }

        // 2. Strona bilingów komórkowych
        public ActionResult BilingiKomorkowe()
        {
            if (Session["IdPracownika"] == null) return RedirectToAction("Login", "Konto");
            int id = Convert.ToInt32(Session["IdPracownika"]);
            var data = PobierzDateOstatniegoBilingu(id);

            // // Łączymy po numerze telefonu, wycinając prefiksy, aby dopasować do tabeli numerów
            // string sql = $@"SELECT b.* FROM BilingiKomorkowe b 
            //JOIN NumeryKomorkowe n ON (CASE WHEN LEN(b.NumerTelefonu) > 9 THEN RIGHT(b.NumerTelefonu, 9) ELSE b.NumerTelefonu END) = n.Numer
            //WHERE n.ID_Pracownika = {id} ORDER BY b.DataPolaczenia DESC";

            // DataTable dt = _baza.PobierzDane(sql);

            // // Przekazujemy dane do widoku (Ustawiamy ViewBag, aby widok wiedział co wyświetla)
            // ViewBag.Typ = "Komórkowe";
            // // Możesz tutaj dodać logikę pobierania nazwy miesiąca z bazy
            // ViewBag.MiesiacBilingowy = DateTime.Now.ToString("MM.yyyy");

            // return View(dt);

            string sql = $@"SELECT b.* FROM BilingiKomorkowe b 
               JOIN NumeryKomorkowe n ON (CASE WHEN LEN(b.NumerTelefonu) > 9 THEN RIGHT(b.NumerTelefonu, 9) ELSE b.NumerTelefonu END) = n.Numer
               WHERE n.ID_Pracownika = {id} 
               AND MONTH(b.DataPolaczenia) = {data.m} AND YEAR(b.DataPolaczenia) = {data.r}
               ORDER BY b.DataPolaczenia DESC";

            ViewBag.Typ = "Komórkowe";
            ViewBag.MiesiacBilingowy = $"{data.m:D2}.{data.r}";
            return View(_baza.PobierzDane(sql));
        }

        // 3. Strona bilingów stacjonarnych
        public ActionResult BilingiStacjonarne()
        {
            if (Session["IdPracownika"] == null) return RedirectToAction("Login", "Konto");
            int id = Convert.ToInt32(Session["IdPracownika"]);
            var data = PobierzDateOstatniegoBilingu(id);

            // // Łączymy po numerze stacjonarnym (7 cyfr dla Tarnowa/Warszawy)
            // string sql = $@"SELECT b.* FROM BilingiStacjonarne b 
            //JOIN NumeryStacjonarne n ON (CASE WHEN b.NumerTelefonu LIKE '4814%' OR b.NumerTelefonu LIKE '4822%' THEN RIGHT(b.NumerTelefonu, 7) ELSE b.NumerTelefonu END) = n.Numer
            //WHERE n.ID_Pracownika = {id} ORDER BY b.DataPolaczenia DESC";

            // DataTable dt = _baza.PobierzDane(sql);

            // ViewBag.Typ = "Stacjonarne";
            // ViewBag.MiesiacBilingowy = DateTime.Now.ToString("MM.yyyy");

            // return View(dt);

            string sql = $@"SELECT b.* FROM BilingiStacjonarne b 
               JOIN NumeryStacjonarne n ON (CASE WHEN b.NumerTelefonu LIKE '4814%' OR b.NumerTelefonu LIKE '4822%' THEN RIGHT(b.NumerTelefonu, 7) ELSE b.NumerTelefonu END) = n.Numer
               WHERE n.ID_Pracownika = {id}
               AND MONTH(b.DataPolaczenia) = {data.m} AND YEAR(b.DataPolaczenia) = {data.r}
               ORDER BY b.DataPolaczenia DESC";

            ViewBag.Typ = "Stacjonarne";
            ViewBag.MiesiacBilingowy = $"{data.m:D2}.{data.r}";
            return View(_baza.PobierzDane(sql));

        }

        public void EksportBilingu(string typ)
        {
            if (Session["IdPracownika"] == null) return;
            int id = Convert.ToInt32(Session["IdPracownika"]);
            var data = PobierzDateOstatniegoBilingu(id);

            string sql = "";
            if (typ == "kom")
            {
                // sql = $@"SELECT b.* FROM BilingiKomorkowe b 
                //JOIN NumeryKomorkowe n ON (CASE WHEN LEN(b.NumerTelefonu) > 9 THEN RIGHT(b.NumerTelefonu, 9) ELSE b.NumerTelefonu END) = n.Numer
                //WHERE n.ID_Pracownika = {id} ORDER BY b.DataPolaczenia DESC";
                sql = $@"SELECT b.* FROM BilingiKomorkowe b 
JOIN NumeryKomorkowe n ON (CASE WHEN LEN(b.NumerTelefonu) > 9 THEN RIGHT(b.NumerTelefonu, 9) ELSE b.NumerTelefonu END) = n.Numer 
WHERE n.ID_Pracownika = {id} AND MONTH(b.DataPolaczenia) = {data.m} AND YEAR(b.DataPolaczenia) = {data.r} ORDER BY b.DataPolaczenia DESC";
            }
            else
            {
               // sql = $@"SELECT b.* FROM BilingiStacjonarne b 
               //JOIN NumeryStacjonarne n ON (CASE WHEN b.NumerTelefonu LIKE '4814%' OR b.NumerTelefonu LIKE '4822%' THEN RIGHT(b.NumerTelefonu, 7) ELSE b.NumerTelefonu END) = n.Numer
               //WHERE n.ID_Pracownika = {id} ORDER BY b.DataPolaczenia DESC";
               sql = $@"SELECT b.* FROM BilingiStacjonarne b 
JOIN NumeryStacjonarne n ON (CASE WHEN b.NumerTelefonu LIKE '4814%' OR b.NumerTelefonu LIKE '4822%' THEN RIGHT(b.NumerTelefonu, 7) ELSE b.NumerTelefonu END) = n.Numer 
WHERE n.ID_Pracownika = {id} AND MONTH(b.DataPolaczenia) = {data.m} AND YEAR(b.DataPolaczenia) = {data.r} ORDER BY b.DataPolaczenia DESC";
            }

            DataTable dt = _baza.PobierzDane(sql);

            // Budowanie CSV
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Data;Numer Wlasny;Numer Wybierany;Czas (s);Brutto;Faktura");

            foreach (DataRow row in dt.Rows)
            {
                sb.AppendLine(string.Format("{0:yyyy-MM-dd HH:mm};{1};{2};{3};{4:N2};{5}",
                    row["DataPolaczenia"], row["NumerTelefonu"], row["NumerWybierany"],
                    row["CzasTrwania"], row["KwotaBrutto"], row["NrFaktury"]));
            }

            Response.Clear();
            Response.AddHeader("content-disposition", "attachment;filename=Moj_Biling_" + typ + ".csv");
            Response.ContentType = "text/csv";
            Response.ContentEncoding = System.Text.Encoding.UTF8;
            Response.Write('\uFEFF');
            Response.Output.Write(sb.ToString());
            Response.End();
        }


        //old z idPracownika
        //public ActionResult Index()
        //{
        //    if (Session["IdPracownika"] == null)
        //    {
        //        return RedirectToAction("Login", "Konto");
        //    }

        //    // POPRAWKA: POBIERAMY ID Z SESJI I UŻYWAMY LOKALNIE
        //    int idPracownika = Convert.ToInt32(Session["IdPracownika"]);

        //    //int idZalogowanegoPracownika = Convert.ToInt32(Session["IdPracownika"]);

        //    //// Przygotowanie kontenera na dane (ViewModel)
        //    var model = new PodsumowaniePracownikaModel();

        //    // inna wersja
        //    //if (Session["IdPracownika"] == null) return RedirectToAction("Login", "Konto");
        //    //int id = Convert.ToInt32(Session["IdPracownika"]);

        //    //var model = new PodsumowaniePracownikaModel();

        //    //// 2. Pobieranie Urządzeń dla zalogowanego pracownika
        //    //// 
        //    //string sqlUrzadzenia = $"SELECT * FROM Urzadzenia WHERE ID_Pracownika = {idZalogowanego}";
        //    // POPRAWKA: Używamy idPracownika zamiast pustej idZalogowanego
        //    string sqlUrzadzenia = $"SELECT * FROM Urzadzenia WHERE ID_Pracownika = {idPracownika}";
        //    DataTable dtUrzadzenia = _baza.PobierzDane(sqlUrzadzenia);
        //    // Zabezpieczenie przed błędem, jeśli baza nie zwróci danych (dtUrzadzenia == null)
        //    if (dtUrzadzenia != null)
        //    {
        //        foreach (DataRow row in dtUrzadzenia.Rows)
        //        {
        //            model.MojeUrzadzenia.Add(new Urzadzenie(
        //                Convert.ToInt32(row["ID"]),
        //                row["Model"].ToString(),
        //                row["SN"].ToString(),
        //                row["Status"].ToString(),
        //                idPracownika // Używamy idPracownika
        //            )
        //            { Aparat = row["Aparat"].ToString() });
        //        }
        //    }
        //    //foreach (DataRow row in dtUrzadzenia.Rows)
        //    //{
        //    //    model.MojeUrzadzenia.Add(new Urzadzenie(
        //    //        Convert.ToInt32(row["ID"]),
        //    //        row["Model"].ToString(),
        //    //        row["SN"].ToString(),
        //    //        row["Status"].ToString(),
        //    //        idZalogowanego
        //    //    )
        //    //    { Aparat = row["Aparat"].ToString() });
        //    //}
        //    //// 3. Pobieranie Połączeń komórkowych i sumowanie kosztów
        //    //string sqlKom = $@"SELECT b.* FROM BilingiKomorkowe b 
        //    //                   JOIN NumeryKomorkowe n ON b.ID_NumeruKomorkowego = n.ID 
        //    //                   WHERE n.ID_Pracownika = {idZalogowanego}";
        //    string sqlKom = $@"SELECT b.* FROM BilingiKomorkowe b 
        //                   JOIN NumeryKomorkowe n ON b.ID_NumeruKomorkowego = n.ID 
        //                   WHERE n.ID_Pracownika = {idPracownika}";

        //    DataTable dtKom = _baza.PobierzDane(sqlKom);
        //    if (dtKom != null)
        //    {
        //        foreach (DataRow row in dtKom.Rows)
        //        {
        //            decimal koszt = Convert.ToDecimal(row["KwotaBrutto"]);
        //            model.BilingiKomorkowe.Add(row); // Używamy DataRow dla uproszczenia bilingu szczegółowego
        //            model.SumaKomorkowe += koszt;
        //        }
        //    }
        //    //foreach (DataRow row in dtKom.Rows)
        //    //{
        //    //    decimal koszt = Convert.ToDecimal(row["KwotaBrutto"]);
        //    //    model.BilingiKomorkowe.Add(row); // Używamy DataRow dla uproszczenia bilingu szczegółowego
        //    //    model.SumaKomorkowe += koszt;
        //    //}
        //    //// 4. Pobieranie Połączeń stacjonarnych i sumowanie kosztów
        //    //string sqlStacjonarne = $@"SELECT b.* FROM BilingiStacjonarne b 
        //    //                          JOIN NumeryStacjonarne n ON b.ID_NumeruStacjonarnego = n.ID 
        //    //                          WHERE n.ID_Pracownika = {idZalogowanego}";
        //    // POPRAWKA: Używamy idPracownika w zapytaniu
        //    string sqlStacjonarne = $@"SELECT b.* FROM BilingiStacjonarne b 
        //                         JOIN NumeryStacjonarne n ON b.ID_NumeruStacjonarnego = n.ID 
        //                         WHERE n.ID_Pracownika = {idPracownika}";

        //    DataTable dtStacjonarne = _baza.PobierzDane(sqlStacjonarne);
        //    if (dtStacjonarne != null)
        //    {
        //        foreach (DataRow row in dtStacjonarne.Rows)
        //        {
        //            decimal koszt = Convert.ToDecimal(row["KwotaBrutto"]);
        //            model.BilingiStacjonarne.Add(row); // Używamy DataRow dla uproszczenia bilingu szczegółowego
        //            model.SumaStacjonarne += koszt;
        //        }
        //    }
        //    //foreach (DataRow row in dtStacjonarne.Rows)
        //    //{
        //    //    decimal koszt = Convert.ToDecimal(row["KwotaBrutto"]);
        //    //    model.BilingiStacjonarne.Add(row); // Używamy DataRow dla uproszczenia bilingu szczegółowego
        //    //    model.SumaStacjonarne += koszt;
        //    //}
        //    return View(model);

        //}

        //    // 2. Strona bilingów komórkowych
        //    public ActionResult BilingiKomorkowe()
        //    {
        //        if (Session["IdPracownika"] == null) return RedirectToAction("Login", "Konto");
        //        int id = Convert.ToInt32(Session["IdPracownika"]);

        //        string sql = $@"SELECT b.* FROM BilingiKomorkowe b 
        //               JOIN NumeryKomorkowe n ON b.ID_NumeruKomorkowego = n.ID 
        //               WHERE n.ID_Pracownika = {id}";
        //        DataTable dt = _baza.PobierzDane(sql);

        //        return View(dt); // Przekazujemy surowe dane do dedykowanego widoku
        //    }

        //    // 3. Strona bilingów stacjonarnych
        //    public ActionResult BilingiStacjonarne()
        //    {
        //        if (Session["IdPracownika"] == null) return RedirectToAction("Login", "Konto");
        //        int id = Convert.ToInt32(Session["IdPracownika"]);

        //        string sql = $@"SELECT b.* FROM BilingiStacjonarne b 
        //               JOIN NumeryStacjonarne n ON b.ID_NumeruStacjonarnego = n.ID 
        //               WHERE n.ID_Pracownika = {id}";
        //        DataTable dt = _baza.PobierzDane(sql);

        //        return View(dt);
        //    }
        //}       

    }
}