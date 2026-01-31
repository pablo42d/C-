// Sklep i Produkty (Kompozycja i Polimorfizm)

using Sklep;

List<Produkty> sklep = new List<Produkty>();
sklep.Add(new Elektronika("Smartfon", 2000));
sklep.Add(new Spozywczy("Chleb", 3));
sklep.Add(new Elektronika("Laptop", 5000));
sklep.Add(new Spozywczy("Mleko", 2.5m));

decimal suma = 0;
foreach (var prod in sklep)
{ Console.WriteLine(prod.ToString());
suma += prod.ObliczCene();
}
Console.WriteLine($"Suma do zaplaty: {suma} zl");

