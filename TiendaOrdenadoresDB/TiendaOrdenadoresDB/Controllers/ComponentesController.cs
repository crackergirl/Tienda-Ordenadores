using Microsoft.AspNetCore.Mvc;
using TiendaOrdenadoresDB.Logging;
using TiendaOrdenadoresDB.Models;
using TiendaOrdenadoresDB.Servicies;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TiendaOrdenadoresDB.Controllers
{
    //[Route("api/[controller]")]
    public class ComponentesController : Controller
    {
        private readonly IRepositorio<Componente> _repositorio;
        private readonly ILoggerManager _logger;

        public ComponentesController(IRepositorio<Componente> repositorio, ILoggerManager logger)
        {
            _repositorio = repositorio;
            _logger = logger;
        }

        // GET: /<controller>/
        public ActionResult Index()
        {
            _logger.LogInfo("Se va a mostrar la lista de componentes");
            var lista = _repositorio.ObtenerTodos();
            return View("Index",lista);
        }

        // GET: Componente/Details/5
        public ActionResult Details(int id)
        {
            var componente = _repositorio.Obtener(id);

            if (componente == null)
            {
                return NotFound();
            }

            return View("Details",componente);
        }

        public ActionResult Create()
        {
            var nuevoComponente = new Componente();
            return View(nuevoComponente);
        }

        // POST: PersonaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection, long Almacenamiento, int Calor, int Categoria, string Description, string NumeroDeSerie, int Precio, string UnidadMedida)
        {
            try
            {
                _logger.LogInfo("Se va a crear un componente");
                _logger.LogInfo(Categoria.ToString());
                _repositorio.Añadir(new Componente() { Almacenamiento = Almacenamiento, Calor = Calor, Categoria = Categoria, Description = Description, NumeroDeSerie = NumeroDeSerie, Precio = Precio, UnidadMedida = UnidadMedida });
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                _logger.LogInfo(ex.Message);
                return View();
            }
        }

        // GET: Regions/Edit/5
        public ActionResult Edit(int id)
        {
            var componente = _repositorio.Obtener(id);
            if (componente == null)
            {
                return NotFound();
            }
      
            return View("Edit", componente);
        }

        // POST: Regions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int Id,[Bind("Id,NumeroDeSerie,Description,Precio,Calor,Almacenamiento,Categoria,UnidadMedida")] Componente componente)
        {
            try
            {
                _logger.LogInfo("componente actualizado");
                _repositorio.Actualizar(componente);
                return RedirectToAction("Index");
            }
            catch
            {
                return View("Index");
            }
        }

        // GET: PersonaController/Delete/5
        public ActionResult Delete(int Id)
        {
            var vehiculo = _repositorio.Obtener(Id);
            return View(vehiculo);
        }

        // POST: PersonaController/Delete/5
        [HttpPost, ActionName("Delete")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int Id)
        {
            try
            {
                _logger.LogInfo("componente borrado");
                _repositorio.Borrar(Id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View("Index");
            }
        }
    }
}

