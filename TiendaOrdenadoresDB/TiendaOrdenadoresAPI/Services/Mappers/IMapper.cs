using Microsoft.Data.SqlClient;

namespace TiendaOrdenadoresAPI.Services.Mappers
{
	public interface IMapper<T>
	{
        T Map(SqlDataReader json);
    }
}

