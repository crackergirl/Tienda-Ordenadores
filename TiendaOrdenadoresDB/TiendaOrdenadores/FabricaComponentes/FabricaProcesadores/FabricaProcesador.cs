using System;
using TiendaOrdenadores.Componentes.Procesadores;

namespace TiendaOrdenadores.FabricaComponentes.FabricaProcesadores
{
	public class FabricaProcesador : IFabricaProcesador
	{
        public IProcesable dameProcesador(TipoProcesador tipo)
        {
            switch (tipo)
            {
                case TipoProcesador._789_XCS: return new Procesador(10, 9, "Procesador intel i7", "789-XCS", 134);
                case TipoProcesador._789_XCD: return new Procesador(12, 10, "Procesador intel i7", "789-XCD", 138);
                case TipoProcesador._789_XCT: return new Procesador(22, 11, "Procesador intel i7", "789-XCT", 138);
                case TipoProcesador._797_X: return new Procesador(30, 10, "Procesador intel i7", "797-X", 78);
                case TipoProcesador._797_X2: return new Procesador(30, 29, "Procesador intel i7", "797-X2", 178);
                case TipoProcesador._797_X3: return new Procesador(60, 34, "Procesador intel i7", "797-X3", 278);
                default: return null;
            }
        }
    }
}

