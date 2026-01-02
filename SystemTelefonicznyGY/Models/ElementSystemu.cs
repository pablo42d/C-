using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SystemTelefonicznyGY.Models
{
    /// <summary>
    /// Klasa bazowa dla elementów systemu telefonicznego posiadających ID
    /// </summary>
    public abstract class ElementSystemu
    {
        /// <summary>
        /// Unikalny identyfikator elementu systemu
        /// </summary>

        // Prywatne pola przechowujące wartości właściwości
        // Dodano 'readonly' zgodnie z sugestią IDE0044 - te pola są ustawiane tylko raz w konstruktorze
        private readonly int _id;
        private readonly DateTime _dataDodaniaWpisu;

        /// Właściwości tylko do odczytu
        public int Id { get { return _id; } }
        public DateTime DataDodaniaWpisu { get { return _dataDodaniaWpisu; } }

        public ElementSystemu(int id)
        {
            _id = id;
            _dataDodaniaWpisu = DateTime.Now;
        }
    }
}
// Koniec pliku ElementSystemu.cs