using TiendaOrdenadores.Componentes.Almacenadores.Guardadores;
using TiendaOrdenadores.Componentes.Almacenadores.Memorizadores;
using TiendaOrdenadores.Componentes.Procesadores;

namespace TiendaOrdenadores.Test
{
    [TestClass]
    public class UnitTestOrdenadorVariosAlmacenadores
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
        List<IGuardable> guardadores ;
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
            guardadores = new List<IGuardable>
                                        {   new Guardador(calorGuardable, 9, "Procesador intel i7", "789-XCS", precioGuardable),
                                            new Guardador(calorGuardable, 9, "Procesador intel i7", "789-XCS", precioGuardable),
                                            new Guardador(calorGuardable, 9, "Procesador intel i7", "789-XCS", precioGuardable) };
            ordenador = new OrdenadorVariosGuardadores(procesador, memorizador, guardadorPrincipal, guardadores);
        }

        [TestMethod]
        public void ordenadorClaseBien()
        { 
            Assert.IsNotNull(ordenador);
            Assert.AreEqual(procesador.getCalor() + guardadorPrincipal.getCalor() + (3 * calorGuardable) + memorizador.getCalor(), ordenador.getCalor());
            Assert.AreEqual(procesador.getPrecio() + guardadorPrincipal.getPrecio() + (3 * precioGuardable) + memorizador.getPrecio(), ordenador.getPrecio());
        }

        [TestMethod]
        public void eliminaGuardadorSecundario()
        {
            (ordenador as OrdenadorVariosGuardadores).eliminarGuardadorSecundario("789-XCS");

            Assert.IsNotNull(ordenador);
            Assert.AreEqual(procesador.getCalor() + guardadorPrincipal.getCalor() + memorizador.getCalor(), ordenador.getCalor());
            Assert.AreEqual(procesador.getPrecio() + guardadorPrincipal.getPrecio() + memorizador.getPrecio(), ordenador.getPrecio());
        }

        [TestMethod]
        public void añadirGuardadorSecundario()
        {
            (ordenador as OrdenadorVariosGuardadores).añadirGuardadorSecundario(new Guardador(calorGuardable, 9, "Procesador intel i7", "789-XCS", precioGuardable));

            Assert.IsNotNull(ordenador);
            Assert.AreEqual(procesador.getCalor() + guardadorPrincipal.getCalor() + (4 * calorGuardable) + memorizador.getCalor(), ordenador.getCalor());
            Assert.AreEqual(procesador.getPrecio() + guardadorPrincipal.getPrecio() + (4 * precioGuardable) + memorizador.getPrecio(), ordenador.getPrecio());
        }

        [TestMethod]
        public void eliminarGuardadorSecundarioQueNoTieneOrdenador()
        {
            (ordenador as OrdenadorVariosGuardadores).eliminarGuardadorSecundario( "789-X2S");

            Assert.IsNotNull(ordenador);
            Assert.AreEqual(procesador.getCalor() + guardadorPrincipal.getCalor() + (3 * calorGuardable) + memorizador.getCalor(), ordenador.getCalor());
            Assert.AreEqual(procesador.getPrecio() + guardadorPrincipal.getPrecio() + (3 * precioGuardable) + memorizador.getPrecio(), ordenador.getPrecio());
        }
    }
}

