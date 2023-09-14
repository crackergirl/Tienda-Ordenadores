using System;
using TiendaOrdenadores.Componentes.Almacenadores.Guardadores;

namespace TiendaOrdenadores.FabricaComponentes.FabricaAlmacenadores.FabricaGuardadores
{
	public interface IFabricaGuardador
	{
        IGuardable dameGuardador(TipoGuardador tipo);
    }
}

