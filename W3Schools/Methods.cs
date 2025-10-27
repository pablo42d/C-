using W3Schools;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

namespace W3Schools
{
    internal class Methods
    {
        //wywołanie metody w głowym programie Main


        //int a = 5, b = 1;
        //Console.WriteLine(a + " + " + b + " = " + sum(a, b));
        //Console.WriteLine("suma liczb 3 + 4 = " + sum(3, 4));
        //Console.WriteLine("suma liczb 3 + 4 = " + sum(3, 4));

        //deklaracja metody wraz z ciałem metody
        private void View(string Welcome = "Hello")
        {
            Console.WriteLine(Welcome);
        }
        static int sum(int a, int b)
        {
            return a + b;
        }
        public int sum1(int a, int b)
        {
            return a + b;
        }

        /// <summary>
        /// Oblicza deltę równania kwadratowego.
        /// </summary>
        /// <param name="a">Współczynnik przy x².</param>
        /// <param name="b">Współczynnik przy x.</param>
        /// <param name="c">Wyraz wolny.</param>
        /// <returns>Wartość wyróżnika (delta).</returns>
        public double ObliczDelta(double a, double b, double c)
        {
            return (b * b) - (4 * a * c);
        }

        //Przykład pełnej dokumentacji metody
        /// <summary>
        /// Losuje liczbę rzeczywistą z podanego przedziału.
        /// </summary>
        /// <param name="min">Dolna granica przedziału.</param>
        /// <param name="max">Górna granica przedziału.</param>
        /// <returns>Wylosowana liczba rzeczywista z zakresu [min, max].</returns>
        /// <example>
        /// <code>
        /// double wynik = LosujLiczbe(1.5, 4.5);
        /// Console.WriteLine(wynik);
        /// </code>
        //PROGRAMOWANIE OBIEKTOWE C#
        /// </example>
        /// 
        private double LosujLiczbe(double min, double max)

        {
            Random rng = new Random();
            return min + rng.NextDouble() * (max - min);
        }
        public double LosujLiczbe()
        {
            return LosujLiczbe(1.5, 4.5);
        }




    }
}
