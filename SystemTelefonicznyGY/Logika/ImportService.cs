//using System;
//using System.Collections.Generic;
//using System.IO;
//using System.Web;
//using System.Globalization;

//namespace SystemTelefonicznyGY.Logika
//{
//    public class ImportService
//    {
//        private readonly BazaDanych _baza;

//        public ImportService(BazaDanych baza)
//        {
//            _baza = baza;
//        }

//        public int ProcesujPlikCSV(HttpPostedFileBase plik, string typ)
//        {
//            string tabela = (typ == "kom") ? "BilingiKomorkowe" : "BilingiStacjonarne";
//            var listaPolecen = new List<(string sql, Dictionary<string, object> paramy)>();
//            int licznik = 0;
//            string numerFakturyZPliku = "";

//            // Ustawiamy kulturę polską dla poprawnego parsowania kwot z przecinkiem
//            var polskaKultura = new CultureInfo("pl-PL");

//            using (var reader = new StreamReader(plik.InputStream))
//            {
//                reader.ReadLine(); // Pomijamy nagłówek
//                while (!reader.EndOfStream)
//                {
//                    var linia = reader.ReadLine();
//                    if (string.IsNullOrWhiteSpace(linia)) continue;
//                    var w = linia.Split(';');
//                    if (w.Length < 9) continue;

//                    numerFakturyZPliku = w[8].Trim();

//                    // BEZPIECZNE PARSOWANIE DATY
//                    if (!DateTime.TryParse(w[0], polskaKultura, DateTimeStyles.None, out DateTime dataPolaczenia))
//                    {
//                        // Jeśli standardowe parsowanie zawiedzie, próbujemy konkretny format
//                        DateTime.TryParseExact(w[0], "dd.MM.yyyy HH:mm", polskaKultura, DateTimeStyles.None, out dataPolaczenia);
//                    }

//                    // BEZPIECZNE PARSOWANIE KWOT (Netto i Brutto)
//                    decimal.TryParse(w[6].Replace('.', ','), NumberStyles.Any, polskaKultura, out decimal netto);
//                    decimal.TryParse(w[7].Replace('.', ','), NumberStyles.Any, polskaKultura, out decimal brutto);

//                    var p = new Dictionary<string, object> {
//                { "@data", dataPolaczenia },
//                { "@numA", KonwertujNumer(w[1]) },
//                { "@numB", KonwertujNumer(w[2]) },
//                { "@typ", w[3] },
//                { "@czas", w[5] },
//                { "@netto", netto },
//                { "@brutto", brutto },
//                { "@faktura", numerFakturyZPliku }
//            };

//                    string sql = $@"INSERT INTO {tabela} (DataPolaczenia, NumerTelefonu, NumerWybierany, TypPolaczenia, CzasTrwania, KwotaNetto, KwotaBrutto, NrFaktury) 
//                           VALUES (@data, @numA, @numB, @typ, @czas, @netto, @brutto, @faktura)";

//                    listaPolecen.Add((sql, p));
//                    licznik++;
//                }
//            }

//            if (listaPolecen.Count > 0 && !string.IsNullOrEmpty(numerFakturyZPliku))
//            {
//                var pUsun = new Dictionary<string, object> { { "@f", numerFakturyZPliku } };
//                listaPolecen.Insert(0, ($"DELETE FROM {tabela} WHERE NrFaktury = @f", pUsun));
//                _baza.WykonajWielePolecen(listaPolecen); // Wykonanie wszystkiego w jednej bezpiecznej transakcji
//            }

//            return licznik;
//        }

//        private string KonwertujNumer(string raw)
//        {
//            if (string.IsNullOrWhiteSpace(raw)) return "";
//            raw = raw.Trim().Replace(" ", "");
//            if (raw.Contains("E+"))
//            {
//                if (double.TryParse(raw.Replace(",", "."), System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out double parsed))
//                    return parsed.ToString("F0");
//            }
//            return raw;
//        }
//    }
//}