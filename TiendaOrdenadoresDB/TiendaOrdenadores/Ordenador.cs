using TiendaOrdenadores.Componentes.Almacenadores.Guardadores;
using TiendaOrdenadores.Componentes.Almacenadores.Memorizadores;
using TiendaOrdenadores.Componentes.Procesadores;

namespace TiendaOrdenadores
{
	public class Ordenador : IOrdenador
	{
		IProcesable procesador;
		IMemorizable memorizador;
        IGuardable guardador;

        public Ordenador(IProcesable procesador, IMemorizable memorizador, IGuardable guardador)
        {
            this.procesador = procesador;
            this.memorizador = memorizador;
            this.guardador = guardador;
        }

        public IProcesable Procesador
        {
            get => procesador;
            set => procesador = value;
        }
        public IMemorizable Memorizador
        {
            get => memorizador;
            set => memorizador = value;
        }
        public IGuardable Guardador
        {
            get => guardador;
            set => guardador = value;
        }

        public int getCalor()
        {
            return procesador.getCalor() + memorizador.getCalor() + guardador.getCalor();
        }

        public int getPrecio()
        {
            return procesador.getPrecio() + memorizador.getPrecio() + guardador.getPrecio();
        }
    }
}

