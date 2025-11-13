using Lab02;
namespace Lab02
{
	internal class Student
	{
        //pola prywatne klasy Student
        private string imie, nazwisko;  // pola przechowujące imię i nazwisko studenta
        private int[] ocena;    // tablica przechowująca oceny studenta


        public Student(string imie, string nazwisko, int ocena) // konstruktor z parametrami
        {
			this.imie = imie;
			this.nazwisko = nazwisko;
			this.ocena = new int[] { ocena }; // Poprawka: inicjalizacja tablicy z jedną oceną
        }
        //Zaimplementuj właściwość SredniaOcen, która obliczy i zwróci średnią ocen
        public double SredniaOcen   // właściwość tylko do odczytu
        {
            get                     // akcesor get dostępu do właściwości ocena
            {
                if (ocena.Length == 0)  // sprawdzenie czy tablica ocen jest pusta
                {
                    return 0; // Unikaj dzielenia przez zero
                }
                double suma = 0;    // zmienna do przechowywania sumy ocen
                foreach (int ocenaValue in ocena)   // iteracja przez każdą ocenę w tablicy
                {
                    suma += ocenaValue; // dodawanie oceny do sumy
                }
                return suma / ocena.Length; // obliczanie i zwracanie średniej ocen
            }
        }

        // Dodaj metodę DodajOcene(int ocena), która doda nową ocenę do tablicy
        public void DodajOcene(int ocenaNowa) // metoda do dodawania nowej oceny
        {
            Array.Resize(ref ocena, ocena.Length + 1);  // zmiana rozmiaru tablicy ocen o 1
            ocena[ocena.Length - 1] = ocenaNowa;    // dodanie nowej oceny na koniec tablicy
        }

        //Zaimplementuj konstruktor inicjujący imię i nazwisko studenta

        //metoda View() wyświetlająca dane studenta
        public void View() // metoda do wyświetlania informacji o studencie
        {
            Console.WriteLine($"Imie: {imie}, Nazwisko: {nazwisko}, Srednia Ocen: {SredniaOcen}");  // wyświetlanie imienia, nazwiska i średniej ocen
        }


    }
}
