using TiendaOrdenadores.Componentes.Almacenadores.Memorizadores;

namespace TiendaOrdenadores.Test
{
    [TestClass]
    public class UnitTestMemorizador
	{
        [TestMethod]
        public void memorizadorBien()
        {
            IMemorizable memorizador = new Memorizador(10, 9, "Procesador intel i7", "789-XCS", 134);

            Assert.IsNotNull(memorizador);
            Assert.AreEqual(10, memorizador.getCalor());
            Assert.AreEqual(9, memorizador.getAlmacenamiento());
            Assert.AreEqual("Procesador intel i7", memorizador.getDescripcion());
            Assert.AreEqual("789-XCS", memorizador.getNumeroDeSerie());
            Assert.AreEqual(134, memorizador.getPrecio());

        }

        [TestMethod]
        public void memorizadorMal()
        {
            IMemorizable memorizador = new Memorizador(-1, -1, "Procesador intel i7", "", -1);

            Assert.IsNotNull(memorizador);
            Assert.AreEqual(0, memorizador.getCalor());
            Assert.AreEqual(0, memorizador.getAlmacenamiento());
            Assert.AreEqual("Procesador intel i7", memorizador.getDescripcion());
            Assert.AreEqual("desconocido", memorizador.getNumeroDeSerie());
            Assert.AreEqual(0, memorizador.getPrecio());

        }
    }
}

