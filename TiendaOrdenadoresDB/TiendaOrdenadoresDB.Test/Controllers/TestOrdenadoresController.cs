using Microsoft.AspNetCore.Mvc;
using TiendaOrdenadoresDB.Controllers;
using TiendaOrdenadoresDB.Models;
using TiendaOrdenadoresDB.Services;
using TiendaOrdenadoresDB.Servicies;
using TiendaOrdenadoresDB.ViewModels;

namespace TiendaOrdenadoresDB.Test.Controllers
{
    [TestClass]
    public class TestOrdenadoresController
	{
        readonly OrdenadoresController controlador;

        public TestOrdenadoresController()
        {
            controlador = new(new FakeRepositorioOrdenador(), new FakeRepositorioComponente(), new FakeRepositorioOrdenadorComponente());
        }

        [TestMethod]
        public void TestOrdenadoresIndexVistaOk()
        {
            var result = controlador.Index() as ViewResult;

            Assert.IsNotNull(result);
            Assert.AreEqual("Index", result.ViewName);
            Assert.IsNotNull(result.ViewData.Model);

            var listaModulos = result.ViewData.Model as List<Ordenador>;

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

            var ordenador = result.ViewData.Model as Ordenador;

            Assert.IsNotNull(ordenador);
            Assert.AreEqual("patata", ordenador.Descripcion);
            Assert.AreEqual("AAAA1", ordenador.NumeroDeSerie);
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
            var result = controlador.Create() as ViewResult;

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void TestOrdenadoresCrearBien()
        {
            var result = controlador.Index() as ViewResult;

            Assert.IsNotNull(result);
            Assert.AreEqual("Index", result.ViewName);
            Assert.IsNotNull(result.ViewData.Model);

            var listaModulos = result.ViewData.Model as List<Ordenador>;

            Assert.IsNotNull(listaModulos);
            Assert.AreEqual(3, listaModulos.Count);

            OrdenadorComponenteViewModel ordenadorForm = new()
            {
                Descripcion = "Prueba",
                NumeroDeSerie = "BBBB",
                ProcesadorId = 1,
                MemoriaRamId = 2,
                DiscoDuroId = 2

            };

            controlador.Create(ordenadorForm);
            result = controlador.Index() as ViewResult;

            Assert.IsNotNull(result);
            Assert.AreEqual("Index", result.ViewName);
            Assert.IsNotNull(result.ViewData.Model);

            listaModulos = result.ViewData.Model as List<Ordenador>;

            Assert.IsNotNull(listaModulos);
            Assert.AreEqual(4, listaModulos.Count);
        }

        [TestMethod]
        public void TestOrdenadoresBorrarBien()
        {
            var result = controlador.Index() as ViewResult;

            Assert.IsNotNull(result);
            Assert.AreEqual("Index", result.ViewName);
            Assert.IsNotNull(result.ViewData.Model);

            var listaModulos = result.ViewData.Model as List<Ordenador>;

            Assert.IsNotNull(listaModulos);
            Assert.AreEqual(3, listaModulos.Count);

            controlador.DeleteConfirmed(1);
            result = controlador.Index() as ViewResult;

            Assert.IsNotNull(result);
            Assert.AreEqual("Index", result.ViewName);
            Assert.IsNotNull(result.ViewData.Model);

            listaModulos = result.ViewData.Model as List<Ordenador>;

            Assert.IsNotNull(listaModulos);
            Assert.AreEqual(2, listaModulos.Count);
        }

        [TestMethod]
        public void TestOrdenadoresBorrarNoExiste()
        {
            var result = controlador.Index() as ViewResult;

            Assert.IsNotNull(result);
            Assert.AreEqual("Index", result.ViewName);
            Assert.IsNotNull(result.ViewData.Model);

            var listaModulos = result.ViewData.Model as List<Ordenador>;

            Assert.IsNotNull(listaModulos);
            Assert.AreEqual(3, listaModulos.Count);

            controlador.DeleteConfirmed(10);
            result = controlador.Index() as ViewResult;

            Assert.IsNotNull(result);
            Assert.AreEqual("Index", result.ViewName);
            Assert.IsNotNull(result.ViewData.Model);

            listaModulos = result.ViewData.Model as List<Ordenador>;

            Assert.IsNotNull(listaModulos);
            Assert.AreEqual(3, listaModulos.Count);
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

            var ordenador = result.ViewData.Model as Ordenador;

            Assert.IsNotNull(ordenador);
        }

        [TestMethod]
        public void TestOrdenadoresEditBien()
        {
            Ordenador ordenadorNuevo = new()
            {
                Id = 1,
                Descripcion = "patata2",
                NumeroDeSerie = "AAAAB"
            };
            controlador.Edit(1, ordenadorNuevo);
            var result = controlador.Details(1) as ViewResult;

            Assert.IsNotNull(result);
            Assert.AreEqual("Details", result.ViewName);
            Assert.IsNotNull(result.ViewData.Model);

            var ordenador = result.ViewData.Model as Ordenador;

            Assert.IsNotNull(ordenador);
            Assert.AreEqual("patata2", ordenador.Descripcion);
            Assert.AreEqual("AAAAB", ordenador.NumeroDeSerie);
        }
    }
}

