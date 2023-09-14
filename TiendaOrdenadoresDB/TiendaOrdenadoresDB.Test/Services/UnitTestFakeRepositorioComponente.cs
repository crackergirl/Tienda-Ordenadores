using TiendaOrdenadoresDB.Models;
using TiendaOrdenadoresDB.Servicies;

namespace TiendaOrdenadoresABaseDeDatos.Test.Services
{
    [TestClass]
    public class UnitTestFakeRepositorioComponente
	{
        readonly IRepositorio<Componente> repositorioComponente = new FakeRepositorioComponente();

        [TestMethod]
        public void TestDameComponenteExiste()
        {
            var componente = repositorioComponente.Obtener(1);
            Assert.IsNotNull(componente);

        }
        [TestMethod]
        public void TestDameComponenteNoExiste()
        {
            var componente = repositorioComponente.Obtener(10);
            Assert.IsNull(componente);

        }

        [TestMethod]
        public void TestActualiza()
        {
            var componente = repositorioComponente.Obtener(1);

            Assert.IsNotNull(componente);
            Assert.AreEqual(0, componente.Categoria);
            Assert.AreEqual("patata", componente.Description);
            Assert.AreEqual(50, componente.Precio);

            repositorioComponente.Actualizar(new Componente()
            {
                Id = 1,
                Almacenamiento = 6,
                Calor = 10,
                Categoria = 2,
                Description = "patata2",
                NumeroDeSerie = "AAAA",
                Precio = 500,
                UnidadMedida = "Cores"
            });
            componente = repositorioComponente.Obtener(1);

            Assert.IsNotNull(componente);
            Assert.AreEqual(2, componente.Categoria);
            Assert.AreEqual("patata2", componente.Description);
            Assert.AreEqual(500, componente.Precio);

        }

        [TestMethod]
        public void TestBorra()
        {
            var misComponentes = repositorioComponente.ObtenerTodos();
            var numeroComponentesAntes = misComponentes.Count();
            repositorioComponente.Borrar(1);
            var numeroComponentesDespues = misComponentes.Count();

            Assert.IsNull(repositorioComponente.Obtener(1));
            Assert.AreEqual(numeroComponentesDespues, numeroComponentesAntes - 1);
        }
    }
}

