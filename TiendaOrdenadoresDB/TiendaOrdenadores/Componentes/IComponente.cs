using System;
namespace TiendaOrdenadores.Componentes
{
	public interface IComponente : ICalorable, ICostable
	{
		String getNumeroDeSerie();
		String getDescripcion();
	}
}

