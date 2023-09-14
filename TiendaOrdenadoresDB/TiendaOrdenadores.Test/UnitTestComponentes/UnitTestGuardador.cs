using TiendaOrdenadores.Componentes.Almacenadores.Guardadores;

namespace TiendaOrdenadores.Test
{
    [TestClass]
    public class UnitTestGuardador
	{
        [TestMethod]
        public void guardadorBien()
        {
            IGuardable guardador = new Guardador(10, 9, "Procesador intel i7", "789-XCS", 134);

            Assert.IsNotNull(guardador);
            Assert.AreEqual(10, guardador.getCalor());
            Assert.AreEqual(9, guardador.getAlmacenamiento());
            Assert.AreEqual("Procesador intel i7", guardador.getDescripcion());
            Assert.AreEqual("789-XCS", guardador.getNumeroDeSerie());
            Assert.AreEqual(134, guardador.getPrecio());

        }

        [TestMethod]
        public void guardadorMal()
        {
            IGuardable guardador = new Guardador(-1, -1, "Procesador intel i7", "", -1);

            Assert.IsNotNull(guardador);
            Assert.AreEqual(0, guardador.getCalor());
            Assert.AreEqual(0, guardador.getAlmacenamiento());
            Assert.AreEqual("Procesador intel i7", guardador.getDescripcion());
            Assert.AreEqual("desconocido", guardador.getNumeroDeSerie());
            Assert.AreEqual(0, guardador.getPrecio());

        }
    }
}

