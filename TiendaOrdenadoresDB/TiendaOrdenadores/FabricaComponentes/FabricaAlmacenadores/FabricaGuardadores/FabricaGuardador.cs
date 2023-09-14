using System;
using TiendaOrdenadores.Componentes.Almacenadores.Guardadores;

namespace TiendaOrdenadores.FabricaComponentes.FabricaAlmacenadores.FabricaGuardadores
{
	public class FabricaGuardador : IFabricaGuardador
	{
        public IGuardable dameGuardador(TipoGuardador tipo)
        {
            switch (tipo)
            {
                case TipoGuardador._789_XX: return new Guardador(10, 500000, "DiscoDuro SanDisk", "789-XX", 50);
                case TipoGuardador._789_XX_2: return new Guardador(29, 1000000, "DiscoDuro SanDisk", "789-XX-2", 90);
                case TipoGuardador._789_XX_3: return new Guardador(39, 2000000, "DiscoDuro SanDisk", "789-XX-3", 128);
                case TipoGuardador._788_FG: return new Guardador(35, 250000, "DiscoMecanico Patatin", "788-FG", 37);
                case TipoGuardador._788_FG_2: return new Guardador(35, 250000, "DiscoMecanico Patatin", "788-FG-2", 67);
                case TipoGuardador._788_FG_3: return new Guardador(35, 250000, "DiscoMecanico Patatin", "788-FG-3", 97);
                case TipoGuardador._1789_XCS: return new Guardador(10, 9000000, "Disco Externo Sam", "1789-XCS", 134);
                case TipoGuardador._1789_XCD: return new Guardador(12, 10000000, "Disco Externo Sam", "1789-XCD", 138);
                case TipoGuardador._1789_XCT: return new Guardador(22, 11000000, "Disco Externo Sam", "1789-XCT", 140);
                default: return null;
            }
        }
    }
}

