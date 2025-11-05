using Lab02;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Zad.1");
        //Person person = new Person();
        //person.FirstName = "Paweł";
        //person.LastName = "Drag";
        //person.Age = 43;
        //person.View();

        // tworzenie tablicy obiektów Person z trzema elementami
        Person[] people = new Person[3];

        // wypełnianie tablicy obiektami Person
        people[0] = new Person("Alice", "Smith", 34);
        people[1] = new Person("Bob", "Johnson", 45);
        people[2] = new Person("Charlie", "Brown", 28);
        
        // wywoływanie metody View() dla każdego obiektu w tablicy
        foreach (Person personValue in people)
        {   personValue.View(); }

        Console.WriteLine("Zad.2");

        // Przykład użycia:
        BankAccount konto = new BankAccount("Jan Kowalski", 1000);
        konto.Wplata(500);
        konto.Wyplata(200);
        Console.WriteLine($"Saldo: {konto.Saldo}");
        Console.WriteLine("Właściciel: " + konto.Wlasciciel + " a jego saldo konta to kwota: " + konto.Saldo);

    }
}
