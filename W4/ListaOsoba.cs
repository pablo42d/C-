using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace W4
{
    internal class ListaOsoba
    {
        private List<Osoba> listaosob;
        public ListaOsoba()
        {
            listaosob = new List<Osoba>();
        }
        public void DodajOsobe(Osoba osoba)
        {
            listaosob.Add(osoba);
        }
        public void WyswietlOsoby()
        {
            Console.WriteLine("Lista osób:");
            foreach (var osoba in listaosob)
            {
                Console.WriteLine(osoba.ToString());
            }
        }
        public void printData(
        {
            Console.WriteLine("Lista osób:");
            foreach (var osoba in listaosob)
            {
                Console.WriteLine(osoba.ToString());
            }
        }
        public void printToFile(string filePath)
        {
            using (var writer = new StreamWriter(filePath))
            {
                foreach (var osoba in listaosob)
                {
                    writer.WriteLine(osoba.ToString());
                }
            }
        }
        public void readFromFile(string filePath)
        {

            using (StreamReader plik = new StreamReader(filePath))
            {
                string linia;
                while ((linia = plik.ReadLine()) != null)
                {
                    string[] dane = SpanLineEnumerator.Split('');
                    //Console.WriteLine(l$"{dane[0]}");
                    ListaOsoba.DodajOsobe(new Osoba(dane[0], dane[1], int.Parse(dane[2]), dane[3]));
                    //var dane = linia.Split(new[] { ", Wiek: ", ", Zawód: " }, StringSplitOptions.None);
                    //if (dane.Length == 3)
                    //{
                    //    var imieNazwisko = dane[0].Split(' ');
                    //    if (imieNazwisko.Length >= 2 && int.TryParse(dane[1], out int wiek))
                    //    {
                    //        string imie = imieNazwisko[0];
                    //        string nazwisko = string.Join(" ", imieNazwisko, 1, imieNazwisko.Length - 1);
                    //        string zawod = dane[2];
                    //        listaosob.Add(new Osoba(imie, nazwisko, wiek, zawod));
                    //    }
                    //}

                    //listaosob.Clear();
                    //using (var reader = new StreamReader(filePath))
                    //{
                    //    string line;
                    //    while ((line = reader.ReadLine()) != null)
                    //    {
                    //        var parts = line.Split(new[] { ", Wiek: ", ", Zawód: " }, StringSplitOptions.None);
                    //        if (parts.Length == 3)
                    //        {
                    //            var nameParts = parts[0].Split(' ');
                    //            if (nameParts.Length >= 2 && int.TryParse(parts[1], out int wiek))
                    //            {
                    //                string imie = nameParts[0];
                    //                string nazwisko = string.Join(" ", nameParts, 1, nameParts.Length - 1);
                    //                string zawod = parts[2];
                    //                listaosob.Add(new Osoba(imie, nazwisko, wiek, zawod));
                    //            }
                    //        }
                    //    }
                    //}

                }
            }
        }

        public void printToJson(string filePath)
        {
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(listaosob, Newtonsoft.Json.Formatting.Indented);
            var options = new System.Text.Json.JsonSerializerOptions { WriteIndented = true };
            string jsonString = System.Text.Json.JsonSerializer.Serialize(listaosob, options);
            System.IO.File.WriteAllText(filePath, jsonString);
        }


        public void redFromJson(string filePath)
        {
            string jsonString = System.IO.File.ReadAllText(filePath);
            listaosob = System.Text.Json.JsonSerializer.Deserialize<List<Osoba>>(jsonString);
            string dane = File.ReadAllText(filePath);
            listaosob = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Osoba>>(dane);
        }


    }
}
