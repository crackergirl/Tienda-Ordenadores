using TiendaOrdenadoresAPI.Models;
using TiendaOrdenadoresAPI.Services;

namespace TiendaOrdenadoresDB.Services.Fakes
{
	public class FakeRepositorioOrdenadorComponente : IRepositorio<OrdenadorComponente>
    {
        readonly List<OrdenadorComponente> misOrdenadoresComponentes = new();

        public FakeRepositorioOrdenadorComponente()
        {
            
            misOrdenadoresComponentes.Add(
               new OrdenadorComponente()
                 {
                     Id = 1,
                     OrdenadorId =  1,
                     ComponenteId = 1,
                     Ordenador = new Ordenador()
                     {
                         Id = 1,
                         Descripcion = "patata",
                         NumeroDeSerie = "AAAA1"
                     },
                     Componente = new Componente()
                     {
                         Id = 1,
                         Almacenamiento = 6,
                         Calor = 10,
                         Categoria = 0,
                         Description = "patata",
                         NumeroDeSerie = "AAAA",
                         Precio = 50,
                         UnidadMedida = "Cores"
                     }
               });
        }

        public void Actualizar(OrdenadorComponente element)
        {
            var ordenadorDeMisOrdenadores = Obtener(element.Id);
            if (ordenadorDeMisOrdenadores != null)
            {
                ordenadorDeMisOrdenadores.ComponenteId = element.ComponenteId;
            }
        }

        public void Añadir(OrdenadorComponente item)
        {
            var ultimoNumero = misOrdenadoresComponentes.Count;
            item.Id = ultimoNumero;
            misOrdenadoresComponentes.Add(item);
        }

        public void Borrar(int id)
        {
            misOrdenadoresComponentes.RemoveAll(x => x.Id == id);
        }

        public OrdenadorComponente? Obtener(int id)
        {
            return misOrdenadoresComponentes.Find(x => x.Id == id);
        }

        public List<OrdenadorComponente> ObtenerTodos()
        {
            return misOrdenadoresComponentes;
        }

        public int ObtenerUltimoId()
        {
            return misOrdenadoresComponentes.Count;
        }
    }
}

