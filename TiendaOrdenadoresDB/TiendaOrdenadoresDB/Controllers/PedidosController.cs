using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using TiendaOrdenadoresDB.Models;
using TiendaOrdenadoresDB.Servicies;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TiendaOrdenadoresDB.Controllers
{
    public class PedidosController : Controller
    {
        private readonly IRepositorio<Pedido> _repositorioPedido;
        private readonly IRepositorio<Ordenador> _repositorioOrdenador;
        private readonly IRepositorio<OrdenadorPedido> _repositorioOrdenadorPedido;

        public PedidosController(IRepositorio<Pedido> repositorioPedido, IRepositorio<Ordenador> repositorioOrdenador, IRepositorio<OrdenadorPedido> repositorioOrdenadorPedido)
        {
            _repositorioPedido = repositorioPedido;
            _repositorioOrdenador = repositorioOrdenador;
            _repositorioOrdenadorPedido = repositorioOrdenadorPedido;
        }

        // GET: Ordenadores
        public IActionResult Index()
        {
            return View("Index", _repositorioPedido.ObtenerTodos());

        }

        // GET: Ordenadores/Details/5
        public IActionResult Details(int id)
        {
            var pedido = _repositorioPedido.Obtener(id);

            if (pedido == null)
            {
                return NotFound();
            }
            var ordenadores = pedido.OrdenadorPedido.Select(c => new
            {
                c.Ordenador.Id,
                Descripcion = c.Ordenador.NumeroDeSerie + " - " + c.Ordenador.Descripcion
            }).ToList();

            ViewBag.Ordenadores = ordenadores;

            return View("Details", pedido);
        }

        // GET: Ordenadores/Create
        public IActionResult Create()
        {
            var ordenadores = _repositorioOrdenador.ObtenerTodos().Select(c => new
            {
                c.Id,
                Descripcion = c.NumeroDeSerie + " - " + c.Descripcion
            }).ToList();
            ViewData["Id"] = new SelectList(ordenadores, "Id", "Descripcion");
            return View();
        }

        // POST: Ordenadores/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(int Id)
        {
            try
            {
                var ordenador = _repositorioOrdenador.Obtener(Id);
                var pedido = new Pedido() { Precio = ordenador.Precio, Calor = ordenador.Calor };
                _repositorioPedido.Añadir(pedido);
                _repositorioOrdenadorPedido.Añadir(new OrdenadorPedido { OrdenadorId = Id, PedidoId = pedido.Id });
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return RedirectToAction("Create");
            }
                
          
        }

        // GET: Ordenadores/Edit/5
        public IActionResult Edit(int id)
        {
            var pedido = _repositorioPedido.Obtener(id);

            if (pedido == null)
            {
                return NotFound();
            }

            return View("Edit", pedido);
        }

        // GET: Ordenadores/Delete/5
        public IActionResult Delete(int id)
        {
            var pedido = _repositorioPedido.Obtener(id);
            if (pedido == null)
            {
                return NotFound();
            }
            return View(pedido);
        }

        // POST: Ordenadores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _repositorioPedido.Borrar(id);
            return RedirectToAction(nameof(Index));
        }
    }
}

