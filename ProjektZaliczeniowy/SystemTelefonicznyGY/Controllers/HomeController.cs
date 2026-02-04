using System.Linq;
using System.Web.Mvc;
using SystemTelefonicznyGY.Logika;
using SystemTelefonicznyGY.Logika.Interfejsy;

namespace SystemTelefonicznyGY.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPracownikService _pracownikService = new PracownikService();

        public ActionResult Index(string szukanaFraza)
        {
            // Pobiera gotową listę obiektów z serwisu.
            var listaPracownikow = _pracownikService.PobierzListęPracownikow(szukanaFraza);

            // Sortowanie
            var posortowanaLista = listaPracownikow.OrderBy(p => p.Nazwisko).ToList();

            return View(posortowanaLista);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Prefiksy zewnętrzne i wewnętrzne dla Systemu telekomunikacynego Firmy.";
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Dane kontaktowe do Firmy.";
            return View();
        }
    }
}