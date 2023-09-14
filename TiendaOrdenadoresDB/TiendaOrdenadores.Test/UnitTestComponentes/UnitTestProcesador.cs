using TiendaOrdenadores.Componentes.Procesadores;

namespace TiendaOrdenadores.Test;

[TestClass]
public class UnitTestProcesador
{
    [TestMethod]
    public void procesadorBien()
    {
        IProcesable procesador = new Procesador(10, 9, "Procesador intel i7", "789-XCS", 134);

        Assert.IsNotNull(procesador);
        Assert.AreEqual(10, procesador.getCalor());
        Assert.AreEqual(9, procesador.getCores());
        Assert.AreEqual("Procesador intel i7", procesador.getDescripcion());
        Assert.AreEqual("789-XCS", procesador.getNumeroDeSerie());
        Assert.AreEqual(134, procesador.getPrecio());

    }

    [TestMethod]
    public void procesadorMal()
    {
        IProcesable procesador = new Procesador(-1, -1, "Procesador intel i7", "", -1);

        Assert.IsNotNull(procesador);
        Assert.AreEqual(0, procesador.getCalor());
        Assert.AreEqual(0, procesador.getCores());
        Assert.AreEqual("Procesador intel i7", procesador.getDescripcion());
        Assert.AreEqual("desconocido", procesador.getNumeroDeSerie());
        Assert.AreEqual(0, procesador.getPrecio());

    }
}
