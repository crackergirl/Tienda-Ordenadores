using TiendaOrdenadores.AlmacenComponentes;

namespace TiendaOrdenadores.Test.UnitTestAlmacenComponentes
{
    [TestClass]
    public class UnitTestAlmacen
	{
        IAlmacen almacen;

        [TestInitialize]
        public void inicializarTeses()
        {
            almacen = new Almacen();
        }

        [TestMethod]
        public void aumentarCantidadComponente()
        {
            int cantidadInicial = almacen.dameCantidadComponente("789-XCS");
            almacen.aumentarCantidadComponente("789-XCS", 3);
            Assert.AreEqual(cantidadInicial + 3 , almacen.dameCantidadComponente("789-XCS"));
        }

        [TestMethod]
        public void utilizarComponenteBien()
        {
            int cantidadInicial = almacen.dameCantidadComponente("789-XCS");
            bool esExtraible = almacen.utilizarComponente("789-XCS", 1);
            Assert.AreEqual(true, esExtraible);
            Assert.AreEqual(cantidadInicial - 1 , almacen.dameCantidadComponente("789-XCS"));
        }

        [TestMethod]
        public void noDisponerCantidadComponente()
        {
            int cantidadInicial = almacen.dameCantidadComponente("789-XCS");
            bool esExtraible = almacen.utilizarComponente("789-XCS", cantidadInicial + 1);
            Assert.AreEqual(false, esExtraible);
        }
    }
}

