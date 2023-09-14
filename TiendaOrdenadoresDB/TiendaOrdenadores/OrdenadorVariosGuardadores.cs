using TiendaOrdenadores.Componentes.Almacenadores.Guardadores;
using TiendaOrdenadores.Componentes.Almacenadores.Memorizadores;
using TiendaOrdenadores.Componentes.Procesadores;

namespace TiendaOrdenadores
{
	public class OrdenadorVariosGuardadores : IOrdenador
    {
        IProcesable procesador;
        IMemorizable memorizador;
        IGuardable guardadorPrimario;
        List<IGuardable> guardadores;

        public OrdenadorVariosGuardadores(IProcesable procesador, IMemorizable memorizador, IGuardable guardadorPrimario, List<IGuardable> guardadores)
        {
            this.procesador = procesador;
            this.memorizador = memorizador;
            this.guardadorPrimario = guardadorPrimario;
            this.guardadores = guardadores;
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
            get => guardadorPrimario;
            set => guardadorPrimario = value;
        }

        public List<IGuardable> dameGuardadoresSecundarios() {
            return guardadores;
        }

        public void añadirGuardadorSecundario(IGuardable guardador)
        {
            guardadores.Add(guardador);
        }

        public void eliminarGuardadorSecundario(String numeroDeSerie)
        {
            guardadores.RemoveAll(x => x.getNumeroDeSerie() == numeroDeSerie);
            //guardadores.Remove(guardadores.Find(x => x.getNumeroDeSerie() == numeroDeSerie));
        
        }

        public int getCalor()
        {
            int calorGuardadores = guardadores.Sum(guardador => guardador.getCalor());
            int calorTotal = procesador.getCalor() + memorizador.getCalor() + guardadorPrimario.getCalor() + calorGuardadores;
            return calorTotal;
        }


        public int getPrecio()
        {
            int precioGuardadores = guardadores.Sum(guardador => guardador.getPrecio());
            int precioTotal = procesador.getPrecio() + memorizador.getPrecio() + guardadorPrimario.getPrecio() + precioGuardadores;
            return precioTotal;
        }
		
	}
}

