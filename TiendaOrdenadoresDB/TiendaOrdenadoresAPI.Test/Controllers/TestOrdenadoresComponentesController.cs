using Microsoft.AspNetCore.Mvc;
using TiendaOrdenadoresAPI.Controllers;
using TiendaOrdenadoresAPI.Models;
using TiendaOrdenadoresDB.Services.Fakes;

namespace TiendaOrdenadoresAPI.Test.Controllers
{
    [TestClass]
    public class TestOrdenadoresComponentesController
	{
        readonly OrdenadoresComponentesController controlador;
        public TestOrdenadoresComponentesController()
		{
            controlador = new(new FakeRepositorioOrdenadorComponente());
        }

        [TestMethod]
        public void TestObtenerTodos()
        {
            var resultado = controlador.Get() as OkObjectResult;
            Assert.IsNotNull(resultado);
            var listaModulos = resultado.Value as List<OrdenadorComponente>;
            Assert.IsNotNull(listaModulos);
            Assert.AreEqual(1, listaModulos.Count);
        }

        [TestMethod]
        public void TestObtenerOrdenadorComponenteExiste()
        {
            var resultado = controlador.Get(1) as OkObjectResult;
            Assert.IsNotNull(resultado);
            var ordenadorComponente = resultado.Value as OrdenadorComponente;
            Assert.IsNotNull(ordenadorComponente);
            Assert.AreEqual(1, ordenadorComponente.ComponenteId);
            Assert.AreEqual(1, ordenadorComponente.OrdenadorId);
        }

        [TestMethod]
        public void TestObtenerOrdenadorComponenteNoExiste()
        {
            var resultado = controlador.Get(999) as NotFoundResult;
            Assert.IsNotNull(resultado);
        }

        [TestMethod]
        public void TestOrdenadorComponenteCrearBien()
        {
            var resultado = controlador.Get() as OkObjectResult;
            Assert.IsNotNull(resultado);
            var listaModulos = resultado.Value as List<OrdenadorComponente>;
            Assert.IsNotNull(listaModulos);
            Assert.AreEqual(1, listaModulos.Count);

            OrdenadorComponente ordenadorComponenteNuevo = new()
            {
                Id = 2,
                OrdenadorId = 2,
                ComponenteId = 1,
                Ordenador = new Ordenador()
                {
                    Id = 2,
                    Descripcion = "patata2",
                    NumeroDeSerie = "AAAA2"
                },
                Componente = new Componente()
                {
                    Id = 1,
                    Almacenamiento = 6,
                    Calor = 10,
                    Categoria = 0,
                    Description = "patata",
                    NumeroDeSerie = "AAAA",
                    Precio = 50,
                    UnidadMedida = "Cores"
                }
            };

            var resultadoPost = controlador.Post(ordenadorComponenteNuevo) as OkResult;
            resultado = controlador.Get() as OkObjectResult;
            Assert.IsNotNull(resultadoPost);
            Assert.IsNotNull(resultado);
            listaModulos = resultado.Value as List<OrdenadorComponente>;
            Assert.IsNotNull(listaModulos);
            Assert.AreEqual(2, listaModulos.Count);
        }

        [TestMethod]
        public void TestOrdenadorComponenteBorrarExiste()
        {
            var resultado = controlador.Get() as OkObjectResult;
            Assert.IsNotNull(resultado);
            var listaModulos = resultado.Value as List<OrdenadorComponente>;
            Assert.IsNotNull(listaModulos);
            Assert.AreEqual(1, listaModulos.Count);

            var resultadoDelete = controlador.Delete(1) as OkResult;
            resultado = controlador.Get() as OkObjectResult;
            Assert.IsNotNull(resultadoDelete);
            Assert.IsNotNull(resultado);
            listaModulos = resultado.Value as List<OrdenadorComponente>;
            Assert.IsNotNull(listaModulos);
            Assert.AreEqual(0, listaModulos.Count);
        }

        [TestMethod]
        public void TestOrdenadorComponenteBorrarNoExiste()
        {
            var resultado = controlador.Get() as OkObjectResult;
            Assert.IsNotNull(resultado);
            var listaModulos = resultado.Value as List<OrdenadorComponente>;
            Assert.IsNotNull(listaModulos);
            Assert.AreEqual(1, listaModulos.Count);

            controlador.Delete(999);
            resultado = controlador.Get() as OkObjectResult;
            Assert.IsNotNull(resultado);
            listaModulos = resultado.Value as List<OrdenadorComponente>;
            Assert.IsNotNull(listaModulos);
            Assert.AreEqual(1, listaModulos.Count);
        }

        [TestMethod]
        public void TestOrdenadorComponenteActualizarExiste()
        {
            OrdenadorComponente ordenadorComponenteNuevo = new()
            {
                Id = 1,
                OrdenadorId = 2,
                ComponenteId = 1,
                Ordenador = new Ordenador()
                {
                    Id = 2,
                    Descripcion = "patata2",
                    NumeroDeSerie = "AAAA2"
                },
                Componente = new Componente()
                {
                    Id = 1,
                    Almacenamiento = 6,
                    Calor = 10,
                    Categoria = 0,
                    Description = "patata",
                    NumeroDeSerie = "AAAA",
                    Precio = 50,
                    UnidadMedida = "Cores"
                }
            };
            var resultadoPut = controlador.Put(ordenadorComponenteNuevo) as OkResult;
            var resultadoGet = controlador.Get(1) as OkObjectResult;

            Assert.IsNotNull(resultadoPut);
            Assert.IsNotNull(resultadoGet);

            var ordenadorComponente = resultadoGet.Value as OrdenadorComponente;

            Assert.IsNotNull(ordenadorComponente);
            Assert.AreEqual(1, ordenadorComponente.ComponenteId);
            Assert.AreEqual(2, ordenadorComponente.OrdenadorId);
            Assert.AreEqual("patata2", ordenadorComponente.Ordenador.Descripcion);
            Assert.AreEqual("AAAA2", ordenadorComponente.Ordenador.NumeroDeSerie);
        }

        [TestMethod]
        public void TestOrdenadorComponenteActualizarNoExiste()
        {
            OrdenadorComponente ordenadorComponenteNuevo = new()
            {
                Id = 90,
                OrdenadorId = 2,
                ComponenteId = 1,
                Ordenador = new Ordenador()
                {
                    Id = 2,
                    Descripcion = "patata2",
                    NumeroDeSerie = "AAAA2"
                },
                Componente = new Componente()
                {
                    Id = 1,
                    Almacenamiento = 6,
                    Calor = 10,
                    Categoria = 0,
                    Description = "patata",
                    NumeroDeSerie = "AAAA",
                    Precio = 50,
                    UnidadMedida = "Cores"
                }
            };
            var resultadoPut = controlador.Put(ordenadorComponenteNuevo) as ObjectResult;
            Assert.IsNotNull(resultadoPut);
            Assert.AreEqual(400, resultadoPut.StatusCode);
        }
    }
}

