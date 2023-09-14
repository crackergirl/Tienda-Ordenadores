using System;
using TiendaOrdenadores.Componentes.Almacenadores.Guardadores;
using TiendaOrdenadores.Componentes.Almacenadores.Memorizadores;
using TiendaOrdenadores.Componentes.Procesadores;
using TiendaOrdenadores.FabricaComponentes.FabricaAlmacenadores.FabricaGuardadores;
using TiendaOrdenadores.FabricaComponentes.FabricaAlmacenadores.FabricaMemorizadores;
using TiendaOrdenadores.FabricaComponentes.FabricaProcesadores;

namespace TiendaOrdenadores.FabricaComponentes
{
	public interface IFabricaComponente
	{
		IProcesable dameComponente(TipoProcesador tipo);
        IGuardable dameComponente(TipoGuardador tipo);
        IMemorizable dameComponente(TipoMemorizador tipo);
    }
}

