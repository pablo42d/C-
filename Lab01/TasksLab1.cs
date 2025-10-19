
using Lab01;

namespace Lab01
{

    /// <summary>

    /// Klasa która zaweira zestaw metod do zadań z lab 1.

    /// </summary>

    /// <remarks>

    /// Autor: Jan Kowalski

    /// data: 12.10.2025

    /// versia: 1.0

    /// Śreodwiska: net9.0

    /// </remarks>

    internal class TasksLab1

    {



        private readonly Random _rng = new Random();



        /// <summary>

        /// Zadanie 1: Wyzanczanie pierwiastkó równanai kwadratowego

        /// </summary>

        /// <remarks>Wyniki wyśweitlane są na konsoli</remarks>

        private void Zadanie1()

        {

            double x1, x2, delta;



            Console.WriteLine("Podaj wartość a:");

            double a = Convert.ToDouble(Console.ReadLine());



            Console.WriteLine("Podaj wartość b:");

            double b = Convert.ToDouble(Console.ReadLine());



            Console.WriteLine("Podaj wartość c:");

            double c = Convert.ToDouble(Console.ReadLine());



            if (a != 0)

            {

                delta = (b * b) - (4 * a * c);

                if (delta > 0)

                {

                    x1 = (-b - Math.Sqrt(delta)) / (2 * a);

                    x2 = (-b + Math.Sqrt(delta)) / (2 * a);



                    Console.WriteLine($"Dwa rozwiązania x1 = {x1:F2} \t x2 = {x2:F2}");

                    Console.WriteLine("Dwa rozwiązania x1 = " + x1 + "\t x2 = " + x2);

                }

                else if (delta == 0)

                {

                    x1 = (-b) / (2 * a);

                    Console.WriteLine($"Jedno rozwiązanie x1 = {x1:F2}");

                }

                else Console.WriteLine("Brak rozwiązania w zbiorze liczb rzeczywistych");



            }

            else

                Console.WriteLine("To nie jest rówananie kwadratowe");

        }



        public void Run()

        {

            //Zadanie1();

            Zadanie2();

        }



        private void Zadanie2()

        {



            //for (int i = 0; i < liczby.Length; i++) {

            //    Console.WriteLine($"Podaj liczbę nr {i + 1}");

            //    liczby[i]= Convert.ToDouble(Console.ReadLine());

            //}



            Console.Write("Podaj liczbę elementów (n): ");

            if (!int.TryParse(Console.ReadLine(), out int n) || n <= 0)

            {

                Console.WriteLine("Błędna wartość n.");

                return;

            }



            Console.Write("Podaj dolną granicę przedziału (min): ");

            if (!double.TryParse(Console.ReadLine(), out double min))

            {

                Console.WriteLine("Błędna wartość min.");

                return;

            }



            Console.Write("Podaj górną granicę przedziału (max): ");

            if (!double.TryParse(Console.ReadLine(), out double max))

            {

                Console.WriteLine("Błędna wartość max.");

                return;

            }



            if (min > max)

            {

                (min, max) = (max, min);

                Console.WriteLine($"Uwaga: zamieniono granice. Nowy przedział: [{min}, {max}].");

            }



            double[] liczby = LosujTabliceDouble(n, min, max);







        }// koniec zadani 2



        private double LosujLiczbeOdUzytkownika()

        {

            Console.Write("Podaj dolną granicę przedziału (min): ");

            double min = Convert.ToDouble(Console.ReadLine());

            Console.Write("Podaj górną granicę przedziału (max): ");

            double max = Convert.ToDouble(Console.ReadLine());

            if (min > max)

            {

                double temp = min;

                min = max;

                max = temp;

                Console.WriteLine($"Zamieniono granice. Nowy przedział: [{min}, {max}]");

            }

            Random rng = new Random();

            double wynik = min + rng.NextDouble() * (max - min);

            Console.WriteLine($"Wylosowana liczba: {wynik:F2}");

            return wynik;

        }

        private double[] LosujTabliceDouble(int n, double min, double max)

        {

            double[] arr = new double[n];

            double zakres = max - min;



            for (int i = 0; i < n; i++)

                arr[i] = min + _rng.NextDouble() * zakres; // NextDouble() -> [0,1)



            return arr;

        }

    }

}

