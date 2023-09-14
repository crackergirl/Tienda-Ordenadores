using Microsoft.AspNetCore.Mvc;
using TiendaOrdenadoresAPI.Controllers;
using TiendaOrdenadoresAPI.Models;
using TiendaOrdenadoresAPI.Services.Fakes;

namespace TiendaOrdenadoresAPI.Test.Controllers
{
    [TestClass]
    public class TestComponentesController
    {
        readonly ComponentesController controlador;
        public TestComponentesController()
        {
            controlador = new(new FakeRepositorioComponente());
        }

        [TestMethod]
        public void TestObtenerTodos()
        {
            var resultado = controlador.Get() as OkObjectResult;
            Assert.IsNotNull(resultado);
            var listaModulos = resultado.Value as List<Componente>;
            Assert.IsNotNull(listaModulos);
            Assert.AreEqual(3, listaModulos.Count);
        }

        [TestMethod]
        public void TestObtenerComponenteExiste()
        {
            var resultado = controlador.Get(1) as OkObjectResult;
            Assert.IsNotNull(resultado);
            var componente = resultado.Value as Componente;
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
        public void TestObtenerComponenteNoExiste()
        {
            var resultado = controlador.Get(999) as NotFoundResult;
            Assert.IsNotNull(resultado);
        }

        [TestMethod]
        public void TestComponentesCrearBien()
        {
            var resultado = controlador.Get() as OkObjectResult;
            Assert.IsNotNull(resultado);
            var listaModulos = resultado.Value as List<Componente>;
            Assert.IsNotNull(listaModulos);
            Assert.AreEqual(3, listaModulos.Count);

            Componente componente = new()
            {
                Description = "Prueba",
                NumeroDeSerie = "BBBB"
            };

            var resultadoPost = controlador.Post(componente) as OkResult;
            resultado = controlador.Get() as OkObjectResult;
            Assert.IsNotNull(resultadoPost);
            Assert.IsNotNull(resultado);
            listaModulos = resultado.Value as List<Componente>;
            Assert.IsNotNull(listaModulos);
            Assert.AreEqual(4, listaModulos.Count);
        }

        [TestMethod]
        public void TestComponentesBorrarExiste()
        {
            var resultado = controlador.Get() as OkObjectResult;
            Assert.IsNotNull(resultado);
            var listaModulos = resultado.Value as List<Componente>;
            Assert.IsNotNull(listaModulos);
            Assert.AreEqual(3, listaModulos.Count);

            var resultadoDelete = controlador.Delete(3) as OkResult;
            resultado = controlador.Get() as OkObjectResult;
            Assert.IsNotNull(resultadoDelete);
            Assert.IsNotNull(resultado);
            listaModulos = resultado.Value as List<Componente>;
            Assert.IsNotNull(listaModulos);
            Assert.AreEqual(2, listaModulos.Count);
        }

        [TestMethod]
        public void TestComponentesBorrarNoExiste()
        {
            var resultado = controlador.Get() as OkObjectResult;
            Assert.IsNotNull(resultado);
            var listaModulos = resultado.Value as List<Componente>;
            Assert.IsNotNull(listaModulos);
            Assert.AreEqual(3, listaModulos.Count);

            controlador.Delete(999);
            resultado = controlador.Get() as OkObjectResult;
            Assert.IsNotNull(resultado);
            listaModulos = resultado.Value as List<Componente>;
            Assert.IsNotNull(listaModulos);
            Assert.AreEqual(3, listaModulos.Count);
        }

        [TestMethod]
        public void TestComponenteActualizarExiste()
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
            var resultadoPut = controlador.Put(componenteNuevo) as OkResult;
            var resultadoGet = controlador.Get(1) as OkObjectResult;

            Assert.IsNotNull(resultadoPut);
            Assert.IsNotNull(resultadoGet);

            var componente = resultadoGet.Value as Componente;

            Assert.IsNotNull(componente);
            Assert.AreEqual(2, componente.Categoria);
            Assert.AreEqual("patata2", componente.Description);
            Assert.AreEqual(10, componente.Calor);
            Assert.AreEqual("Megas", componente.UnidadMedida);
            Assert.AreEqual(52, componente.Precio);
            Assert.AreEqual("AAAA", componente.NumeroDeSerie);
            Assert.AreEqual(512, componente.Almacenamiento);
        }

        [TestMethod]
        public void TestComponenteActualizarNoExiste()
        {
            Componente componenteNuevo = new()
            {
                Id = 90,
                Almacenamiento = 512,
                Calor = 10,
                Categoria = 2,
                Description = "patata2",
                NumeroDeSerie = "AAAA",
                Precio = 52,
                UnidadMedida = "Megas"
            };
            var resultadoPut = controlador.Put(componenteNuevo) as ObjectResult;
            Assert.IsNotNull(resultadoPut);
            Assert.AreEqual(400, resultadoPut.StatusCode);
        }
    }
}

