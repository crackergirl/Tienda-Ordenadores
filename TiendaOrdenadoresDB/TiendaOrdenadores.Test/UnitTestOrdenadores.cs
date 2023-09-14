using TiendaOrdenadores.Componentes.Almacenadores.Guardadores;
using TiendaOrdenadores.Componentes.Almacenadores.Memorizadores;
using TiendaOrdenadores.Componentes.Procesadores;

namespace TiendaOrdenadores.Test
{
    [TestClass]
    public class UnitTestOrdenadores
	{
        int calorProcesador;
        int calorMemorizable;
        int calorGuardable;
        int precioProcesador;
        int precioMemorizable;
        int precioGuardable;
        IProcesable procesador;
        IMemorizable memorizador;
        IGuardable guardadorPrincipal;
        IOrdenador ordenador;

        [TestInitialize]
        public void inicializarTeses()
        {
            calorProcesador = 10;
            calorMemorizable = 15;
            calorGuardable = 20;
            precioProcesador = 50;
            precioMemorizable = 20;
            precioGuardable = 100;
            procesador = new Procesador(calorProcesador, 9, "Procesador intel i7", "789-XCS", precioProcesador);
            memorizador = new Memorizador(calorMemorizable, 9, "Procesador intel i7", "789-XCS", precioMemorizable);
            guardadorPrincipal = new Guardador(calorGuardable, 9, "Procesador intel i7", "789-XCS", precioGuardable);
            ordenador = new Ordenador(procesador, memorizador, guardadorPrincipal);
        }

        [TestMethod]
        public void ordenadorClaseBien()
        {

            Assert.IsNotNull(ordenador);
            Assert.AreEqual(procesador.getCalor() + guardadorPrincipal.getCalor() + memorizador.getCalor(), ordenador.getCalor());
            Assert.AreEqual(procesador.getPrecio() + guardadorPrincipal.getPrecio() + memorizador.getPrecio(), ordenador.getPrecio());
        }

        [TestMethod]
        public void modificarProcesadorBien()
        {
            ordenador.Procesador = new Procesador(80, 9, "Procesador intel i7", "789-XCS", 50);
            Assert.IsNotNull(ordenador);
            Assert.AreEqual(80 + guardadorPrincipal.getCalor() + memorizador.getCalor(), ordenador.getCalor());
            Assert.AreEqual(50 + guardadorPrincipal.getPrecio() + memorizador.getPrecio(), ordenador.getPrecio());
        }

        [TestMethod]
        public void modificarMemorizadorBien()
        {
            ordenador.Memorizador = new Memorizador(80, 9, "Procesador intel i7", "789-XCS", 50);
            Assert.IsNotNull(ordenador);
            Assert.AreEqual(procesador.getCalor() + guardadorPrincipal.getCalor() + 80, ordenador.getCalor());
            Assert.AreEqual(procesador.getPrecio() + guardadorPrincipal.getPrecio() + 50, ordenador.getPrecio());
        }

        [TestMethod]
        public void modificarGuardadorBien()
        {
            ordenador.Guardador = new Guardador(80, 9, "Procesador intel i7", "789-XCS", 50);
            Assert.IsNotNull(ordenador);
            Assert.AreEqual(procesador.getCalor() + 80 + memorizador.getCalor(), ordenador.getCalor());
            Assert.AreEqual(procesador.getPrecio() + 50 + memorizador.getPrecio(), ordenador.getPrecio());
        }

    }
}

