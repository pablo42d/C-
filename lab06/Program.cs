//// See https://aka.ms/new-console-template for more information
//using System.Text.Json;

//Console.WriteLine("Hello, World!");


//string content = File.ReadAllText("dane.txt");
//Console.WriteLine(content);

//string[] lines = File.ReadLines(content);

//StreamReader // duże dane 
//File.WriteAllText // adpisanie danych
////joson i seriolizacja  danych to string string na text i text na string
//string joson = JsonSerializer.Serialize(lines);
//// 5 kroków 

using lab06;

var repo = new TxtContactReposytory("contact.txt");
ShowAll(repo);
static void ShowAll(TxtContactReposytory repo)
{
    var contact = repo.GetAll();
    if (contact.Count == 0)
    { Console.WriteLine("brak kontaktó"};
    return;
}

static void Add(TxtContactReposytory repo);
{
    var c = ReadContactFromUser(requireID: true);
    repo.Add(c);
    Console.WriteLine("Dodano dane");
};
// linia 56 /line nie zadziała zmiana na 
static Contact ReadContactFromeUser (bool requireID)
{
    int id = 0;
    if (requireID)
    {
        Console.WriteLine("Id: ");
        id = int.Parse(Console.ReadLine()) ?? "0");
    }
    Console.WriteLine("Podaj Imię i nazwisko: ");
    string name = Console.ReadLine() ?? "";

    Console.WriteLine("Podaj e-mail: ");
    string email = Console.ReadLine() ?? "");

    return new Contact {Id = id, Name = name, Email = email};

}