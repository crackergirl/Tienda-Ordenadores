using TiendaOrdenadores.AlmacenComponentes;
using TiendaOrdenadores.Pedidos;

namespace TiendaOrdenadores.Facturas
{
	public class Factura : IFactura
	{
        IAlmacen almacen;
        List<IPedido> factura;
        bool esPosibleFactura;
        int precioTotal;

        public Factura(IAlmacen almacen)
		{
            this.almacen = almacen;
            factura = new List<IPedido>();
            esPosibleFactura = true;
        }

        public void add(IPedido pedido)
        {
            factura.Add(pedido);
            precioTotal += pedido.getPrecio();
            if (esPosibleFactura)
                esPosibleFactura = esPosibleIncluirEstePedido(pedido.dameCantidadComponentesPedido());
        }

        private bool esPosibleIncluirEstePedido(Dictionary<String, int> cantidadesPedido) {
            var pedidoNoPosible = cantidadesPedido.Keys.ToList().Find( componente =>

                almacen.utilizarComponente(componente, cantidadesPedido[componente]) == false
            );

            if (pedidoNoPosible == null)
                return true;
            else
                return false;

        }

        public bool esPosibleCrearEstaFactura()
        {
           return esPosibleFactura;
        }

        public int getPrecio()
        {
            return precioTotal;
        }
    }
}

