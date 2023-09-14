using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using TiendaOrdenadoresDB.Models;
using TiendaOrdenadoresDB.Servicies;

namespace TiendaOrdenadoresDB.Controllers
{
    public class OrdenadoresComponentesController : Controller
    {

        private readonly IRepositorio<OrdenadorComponente> _repositorioOrdenadorComponente;
        private readonly IRepositorio<Componente> _repositorioComponente;

        public OrdenadoresComponentesController(IRepositorio<OrdenadorComponente> repositorioOrdenadorComponente, IRepositorio<Componente> repositorioComponente)
        {
            _repositorioOrdenadorComponente = repositorioOrdenadorComponente;
            _repositorioComponente = repositorioComponente;
        }

        // GET: OrdenadoresPedido/Details/5
        public IActionResult Details(int id)
        {
            var ordenadoresPedido = _repositorioOrdenadorComponente.Obtener(id);
            if (ordenadoresPedido == null)
            {
                return NotFound();
            }

            return View("Details", ordenadoresPedido);
        }

        // GET: OrdenadoresComponentes/Create
        public IActionResult Create(int id)
        {
            var componentes = _repositorioComponente.ObtenerTodos().Select(c => new
            {
                c.Id,
                c.Categoria,
                Descripcion = c.NumeroDeSerie + " - " + c.Description
            }).ToList();

            var componentesOrdenador = new OrdenadorComponente()
            {
                OrdenadorId = id 
            };
            if (componentesOrdenador == null)
            {
                return NotFound();
            }
            var discosDuros = componentes.FindAll(componente => componente.Categoria == (int)TipoComponente.Guardador);
            ViewData["ComponenteId"] = new SelectList(discosDuros, "Id", "Descripcion");
            return View("Create", componentesOrdenador);
        }

        // POST: OrdenadoresComponentes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("ComponenteId,OrdenadorId")] OrdenadorComponente ordenadorComponente)
        {
            //if (ModelState.IsValid)
            try
            {
                _repositorioOrdenadorComponente.Añadir(ordenadorComponente);
                return RedirectToAction("Edit", "Ordenadores", new { id = ordenadorComponente.OrdenadorId });

            }
            catch
            {
                return RedirectToAction("Create", new { id = ordenadorComponente.OrdenadorId });
            }
            
        }

        // GET: OrdenadoresComponentes/Edit/5
        public IActionResult Edit(int id)
        {
            var ordenadorComponente = _repositorioOrdenadorComponente.Obtener(id);

            if (ordenadorComponente == null)
            {
                return NotFound();
            }

            var componentes = _repositorioComponente.ObtenerTodos().Select(c => new
            {
                c.Id,
                c.Categoria,
                Descripcion = c.NumeroDeSerie + " - " + c.Description
            }).ToList();

            var discosDuros = componentes.FindAll(componente => componente.Categoria == ordenadorComponente.Componente.Categoria);
            ViewData["ComponenteId"] = new SelectList(discosDuros, "Id", "Descripcion");

            return View("Edit", ordenadorComponente);
        }

        // POST: OrdenadoresComponentes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,ComponenteId,OrdenadorId")] OrdenadorComponente ordenadorComponente)
        {
            if (id != ordenadorComponente.Id)
            {
                return NotFound();
            }
            try
            {
                _repositorioOrdenadorComponente.Actualizar(ordenadorComponente);
                return RedirectToAction("Edit", "Ordenadores", new { id = ordenadorComponente.OrdenadorId });
            }
            catch
            {
                return RedirectToAction("Edit", new { ordenadorid= ordenadorComponente.OrdenadorId, componenteid = ordenadorComponente.ComponenteId });
            }
        }

        // GET: OrdenadoresComponentes/Delete/5
        public IActionResult Delete(int id)
        {
            var ordenadorComponente = _repositorioOrdenadorComponente.Obtener(id);
            if (ordenadorComponente == null)
            {
                return NotFound();
            }
            return View("Delete", ordenadorComponente);
        }

        // POST: OrdenadoresComponentes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var componentesOrdenador = _repositorioOrdenadorComponente.Obtener(id);
            _repositorioOrdenadorComponente.Borrar(id);
            return RedirectToAction("Edit", "Ordenadores", new { id = componentesOrdenador.OrdenadorId });
        }
    }
}
