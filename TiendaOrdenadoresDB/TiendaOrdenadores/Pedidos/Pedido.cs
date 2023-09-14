using TiendaOrdenadores.Componentes;

namespace TiendaOrdenadores.Pedidos
{
	public class Pedido : IPedido
	{
        List<IOrdenador> ordenadores;
        int calorTotal;
        int precioTotal;
        Dictionary<string, int> totalComponentes;

        public Pedido()
		{
            ordenadores = new List<IOrdenador>();
            calorTotal = 0;
            precioTotal = 0;
            totalComponentes = new();
        }

        public void add(IOrdenador ordenador)
        {
            ordenadores.Add(ordenador);
            calorTotal += ordenador.getCalor();
            precioTotal += ordenador.getPrecio();
            Dictionary<String, int>  componentesOrdenador = dameCantidadComponentesOrdenador(ordenador);
            totalComponentes = totalComponentes.Concat(componentesOrdenador)
            .GroupBy(kv => kv.Key)
            .ToDictionary(group => group.Key, group => group.Sum(kv => kv.Value));

        }

        private Dictionary<String, int> dameCantidadComponentesOrdenador(IOrdenador ordenador)
        {
            var todosComponentes = new List<IComponente>()
            {
                ordenador.Procesador,
                ordenador.Memorizador,
                ordenador.Guardador
            };

            if (ordenador is OrdenadorVariosGuardadores)
                todosComponentes.AddRange(((OrdenadorVariosGuardadores)ordenador).dameGuardadoresSecundarios());

            return todosComponentes
                .GroupBy(componente => componente.getNumeroDeSerie())
                .ToDictionary(group => group.Key, group => group.Count());
        }

        public int getCalor()
        {
            return calorTotal;
        }

        public int getPrecio()
        {
            return precioTotal;
        }

        public Dictionary<string, int> dameCantidadComponentesPedido()
        {
            return totalComponentes;
        }
    }
}

