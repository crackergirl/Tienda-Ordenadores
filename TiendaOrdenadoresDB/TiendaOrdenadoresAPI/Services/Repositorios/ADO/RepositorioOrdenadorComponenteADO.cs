using Microsoft.Data.SqlClient;
using TiendaOrdenadoresAPI.Data;
using TiendaOrdenadoresAPI.Models;
using TiendaOrdenadoresAPI.Services.ConsultasSQL;
using TiendaOrdenadoresAPI.Services.Mappers;

namespace TiendaOrdenadoresAPI.Services
{
	public class RespositorioOrdenadorComponenteADO : IRepositorio<OrdenadorComponente>
    {
        private readonly SqlConnection conexion;
        private readonly IConsultas<OrdenadorComponente> consultasSQL;
        private readonly IMapper<Ordenador> mapperOrdenador;
        private readonly IMapper<Componente> mapperComponente;
        private readonly IMapper<OrdenadorComponente> mapperOrdenadorComponente;

        public RespositorioOrdenadorComponenteADO(ADOContext context)
		{
            conexion = context.GetConnection();
            consultasSQL = new ConsultasOrdenadorComponente();
            mapperOrdenador = new MapperOrdenador();
            mapperComponente = new MapperComponente();
            mapperOrdenadorComponente = new MapperOrdenadorComponente();
        }

        public void Actualizar(OrdenadorComponente element)
        {
            string sql = consultasSQL.Actualizar(element);
            SqlCommand command = new SqlCommand(sql, conexion);
            conexion.Open();
            command.ExecuteNonQuery();
            conexion.Close();
        }

        public void Añadir(OrdenadorComponente item)
        {
            string sql = consultasSQL.Añadir(item);
            SqlCommand command = new SqlCommand(sql, conexion);
            conexion.Open();
            command.ExecuteNonQuery();
            conexion.Close();
        }

        public void Borrar(int id)
        {
            string sql = consultasSQL.Borrar(id);
            SqlCommand command = new SqlCommand(sql, conexion);
            conexion.Open();
            command.ExecuteNonQuery();
            conexion.Close();
        }

        public OrdenadorComponente? Obtener(int id)
        {
            OrdenadorComponente? ordenadorComponente;
            string sql = consultasSQL.Obtener(id);
            SqlCommand command = new SqlCommand(sql, conexion);
            conexion.Open();
            SqlDataReader dataReader = command.ExecuteReader();
            if (dataReader.Read())
            {
                ordenadorComponente = mapperOrdenadorComponente.Map(dataReader);
                Componente componente = mapperComponente.Map(dataReader);
                Ordenador ordenador = mapperOrdenador.Map(dataReader);
                ordenadorComponente.Componente = componente;
                ordenadorComponente.Ordenador = ordenador;
            }
            else
            {
                ordenadorComponente = null;
            }
            conexion.Close();

            return ordenadorComponente;
        }

        public List<OrdenadorComponente> ObtenerTodos()
        {
            List<OrdenadorComponente> ordenadorComponentes = new();
            OrdenadorComponente ordenadorComponente = new();
            string sql = consultasSQL.ObtenerTodos();
            SqlCommand command = new SqlCommand(sql, conexion);
            conexion.Open();
            SqlDataReader dataReader = command.ExecuteReader();
            int currentOrdenadorComponenteId = -1;
            while (dataReader.Read())
            {
                int ordenadorComponenteId = Convert.ToInt32(dataReader["OrdenadorComponenteId"]);

                if (ordenadorComponenteId != currentOrdenadorComponenteId)
                {
                    currentOrdenadorComponenteId = ordenadorComponenteId;
                    ordenadorComponente = mapperOrdenadorComponente.Map(dataReader);
                    ordenadorComponentes.Add(ordenadorComponente);
                }
                Componente componente = mapperComponente.Map(dataReader);
                Ordenador ordenador = mapperOrdenador.Map(dataReader);
                ordenadorComponente.Componente = componente;
                ordenadorComponente.Ordenador = ordenador;
            }
            conexion.Close();
            return ordenadorComponentes;
        }

        public int ObtenerUltimoId()
        {
            string sql = consultasSQL.ObtenerUltimoId();
            SqlCommand command = new SqlCommand(sql, conexion);
            int ordenadorComponenteId = 0;
            conexion.Open();
            SqlDataReader dataReader = command.ExecuteReader();
            if (dataReader.Read())
            {
                ordenadorComponenteId = Convert.ToInt32(dataReader["Id"]);
            }
            conexion.Close();
            return ordenadorComponenteId;
        }
    }
}

