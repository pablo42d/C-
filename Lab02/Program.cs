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

        Console.WriteLine("Zad.3");
        // Przykład użycia:
        Student student = new Student("Anna", "Nowak", 4);
        student.DodajOcene(5);
        student.DodajOcene(4);       
        student.View(); // Wyświetla informacje o studencie wraz ze średnią ocen 4.333333
        Student student2 = new Student("Marek", "Kowalski", 2);
        student2.DodajOcene(3); 
        student2.DodajOcene(4);
        student2.View();

        Console.WriteLine("Zad.4");
        Licz licz = new Licz(40);
        Licz licz2 = new Licz(20);
        licz.Dodaj(10);
        licz.Odejmij(3);
        //licz.Wynik = 20; // Ustawienie wyniku bezpośrednio
        Console.WriteLine($"Wartość licz: {licz.Wynik}, wartość licz2: {licz.Wynik}");

        //// Przykład użycia bez konstruktora:
        //Licz liczbk = new Licz();
        //liczbk.Dodaj(7);
        //liczbk.Odejmij(2);
        //Licz.PokazWyrazenie(liczbk.Wynik); // Wyświetli: "Wynik wyrażenia: 11" z konstruktorem i dodaniem parametru seter Wynik wyrażenia:0
        ////Przykład użycia z konstruktorem:
        //Licz liczzk = new Licz(10);
        //liczzk.Dodaj(5);
        //liczzk.Odejmij(3);
        //Licz.PokazWyrazenie(liczzk.Wynik); // Wyświetli: "Wynik wyrażenia: 12"


        Console.WriteLine("Koniec programu.");

    }
}
