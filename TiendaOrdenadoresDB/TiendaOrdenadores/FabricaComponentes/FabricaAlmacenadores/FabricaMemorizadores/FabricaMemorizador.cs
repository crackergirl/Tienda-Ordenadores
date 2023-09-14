using System;
using TiendaOrdenadores.Componentes.Almacenadores.Guardadores;
using TiendaOrdenadores.Componentes.Almacenadores.Memorizadores;

namespace TiendaOrdenadores.FabricaComponentes.FabricaAlmacenadores.FabricaMemorizadores
{
	public class FabricaMemorizador : IFabricaMemorizador
	{
        public IMemorizable dameMemorizador(TipoMemorizador tipo)
        {
            switch (tipo)
            {
                case TipoMemorizador._879_FH: return new Memorizador(10, 4096, "Banco de Memoria SDRAM", "879-FH", 100);
                case TipoMemorizador._879_FH_L: return new Memorizador(15, 1000, "Banco de Memoria SDRAM", "879-FH-L", 125);
                case TipoMemorizador._879_FH_T: return new Memorizador(24, 2000, "Banco de Memoria SDRAM", "879-FH-T", 150);
                default: return null;
            }
        }
    }
}

