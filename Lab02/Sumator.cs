using Lab02;

public class Sumator
{
    // publiczne pole Liczby będącym tablicą liczb

    //public int[] Liczby;
    private int[] Liczby;

    // konstruktor z parametrem inicjującym pole Liczby
    public Sumator(int[] liczby)
    {
        this.Liczby = liczby;
    }

    // metoda Suma zwracającą sumę liczb z pola Liczby
    public int Suma()
    {
        int suma = 0;
        foreach (int liczba in Liczby)
        {
            suma += liczba;
        }
        return suma;
    }
    // metodę SumaPodziel2 zwracającą sumę liczb z tablicy, które są podzielne przez 2
    public int SumaPodziel2()
    {
        int sumaPodziel2 = 0;
        foreach (int liczba in Liczby)
        {
            if (liczba % 2 == 0)
            {
                sumaPodziel2 += liczba;
            }
        }
        return sumaPodziel2;
    }

    //Dodaję metodę: int IleElementów() zwracającej liczbę elementów w tablicy
    public int IleElementow()
    {
        return Liczby.Length;
    }
    public int IleElementow2() {
        int count = 0;
        foreach (int liczba in Liczby) {
            count++;
        }
        return count;
    }

    //Dodaję metodę wypisującą wszystkie elementy tablicy    
    public int WypiszElementy()
    {
        Console.WriteLine("Elementy tablicy:");
        foreach (int liczba in Liczby)
        {
            Console.WriteLine(liczba);
        }
        return Liczby.Length;
    }

    //Dodaję metodę przyjmującą dwa parametry: lowIndex oraz highIndex, która wypisze elementy o indeksach >= lowIndex oraz <= highIndex.Metoda powinna zadziałać poprawnie, gdy lowIndex lub highIndex wykraczają poza zakres tablicy(pominąć te elementy).
    public void WypiszElementyZakres(int lowIndex, int highIndex)
    {
        Console.WriteLine($"Elementy tablicy od indeksu {lowIndex} do {highIndex}:");
        for (int i = lowIndex; i <= highIndex; i++)
        {
            if (i >= 0 && i < Liczby.Length)
            {
                Console.WriteLine(Liczby[i]);
            }
        }
    }
}
