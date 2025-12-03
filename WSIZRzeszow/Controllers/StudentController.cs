using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WSIZRzeszow.DAL;
using System.Net;   // Wymagane do użycia HttpStatusCodeaby obsłużyć błędy (np. NotFound)
using System.Data.Entity; // Wymagane do użycia EntityState

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
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Student/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Student/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
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
        public ActionResult Edit([Bind(Include = "Id,LastName,FirstName,EnrollmentDate")] Student student)
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
        //public ActionResult Edit(int id, FormCollection collection)
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

        // GET: Student/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Student/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
