using Microsoft.EntityFrameworkCore;
using TiendaOrdenadoresDB.Data;
using TiendaOrdenadoresDB.Models;

namespace TiendaOrdenadoresDB.Servicies
{
    public class RepositorioOrdenadorDB : IRepositorio<Ordenador>
    {
        private readonly TiendaOrdenadoresDBContext _context;

        public RepositorioOrdenadorDB(TiendaOrdenadoresDBContext context)
        {
            _context = context;
        }

        public void Actualizar(Ordenador element)
        {
            _context.Update(element);
            _context.SaveChanges();
        }

        public void Añadir(Ordenador item)
        {
            _context.Add(item);
            _context.SaveChanges();
        }

        public void Borrar(int id)
        {
            var item = _context.Ordenador.AsNoTracking().First(x => x.Id == id);
            if (item == null)
            {
                return;
            }

            item.OrdenadorComponentes.ToList().ForEach(x =>
            {
                var componentesOrdenador = _context.OrdenadorComponente.Find(x.Id);
                if (componentesOrdenador != null)
                {
                    _context.OrdenadorComponente.Remove(componentesOrdenador);
                }
                _context.SaveChanges();
            });

            item.OrdenadorComponentes.Clear();

            // Sirve para limpiar los elementos trackeados por el contexto y asi poder eliminar elementos de este
            //_context.ChangeTracker.Clear();

            _context.Ordenador.Remove(item);
            _context.SaveChanges();

        }

        public Ordenador? Obtener(int id)
        {
          
            return ObtenerTodos().First(c => c.Id == id);
        }

        public List<Ordenador> ObtenerTodos()
        {
         
            return _context.Ordenador
                            .Include(c => c.OrdenadorComponentes)
                            .ThenInclude(c => c.Componente)
                            .AsNoTracking()
                            .ToList();
        }
    }
}
