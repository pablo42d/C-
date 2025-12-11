using System;
using System.Collections.Generic;
using System.Text;

namespace Lab04.Zadanie2
{
    internal class Nauczyciel : Uczen
    {
        private string TytulNaukowy;
        public List<Uczen> PodwladniUczniowie{ get; private set; }
        public Nauczyciel(string imie, string nazwisko, string pesel, string szkola, bool mozeSamWracacDoDomu, string tytulNaukowy)
            : base(imie, nazwisko, pesel, szkola, mozeSamWracacDoDomu)
        {
            TytulNaukowy = tytulNaukowy;
            PodwladniUczniowie = new List<Uczen>();
        }
        public void DodajUcznia(Uczen uczen)
        {
            PodwladniUczniowie.Add(uczen);
        }
        public override string GetEducationInfo()
        {
            return $"Nauczyciel z tytułem naukowym: {TytulNaukowy}, uczący w szkole: {Szkola}";
        }
        public override string GetFullName()
        {
            return $"{TytulNaukowy} {Imie} {Nazwisko}";
        }
        public override bool CanGoAloneToHome()
        {
            return true; // Nauczyciele zawsze mogą wracać sami do domu
        }

        public string WhichStudentCanGoHomeAlone(DateTime now)
        {
            StringBuilder result = new StringBuilder(); // Używamy StringBuilder do budowania wyniku
            result.AppendLine("\nUczniowie, którzy mogą iść sami do domu:");    // Dodajemy nagłówek
            foreach (var u in PodwladniUczniowie)   // Iterujemy przez podwładnych uczniów
            {
                if (u.CanGoAloneToHome())   // Sprawdzamy, czy uczeń może iść sam do domu
                {
                    result.AppendLine($"- {u.GetFullName()} (wiek: {u.GetAge()} lat)"); // Dodajemy informacje o uczniu do wyniku
                }
            }
            return result.ToString();   // Zwracamy zbudowany wynik jako string
        }

        //public string TytulNaukowy { get; set; }
        //public List<Uczen> PodwladniUczniowie { get; set; } = new List<Uczen>();

        //public void WhichStudentCanGoHomeAlone(DateTime dateToCheck)
        //{
        //    Console.WriteLine($"\nUczniowie, którzy mogą iść sami do domu:");

        //    foreach (var u in PodwladniUczniowie)
        //    {
        //        if (u.CanGoAloneToHome())
        //        {
        //            Console.WriteLine($"- {u.GetFullName()} (wiek: {u.GetAge()} lat)");
        //        }
        //    }
        //}
    }
}
