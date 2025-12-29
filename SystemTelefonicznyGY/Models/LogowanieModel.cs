//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
using System.ComponentModel.DataAnnotations;

namespace SystemTelefonicznyGY.Models
{
    public class LogowanieModel : ILogowanieModel
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

        [Required(ErrorMessage = "Proszę podać hasło")] // Atrybut walidacji
        [DataType(DataType.Password)]   // Określa, że pole jest typu hasło
        public string Haslo
        {
            get { return _haslo; }
            set { _haslo = value; }
        }
    }
    public class ZmianaHaslaModel
    {
        public int IdPracownika { get; set; }
        public string StareHaslo { get; set; }
        public string NoweHaslo { get; set; }
        public string PowtorzHaslo { get; set; }

        public string SprawdzBledy()
        {
            if (string.IsNullOrEmpty(NoweHaslo) || NoweHaslo.Length < 5)
                return "Nowe hasło musi mieć minimum 5 znaków.";
            if (NoweHaslo != PowtorzHaslo)
                return "Nowe hasła nie są identyczne.";
            return null;
        }
    }
}