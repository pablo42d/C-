using System;
using System.Collections.Generic;
using System.Text;
using Lab04.Zadanie2;


namespace Lab04.Zadanie2
{
    internal class Uczen : Osoba
    {
        public string Szkola { get; private set; }
        public bool MozeSamWracacDoDomu { get; private set; }

        public void SetSchool(string school) => Szkola = school;
        public void ChangeSchool(string newSchool) => Szkola = newSchool;
        public void SetCanGoHomeAlone(bool canGo) => MozeSamWracacDoDomu = canGo;
        public Uczen(string imie, string nazwisko, string pesel, string szkola,  bool mozeSamWracacDoDomu)
            : base(imie, nazwisko, pesel)
        {
            Szkola = szkola;
            MozeSamWracacDoDomu = mozeSamWracacDoDomu;
        }

        public override string GetEducationInfo()
        {
            return $"Uczeń szkoły: {Szkola}";
        }

        public override string GetFullName()
        {
            return $"{Imie} {Nazwisko}";
        }

        public override bool CanGoAloneToHome()
        {
            int age;
            if (int.TryParse(GetAge().ToString(), out age))    // Sprawdza czy GetAge() można przekonwertować na int
            {
                if (age >= 12) return true;
                return MozeSamWracacDoDomu;
            }
            // Jeśli nie można przekonwertować, zwróć false lub obsłuż błąd w inny sposób
            return false;
        }
    }
}
