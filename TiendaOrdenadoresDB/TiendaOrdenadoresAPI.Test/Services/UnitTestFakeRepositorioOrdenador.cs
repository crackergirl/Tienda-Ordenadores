using TiendaOrdenadoresAPI.Models;
using TiendaOrdenadoresAPI.Services;
using TiendaOrdenadoresAPI.Services.Fakes;

namespace TiendaOrdenadoresAPI.Test.Services
{
    [TestClass]
    public class UnitTestFakeRepositorioOrdenador
	{
        readonly IRepositorio<Ordenador> repositorioOrdenador = new FakeRepositorioOrdenador();

        [TestMethod]
        public void TestDameOrdenadorExiste()
        {
            var componente = repositorioOrdenador.Obtener(1);
            Assert.IsNotNull(componente);

        }
        [TestMethod]
        public void TestDameOrdenadorNoExiste()
        {
            var componente = repositorioOrdenador.Obtener(10);
            Assert.IsNull(componente);
        }

        [TestMethod]
        public void TestActualiza()
        {
            var ordenador = repositorioOrdenador.Obtener(1);

            Assert.IsNotNull(ordenador);
            Assert.AreEqual("patata", ordenador.Descripcion);
            Assert.AreEqual("AAAA1", ordenador.NumeroDeSerie);

            repositorioOrdenador.Actualizar(new Ordenador()
            {
                Id = 1,
                Descripcion = "patata2",
                NumeroDeSerie = "AAAA",
            });
            ordenador = repositorioOrdenador.Obtener(1);

            Assert.IsNotNull(ordenador);
            Assert.AreEqual("patata2", ordenador.Descripcion);
            Assert.AreEqual("AAAA", ordenador.NumeroDeSerie);
        }

        [TestMethod]
        public void TestBorra()
        {
            var misOrdenadores = repositorioOrdenador.ObtenerTodos();
            var numeroOrdenadoresAntes = misOrdenadores.Count();
            repositorioOrdenador.Borrar(1);
            var numeroOrdenadoresDespues = misOrdenadores.Count();

            Assert.IsNull(repositorioOrdenador.Obtener(1));
            Assert.AreEqual(numeroOrdenadoresDespues, numeroOrdenadoresAntes - 1);
        }
    }
}

