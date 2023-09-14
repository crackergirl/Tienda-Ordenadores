using Microsoft.Data.SqlClient;
using TiendaOrdenadoresAPI.Models;

namespace TiendaOrdenadoresAPI.Services.Mappers
{
	public class MapperComponente : IMapper<Componente>
	{
        public Componente Map(SqlDataReader dataReader)
        {
            return new Componente()
            {
                Id = Convert.ToInt32(dataReader["Id"]),
                NumeroDeSerie = Convert.ToString(dataReader["NumeroDeSerie"]) ?? "",
                Description = Convert.ToString(dataReader["Description"]) ?? "",
                Precio = Convert.ToInt32(dataReader["Precio"]),
                Calor = Convert.ToInt32(dataReader["Calor"]),
                Categoria = Convert.ToInt32(dataReader["Categoria"]),
                Almacenamiento = Convert.ToInt64(dataReader["Almacenamiento"]),
                UnidadMedida = Convert.ToString(dataReader["UnidadMedida"]) ?? ""
            };
        }
    }
}

