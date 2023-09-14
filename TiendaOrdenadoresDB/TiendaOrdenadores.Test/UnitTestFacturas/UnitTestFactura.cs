using TiendaOrdenadores.AlmacenComponentes;
using TiendaOrdenadores.BuilderOrdenadores;
using TiendaOrdenadores.FabricaComponentes.FabricaAlmacenadores.FabricaGuardadores;
using TiendaOrdenadores.FabricaComponentes.FabricaAlmacenadores.FabricaMemorizadores;
using TiendaOrdenadores.FabricaComponentes.FabricaProcesadores;
using TiendaOrdenadores.Facturas;
using TiendaOrdenadores.Pedidos;

namespace TiendaOrdenadores.Test.UnitTestFacturas
{
    [TestClass]
    public class UnitTestFactura
	{
        IAlmacen almacen;
        IFactura factura;
        IPedido pedido;
        IBuilderOrdenador builder;
        IOrdenador ordenador;

        [TestInitialize]
        public void inicializarTeses()
        {
            almacen = new Almacen();
            factura = new Factura(almacen);
            pedido = new Pedido();
            builder = new BuilderOrdenador();
            ordenador = builder.dameOrdenador(TipoProcesador._789_XCS, TipoGuardador._789_XX, TipoMemorizador._879_FH);
        }

        [TestMethod]
        public void facturaPosible()
        {
            int cantidad_789_XCS_inicial = almacen.dameCantidadComponente("789-XCS");
            int cantidad_789_XX_inicial = almacen.dameCantidadComponente("789-XX");
            int cantidad_879_FH_inicial = almacen.dameCantidadComponente("879-FH");
            pedido.add(ordenador);
            factura.add(pedido);
            int cantidad_789_XCS = almacen.dameCantidadComponente("789-XCS");
            int cantidad_789_XX = almacen.dameCantidadComponente("789-XX");
            int cantidad_879_FH = almacen.dameCantidadComponente("879-FH");
            Assert.AreEqual(true, factura.esPosibleCrearEstaFactura());
            Assert.AreEqual(pedido.getPrecio(), factura.getPrecio());
            Assert.AreNotEqual(cantidad_789_XCS_inicial, cantidad_789_XCS);
            Assert.AreNotEqual(cantidad_789_XX_inicial, cantidad_789_XX);
            Assert.AreNotEqual(cantidad_879_FH_inicial, cantidad_879_FH);
        }

        [TestMethod]
        public void facturaNoPosible()
        {
            IOrdenador ordenadorExtra = builder.dameOrdenador(TipoProcesador._789_XCS, TipoGuardador._789_XX, TipoMemorizador._879_FH);

            pedido.add(ordenador);
            pedido.add(ordenadorExtra);
            factura.add(pedido);

            Assert.AreEqual(false, factura.esPosibleCrearEstaFactura());
        }
    }
}

