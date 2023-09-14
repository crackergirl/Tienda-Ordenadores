using TiendaOrdenadores.Pedidos;

namespace TiendaOrdenadores.Facturas
{
	public interface IFactura : ICostable
	{
        void add(IPedido pedido);
        bool esPosibleCrearEstaFactura();
    }
}

