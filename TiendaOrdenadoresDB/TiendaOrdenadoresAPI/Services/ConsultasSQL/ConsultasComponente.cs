using System;
using TiendaOrdenadoresAPI.Models;

namespace TiendaOrdenadoresAPI.Services.ConsultasSQL
{
	public class ConsultasComponente : IConsultas<Componente>
	{
        public string Actualizar(Componente element)
        {
            return  "UPDATE Componente " +
                         "SET " +
                             $"NumeroDeSerie = '{element.NumeroDeSerie}', " +
                             $"Description = '{element.Description}', " +
                             $"Precio = {element.Precio}, " +
                             $"Calor = {element.Calor}, " +
                             $"Categoria = '{element.Categoria}', " +
                             $"Almacenamiento = '{element.Almacenamiento}', " +
                             $"UnidadMedida = '{element.UnidadMedida}' " +
                         $"WHERE Id = {element.Id}";
        }

        public string Añadir(Componente item)
        {
           return "INSERT INTO Componente " +
                        "(NumeroDeSerie, Description, Precio, Calor, Categoria, Almacenamiento, UnidadMedida) " +
                        "VALUES " +
                        $"('{item.NumeroDeSerie}', '{item.Description}', {item.Precio}, {item.Calor}, '{item.Categoria}', '{item.Almacenamiento}', '{item.UnidadMedida}')";
        }

        public string Borrar(int id)
        {
           return $"DELETE FROM Componente WHERE Id = {id}";
        }

        public string Obtener(int id)
        {
            return "Select * From Componente WHERE Id = " + id;
        }

        public string ObtenerTodos()
        {
            return "Select * From Componente";
        }

        public string ObtenerUltimoId()
        {
            return "SELECT MAX(Id) AS Id FROM Componente";
        }
    }
}

