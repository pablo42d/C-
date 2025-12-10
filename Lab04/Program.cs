using Lab04;
using Lab04.Klasy_Abstrakcyjne;
using Lab04.Interfejs;
using System;
using System.Net.NetworkInformation;
using Lab04.PrzeciazanieMetod;
using Lab04.Polimorfizm;
using Lab04.Cwiczenie1;

/*
 * Polimorfizm statyczny mechanim łączenia metody z obiektem w trakcie kompilacji jest nazywany
wczesnym wiązaniem lub też statycznym wiązaniem. C# udostępnia dwa sposoby implementowania
statycznego polimorfizmu: przeciążanie metod, przeciązanie operatorów.
Polimorfizm dynamiczny - pozwala tworzyć klasy abstrakcyjne, które następnie są implementowane w
klasach pochodnych. Klasa taka zawiera abstrakcyjne metody, których implementacja zależy od
wykorzystania w poszczególnych klasach pochodnych. Poniżej lista zasad o których należy pamiętać
tworząc klasy abstrakcyjne:
• nie można utworzyć instancji klasy abstrakcyjnej;
• nie można zadeklarować metody abstrakcyjnej poza klasą abstrakcyjną;
• kiedy klasa opatrzona jest modyfikatorem dostępu sealed nie może być dziedziczona.
Dodatkowo, klasa abstrakcyjna nie może być zdefiniowana jakas sealed
*/

Console.WriteLine("=============== Polimorfizm ====================");

// Example usage of the Animal class with different contracts Dog and Pig

// ========= Main ===========================
Animal myAnimal = new Animal(); // Create a Animal object
Animal myPig = new Pig(); // Create a Pig object
Animal myDog = new Dog(); // Create a Dog object
myAnimal.Speak();
myPig.Speak();
myDog.Speak();

// ===========================================

Console.WriteLine("===================== Przeciążanie metod ==============");

//Przeciążanie metod w clasie WyswietlanieDanych
WyswietlanieDanych wd = new WyswietlanieDanych();
wd.Wyswietl(5);
wd.Wyswietl(5.5);
wd.Wyswietl(4.5);
wd.Wyswietl("4.5");
wd.Wyswietl("Ala ma kota");

// ===========================================

Console.WriteLine("===================== Przeciążanie operatorów ==============");
//Przeciążanie operatorów w klasie Pudelko
double objetosc = 0;
Pudelko p1 = new Pudelko();
Pudelko p2 = new Pudelko();
Pudelko p3 = new Pudelko();
// specyfikacja 1
p1.PobierzDlugosc(3.5);
p1.PobierzSzerokosc(4.0);
p1.PobierzWysokosc(5.5);
// specyfikacja 2
p2.PobierzDlugosc(2.5);
p2.PobierzSzerokosc(5.0);
p2.PobierzWysokosc(4.5);
// specyfikacja 3
p3.PobierzDlugosc(12.5);
p3.PobierzSzerokosc(15.0);
p3.PobierzWysokosc(14.5);
// Wyswietlenie danych wewnatrz kolejnych obiektow
Console.WriteLine("Pudelko 1: {0}", p1.ToString());
Console.WriteLine("Pudelko 2: {0}", p2.ToString());
Console.WriteLine("Pudelko 3: {0}", p3.ToString());

// objetosc 1
objetosc = p1.ObliczObjetosc();
Console.WriteLine("Objetosc 1: {0}", objetosc);
// objetosc 2
objetosc = p2.ObliczObjetosc();
Console.WriteLine("Objetosc 2: {0}", objetosc);
// Dodanie 2 obiektów
p3 = p1 + p2;
// objetosc 3
objetosc = p3.ObliczObjetosc();
Console.WriteLine("Objetosc 3: {0}", objetosc);
// porównanie obiektów
if (p1 == p2)
    Console.WriteLine("Pudełka p1 oraz p2 są identyczne");
if (p1 != p2)
    Console.WriteLine("Pudełka p1 oraz p2 są różne");
Console.ReadKey();

// ===========================================

Console.WriteLine("===================== Klasy abstrakcyjne ===================");

//Klasy abstrakcyjne Figure, Square, Rectangle

Square square = new Square();
square.view();
Rectangle rectangle = new Rectangle();
rectangle.view();
// ===========================================

Console.WriteLine("===================== Interfejs ===================");

Transakcje t1 = new Transakcje("01", "25/11/2023", 331);
Transakcje t2 = new Transakcje("02", "26/11/2023", 3321);
t1.WyswietlDane();
t2.WyswietlDane();

// ===========================================

Console.WriteLine("===============  System zarządzania formami zatrudnienia w firmie ====================");

Employee[] employees =
{
    new Employee("Jan", "Nowak"),
    new Employee("Jan1", "Nowak1", new Position(5200m, 10)),
    new Employee("Jan2", "Nowak2"),
    new Employee("Jan3", "Nowa3", new Position(5200m, 120))
};


foreach (var item in employees)
{
    Console.WriteLine(item.ToString());
}





