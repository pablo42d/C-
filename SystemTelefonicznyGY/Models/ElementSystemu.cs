using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
// Tworze klase ElementSystemu w przestrzeni nazw SystemTelefonicznyGY.Models bedie to klasa bazowa dla innych elementow systemu telefonicznego

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
        /// 
        // Prywatne pola przechowujące wartości właściwości
        private int _id;
        private DateTime _dataDodaniaWpisu;
        
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