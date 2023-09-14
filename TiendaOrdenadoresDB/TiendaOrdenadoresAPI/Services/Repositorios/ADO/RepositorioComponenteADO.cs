using Microsoft.Data.SqlClient;
using TiendaOrdenadoresAPI.Data;
using TiendaOrdenadoresAPI.Models;
using TiendaOrdenadoresAPI.Services.ConsultasSQL;
using TiendaOrdenadoresAPI.Services.Mappers;

namespace TiendaOrdenadoresAPI.Services
{
	public class RepositorioComponenteADO : IRepositorio<Componente>
	{
        readonly SqlConnection conexion;
        readonly IConsultas<Componente> consultasSQL;
        readonly IMapper<Componente> mapper;

        public RepositorioComponenteADO(ADOContext context)
        {
            conexion = context.GetConnection();
            consultasSQL = new ConsultasComponente();
            mapper = new MapperComponente();
        }

        public void Actualizar(Componente element)
        {
            string sql = consultasSQL.Actualizar(element);
            SqlCommand command = new SqlCommand(sql, conexion);
            conexion.Open();
            command.ExecuteNonQuery();
            conexion.Close();
        }

        public void Añadir(Componente item)
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

        public Componente? Obtener(int id)
        {
            Componente? componente;
            string sql = consultasSQL.Obtener(id);
            SqlCommand command = new SqlCommand(sql, conexion);
            conexion.Open();
            SqlDataReader dataReader = command.ExecuteReader();
            if (dataReader.Read())
            {
                componente = mapper.Map(dataReader);
            }
            else
            {
                componente = null;
            }
            
            conexion.Close();
            return componente;
        }

        public List<Componente> ObtenerTodos()
        {
            var componentes = new List<Componente>();
            string sql = consultasSQL.ObtenerTodos();
            SqlCommand command = new SqlCommand(sql, conexion);
            conexion.Open();
            SqlDataReader dataReader = command.ExecuteReader();
            while (dataReader.Read())
            {  
                componentes.Add(mapper.Map(dataReader));
            }
            conexion.Close();
            return componentes;
        }

        public int ObtenerUltimoId()
        {
            string sql = consultasSQL.ObtenerUltimoId();
            SqlCommand command = new SqlCommand(sql, conexion);
            int componenteId = 0;
            conexion.Open();
            SqlDataReader dataReader = command.ExecuteReader();
            
            if (dataReader.Read())
            {
                componenteId = Convert.ToInt32(dataReader["Id"]);
            }
            conexion.Close();
            return componenteId;
        }
    }
}

