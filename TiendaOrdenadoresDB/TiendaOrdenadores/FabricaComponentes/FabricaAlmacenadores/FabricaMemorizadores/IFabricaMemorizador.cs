using System;
using TiendaOrdenadores.Componentes.Almacenadores.Memorizadores;

namespace TiendaOrdenadores.FabricaComponentes.FabricaAlmacenadores.FabricaMemorizadores
{
	public interface IFabricaMemorizador
	{
        IMemorizable dameMemorizador(TipoMemorizador tipo);
    }
}

