using System;
using System.Drawing;
using Microsoft.Data.SqlClient;
using TiendaOrdenadoresAPI.Models;

namespace TiendaOrdenadoresAPI.Services.Mappers
{
	public class MapperOrdenador : IMapper<Ordenador>
	{

        public Ordenador Map(SqlDataReader dataReader)
        {
            return new Ordenador()
            {
                Id = Convert.ToInt32(dataReader["OrdenadorId"]),
                NumeroDeSerie = Convert.ToString(dataReader["OrdenadorNumeroDeSerie"]) ?? "",
                Descripcion = Convert.ToString(dataReader["OrdenadorDescripcion"]) ?? "",
                OrdenadorComponentes = new List<OrdenadorComponente>() 
            };
        }
    }
}

