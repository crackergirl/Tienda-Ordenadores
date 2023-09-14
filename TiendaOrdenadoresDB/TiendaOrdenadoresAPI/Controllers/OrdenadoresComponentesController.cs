using Microsoft.AspNetCore.Mvc;
using TiendaOrdenadoresAPI.Models;
using TiendaOrdenadoresAPI.Services;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TiendaOrdenadoresAPI.Controllers
{
    [Route("api/[controller]")]
    public class OrdenadoresComponentesController : Controller
    {
        private readonly IRepositorio<OrdenadorComponente> _repositorio;

        public OrdenadoresComponentesController(IRepositorio<OrdenadorComponente> repositorio)
        {
            _repositorio = repositorio;
        }
        // GET: api/values
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_repositorio.ObtenerTodos());
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var componente = _repositorio.Obtener(id);

            if (componente == null)
            {
                return NotFound();
            }

            return Ok(componente);
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody] OrdenadorComponente ordenador)
        {
            _repositorio.Añadir(ordenador);
            return Ok();
        }

        // PUT api/values/5
        [HttpPut()]
        public IActionResult Put([FromBody] OrdenadorComponente ordenador)
        {
            if (_repositorio.Obtener(ordenador.Id) == null)
            {
                return BadRequest(504);
            }
            _repositorio.Actualizar(ordenador);
            return Ok();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _repositorio.Borrar(id);
            return Ok();
        }
    }
}

