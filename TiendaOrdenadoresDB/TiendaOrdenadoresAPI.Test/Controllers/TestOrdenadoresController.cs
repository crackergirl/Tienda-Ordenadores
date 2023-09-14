using Microsoft.AspNetCore.Mvc;
using TiendaOrdenadoresAPI.Controllers;
using TiendaOrdenadoresAPI.Models;
using TiendaOrdenadoresAPI.Services.Fakes;

namespace TiendaOrdenadoresAPI.Test.Controllers
{
    [TestClass]
    public class TestOrdenadoresController
	{
        readonly OrdenadoresController controlador;
        public TestOrdenadoresController()
		{
            controlador = new(new FakeRepositorioOrdenador());
        }
        [TestMethod]
        public void TestObtenerTodos()
        {
            var resultado = controlador.Get() as OkObjectResult;
            Assert.IsNotNull(resultado);
            var listaModulos = resultado.Value as List<Ordenador>;
            Assert.IsNotNull(listaModulos);
            Assert.AreEqual(3, listaModulos.Count);
        }

        [TestMethod]
        public void TestObtenerOrdenadorExiste()
        {
            var resultado = controlador.Get(1) as OkObjectResult;
            Assert.IsNotNull(resultado);
            var ordenador = resultado.Value as Ordenador;
            Assert.IsNotNull(ordenador);
            Assert.AreEqual("patata", ordenador.Descripcion);
            Assert.AreEqual("AAAA1", ordenador.NumeroDeSerie);
        }

        [TestMethod]
        public void TestObtenerOrdenadorNoExiste()
        {
            var resultado = controlador.Get(999) as NotFoundResult;
            Assert.IsNotNull(resultado);
        }

        [TestMethod]
        public void TestOrdenadoresCrearBien()
        {
            var resultado = controlador.Get() as OkObjectResult;
            Assert.IsNotNull(resultado);
            var listaModulos = resultado.Value as List<Ordenador>;
            Assert.IsNotNull(listaModulos);
            Assert.AreEqual(3, listaModulos.Count);

            Ordenador ordenadorNuevo = new()
            {
                Id = 1,
                Descripcion = "patata2",
                NumeroDeSerie = "AAAAB"
            };

            var resultadoPost= controlador.Post(ordenadorNuevo) as OkResult;
            resultado = controlador.Get() as OkObjectResult;
            Assert.IsNotNull(resultadoPost);
            Assert.IsNotNull(resultado);
            listaModulos = resultado.Value as List<Ordenador>;
            Assert.IsNotNull(listaModulos);
            Assert.AreEqual(4, listaModulos.Count);
        }

        [TestMethod]
        public void TestOrdenadoresBorrarExiste()
        {
            var resultado = controlador.Get() as OkObjectResult;
            Assert.IsNotNull(resultado);
            var listaModulos = resultado.Value as List<Ordenador>;
            Assert.IsNotNull(listaModulos);
            Assert.AreEqual(3, listaModulos.Count);

            var resultadoDelete = controlador.Delete(3) as OkResult;
            resultado = controlador.Get() as OkObjectResult;
            Assert.IsNotNull(resultadoDelete);
            Assert.IsNotNull(resultado);
            listaModulos = resultado.Value as List<Ordenador>;
            Assert.IsNotNull(listaModulos);
            Assert.AreEqual(2, listaModulos.Count);
        }

        [TestMethod]
        public void TestOrdenadoresBorrarNoExiste()
        {
            var resultado = controlador.Get() as OkObjectResult;
            Assert.IsNotNull(resultado);
            var listaModulos = resultado.Value as List<Ordenador>;
            Assert.IsNotNull(listaModulos);
            Assert.AreEqual(3, listaModulos.Count);

            controlador.Delete(999);
            resultado = controlador.Get() as OkObjectResult;
            Assert.IsNotNull(resultado);
            listaModulos = resultado.Value as List<Ordenador>;
            Assert.IsNotNull(listaModulos);
            Assert.AreEqual(3, listaModulos.Count);
        }

        [TestMethod]
        public void TestOrdenadoresActualizarExiste()
        {
            Ordenador ordenadorNuevo = new()
            {
                Id = 1,
                Descripcion = "patata2",
                NumeroDeSerie = "AAAAB"
            };
            var resultadoPut = controlador.Put(ordenadorNuevo) as OkResult;
            var resultadoGet = controlador.Get(1) as OkObjectResult;

            Assert.IsNotNull(resultadoPut);
            Assert.IsNotNull(resultadoGet);

            var ordenador = resultadoGet.Value as Ordenador;

            Assert.IsNotNull(ordenador);
            Assert.AreEqual("patata2", ordenador.Descripcion);
            Assert.AreEqual("AAAAB", ordenador.NumeroDeSerie);
        }

        [TestMethod]
        public void TestOrdenadoresActualizarNoExiste()
        {
            Ordenador ordenadorNuevo = new()
            {
                Id = 90,
                Descripcion = "patata2",
                NumeroDeSerie = "AAAAB"
            };
            var resultadoPut = controlador.Put(ordenadorNuevo) as ObjectResult;
            Assert.IsNotNull(resultadoPut);
            Assert.AreEqual(400, resultadoPut.StatusCode);
        }
    }
}

