﻿using Lab02;

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

        Person[] people = new Person[3];
        // wypełnianie tablicy obiektami Person

        people[0] = new Person("Alice", "Smith", 34);
        people[1] = new Person("Bob", "Johnson", 45);
        people[2] = new Person("Charlie", "Brown", 28);
        // wywoływanie metody View() dla każdego obiektu w tablicy

        foreach (Person personValue in people)
        {   personValue.View(); }


        
        //    //Parallel.For(0, people.Length, i =>
        //    //{
        //    //    people[i].View();
        //    //});
        
    }
}
