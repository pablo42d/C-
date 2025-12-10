using Lab04;

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
Dodatkowo, klasa abstrakcyjna nie może być zdefinowana jakas sealed
*/


