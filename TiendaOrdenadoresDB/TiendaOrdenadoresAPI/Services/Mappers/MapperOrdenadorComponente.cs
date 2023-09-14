using System;
using Microsoft.Data.SqlClient;
using TiendaOrdenadoresAPI.Models;

namespace TiendaOrdenadoresAPI.Services.Mappers
{
	public class MapperOrdenadorComponente : IMapper<OrdenadorComponente>
	{
        public OrdenadorComponente Map(SqlDataReader dataReader)
        {
            return new OrdenadorComponente()
            {
                Id = Convert.ToInt32(dataReader["OrdenadorComponenteId"]),
                OrdenadorId = Convert.ToInt32(dataReader["OrdenadorId"]),
                ComponenteId = Convert.ToInt32(dataReader["Id"])
            };
        }
    }
}

