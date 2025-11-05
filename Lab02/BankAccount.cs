using Lab02;

namespace Lab02
{
    internal class BankAccount
    {
        // Zaimplementuj właściwości Saldo (publiczne, tylko do odczytu) oraz Właściciel (publiczne, tylko do odczytu) i Właściciel.

        private decimal Saldo;
        private readonly string Wlasciciel;

        // Metoda Wplata(decimal kwota), która pozwala na zwiększenie salda,
        public BankAccount(string wlasciciel, decimal saldoPoczatkowe) // konstruktor z parametrami
        {
            this.Wlasciciel = wlasciciel;
            this.Saldo = saldoPoczatkowe;
        }
        public void Wplata(decimal kwota)
        {
            if (kwota <= 0)
            {
                throw new ArgumentException("Kwota wpłaty musi być większa od zera.");
            }
            Saldo += kwota;
        }

        // Metoda Wyplata(decimal kwota), która sprawdzi, czy jest wystarczająca ilość środków, a następnie odejmie odpowiednią kwotę.
        public void Wyplata(decimal kwota)
        {
            if (kwota <= 0)
            {
                throw new ArgumentException("Kwota wypłaty musi być większa od zera.");
            }
            if (kwota > Saldo)
            {
                throw new InvalidOperationException("Niewystarczające środki na koncie.");
            }
            Saldo -= kwota;
        }

        // Użyj operatorów dostępu, aby zabezpieczyć saldo przed bezpośrednią modyfikacją.
        public decimal Saldo
        {
            get { return saldo; }
        }
        public string Wlasciciel
        {
            get { return wlasciciel; }
        }



    }
}
