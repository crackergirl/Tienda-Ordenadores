using TiendaOrdenadores.Componentes.Almacenadores.Guardadores;
using TiendaOrdenadores.Componentes.Almacenadores.Memorizadores;
using TiendaOrdenadores.Componentes.Procesadores;
using TiendaOrdenadores.FabricaComponentes;
using TiendaOrdenadores.FabricaComponentes.FabricaAlmacenadores.FabricaGuardadores;
using TiendaOrdenadores.FabricaComponentes.FabricaAlmacenadores.FabricaMemorizadores;
using TiendaOrdenadores.FabricaComponentes.FabricaProcesadores;

namespace TiendaOrdenadores.BuilderOrdenadores
{
	public class BuilderOrdenador : IBuilderOrdenador
	{
        public IOrdenador dameOrdenador(TipoProcesador tipoProcesador, TipoGuardador tipoGuardador, TipoMemorizador tipoMemorizador)
        {
            IFabricaComponente fabrica = new FabricaComponente();
            IProcesable? procesador = fabrica.dameComponente(tipoProcesador);
            IMemorizable? memorizador = fabrica.dameComponente(tipoMemorizador);
            IGuardable? guardador = fabrica.dameComponente(tipoGuardador);
            return new Ordenador(procesador, memorizador, guardador);
            
        }

        public IOrdenador dameOrdenador(TipoProcesador tipoProcesador, TipoGuardador tipoGuardadorPrimario, List<TipoGuardador> tipoGuardadores, TipoMemorizador tipoMemorizador)
        {
            IFabricaComponente fabrica = new FabricaComponente();
            IProcesable? procesador = fabrica.dameComponente(tipoProcesador);
            IMemorizable? memorizador = fabrica.dameComponente(tipoMemorizador);
            IGuardable? guardadorPrimario = fabrica.dameComponente(tipoGuardadorPrimario);
            List<IGuardable> guardadores = new List<IGuardable>(tipoGuardadores.Count);
            tipoGuardadores.ForEach(tipoGuardador =>
            {
                var guardador = fabrica.dameComponente(tipoGuardador);
                if(guardador != null)
                    guardadores.Add(guardador);
            });
            return new OrdenadorVariosGuardadores(procesador, memorizador, guardadorPrimario, guardadores);

        }
    }
}

