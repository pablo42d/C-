using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SystemTelefonicznyGY.Logika.BilingService;

namespace SystemTelefonicznyGY.Logika.Interfejsy
{
    public interface IBilingService
    {
        WynikImportu ImportujPlik(Stream strumienPliku, string typ);
        bool CzyIstniejaBilingi(int miesiac, int rok);
        DataTable PobierzRaport(int miesiac, int rok, string fraza, string nrFaktury, int? dzialId, string manager, DateTime? od, DateTime? doDaty, int nrStrony = 1, int rozmiarStrony = 0);
        int PoliczRekordy(int miesiac, int rok, string fraza, string nrFaktury, int? dzialId, string manager, DateTime? od, DateTime? doDaty);
        StringBuilder GenerujCsvRaportu(DataTable dt);
        decimal PobierzSumeKosztow(int miesiac, int rok);
        (int m, int r) PobierzDateOstatniegoBilinguPracownika(int idPracownika);
        DataTable PobierzBilingiPracownika(int idPracownika, int m, int r, string typ);
        DataTable PobierzWszystkieBilingi();
    }
}
