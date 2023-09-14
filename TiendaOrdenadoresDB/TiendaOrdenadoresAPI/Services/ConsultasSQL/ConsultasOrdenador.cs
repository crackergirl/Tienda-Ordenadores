using System;
using TiendaOrdenadoresAPI.Models;

namespace TiendaOrdenadoresAPI.Services.ConsultasSQL
{
	public class ConsultasOrdenador : IConsultas<Ordenador>
	{
        public string Actualizar(Ordenador element)
        {
            return "UPDATE Ordenador " +
                         "SET " +
                             $"NumeroDeSerie = '{element.NumeroDeSerie}', " +
                             $"Descripcion = '{element.Descripcion}' " +
                         $"WHERE Id = {element.Id}";
        }

        public string Añadir(Ordenador item)
        {
            return $"INSERT INTO Ordenador (Descripcion, NumeroDeSerie) VALUES ('{item.Descripcion}', '{item.NumeroDeSerie}'); ";
        }

        public string Borrar(int id)
        {
            return $"DELETE FROM Ordenador WHERE Id = {id}";
        }

        public string Obtener(int id)
        {
            return "SELECT o.Id AS OrdenadorId, o.NumeroDeSerie AS OrdenadorNumeroDeSerie, o.Descripcion as OrdenadorDescripcion , " +
              "c.*, oc.Id AS OrdenadorComponenteId " +
             "FROM Ordenador o " +
             "LEFT JOIN OrdenadorComponente oc ON o.Id = oc.OrdenadorId " +
             "LEFT JOIN Componente c ON oc.ComponenteId = c.Id " +
             "WHERE o.Id = " + id;
        }

        public string ObtenerTodos()
        {
           return "SELECT o.Id AS OrdenadorId, o.NumeroDeSerie AS OrdenadorNumeroDeSerie, o.Descripcion AS OrdenadorDescripcion, " +
                         "c.*, oc.Id AS OrdenadorComponenteId " +
                         "FROM Ordenador o " +
                         "LEFT JOIN OrdenadorComponente oc ON o.Id = oc.OrdenadorId " +
                         "LEFT JOIN Componente c ON oc.ComponenteId = c.Id";
        }

        public string ObtenerUltimoId()
        {
            return "SELECT MAX(Id) AS Id FROM Ordenador";
        }
    }
}

