using Microsoft.EntityFrameworkCore;
using TiendaOrdenadoresDB.Data;
using TiendaOrdenadoresDB.Models;
using TiendaOrdenadoresDB.Servicies;

namespace TiendaOrdenadoresDB.Services
{
	public class RepositorioOrdenadorPedidoDB : IRepositorio<OrdenadorPedido>
    {
        readonly TiendaOrdenadoresDBContext _context;

        public RepositorioOrdenadorPedidoDB(TiendaOrdenadoresDBContext context)
		{
            _context = context;
        }

        public void Actualizar(OrdenadorPedido element)
        {
            _context.Update(element);
            _context.SaveChanges();
        }

        public void Añadir(OrdenadorPedido item)
        {
            _context.Add(item);
            _context.SaveChanges();
        }

        public void Borrar(int id)
        {
            var ordenadoresPedido = _context.OrdenadorPedido.Find(id);
            if (ordenadoresPedido != null)
            {
                _context.OrdenadorPedido.Remove(ordenadoresPedido);
            }

            _context.SaveChanges();
        }

        public OrdenadorPedido? Obtener(int id)
        {
            return ObtenerTodos().First(c => c.Id == id);
        }

        public List<OrdenadorPedido> ObtenerTodos()
        {
            return _context.OrdenadorPedido
                .Include(o => o.Ordenador)
                .Include(p => p.Pedido)
                .AsNoTracking()
                .ToList();
        }
    }
}

