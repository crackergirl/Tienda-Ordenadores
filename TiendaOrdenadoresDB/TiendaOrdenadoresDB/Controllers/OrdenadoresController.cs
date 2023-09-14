using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using TiendaOrdenadoresDB.Models;
using TiendaOrdenadoresDB.Servicies;
using TiendaOrdenadoresDB.ViewModels;

namespace TiendaOrdenadoresDB.Controllers
{
    public class OrdenadoresController : Controller
    {
        private readonly IRepositorio<Ordenador> _repositorioOrdenador;
        private readonly IRepositorio<Componente> _repositorioComponente;
        private readonly IRepositorio<OrdenadorComponente> _repositorioOrdenadorComponente;

        public OrdenadoresController(IRepositorio<Ordenador> repositorioOrdenador, IRepositorio<Componente> repositorioComponente, IRepositorio<OrdenadorComponente> repositorioOrdenadorComponente)
        {
            _repositorioOrdenador = repositorioOrdenador;
            _repositorioComponente = repositorioComponente;
            _repositorioOrdenadorComponente = repositorioOrdenadorComponente;
        }

        // GET: Ordenadores
        public IActionResult Index()
        {
            return View("Index",_repositorioOrdenador.ObtenerTodos());

        }

        // GET: Ordenadores/Details/5
        public IActionResult Details(int id)
        {
            var ordenador = _repositorioOrdenador.Obtener(id);

            if (ordenador == null)
            {
                return NotFound();
            }
            var componentes = ordenador.OrdenadorComponentes.Select(c => new
            {
                c.Componente.Categoria,
                Descripcion = c.Componente.NumeroDeSerie + " - " + c.Componente.Description
            }).ToList();

            ViewBag.Componentes = componentes;

            return View("Details", ordenador);
        }

        // GET: Ordenadores/Create
        public IActionResult Create()
        {
            var componentes = _repositorioComponente.ObtenerTodos().Select(c => new
            {
                c.Id,
                c.Categoria,
                Descripcion = c.NumeroDeSerie + " - " + c.Description
            }).ToList();
            var procesadores = componentes.FindAll(componente => componente.Categoria == (int)TipoComponente.Procesador);
            var memoriasRam = componentes.FindAll(componente => componente.Categoria == (int)TipoComponente.Memorizador);
            var discosDuros = componentes.FindAll(componente => componente.Categoria == (int)TipoComponente.Guardador);
            ViewData["ProcesadorId"] = new SelectList(procesadores, "Id", "Descripcion");
            ViewData["MemoriaRamId"] = new SelectList(memoriasRam, "Id", "Descripcion");
            ViewData["DiscoDuroId"] = new SelectList(discosDuros, "Id", "Descripcion");
            return View();
        }

        // POST: Ordenadores/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create( OrdenadorComponenteViewModel ordenadorForm)
        {
            if (ModelState.IsValid)
            {
                var ordenador = new Ordenador() { NumeroDeSerie = ordenadorForm.NumeroDeSerie, Descripcion = ordenadorForm.Descripcion };
                _repositorioOrdenador.Añadir(ordenador);
                _repositorioOrdenadorComponente.Añadir(new OrdenadorComponente { OrdenadorId = ordenador.Id, ComponenteId = ordenadorForm.ProcesadorId });
                _repositorioOrdenadorComponente.Añadir(new OrdenadorComponente { OrdenadorId = ordenador.Id, ComponenteId = ordenadorForm.MemoriaRamId });
                _repositorioOrdenadorComponente.Añadir(new OrdenadorComponente { OrdenadorId = ordenador.Id, ComponenteId = ordenadorForm.DiscoDuroId });
                return RedirectToAction(nameof(Index));
            }
            var componentes = _repositorioComponente.ObtenerTodos().Select(c => new
            {
                c.Id,
                c.Categoria,
                Descripcion = c.NumeroDeSerie + " - " + c.Description
            }).ToList();
            var procesadores = componentes.FindAll(componente => componente.Categoria == (int)TipoComponente.Procesador);
            var memoriasRam = componentes.FindAll(componente => componente.Categoria == (int)TipoComponente.Memorizador);
            var discosDuros = componentes.FindAll(componente => componente.Categoria == (int)TipoComponente.Guardador);
            ViewData["ProcesadorId"] = new SelectList(procesadores, "Id", "Descripcion");
            ViewData["MemoriaRamId"] = new SelectList(memoriasRam, "Id", "Descripcion");
            ViewData["DiscoDuroId"] = new SelectList(discosDuros, "Id", "Descripcion");
            return View();
        }

        // GET: Ordenadores/Edit/5
        public IActionResult Edit(int id)
        {
            var ordenador = _repositorioOrdenador.Obtener(id);

            if (ordenador == null)
            {
                return NotFound();
            }

            return View("Edit", ordenador);
        }

        // POST: Ordenadores/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,NumeroDeSerie,Descripcion")] Ordenador ordenador)
        {
            if (id != ordenador.Id)
            {
                return NotFound();
            }
            try
            {
                _repositorioOrdenador.Actualizar(ordenador);
                return RedirectToAction(nameof(Index));
            }
            catch 
            {
                throw;
            }
        }

        // GET: Ordenadores/Delete/5
        public IActionResult Delete(int id)
        {
            var ordenador = _repositorioOrdenador.Obtener(id);
            if (ordenador == null)
            {
                return NotFound();
            }
            return View(ordenador);
        }

        // POST: Ordenadores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _repositorioOrdenador.Borrar(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
