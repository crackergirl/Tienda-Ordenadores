using System;
namespace TiendaOrdenadores.AlmacenComponentes
{
	public interface IAlmacen
	{
		int dameCantidadComponente(String numeroDeSerie);
		bool utilizarComponente(String numeroDeSerie, int cantidad);
		void aumentarCantidadComponente(String numeroDeSerie, int cantidad);
	}
}

