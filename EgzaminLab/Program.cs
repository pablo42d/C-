// 

using EgzaminLab;

//Console.WriteLine("\n=== REJESTR REZERWACJI- Wyświetl wszystkie rezerwacje ===");
//Console.WriteLine("\n");
//RejestrRezerwacji system = new RejestrRezerwacji();

//// Tworzymy rezerwację na jutro i na 
//Rezerwacja r1 = new Rezerwacja("R001", "Sala 204", "Jan Kowalski", DateTime.Now.AddDays(1), "Aktywna");
//Rezerwacja r2 = new Rezerwacja("R005", "Projektor", "Anna Nowak", DateTime.Now.AddDays(1), "Aktywna");
//Rezerwacja r3 = new Rezerwacja("R022", "Laboratorium AI", "Piotr Wiśniewski", DateTime.Now.AddDays(4), "Aktywna");

//system.DodajRezerwacje(r1);
//system.DodajRezerwacje(r2);
//system.DodajRezerwacje(r3);
//system.WyswietlWszystkie();

//Console.WriteLine("\n=== REJESTR REZERWACJI - Zmiana statusu ===");
//Console.WriteLine("\n");
//r1.ZmienStatus("Zrealizowana");
//system.WyswietlWszystkie();

//Console.WriteLine("\n=== REJESTR REZERWACJI - Usuwanie rezerwacji ===");
//Console.WriteLine("\n");
//system.UsunRezerwacje("R005"); //bez obsługi wyjątków 
//system.WyswietlWszystkie();

//Console.WriteLine("\n=== REJESTR REZERWACJI - Szukanie rezerwacji ===");
//Console.WriteLine("\n");
//system.ZnajdzRezerwacje("R022");//bez obsługi wyjątków

// Zadanie 2 - Polimorfizm i interfejsy
Console.WriteLine("\n");
Console.WriteLine("\n=== REJESTR REZERWACJI- Wyświetl wszystkie rezerwacje zadanie 2===");
Console.WriteLine("\n");

// Tworzymy różne typy rezerwacji
RejestrRezerwacji system = new RejestrRezerwacji();

// 1. Tworzymy różne obiekty (Polimorfizm)
RezerwacjaSali sala = new RezerwacjaSali
{
    IdRezerwacji = "S001",
    Zasob = "Sala Wykładowa",
    NumerSali = 204
};

RezerwacjaSprzetu projektor = new RezerwacjaSprzetu
{
    IdRezerwacji = "P005",
    Zasob = "Projektor Multimedialny",
    TypSprzetu = "Elektronika"
};

RezerwacjaLaboratorium lab = new RezerwacjaLaboratorium
{
    IdRezerwacji = "L022",
    Zasob = "Pracownia Komputerowa",
    NazwaLaboratorium = "Laboratorium AI"
};

// 2. Dodajemy je do jednego systemu
system.DodajRezerwacje(sala);
system.DodajRezerwacje(projektor);
system.DodajRezerwacje(lab);

// 3. Wyświetlamy wszystko (każdy obiekt wywoła swoją wersję metody Wyswietl)
Console.WriteLine("=== REJESTR REZERWACJI (Zadanie 2) ===");
system.WyswietlWszystkie();

// 4. Test szukania/usuwania
Console.WriteLine("\nUsuwanie rezerwacji sprzętu P005...");
system.UsunRezerwacje("P005");

Console.WriteLine("\n=== LISTA PO USUNIĘCIU ===");
system.WyswietlWszystkie();