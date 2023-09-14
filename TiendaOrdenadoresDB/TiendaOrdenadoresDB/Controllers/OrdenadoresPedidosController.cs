using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TiendaOrdenadoresDB.Models;
using TiendaOrdenadoresDB.Servicies;

namespace TiendaOrdenadoresDB.Controllers
{
    public class OrdenadoresPedidosController : Controller
    {
        private readonly IRepositorio<OrdenadorPedido> _repositorio;
        private readonly IRepositorio<Ordenador> _repositorioOrdenador;
        private readonly IRepositorio<Pedido> _repositorioPedido;

        public OrdenadoresPedidosController(IRepositorio<OrdenadorPedido> repositorio, IRepositorio<Ordenador> repositorioOrdenador, IRepositorio<Pedido> repositorioPedido)
        {
            _repositorio = repositorio;
            _repositorioOrdenador = repositorioOrdenador;
            _repositorioPedido = repositorioPedido;
        }

        // GET: OrdenadoresPedido
        public IActionResult Index()
        {
            return View("Index", _repositorio.ObtenerTodos());
        }

        // GET: OrdenadoresPedido/Details/5
        public IActionResult Details(int id)
        {
            var ordenadoresPedido = _repositorio.Obtener(id);
            if (ordenadoresPedido == null)
            {
                return NotFound();
            }

            return View(ordenadoresPedido);
        }

        // GET: OrdenadoresPedido/Create
        public IActionResult Create(int id)
        {
            var ordenadorPedido = new OrdenadorPedido { PedidoId = id };
            var ordenadores = _repositorioOrdenador.ObtenerTodos().Select(c => new
            {
                c.Id,
                Descripcion = c.NumeroDeSerie + " - " + c.Descripcion
            }).ToList();
            ViewData["OrdenadorId"] = new SelectList(ordenadores, "Id", "Descripcion");

            return View(ordenadorPedido);
        }

        // POST: OrdenadoresPedido/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("PedidoId,OrdenadorId")] OrdenadorPedido ordenadoresPedido)
        {
            try
            {
                _repositorio.Añadir(ordenadoresPedido);
                var ordenador = _repositorioOrdenador.Obtener(ordenadoresPedido.OrdenadorId);
                var pedidoAnterior = _repositorioPedido.Obtener(ordenadoresPedido.PedidoId);
                var pedido = new Pedido() { Id = ordenadoresPedido.PedidoId, Precio = pedidoAnterior.Precio + ordenador.Precio, Calor = pedidoAnterior.Calor + ordenador.Calor };
                _repositorioPedido.Actualizar(pedido);
                return RedirectToAction("Edit", "Pedidos", new { id = ordenadoresPedido.PedidoId });

            }
            catch
            {
                return View(ordenadoresPedido);
            }
        }

        // GET: OrdenadoresPedido/Edit/5
        public IActionResult Edit(int id)
        {
            var ordenadoresPedido = _repositorio.Obtener(id);
            if (ordenadoresPedido == null)
            {
                return NotFound();
            }
            var ordenadores = _repositorioOrdenador.ObtenerTodos().Select(c => new
            {
                c.Id,
                Descripcion = c.NumeroDeSerie + " - " + c.Descripcion
            }).ToList();
            ViewData["OrdenadorId"] = new SelectList(ordenadores, "Id", "Descripcion");
            return View("Edit", ordenadoresPedido);
        }

        // POST: OrdenadoresPedido/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,PedidoId,OrdenadorId")] OrdenadorPedido ordenadoresPedido)
        {

            try
            {
                var ordenadoresPedidoAnterior = _repositorio.Obtener(id);
                var ordenadorAnterior = _repositorioOrdenador.Obtener(ordenadoresPedidoAnterior.OrdenadorId);
                var pedidoAnterior = _repositorioPedido.Obtener(ordenadoresPedidoAnterior.PedidoId);
                var ordenador = _repositorioOrdenador.Obtener(ordenadoresPedido.OrdenadorId);
                var pedido = new Pedido()
                {
                    Id = ordenadoresPedido.PedidoId,
                    Precio = pedidoAnterior.Precio - ordenadorAnterior.Precio + ordenador.Precio,
                    Calor = pedidoAnterior.Calor - ordenadorAnterior.Calor + ordenador.Calor
                };
                _repositorioPedido.Actualizar(pedido);
                _repositorio.Actualizar(ordenadoresPedido);
                return RedirectToAction("Edit", "Pedidos", new { id = ordenadoresPedido.PedidoId });

            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrdenadoresPedidoExists(ordenadoresPedido.Id))
                {
                    return NotFound();
                }
                else
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            
            
           
        }

        // GET: OrdenadoresPedido/Delete/5
        public IActionResult Delete(int id)
        {
            var ordenadoresPedido = _repositorio.Obtener(id);
            if (ordenadoresPedido == null)
            {
                return NotFound();
            }

            return View(ordenadoresPedido);
        }

        // POST: OrdenadoresPedido/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var pedidoId = id;
            var ordenadoresPedido = _repositorio.Obtener(id);

            if (ordenadoresPedido != null)
            {
                var ordenador = _repositorioOrdenador.Obtener(ordenadoresPedido.OrdenadorId);
                var pedidoAnterior = _repositorioPedido.Obtener(ordenadoresPedido.PedidoId);
                var pedido = new Pedido() { Id = ordenadoresPedido.PedidoId, Precio = pedidoAnterior.Precio - ordenador.Precio, Calor = pedidoAnterior.Calor - ordenador.Calor };
                _repositorioPedido.Actualizar(pedido);
                pedidoId = ordenadoresPedido.PedidoId;
                _repositorio.Borrar(id);

            }
            return RedirectToAction("Edit", "Pedidos", new { id = pedidoId });

        }

        private bool OrdenadoresPedidoExists(int id)
        {
            return _repositorio.Obtener(id) != null;
        }
    }
}