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
        private readonly int _id;
        private readonly DateTime _dataDodaniaWpisu;

        /// Właściwości tylko do odczytu
        public int Id { get { return _id; } }
        public DateTime DataDodaniaWpisu { get { return _dataDodaniaWpisu; } } // Obecnie nieużywane

        public ElementSystemu(int id)
        {
            _id = id;
            _dataDodaniaWpisu = DateTime.Now;
        }
    }
}
