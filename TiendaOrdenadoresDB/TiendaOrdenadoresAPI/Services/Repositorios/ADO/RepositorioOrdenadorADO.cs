using Microsoft.Data.SqlClient;
using TiendaOrdenadoresAPI.Data;
using TiendaOrdenadoresAPI.Models;
using TiendaOrdenadoresAPI.Services.ConsultasSQL;
using TiendaOrdenadoresAPI.Services.Mappers;

namespace TiendaOrdenadoresAPI.Services
{
	public class RepositorioOrdenadorADO : IRepositorio<Ordenador>
	{
        private readonly SqlConnection conexion;
        private readonly IConsultas<Ordenador> consultasSQL;
        private readonly IMapper<Ordenador> mapperOrdenador;
        private readonly IMapper<Componente> mapperComponente;
        private readonly IMapper<OrdenadorComponente> mapperOrdenadorComponente;

        public RepositorioOrdenadorADO(ADOContext context)
        {
            conexion = context.GetConnection();
            consultasSQL = new ConsultasOrdenador();
            mapperOrdenador = new MapperOrdenador();
            mapperComponente = new MapperComponente();
            mapperOrdenadorComponente = new MapperOrdenadorComponente();
        }

        public void Actualizar(Ordenador element)
        {
            string sql = consultasSQL.Actualizar(element);
            SqlCommand command = new SqlCommand(sql, conexion);
            conexion.Open();
            command.ExecuteNonQuery();
            conexion.Close();
        }

        public void Añadir(Ordenador item)
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

        public Ordenador? Obtener(int id)
        {
            Ordenador? ordenador = null; 
            string sql = consultasSQL.Obtener(id);
            SqlCommand command = new SqlCommand(sql, conexion);
            conexion.Open();
            SqlDataReader dataReader = command.ExecuteReader();
            while (dataReader.Read())
            {
                if (ordenador == null)
                {
                    ordenador = mapperOrdenador.Map(dataReader);
                }
                if (dataReader["Id"] != DBNull.Value)
                {
                    Componente componente = mapperComponente.Map(dataReader);
                    OrdenadorComponente ordenadorComponente = mapperOrdenadorComponente.Map(dataReader);
                    ordenadorComponente.Componente = componente;
                    ordenador.OrdenadorComponentes.Add(ordenadorComponente);
                }         
            }
            conexion.Close();

            return ordenador;
        }

        public List<Ordenador> ObtenerTodos()
        {
            List<Ordenador> ordenadores = new List<Ordenador>();
            string sql = consultasSQL.ObtenerTodos();
            SqlCommand command = new SqlCommand(sql, conexion);
            conexion.Open();
            SqlDataReader dataReader = command.ExecuteReader();
            int currentOrdenadorId = -1;
            Ordenador ordenador = new Ordenador();
            while (dataReader.Read())
            {
                int ordenadorId = Convert.ToInt32(dataReader["OrdenadorId"]);

                if (ordenadorId != currentOrdenadorId)
                {
                    currentOrdenadorId = ordenadorId;
                    ordenador = mapperOrdenador.Map(dataReader);
                    ordenadores.Add(ordenador);
                }
                if (dataReader["Id"] != DBNull.Value)
                {
                    Componente componente = mapperComponente.Map(dataReader);
                    OrdenadorComponente ordenadorComponente = mapperOrdenadorComponente.Map(dataReader);
                    ordenadorComponente.Componente = componente;
                    ordenador.OrdenadorComponentes.Add(ordenadorComponente);
                }
            }
            conexion.Close();
            return ordenadores;
        }

        public int ObtenerUltimoId()
        {
            string sql = consultasSQL.ObtenerUltimoId();
            SqlCommand command = new SqlCommand(sql, conexion);
            int ordenadorId = 0;
            conexion.Open();
            SqlDataReader dataReader = command.ExecuteReader();
            if (dataReader.Read())
            {
                ordenadorId = Convert.ToInt32(dataReader["Id"]);
            }
            conexion.Close();
            return ordenadorId;
        }
    }
}

