using Microsoft.EntityFrameworkCore;
using TiendaOrdenadoresDB.Data;
using TiendaOrdenadoresDB.Models;
using TiendaOrdenadoresDB.Servicies;

namespace TiendaOrdenadoresDB.Services
{
    public class RepositorioOrdenadorComponenteDB : IRepositorio<OrdenadorComponente>
    {
        private readonly TiendaOrdenadoresDBContext _context;
        public RepositorioOrdenadorComponenteDB(TiendaOrdenadoresDBContext context)
        {
            _context = context;
        }
        public void Actualizar(OrdenadorComponente element)
        {
            _context.Update(element);
            _context.SaveChanges();
        }

        public void Añadir(OrdenadorComponente item)
        {
            _context.Add(item);
            _context.SaveChanges();
        }

        public void Borrar(int id)
        {
            var componentesOrdenador = Obtener(id);
            if (componentesOrdenador != null)
            {
                _context.OrdenadorComponente.Remove(componentesOrdenador);
            }
            _context.SaveChanges();
        }

        public OrdenadorComponente? Obtener(int id)
        {
            return ObtenerTodos().First(c => c.Id == id);
        }
        public List<OrdenadorComponente> ObtenerTodos()
        {
            return _context.OrdenadorComponente
                .Include(c => c.Componente)
                .Include(c => c.Ordenador)
                .AsNoTracking()
                .ToList();
        }
    }
}
