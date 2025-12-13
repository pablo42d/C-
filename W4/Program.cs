using W4;

ListaOsoba zespolIT = new ListaOsoba("Zespół IT");  //najlepiej żeby była to klasa abstrakcyjna lub interface
Osoba o1  = new Osoba("Jan", "Kowalski", 30, "Programista");
Osoba o2  = new Osoba("Anna", "Nowak", 28, "Tester");
zespolIT.DodajOsobe(o1);
zespolIT.DodajOsobe(o2);
zespolIT.DodajOsobe(new Osoba("Marek", "Wiśniewski", 35, "Administrator"));
zespolIT.DodajOsobe("Kasia", "Wójcik", 26, "Projektant UX");
zespolIT.WyswietlOsoby();
zespolIT.printData();
string filePath = "lista_osob.txt";
zespolIT.printToFile(filePath);

zespolIT.readFromFile(filePath);

// JSON 
// System.Text.Json
// Newtonsoft.Json (Json.NET) trzeba dodać przez NuGet package manager

zespolIT.printToJson("lista_osob.json");
zespolIT.redFromJson("lista_osob.json");
zespolIT.readFromFile(filePath);
zespolIT.printData();
zespolIT.readFromFile(dane);
zespolIT.WyswietlOsoby();
//             System.IO.File.WriteAllText(filePath, json);
