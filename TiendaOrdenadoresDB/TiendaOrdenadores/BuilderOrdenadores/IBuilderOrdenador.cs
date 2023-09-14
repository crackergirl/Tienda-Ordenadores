using TiendaOrdenadores.FabricaComponentes.FabricaAlmacenadores.FabricaGuardadores;
using TiendaOrdenadores.FabricaComponentes.FabricaAlmacenadores.FabricaMemorizadores;
using TiendaOrdenadores.FabricaComponentes.FabricaProcesadores;
namespace TiendaOrdenadores.BuilderOrdenadores
{
	public interface IBuilderOrdenador
	{
		IOrdenador dameOrdenador(TipoProcesador tipoProcesador, TipoGuardador tipoGuardador, TipoMemorizador tipoMemorizador);
        IOrdenador dameOrdenador(TipoProcesador tipoProcesador, TipoGuardador tipoGuardadorPrimario, List<TipoGuardador> tipoGuardadores, TipoMemorizador tipoMemorizador);
    }
}

