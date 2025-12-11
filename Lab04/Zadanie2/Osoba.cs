using Lab04.Zadanie2;
using System;
using System.Collections.Generic;
using System.Text;
using static System.Net.Mime.MediaTypeNames;

namespace Lab04.Zadanie2
{
    abstract class Osoba
    {
        protected string Imie;
        protected string Nazwisko;
        protected string Pesel;
        // metody
        public Osoba(string imie, string nazwisko, string pesel)
        {
            Imie = imie;
            Nazwisko = nazwisko;
            Pesel = pesel;
            //SetPesel(pesel);
        }
        //public void SetLastName(string nazwisko) => Nazwisko = nazwisko;
        //public void SetPesel(string pesel) => Pesel = pesel;
        //public string SetFirstName(string imie)
        //{
        //    Imie = imie;
        //    return Imie;
        //}

        

        //public void SetPesel(string pesel)
        //{
        //    if (!IsValidPesel(pesel))
        //        throw new ArgumentException("PESEL must be 11 digits.", nameof(pesel));
        //    Pesel = pesel;
        //}
        //private static bool IsValidPesel(string pesel) =>
        //!string.IsNullOrEmpty(pesel) && pesel.Length == 11 && pesel.All(char.IsDigit);

        //public int GetAge()
        //{
        //    if (!IsValidPesel(Pesel))
        //        throw new InvalidOperationException("PESEL is not set or invalid.");

        //    int rok = int.Parse(Pesel.Substring(0, 2));
        //    int miesiac = int.Parse(Pesel.Substring(2, 2));
        //    int dzien = int.Parse(Pesel.Substring(4, 2));

        //    if (miesiac > 20) { rok += 2000; miesiac -= 20; }
        //    else { rok += 1900; }

        //    var dataUrodzenia = new DateTime(rok, miesiac, dzien);
        //    int age = DateTime.Now.Year - dataUrodzenia.Year;
        //    if (DateTime.Now.DayOfYear < dataUrodzenia.DayOfYear) age--;
        //    return age;
        //}
        //public string GetGender()
        //{
        //    if (!IsValidPesel(Pesel)) throw new InvalidOperationException("PESEL is not set or invalid.");
        //    int genderDigit = Pesel[9] - '0';
        //    return genderDigit % 2 == 0 ? "Kobieta" : "Mężczyzna";
        //}


        //public string SetPesel(string pesel)
        //{
        //    if (pesel.Length != 11 || !long.TryParse(pesel, out _))
        //    {
        //        throw new ArgumentException("PESEL must be exactly 11 digits.");
        //    }
        //    Pesel = pesel;
        //    return Pesel;
        //}


       

        public int GetAge()
        {
            int rok = int.Parse(Pesel.ToString().Substring(0, 2)); // pobranie roku z PESEL
            int miesiac = int.Parse(Pesel.ToString().Substring(2, 2));  // pobranie miesiąca z PESEL
            int dzien = int.Parse(Pesel.ToString().Substring(4, 2));    // pobranie dnia z PESEL

            if (miesiac > 20)
            {
                rok += 2000;
                miesiac -= 20;
            }
            else
            {
                rok += 1900;
            }
            DateTime dataUrodzenia = new DateTime(rok, miesiac, dzien);
            int age = DateTime.Now.Year - dataUrodzenia.Year;
            if (DateTime.Now.DayOfYear < dataUrodzenia.DayOfYear)
                age--;
            return age;
            

            //------------ alternatywna wersja ----------------
            /*
            // obsługa stuleci
            int centuryModifier = month / 20; // 0 → 1900, 1 → 2000, itd.
            if (centuryModifier == 0) year += 1900;
            else if (centuryModifier == 1) year += 2000;

            month %= 20;

            DateTime birthDate = new DateTime(year, month, day);
            int age = DateTime.Now.Year - birthDate.Year;
            if (DateTime.Now < birthDate.AddYears(age))
                age--;
            return age;
            */

        }
        public string GetGender()
        {
            //string peselStr = Pesel.ToString().PadLeft(11, '0');
            //int genderDigit = int.Parse(peselStr[9].ToString());
            int genderDigit = int.Parse(Pesel[9].ToString());
            return genderDigit % 2 == 0 ? "Kobieta" : "Mężczyzna";
        }


        public abstract string GetEducationInfo();
        public abstract string GetFullName();
        public abstract bool CanGoAloneToHome();

    }
}
