//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
using System.ComponentModel.DataAnnotations;

namespace SystemTelefonicznyGY.Models
{
    public class LogowanieModel
    {
        // Używamy pól prywatnych i publicznych właściwości
        private string _login;
        private string _haslo;
        
        // Właściwości publiczne z walidacją
        [Required(ErrorMessage = "Proszę podać login")] // Atrybut walidacji
        
        public string Login
        {
            get { return _login; }
            set { _login = value; }
        }
        
        // Właściwość Haslo z walidacją
        [Required(ErrorMessage = "Proszę podać hasło")] // Atrybut walidacji
        [DataType(DataType.Password)]   // Określa, że pole jest typu hasło
        public string Haslo
        {
            get { return _haslo; }
            set { _haslo = value; }
        }
    }
}