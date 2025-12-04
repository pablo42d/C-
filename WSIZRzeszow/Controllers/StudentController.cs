using System.Data.Entity; // Wymagane do użycia EntityState
using System.Linq;  // Wymagane do użycia LINQ (np. ToList())
using System.Net;   // Wymagane do użycia HttpStatusCodeaby obsłużyć błędy (np. NotFound), aby użyć HttpStatusCodeResult i HttpNotFound
using System.Web.Mvc;   // Wymagane do użycia klasy Controller i ActionResult
using WSIZRzeszow.DAL;  // Importujemy kontekst bazy danych
using WSIZRzeszow.Models;   // Importujemy klasę Student

namespace WSIZRzeszow.Controllers
{
    public class StudentController : Controller
    {
        // 1. Zdefiniuj i zainicjuj kontekst bazy danych
        private readonly UniversityContext db = new UniversityContext();

        // GET: Student
        public ActionResult Index()
        {
            // 2. Pobierz dane i przekaż je do widoku
            var students = db.Students.ToList();
            return View(students); // Przekazujemy listę studentów jako Model
            //return View(); 
        }

        // GET: Student/Details/5
        public ActionResult Details(int? id)    // Używamy int? aby id mogło być null
        {
            // 1. Sprawdzamy, czy id jest przekazane
            if (id == null)
            {
                // Jeśli ID jest null, zwróć błąd HTTP 400 (Bad Request)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest); // Zwracamy błąd 400 Bad Request
            }
            // 2. Pobieramy pojedynczego studenta z bazy danych po ID
            // Metoda Find() jest zoptymalizowana do szukania po kluczu głównym
            Student student = db.Students.Find(id);

            // 3. Sprawdzamy, czy student został znaleziony
            if (student == null)
            {
                return HttpNotFound(); // Zwracamy błąd 404 Not Found, jeśli student nie istnieje
            }
            // 4. Przekazujemy studenta do widoku
            return View(student);
        }

        /* public ActionResult Details(int id)
        {

            return View();
        }
        */

        // GET: Student/Create
        public ActionResult Create()
        {
            // Po prostu zwracamy widok z formularzem do tworzenia nowego studenta
            return View(new Student());
        }

        public UniversityContext GetDb()
        {
            return db;
        }

        // POST: Student/Create
        // Ta akcja odbiera dane przesłane z formularza w widoku Create.cshtml i zapisuje je do bazy danych za pomocą Entity Framework.Aby zabezpieczyć się przed atakami CSRF, dodajemy atrybut ValidateAntiForgeryToken
        [HttpPost]
        [ValidateAntiForgeryToken] // Standardowe zabezpieczenie przed atakami CSRF
        public ActionResult Create([Bind(Include = "LastName, FirstMidName, EnrollmentDate")] Student student)
        {
            // 1. Sprawdzamy, czy dane z formularza są poprawne (walidacja modelu)
            // Walidacja sprawdza, czy pola wymagane zostały wypełnione i czy typy danych są poprawne
            if (ModelState.IsValid)
            {
                try
                {
                    // 2. Dodajemy nowy obiekt studenta do kontekstu
                    db.Students.Add(student);

                    // 3. Zapisujemy zmiany w bazie danych
                    db.SaveChanges();

                    // 4. Przekierowujemy na listę studentów
                    return RedirectToAction("Index");
                }
                catch (System.Data.DataException /* e */)
                {
                    // Zapisujemy błąd (do logów)
                    ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
                }
            }

            // 5. Jeśli walidacja się nie powiodła LUB wystąpił błąd zapisu do bazy,
            // wracamy do formularza, aby użytkownik mógł poprawić dane.
            return View(student);
        }


        // GET: Student/Edit/5
        public ActionResult Edit(int id)
        {
            // 1. Sprawdzamy, czy id jest poprawne
            if (id <= 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            // 2. Pobieramy studenta z bazy danych
            var student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            // 3. Sprawdzamy, czy student o danym ID istnieje

            // 4. Przekazujemy studenta do widoku, aby go edytować
            return View(student);
        }

        // POST: Student/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken] // Zapobiega atakom CSRF
        public ActionResult Edit([Bind(Include = "Id,LastName,FirstName,EnrollmentDate")] Models.Student student)
        {
            // Sprawdzamy, czy dane z formularza są poprawne (walidacja modelu)
            if (ModelState.IsValid)
            {
                // 1. Oznaczamy encję jako zmodyfikowaną stan obiektu w kontekście jako Modified
                // Powoduje to, że Entity Framework wygeneruje odpowiednie zapytanie UPDATE w bazie danych
                db.Entry(student).State = EntityState.Modified;
                // 2. Zapisujemy zmiany w bazie danych
                db.SaveChanges();
                // 3. Przekierowujemy do akcji Index do listy studentów
                return RedirectToAction("Index");
            }
            // Jeśli model jest nieprawidłowy, zwracamy widok z modelem do poprawy (wróć do formularz z błedem)
            return View(student);
        }

        /*
         * public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        */

        // GET: Student/Delete/5
        public ActionResult Delete(int? id)
        {
            // 1. Sprawdzamy, czy id jest przekazane
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            // 2. Pobieramy studenta z bazy danych
            Student student = db.Students.Find(id);

            // 3. Sprawdzamy, czy student istnieje
            if (student == null)
            {
                return HttpNotFound();
            }
            // 4. Przekazujemy studenta do widoku, aby potwierdzić usunięcie
            return View(student);
        }

        // POST: Student/Delete/5
        // Ta akcja jest wywoływana po kliknięciu przycisku "Usuń" w widoku Delete.cshtml. Akceptuje ID rekordu, który ma zostać usunięty.
        [HttpPost, ActionName("Delete")] // Używamy atrybutu ActionName, ponieważ nazwa metody jest ta sama co GET
        [ValidateAntiForgeryToken] // Dodaj zabezpieczenie przed atakami CSRF
        public ActionResult Delete(int id)   // Argument FormCollection jest niepotrzebny
        {
            try
            {
                // 1. Znajdź studenta do usunięcia
                Student student = db.Students.Find(id);

                // 2. Usuń studenta z kontekstu
                db.Students.Remove(student);

                // 3. Zapisz zmiany w bazie danych
                db.SaveChanges();

                // 4. Przekieruj z powrotem do listy
                return RedirectToAction("Index");                
            }
            catch (System.Data.DataException /* e */) // Bardziej specyficzna obsługa błędów bazy danych
            {
                // W przypadku błędu (np. ograniczenie klucza obcego), wróć do widoku 
                // i możesz opcjonalnie wyświetlić komunikat o błędzie dla użytkownika.
                return RedirectToAction("Delete", new { id = id, saveChangesError = true });
            }
        }
    }
}
