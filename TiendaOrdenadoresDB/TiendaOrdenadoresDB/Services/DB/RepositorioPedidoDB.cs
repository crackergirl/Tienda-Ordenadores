using Microsoft.EntityFrameworkCore;
using TiendaOrdenadoresDB.Data;
using TiendaOrdenadoresDB.Models;
using TiendaOrdenadoresDB.Servicies;

namespace TiendaOrdenadoresDB.Services
{
	public class RepositorioPedidoDB : IRepositorio<Pedido>
    {
        readonly TiendaOrdenadoresDBContext _context;

        public RepositorioPedidoDB(TiendaOrdenadoresDBContext context)
        {
            _context = context;
        }

        public void Actualizar(Pedido pedido)
        {
            _context.Update(pedido);
            _context.SaveChanges();
        }

        public void Añadir(Pedido item)
        {
            _context.Add(item);
            _context.SaveChanges();
        }

        public void Borrar(int id)
        {
            var item = _context.Pedido.AsNoTracking().First(x => x.Id == id);
            if (item == null)
            {
                return;
            }

            item.OrdenadorPedido.ToList().ForEach(x =>
            {
                var ordenadorPedido = _context.OrdenadorPedido.Find(x.Id);
                if (ordenadorPedido != null)
                {
                    _context.OrdenadorPedido.Remove(ordenadorPedido);
                }
                _context.SaveChanges();
            });

            item.OrdenadorPedido.Clear();

            // Sirve para limpiar los elementos trackeados por el contexto y asi poder eliminar elementos de este
            //_context.ChangeTracker.Clear();

            _context.Pedido.Remove(item);
            _context.SaveChanges();
        }

        public Pedido? Obtener(int id)
        {

            return ObtenerTodos().First(c => c.Id == id);
        }

        public List<Pedido> ObtenerTodos()
        {
            return _context.Pedido
                    .Include(c => c.OrdenadorPedido)
                    .ThenInclude(c => c.Ordenador)
                    .ThenInclude(o => o.OrdenadorComponentes)
                    .ThenInclude(c => c.Componente)
                    .AsNoTracking()
                    .ToList();
        }
    }
}

