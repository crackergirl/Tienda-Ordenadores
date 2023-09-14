using TiendaOrdenadoresDB.Models;
using TiendaOrdenadoresDB.Services;
using TiendaOrdenadoresDB.Servicies;

namespace TiendaOrdenadoresDB.Test.Services
{
    [TestClass]
    public class UnitTestFakeRepositorioOrdenadorComponente
	{
        readonly IRepositorio<OrdenadorComponente> repositorioOrdenadorComponente = new FakeRepositorioOrdenadorComponente();

        [TestMethod]
        public void TestDameOrdenadorComponenteExiste()
        {
            var componente = repositorioOrdenadorComponente.Obtener(1);
            Assert.IsNotNull(componente);

        }
        [TestMethod]
        public void TestDameOrdenadorComponenteNoExiste()
        {
            var componente = repositorioOrdenadorComponente.Obtener(10);
            Assert.IsNull(componente);
        }

        [TestMethod]
        public void TestActualiza()
        {
            var ordenador = repositorioOrdenadorComponente.Obtener(1);

            Assert.IsNotNull(ordenador);
            Assert.AreEqual(1, ordenador.OrdenadorId);
            Assert.AreEqual(1, ordenador.ComponenteId);

            repositorioOrdenadorComponente.Actualizar(new OrdenadorComponente()
            {
                Id = 1,
                OrdenadorId = 1,
                ComponenteId = 2
            });
            ordenador = repositorioOrdenadorComponente.Obtener(1);

            Assert.IsNotNull(ordenador);
            Assert.AreEqual(1, ordenador.OrdenadorId);
            Assert.AreEqual(2, ordenador.ComponenteId);
        }

        [TestMethod]
        public void TestBorra()
        {
            var misOrdenadores = repositorioOrdenadorComponente.ObtenerTodos();
            var numeroOrdenadoresAntes = misOrdenadores.Count();
            repositorioOrdenadorComponente.Borrar(1);
            var numeroOrdenadoresDespues = misOrdenadores.Count();

            Assert.IsNull(repositorioOrdenadorComponente.Obtener(1));
            Assert.AreEqual(numeroOrdenadoresDespues, numeroOrdenadoresAntes - 1);
        }
    }
}

