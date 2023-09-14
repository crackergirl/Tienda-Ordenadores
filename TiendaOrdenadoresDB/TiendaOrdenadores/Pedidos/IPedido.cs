namespace TiendaOrdenadores.Pedidos
{
	public interface IPedido : ICalorable, ICostable
    {
		void add(IOrdenador ordenador);
        Dictionary<String, int> dameCantidadComponentesPedido();

    }
}

