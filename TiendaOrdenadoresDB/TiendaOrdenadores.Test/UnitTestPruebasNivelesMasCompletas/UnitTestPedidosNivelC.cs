using TiendaOrdenadores.Pedidos;
using TiendaOrdenadores.Test.UnitTestPruebasNivelesMasCompletas.FabricaOrdenadores;

namespace TiendaOrdenadores.Test.UnitTestPruebasNivelesMasCompletas
{
    [TestClass]
    public class UnitTestPedidosNivelC
    {
        FabricaOrdenadorConBuilder fabricaOrdenador;
        IPedido pedido;

        [TestInitialize]
        public void inicializarTeses()
        {
            fabricaOrdenador = new FabricaOrdenadorConBuilder();
            pedido = new Pedido();
        }

        [TestMethod]
        public void pedidoOrdenadoresBasicos()
        {
            IOrdenador ordenadorMaria = fabricaOrdenador.dameOrdenador(TipoOrdenador.OrdenadorMaria);
            IOrdenador ordenadorAndres = fabricaOrdenador.dameOrdenador(TipoOrdenador.OrdenadorAndres);
            pedido.add(ordenadorMaria);
            pedido.add(ordenadorAndres);

            Assert.AreEqual(ordenadorMaria.getPrecio() + ordenadorAndres.getPrecio(), pedido.getPrecio());
            Assert.AreEqual(ordenadorMaria.getCalor() + ordenadorAndres.getCalor(), pedido.getCalor());
        }

        [TestMethod]
        public void pedidoOrdenadoresVariosGuardadores()
        {
            IOrdenador ordenadorAndresCF = fabricaOrdenador.dameOrdenador(TipoOrdenador.OrdenadorMaria);
            IOrdenador ordenadorTiburcioII = fabricaOrdenador.dameOrdenador(TipoOrdenador.OrdenadorAndres);
            pedido.add(ordenadorAndresCF);
            pedido.add(ordenadorTiburcioII);

            Assert.AreEqual(ordenadorAndresCF.getPrecio() + ordenadorTiburcioII.getPrecio(), pedido.getPrecio());
            Assert.AreEqual(ordenadorAndresCF.getCalor() + ordenadorTiburcioII.getCalor(), pedido.getCalor());
        }
    }
}

