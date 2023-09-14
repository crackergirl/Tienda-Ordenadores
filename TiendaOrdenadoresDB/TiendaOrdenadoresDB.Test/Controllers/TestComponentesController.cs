using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using TiendaOrdenadoresDB.Controllers;
using TiendaOrdenadoresDB.Logging;
using TiendaOrdenadoresDB.Models;
using TiendaOrdenadoresDB.Servicies;

namespace TiendaOrdenadoresABaseDeDatos.Test.Controllers
{
    [TestClass]
    public class TestComponentesController
	{
        readonly ComponentesController controlador;
        readonly IFormCollection formCollection;
        readonly Dictionary<string, StringValues> formData;

        public TestComponentesController() {

            controlador = new(new FakeRepositorioComponente(), new LoggerManager());
            formData = new()
            {
                { "Almacenamiento", new StringValues("6") },
                { "NumeroDeSerie", new StringValues("AAAAA") },
                { "Description", new StringValues("prueba") },
                { "UnidadMedida", new StringValues("Megas") },
                { "Precio", new StringValues("140") },
                { "Categoria", new StringValues("2") },
                { "Calor", new StringValues("50") }
            };

            formCollection = new FormCollection(formData, new FormFileCollection());

        }

        [TestMethod]
        public void TestComponentesIndexVistaOk()
        {
            var result = controlador.Index() as ViewResult;

            Assert.IsNotNull(result);
            Assert.AreEqual("Index", result.ViewName);
            Assert.IsNotNull(result.ViewData.Model);

            var listaModulos = result.ViewData.Model as List<Componente>;

            Assert.IsNotNull(listaModulos);
            Assert.AreEqual(3, listaModulos.Count);
        }

        [TestMethod]
        public void PruebaComponentesDetallesVistaEncontrada()
        {
            var result = controlador.Details(1) as ViewResult;

            Assert.IsNotNull(result);
            Assert.AreEqual("Details", result.ViewName);
            Assert.IsNotNull(result.ViewData.Model);

            var componente = result.ViewData.Model as Componente;

            Assert.IsNotNull(componente);
            Assert.AreEqual(0, componente.Categoria);
            Assert.AreEqual("patata", componente.Description);
            Assert.AreEqual(10, componente.Calor);
            Assert.AreEqual("Cores", componente.UnidadMedida);
            Assert.AreEqual(50, componente.Precio);
            Assert.AreEqual("AAAA", componente.NumeroDeSerie);
            Assert.AreEqual(6, componente.Almacenamiento);
        }

        [TestMethod]
        public void TestComponentesDetallesVistaNoEncontrada()
        {
            var result = controlador.Details(5) as ViewResult;

            Assert.IsNull(result);
        }

        [TestMethod]
        public void TestComponentesCrearVistaEncontrada()
        {
            var result = controlador.Create() as ViewResult;

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void TestComponentesCrearBien()
        {
            var result = controlador.Index() as ViewResult;

            Assert.IsNotNull(result);
            Assert.AreEqual("Index", result.ViewName);
            Assert.IsNotNull(result.ViewData.Model);

            var listaModulos = result.ViewData.Model as List<Componente>;

            Assert.IsNotNull(listaModulos);
            Assert.AreEqual(3, listaModulos.Count);

            controlador.Create(formCollection, 6,50,2,"prueba","AAAAA",140,"Megas");
            result = controlador.Index() as ViewResult;

            Assert.IsNotNull(result);
            Assert.AreEqual("Index", result.ViewName);
            Assert.IsNotNull(result.ViewData.Model);

            listaModulos = result.ViewData.Model as List<Componente>;

            Assert.IsNotNull(listaModulos);
            Assert.AreEqual(4, listaModulos.Count);
        }

        [TestMethod]
        public void TestComponentesBorrarBien()
        {
            var result = controlador.Index() as ViewResult;

            Assert.IsNotNull(result);
            Assert.AreEqual("Index", result.ViewName);
            Assert.IsNotNull(result.ViewData.Model);

            var listaModulos = result.ViewData.Model as List<Componente>;

            Assert.IsNotNull(listaModulos);
            Assert.AreEqual(3, listaModulos.Count);

            controlador.DeleteConfirmed(1);
            result = controlador.Index() as ViewResult;

            Assert.IsNotNull(result);
            Assert.AreEqual("Index", result.ViewName);
            Assert.IsNotNull(result.ViewData.Model);

            listaModulos = result.ViewData.Model as List<Componente>;

            Assert.IsNotNull(listaModulos);
            Assert.AreEqual(2, listaModulos.Count);
        }

        [TestMethod]
        public void TestComponentesBorrarNoExiste()
        {
            var result = controlador.Index() as ViewResult;

            Assert.IsNotNull(result);
            Assert.AreEqual("Index", result.ViewName);
            Assert.IsNotNull(result.ViewData.Model);

            var listaModulos = result.ViewData.Model as List<Componente>;

            Assert.IsNotNull(listaModulos);
            Assert.AreEqual(3, listaModulos.Count);

            controlador.DeleteConfirmed(10);
            result = controlador.Index() as ViewResult;

            Assert.IsNotNull(result);
            Assert.AreEqual("Index", result.ViewName);
            Assert.IsNotNull(result.ViewData.Model);

            listaModulos = result.ViewData.Model as List<Componente>;

            Assert.IsNotNull(listaModulos);
            Assert.AreEqual(3, listaModulos.Count);
        }

        [TestMethod]
        public void TestComponentesEditVistaNoEncontrada()
        {
            var result = controlador.Edit(5) as ViewResult;

            Assert.IsNull(result);
        }

        [TestMethod]
        public void TestComponentesEditVistaEncontrada()
        {
            var result = controlador.Edit(1) as ViewResult;

            Assert.IsNotNull(result);
            Assert.AreEqual("Edit", result.ViewName);
            Assert.IsNotNull(result.ViewData.Model);

            var componente = result.ViewData.Model as Componente;

            Assert.IsNotNull(componente);
        }

        [TestMethod]
        public void TestComponenteEditBien()
        {
            Componente componenteNuevo = new()
            {
                Id = 1,
                Almacenamiento = 512,
                Calor = 10,
                Categoria = 2,
                Description = "patata2",
                NumeroDeSerie = "AAAA",
                Precio = 52,
                UnidadMedida = "Megas"
            };
            controlador.Edit(1, componenteNuevo);
            var result = controlador.Details(1) as ViewResult;

            Assert.IsNotNull(result);
            Assert.AreEqual("Details", result.ViewName);
            Assert.IsNotNull(result.ViewData.Model);

            var componente = result.ViewData.Model as Componente;

            Assert.IsNotNull(componente);
            Assert.AreEqual(2, componente.Categoria);
            Assert.AreEqual("patata2", componente.Description);
            Assert.AreEqual(10, componente.Calor);
            Assert.AreEqual("Megas", componente.UnidadMedida);
            Assert.AreEqual(52, componente.Precio);
            Assert.AreEqual("AAAA", componente.NumeroDeSerie);
            Assert.AreEqual(512, componente.Almacenamiento);
        }

    }
}

