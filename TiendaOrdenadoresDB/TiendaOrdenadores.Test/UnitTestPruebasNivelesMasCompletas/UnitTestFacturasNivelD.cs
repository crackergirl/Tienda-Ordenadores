using System;
using TiendaOrdenadores.AlmacenComponentes;
using TiendaOrdenadores.Facturas;
using TiendaOrdenadores.Pedidos;
using TiendaOrdenadores.Test.UnitTestPruebasNivelesMasCompletas.FabricaOrdenadores;

namespace TiendaOrdenadores.Test.UnitTestPruebasNivelesMasCompletas
{
    [TestClass]
    public class UnitTestFacturaNivelD
	{
        FabricaOrdenadorConBuilder fabricaOrdenador;
        IPedido pedidoA;
        IFactura factura;
        IPedido pedidoB;
        IAlmacen almacen;

        [TestInitialize]
        public void inicializarTeses()
        {
            fabricaOrdenador = new FabricaOrdenadorConBuilder();
            pedidoA = new Pedido();
            pedidoB = new Pedido();
            almacen = new Almacen();
            factura = new Factura(almacen);
        }

        [TestMethod]
        public void facturaA()
        {
            IOrdenador ordenadorMaria = fabricaOrdenador.dameOrdenador(TipoOrdenador.OrdenadorMaria);
            IOrdenador ordenadorAndres = fabricaOrdenador.dameOrdenador(TipoOrdenador.OrdenadorAndres);
            pedidoA.add(ordenadorMaria);
            pedidoA.add(ordenadorAndres);
            factura.add(pedidoA);
            Assert.AreEqual(pedidoA.getPrecio(), factura.getPrecio());
            Assert.AreEqual(true, factura.esPosibleCrearEstaFactura());
        }

        [TestMethod]
        public void facturaB()
        {
            IOrdenador ordenadorAndresCF = fabricaOrdenador.dameOrdenador(TipoOrdenador.OrdenadorMaria);
            IOrdenador ordenadorTiburcioII = fabricaOrdenador.dameOrdenador(TipoOrdenador.OrdenadorAndres);
            pedidoB.add(ordenadorAndresCF);
            pedidoB.add(ordenadorTiburcioII);
            factura.add(pedidoB);

            Assert.AreEqual(pedidoB.getPrecio(), factura.getPrecio());
            Assert.AreEqual(true, factura.esPosibleCrearEstaFactura());
        }

        [TestMethod]
        public void facturaC()
        {
            IOrdenador ordenadorMaria = fabricaOrdenador.dameOrdenador(TipoOrdenador.OrdenadorMaria);
            IOrdenador ordenadorAndres = fabricaOrdenador.dameOrdenador(TipoOrdenador.OrdenadorAndres);
            IOrdenador ordenadorAndresCF = fabricaOrdenador.dameOrdenador(TipoOrdenador.OrdenadorMaria);
            IOrdenador ordenadorTiburcioII = fabricaOrdenador.dameOrdenador(TipoOrdenador.OrdenadorAndres);
            pedidoA.add(ordenadorMaria);
            pedidoA.add(ordenadorAndres);
            pedidoB.add(ordenadorAndresCF);
            pedidoB.add(ordenadorTiburcioII);
            factura.add(pedidoB);
            factura.add(pedidoA);

            Assert.AreEqual(pedidoA.getPrecio() + pedidoB.getPrecio(), factura.getPrecio());
            Assert.AreEqual(false, factura.esPosibleCrearEstaFactura());
        }
    }
}

