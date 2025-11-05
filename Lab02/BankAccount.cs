using Lab02;

namespace Lab02
{
    internal class BankAccount
    {
        // Zaimplementuj właściwości Saldo (publiczne, tylko do odczytu) oraz Właściciel (publiczne, tylko do odczytu) i Właściciel.

        private decimal SaldoPoczatkowe;
        public readonly string Wlasciciel;

        // Metoda Wplata(decimal kwota), która pozwala na zwiększenie salda,
        public BankAccount(string wlasciciel, decimal saldoPoczatkowe) // konstruktor z parametrami
        {
            this.Wlasciciel = wlasciciel;
            this.SaldoPoczatkowe = saldoPoczatkowe;
        }
        public void Wplata(decimal kwota)
        {
            if (kwota <= 0)
            {
                throw new ArgumentException("Kwota wpłaty musi być większa od zera.");
            }
            SaldoPoczatkowe += kwota;
        }

        // Metoda Wyplata(decimal kwota), która sprawdzi, czy jest wystarczająca ilość środków, a następnie odejmie odpowiednią kwotę.
        public void Wyplata(decimal kwota)
        {
            if (kwota <= 0)
            {
                throw new ArgumentException("Kwota wypłaty musi być większa od zera.");
            }
            if (kwota > SaldoPoczatkowe)
            {
                throw new InvalidOperationException("Niewystarczające środki na koncie.");
            }
            SaldoPoczatkowe -= kwota;
        }

        // Użyj operatorów dostępu, aby zabezpieczyć saldo przed bezpośrednią modyfikacją.
        public decimal Saldo
        {
            get { return SaldoPoczatkowe; }
        }
        //public string Wlasciciel
        //{
        //    get { return wlasciciel; }
        //}



    }
}
