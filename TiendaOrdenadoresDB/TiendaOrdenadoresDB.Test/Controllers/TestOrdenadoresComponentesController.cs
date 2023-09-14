using Microsoft.AspNetCore.Mvc;
using TiendaOrdenadoresDB.Controllers;
using TiendaOrdenadoresDB.Models;
using TiendaOrdenadoresDB.Services;
using TiendaOrdenadoresDB.Servicies;

namespace TiendaOrdenadoresDB.Test.Controllers
{
    [TestClass]
    public class TestOrdenadoresComponentesController
	{
        readonly OrdenadoresComponentesController controlador;

        public TestOrdenadoresComponentesController()
		{
            controlador = new(new FakeRepositorioOrdenadorComponente(), new FakeRepositorioComponente());
        }

        [TestMethod]
        public void PruebaComponentesDetallesVistaEncontrada()
        {
            var result = controlador.Details(1) as ViewResult;

            Assert.IsNotNull(result);
            Assert.AreEqual("Details", result.ViewName);
            Assert.IsNotNull(result.ViewData.Model);

            var ordenadorComponente = result.ViewData.Model as OrdenadorComponente;

            Assert.IsNotNull(ordenadorComponente);
            Assert.AreEqual(1, ordenadorComponente.ComponenteId);
            Assert.AreEqual(1, ordenadorComponente.OrdenadorId);
        }

        [TestMethod]
        public void TestOrdenadoresDetallesVistaNoEncontrada()
        {
            var result = controlador.Details(5) as ViewResult;

            Assert.IsNull(result);
        }

        [TestMethod]
        public void TestOrdenadoresCrearVistaEncontrada()
        {
            var result = controlador.Create(1) as ViewResult;
            Assert.IsNotNull(result);
            Assert.AreEqual("Create", result.ViewName);
            Assert.IsNotNull(result.ViewData.Model);

            var ordenadorComponete = result.ViewData.Model as OrdenadorComponente;
            Assert.IsNotNull(ordenadorComponete);
        }

        [TestMethod]
        public void TestOrdenadoresCrearVistaNoEncontrada()
        {
            var result = controlador.Create(999) as ViewResult;

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void TestOrdenadoresBorrarVistaEncontrada()
        {
            var result = controlador.Delete(1) as ViewResult;
            Assert.IsNotNull(result);
            Assert.AreEqual("Delete", result.ViewName);
            Assert.IsNotNull(result.ViewData.Model);

            var ordenadorComponete = result.ViewData.Model as OrdenadorComponente;
            Assert.IsNotNull(ordenadorComponete);
        }

        [TestMethod]
        public void TestOrdenadoresBorrarVistaNoEncontrada()
        {
            var result = controlador.Delete(999) as ViewResult;

            Assert.IsNull(result);
        }

        [TestMethod]
        public void TestOrdenadoresEditVistaNoEncontrada()
        {
            var result = controlador.Edit(5) as ViewResult;

            Assert.IsNull(result);
        }

        [TestMethod]
        public void TestOrdenadoresEditVistaEncontrada()
        {
            var result = controlador.Edit(1) as ViewResult;

            Assert.IsNotNull(result);
            Assert.AreEqual("Edit", result.ViewName);
            Assert.IsNotNull(result.ViewData.Model);

            var ordenadorComponete = result.ViewData.Model as OrdenadorComponente;

            Assert.IsNotNull(ordenadorComponete);
        }
    }
}

