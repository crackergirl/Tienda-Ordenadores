using System;
using TiendaOrdenadoresAPI.Models;

namespace TiendaOrdenadoresAPI.Services.ConsultasSQL
{
	public class ConsultasOrdenadorComponente : IConsultas<OrdenadorComponente>
	{
        public string Actualizar(OrdenadorComponente element)
        {
            return "UPDATE OrdenadorComponente " +
                         "SET " +
                             $"OrdenadorId = '{element.OrdenadorId}', " +
                             $"ComponenteId = '{element.ComponenteId}' " +
                         $"WHERE Id = {element.Id}";
        }

        public string Añadir(OrdenadorComponente item)
        {
            return $"INSERT INTO OrdenadorComponente (OrdenadorId, ComponenteId) VALUES ('{item.OrdenadorId}', '{item.ComponenteId}'); ";
        }

        public string Borrar(int id)
        {
            return $"DELETE FROM OrdenadorComponente WHERE Id = {id}";
        }

        public string Obtener(int id)
        {
           return "SELECT o.Id AS OrdenadorId, o.NumeroDeSerie AS OrdenadorNumeroDeSerie, o.Descripcion as OrdenadorDescripcion , " +
              "c.*, oc.Id AS OrdenadorComponenteId " +
             "FROM Ordenador o " +
             "INNER JOIN OrdenadorComponente oc ON o.Id = oc.OrdenadorId " +
             "INNER JOIN Componente c ON oc.ComponenteId = c.Id " +
             "WHERE oc.Id = " + id;
        }

        public string ObtenerTodos()
        {
            return "SELECT o.Id AS OrdenadorId, o.NumeroDeSerie AS OrdenadorNumeroDeSerie, o.Descripcion as OrdenadorDescripcion , " +
              "c.*, oc.Id AS OrdenadorComponenteId " +
             "FROM Ordenador o " +
             "INNER JOIN OrdenadorComponente oc ON o.Id = oc.OrdenadorId " +
             "INNER JOIN Componente c ON oc.ComponenteId = c.Id ";
        }

        public string ObtenerUltimoId()
        {
            return "SELECT MAX(Id) AS Id FROM OrdenadorComponente";
        }
    }
}

