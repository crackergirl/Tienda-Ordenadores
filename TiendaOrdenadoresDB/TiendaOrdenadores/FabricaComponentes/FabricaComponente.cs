using System;
using TiendaOrdenadores.Componentes.Almacenadores.Guardadores;
using TiendaOrdenadores.Componentes.Almacenadores.Memorizadores;
using TiendaOrdenadores.Componentes.Procesadores;
using TiendaOrdenadores.FabricaComponentes.FabricaAlmacenadores.FabricaGuardadores;
using TiendaOrdenadores.FabricaComponentes.FabricaAlmacenadores.FabricaMemorizadores;
using TiendaOrdenadores.FabricaComponentes.FabricaProcesadores;

namespace TiendaOrdenadores.FabricaComponentes
{
	public class FabricaComponente : IFabricaComponente
	{

        public IProcesable dameComponente(TipoProcesador tipo)
        {
            return new FabricaProcesador().dameProcesador(tipo);
        }

        public IGuardable dameComponente(TipoGuardador tipo)
        {
            return new FabricaGuardador().dameGuardador(tipo);
        }

        public IMemorizable dameComponente(TipoMemorizador tipo)
        {
            return new FabricaMemorizador().dameMemorizador(tipo);
        }
    }
}

