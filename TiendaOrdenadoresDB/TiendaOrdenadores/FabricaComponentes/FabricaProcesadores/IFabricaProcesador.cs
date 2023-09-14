using System;
using TiendaOrdenadores.Componentes.Procesadores;

namespace TiendaOrdenadores.FabricaComponentes.FabricaProcesadores
{
	public interface IFabricaProcesador
	{
        IProcesable dameProcesador(TipoProcesador tipo);
    }
}

