using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace SystemTelefonicznyGY.Logika.Interfejsy
{
    public interface IBazaDanych
    {
        DataTable PobierzDane(string zapytanieSql, List<SqlParameter> parametry = null);       
        int WykonajPolecenie(string zapytanieSql, List<SqlParameter> parametry = null);        
    }
}
