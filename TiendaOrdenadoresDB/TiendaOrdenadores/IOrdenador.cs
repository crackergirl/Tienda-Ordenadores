using System;
using TiendaOrdenadores.Componentes.Almacenadores.Guardadores;
using TiendaOrdenadores.Componentes.Almacenadores.Memorizadores;
using TiendaOrdenadores.Componentes.Procesadores;

namespace TiendaOrdenadores
{
	public interface IOrdenador : ICalorable, ICostable
	{
        IProcesable Procesador { get; set; }
        IMemorizable Memorizador { get; set; }
        IGuardable Guardador { get; set; }

    }
}

