using Microsoft.EntityFrameworkCore;
using TiendaOrdenadoresDB.Data;
using TiendaOrdenadoresDB.Models;

namespace TiendaOrdenadoresDB.Servicies
{
	public class RepositorioComponenteDB : IRepositorio<Componente>
{
        private readonly TiendaOrdenadoresDBContext _context;
        public RepositorioComponenteDB(TiendaOrdenadoresDBContext context)
        {
            _context = context;
        }

        public void Añadir(Componente componente)
        {
            
            _context.Componente.Add(componente);
            _context.SaveChanges();
            
        }
        public List<Componente> ObtenerTodos()
        {
            return _context.Componente
            .AsNoTracking()
            .ToList();
        }

        public void Borrar(int id)
        {
            var componente = Obtener(id);
            if (componente is not null)
            {
                _context.Componente.Remove(componente);
                _context.SaveChanges();
            }
        }

        public void Actualizar(Componente componente)
        {
          
            _context.Update(componente);
            _context.SaveChanges();
            
        }

        public Componente? Obtener(int id)
        {
            return _context.Componente.Find(id);
        }

    }
}

