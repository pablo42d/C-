using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using SystemTelefonicznyGY.Controllers;
using SystemTelefonicznyGY.Logika.Interfejsy;
using SystemTelefonicznyGY.Models;

namespace SystemTelefonicznyGY.Tests
{
    [TestClass]
    public class KontoControllerTests
    {
        // --- 1. Ulepszona klasa FakeSession (Obs³uguje Abandon) ---
        private class FakeSession : HttpSessionStateBase
        {
            private readonly Dictionary<string, object> _store = new Dictionary<string, object>();

            public override object this[string name]
            {
                get => _store.ContainsKey(name) ? _store[name] : null;
                set => _store[name] = value;
            }

            // Naprawa b³êdu "NotImplementedException" przy wylogowywaniu
            public override void Abandon()
            {
                _store.Clear();
            }
        }

        // --- Metoda pomocnicza do tworzenia Kontekstu z Requestem i Sesj¹ ---
        private ControllerContext StworzKontekst(KontoController controller)
        {
            // 1. Mockujemy Request (¿eby dzia³a³o Request.UrlReferrer)
            var mockRequest = new Mock<HttpRequestBase>();
            mockRequest.Setup(r => r.UrlReferrer).Returns(new Uri("http://localhost/poprzednia_strona"));

            // 2. Tworzymy nasz¹ FakeSesjê
            var fakeSession = new FakeSession();

            // 3. Mockujemy HttpContext (spinamy Request i Sesjê)
            var mockHttpContext = new Mock<HttpContextBase>();
            mockHttpContext.Setup(c => c.Session).Returns(fakeSession);
            mockHttpContext.Setup(c => c.Request).Returns(mockRequest.Object);

            // 4. Zwracamy gotowy kontekst
            return new ControllerContext(mockHttpContext.Object, new RouteData(), controller);
        }

        [TestMethod]
        public void Login_PoprawneDane_PrzekierowujeIUsawiaSesje()
        {
            // ARRANGE
            var mockService = new Mock<IPracownikService>();
            DataTable dt = new DataTable();
            dt.Columns.Add("ID"); dt.Columns.Add("Imie"); dt.Columns.Add("Nazwisko"); dt.Columns.Add("Rola");
            var row = dt.NewRow();
            row["ID"] = 1; row["Imie"] = "Jan"; row["Rola"] = "User";
            mockService.Setup(s => s.Zaloguj("admin", "123")).Returns(row);

            var controller = new KontoController(mockService.Object);
            controller.ControllerContext = StworzKontekst(controller); // U¿ywamy nowej metody

            // ACT
            var result = controller.Login(new LogowanieModel { Login = "admin", Haslo = "123" }) as RedirectToRouteResult;

            // ASSERT
            Assert.IsNotNull(result);
            Assert.AreEqual("Index", result.RouteValues["action"]);
            Assert.AreEqual("Jan", controller.Session["ImiePracownika"]);
        }

        [TestMethod]
        public void Wyloguj_AbandonsSession_RedirectsHome()
        {
            // ARRANGE
            var mockService = new Mock<IPracownikService>();
            var controller = new KontoController(mockService.Object);
            controller.ControllerContext = StworzKontekst(controller);

            // Ustawiamy coœ w sesji
            controller.Session["IdPracownika"] = 123;

            // ACT
            var result = controller.Wyloguj() as RedirectToRouteResult;

            // ASSERT
            Assert.IsNotNull(result);
            Assert.AreEqual("Index", result.RouteValues["action"]);
            Assert.AreEqual("Home", result.RouteValues["controller"]);

            // Sprawdzamy czy sesja jest pusta (czy Abandon zadzia³a³o - w naszym FakeSession Abandon czyœci s³ownik)
            Assert.IsNull(controller.Session["IdPracownika"]);
        }

        [TestMethod]
        public void ProcesZmianyHasla_InvalidNewPassword_RedirectsBackWithError()
        {
            // ARRANGE
            var mockService = new Mock<IPracownikService>();
            var controller = new KontoController(mockService.Object);
            controller.ControllerContext = StworzKontekst(controller);

            // Musimy byæ zalogowani
            controller.Session["IdPracownika"] = 1;

            var model = new ZmianaHaslaModel
            {
                IdPracownika = 1,
                NoweHaslo = "krotkie", // Za krótkie has³o
                PowtorzHaslo = "krotkie"
            };

            // ACT
            var result = controller.ProcesZmianyHasla(model) as RedirectResult;

            // ASSERT
            Assert.IsNotNull(result);
            // Sprawdzamy czy przekierowa³ nas z powrotem (dziêki mockRequest.UrlReferrer)
            Assert.AreEqual("http://localhost/poprzednia_strona", result.Url);
            Assert.IsNotNull(controller.TempData["Blad"]); // Czy jest komunikat b³êdu?
        }
    }
}



//using System;
//using System.Web.Mvc;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using Moq;
//using System.Web;
//using System.Web.Routing;
//using SystemTelefonicznyGY.Controllers;
//using SystemTelefonicznyGY.Logika.Interfejsy;
//using SystemTelefonicznyGY.Models;
//using System.Data;

//namespace SystemTelefonicznyGY.Tests
//{
//    [TestClass]
//    public class KontoControllerTests
//    {
//        private class FakeSession : HttpSessionStateBase
//        {
//            private readonly System.Collections.Generic.Dictionary<string, object> _store = new System.Collections.Generic.Dictionary<string, object>();
//            public override object this[string name]
//            {
//                get => _store.ContainsKey(name) ? _store[name] : null;
//                set => _store[name] = value;
//            }
//        }
//        private class FakeHttpContext : HttpContextBase
//        {
//            private readonly HttpSessionStateBase _session = new FakeSession();
//            public override HttpSessionStateBase Session => _session;
//        }

//        [TestMethod]
//        public void Login_Get_ReturnsModel()
//        {
//            var controller = new KontoController();
//            var result = controller.Login() as ViewResult;
//            Assert.IsNotNull(result);
//            Assert.IsInstanceOfType(result.Model, typeof(LogowanieModel));
//        }

//        [TestMethod]
//        public void Login_Post_InvalidModel_ReturnsView()
//        {
//            var mockPr = new Mock<IPracownikService>();
//            var controller = new KontoController(mockPr.Object);
//            controller.ModelState.AddModelError("Login", "Required");

//            var model = new LogowanieModel();
//            var result = controller.Login(model) as ViewResult;

//            Assert.IsNotNull(result);
//            Assert.AreEqual(model, result.Model);
//        }

//        [TestMethod]
//        public void Login_Post_ValidCredentials_RedirectsHome()
//        {
//            var mockPr = new Mock<IPracownikService>();
//            var row = new DataTable();
//            row.Columns.Add("ID"); row.Columns.Add("Imie"); row.Columns.Add("Nazwisko"); row.Columns.Add("Rola");
//            var dr = row.NewRow();
//            dr["ID"] = 1; dr["Imie"] = "A"; dr["Nazwisko"] = "B"; dr["Rola"] = "Admin";

//            mockPr.Setup(s => s.Zaloguj(It.IsAny<string>(), It.IsAny<string>())).Returns(dr);

//            var controller = new KontoController(mockPr.Object);
//            var http = new FakeHttpContext();
//            controller.ControllerContext = new ControllerContext(http, new RouteData(), controller);

//            var model = new LogowanieModel { Login = "x", Haslo = "y" };
//            var result = controller.Login(model) as RedirectToRouteResult;

//            Assert.IsNotNull(result);
//            Assert.AreEqual("Index", result.RouteValues["action"]);
//            Assert.AreEqual("Home", result.RouteValues["controller"]);
//            Assert.IsNotNull(http.Session["IdPracownika"]);
//        }

//        [TestMethod]
//        public void Wyloguj_AbandonsSession_RedirectsHome()
//        {
//            var controller = new KontoController();
//            var http = new FakeHttpContext();
//            controller.ControllerContext = new ControllerContext(http, new RouteData(), controller);

//            var result = controller.Wyloguj() as RedirectToRouteResult;
//            Assert.IsNotNull(result);
//            Assert.AreEqual("Index", result.RouteValues["action"]);
//            Assert.AreEqual("Home", result.RouteValues["controller"]);
//        }

//        [TestMethod]
//        public void ProcesZmianyHasla_NotLogged_RedirectsToLogin()
//        {
//            var mockPr = new Mock<IPracownikService>();
//            var controller = new KontoController(mockPr.Object);
//            controller.ControllerContext = new ControllerContext(new FakeHttpContext(), new RouteData(), controller);

//            var model = new ZmianaHaslaModel { IdPracownika = 1, NoweHaslo = "12345", PowtorzHaslo = "12345", StareHaslo = "old" };
//            var result = controller.ProcesZmianyHasla(model) as RedirectToRouteResult;

//            Assert.IsNotNull(result);
//            Assert.AreEqual("Login", result.RouteValues["action"]);
//            Assert.AreEqual("Konto", result.RouteValues["controller"]);
//        }

//        [TestMethod]
//        public void ProcesZmianyHasla_InvalidNewPassword_RedirectsBackWithError()
//        {
//            var mockPr = new Mock<IPracownikService>();
//            var controller = new KontoController(mockPr.Object);
//            var http = new FakeHttpContext();
//            http.Session["IdPracownika"] = 1;
//            controller.ControllerContext = new ControllerContext(http, new RouteData(), controller);

//            var model = new ZmianaHaslaModel { IdPracownika = 1, NoweHaslo = "1", PowtorzHaslo = "1", StareHaslo = "old" };
//            var result = controller.ProcesZmianyHasla(model) as RedirectResult;

//            Assert.IsNotNull(result);
//            Assert.IsNotNull(controller.TempData["Blad"]);
//        }
//    }
//}
