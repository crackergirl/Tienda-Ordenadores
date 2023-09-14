using TiendaOrdenadores.BuilderOrdenadores;
using TiendaOrdenadores.FabricaComponentes.FabricaAlmacenadores.FabricaGuardadores;
using TiendaOrdenadores.FabricaComponentes.FabricaAlmacenadores.FabricaMemorizadores;
using TiendaOrdenadores.FabricaComponentes.FabricaProcesadores;
namespace TiendaOrdenadores.Test.UnitTestPruebasNivelesMasCompletas.FabricaOrdenadores
{
    public class FabricaOrdenadorConBuilder : IFabricaOrdenadorconBuilder
    {
        public IOrdenador dameOrdenador(TipoOrdenador tipo)
        {
            IBuilderOrdenador builder = new BuilderOrdenador();
            switch (tipo)
            {
                case TipoOrdenador.OrdenadorMaria:
                    return builder.dameOrdenador(TipoProcesador._789_XCS, TipoGuardador._789_XX, TipoMemorizador._879_FH);
                case TipoOrdenador.OrdenadorAndres:
                    return builder.dameOrdenador(TipoProcesador._797_X3, TipoGuardador._789_XX_3, TipoMemorizador._879_FH_T);
                case TipoOrdenador.OrdenadorTiburcioII:
                    return builder.dameOrdenador(TipoProcesador._789_XCS, TipoGuardador._789_XX, new List<TipoGuardador>{TipoGuardador._1789_XCS,TipoGuardador._788_FG }, TipoMemorizador._879_FH);
                case TipoOrdenador.OrdenadorAndresCF:
                    return builder.dameOrdenador(TipoProcesador._797_X3, TipoGuardador._788_FG, new List<TipoGuardador> { TipoGuardador._789_XX_3}, TipoMemorizador._879_FH_T);
                default: return null;
            }
        }
    }
}

