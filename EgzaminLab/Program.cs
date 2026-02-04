// 

using EgzaminLab;

Console.WriteLine("\n=== REJESTR REZERWACJI- Wyświetl wszystkie rezerwacje ===");
Console.WriteLine("\n");
RejestrRezerwacji system = new RejestrRezerwacji();

// Tworzymy rezerwację na jutro i na 
Rezerwacja r1 = new Rezerwacja("R001", "Sala 204", "Jan Kowalski", DateTime.Now.AddDays(1), "Aktywna");
Rezerwacja r2 = new Rezerwacja("R005", "Projektor", "Anna Nowak", DateTime.Now.AddDays(1), "Aktywna");
Rezerwacja r3 = new Rezerwacja("R022", "Laboratorium AI", "Piotr Wiśniewski", DateTime.Now.AddDays(4), "Aktywna");

system.DodajRezerwacje(r1);
system.DodajRezerwacje(r2);
system.DodajRezerwacje(r3);
system.WyswietlWszystkie();

Console.WriteLine("\n=== REJESTR REZERWACJI - Zmiana statusu ===");
Console.WriteLine("\n");
r1.ZmienStatus("Zrealizowana");
system.WyswietlWszystkie();

Console.WriteLine("\n=== REJESTR REZERWACJI - Usuwanie rezerwacji ===");
Console.WriteLine("\n");
system.UsunRezerwacje("R005"); //bez obsługi wyjątków 
system.WyswietlWszystkie();

Console.WriteLine("\n=== REJESTR REZERWACJI - Szukanie rezerwacji ===");
Console.WriteLine("\n");
system.ZnajdzRezerwacje("R022");//bez obsługi wyjątków

